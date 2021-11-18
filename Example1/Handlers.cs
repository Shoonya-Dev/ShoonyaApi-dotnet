using NorenRestApiWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorenRestSample
{
    public static class Handlers
    {
        static NorenRestApi nApi => Program.nApi;

        public static void OnAppLoginResponse(NorenResponseMsg Response, bool ok)
        {
            //do all work here
            LoginResponse loginResp = Response as LoginResponse;

            if (loginResp.stat != "Ok")
            {
                if (loginResp.emsg == "Invalid Input : Change Password" || loginResp.emsg == "Invalid Input : Password Expired")
                {
                    //
                    Changepwd changepwd = new Changepwd();
                    changepwd.uid = Program.uid;
                    changepwd.oldpwd = Program.pwd;
                    changepwd.pwd = Program.newpwd;
                    nApi.Changepwd(Handlers.OnResponseNOP, changepwd);
                    //this will change pwd. restart to relogin with new pwd
                    return;
                }
                else if (loginResp.emsg == "Invalid Input : Blocked")
                {
                    nApi.SendForgotPassword(Handlers.OnResponseNOP, Program.endPoint, Program.uid, Program.pan, Program.dob);
                }
                return;
            }

            //we are logged in as stat is ok

            //subscribe to server for async messages            
            //nApi.ConnectWatcher(Program.wsendpoint, Handlers.OnFeed, Handlers.OnOrderUpdate);
            //nApi.SubscribeOrders(Handlers.OnOrderUpdate, Program.uid);
            Program.loggedin = true;



            Program.ActionOptions();
            return;           
        }
        public static void OnUserDetailsResponse(NorenResponseMsg Response, bool ok)
        {
            UserDetailsResponse userDetailsResponse = Response as UserDetailsResponse;
            Console.WriteLine(userDetailsResponse.toJson());
        }
        public static void OnResponseNOP(NorenResponseMsg Response, bool ok)
        {
            Console.WriteLine("app handler :" + Response.toJson());
        }
        public static void OnAppLogout(NorenResponseMsg Response, bool ok)
        {
            Console.WriteLine("logout handler :" + Response.toJson());
        }

        public static void OnHoldingsResponse(NorenResponseMsg Response, bool ok)
        {
            HoldingsResponse holdingsResponse = Response as HoldingsResponse;

            Console.WriteLine("Holdings Response:" + holdingsResponse.toJson());


            printDataView(holdingsResponse.dataView);
        }

        public static void printDataView(DataView dv)
        {
            string order;
            foreach (DataRow dataRow in dv.Table.Rows)
            {
                order = "order:";
                foreach (var item in dataRow.ItemArray)
                {
                    order += item + " ,";
                }
                Console.WriteLine(order);
            }
            Console.WriteLine();
        }
        public static void OnOrderHistoryResponse(NorenResponseMsg Response, bool ok)
        {
            OrderHistoryResponse orderhistory = Response as OrderHistoryResponse;

            if (orderhistory.list != null)
            {
                DataView dv = orderhistory.dataView;

                //    for (int i = 0; i < dv.Count; i++)
                printDataView(dv);
            }
            else
            {
                Console.WriteLine("app handler: no orders");
            }
        }
        public static void OnTradeBookResponse(NorenResponseMsg Response, bool ok)
        {
            TradeBookResponse orderBook = Response as TradeBookResponse;

            if (orderBook.trades != null)
            {
                DataView dv = orderBook.dataView;

                //    for (int i = 0; i < dv.Count; i++)
                printDataView(dv);
            }
            else
            {
                Console.WriteLine("app handler: no trades");
            }
        }
        public static void OnOrderBookResponse(NorenResponseMsg Response, bool ok)
        {
            OrderBookResponse orderBook = Response as OrderBookResponse;

            if (orderBook.Orders != null)
            {
                DataView dv = orderBook.dataView;

                //    for (int i = 0; i < dv.Count; i++)
                printDataView(dv);
            }
            else
            {
                Console.WriteLine("app handler: no orders");
            }
        }
        public static void OnFeed(NorenFeed Feed)
        {
            NorenFeed feedmsg = Feed as NorenFeed;
            Console.WriteLine(Feed.toJson());
            if (feedmsg.t == "dk")
            {
                //acknowledgment
            }
            if (feedmsg.t == "df")
            {
                //feed
                Console.WriteLine($"Feed received: {Feed.toJson()}");
            }
        }
        public static void OnOrderUpdate(NorenOrderFeed Order)
        {
            Console.WriteLine($"Order update: {Order.toJson()}");
        }


    }

}
