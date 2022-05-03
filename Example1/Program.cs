using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NorenRestApiWrapper;

namespace NorenRestSample
{    
    public static class Program
    {
        #region dev  credentials

        public const string endPoint = "https://shoonyatrade.finvasia.com/NorenWClientTP/";
        public const string wsendpoint = "wss://shoonyatrade.finvasia.com/NorenWSTP/";
        public const string uid = "FA30417";
        public const string actid = "FA30417";
        public const string pwd = "Daiwik@9";
        public const string factor2 = dob;
        public const string pan = "AYJPB4562B";
        public const string dob = "";
        public const string imei = "xyz12345";
        public const string vc = "FA30417_U";
        public const string appkey = "16592686bb6b07074ed91db0cac6c1a7";
        public const string newpwd = "";
        #endregion    
        

        public static bool loggedin = false;

        
        public static void OnStreamConnect(NorenStreamMessage msg)
        {
            Program.loggedin = true;
            nApi.SubscribeOrders(Handlers.OnOrderUpdate, uid);

            for(var i= 52120; i < 20; i++)
                nApi.SubscribeToken("NFO", i.ToString());
            
        }
        public static NorenRestApi nApi = new NorenRestApi();
        
        static void Main(string[] args)
        {
            LoginMessage loginMessage = new LoginMessage();
            loginMessage.apkversion = "1.0.0";
            loginMessage.uid = uid;
            loginMessage.pwd = pwd;
            loginMessage.factor2 = factor2;
            loginMessage.imei = imei;
            loginMessage.vc = vc;
            loginMessage.source = "API";
            loginMessage.appkey = appkey;
            nApi.SendLogin(Handlers.OnAppLoginResponse, endPoint, loginMessage);

            nApi.SessionCloseCallback = Handlers.OnAppLogout;
            nApi.onStreamConnectCallback = Program.OnStreamConnect;

            while (Program.loggedin == false)
            {
                //dont do anything till we get a login response         
                Thread.Sleep(5);
            }          
            
            bool dontexit = true;
            while(dontexit)
            {                
                var input = Console.ReadLine();
                var opts = input.Split(' ');
                foreach (string opt in opts)
                {
                    switch (opt.ToUpper())
                    {
                        case "B":
                            ActionPlaceBuyorder();
                            break;
                        case "C":
                            // process argument...
                            ActionPlaceCOorder();
                            break;
                        case "D":
                            ActionGetOptionChain();
                            break;
                        case "G":
                            nApi.SendGetHoldings(Handlers.OnHoldingsResponse, actid, "C");
                            break;
                        case "H":
                            //check order
                            Console.WriteLine("Enter OrderNo:");
                            var orderno = Console.ReadLine();
                            nApi.SendGetOrderHistory(Handlers.OnOrderHistoryResponse, orderno);
                            break;
                        case "I":
                            nApi.SendGetIndexList(Handlers.OnResponseNOP, "NSE");
                            break;

                        case "L":
                            nApi.SendGetLimits(Handlers.OnResponseNOP, actid);
                            break;
                        case "M":
                            ActionGetOrderMargin();
                            break;
                        case "O":
                            nApi.SendGetOrderBook(Handlers.OnOrderBookResponse, "");
                            break;

                        case "P":
                            ProductConversion productConversion = new ProductConversion();
                            productConversion.actid = actid;
                            productConversion.exch = "NSE";
                            productConversion.ordersource = "API";
                            productConversion.prd = "C";
                            productConversion.prevprd = "I";
                            productConversion.qty = "1";
                            productConversion.trantype = "B";
                            productConversion.tsym = "YESBANK-EQ";
                            productConversion.uid = uid;
                            productConversion.postype = "Day";
                            nApi.SendProductConversion(Handlers.OnResponseNOP, productConversion);
                            break;
                        case "R":
                            ActionPlaceBOorder();
                            break;
                        case "S":
                            string exch;
                            string token;
                            Console.WriteLine("Enter exch:");
                            exch = Console.ReadLine();
                            Console.WriteLine("Enter Token:");
                            token = Console.ReadLine();
                            nApi.SendGetSecurityInfo(Handlers.OnResponseNOP, exch, token);
                            break;
                        case "T":
                            nApi.SendGetTradeBook(Handlers.OnTradeBookResponse, actid);
                            break;
                        case "Q":
                            nApi.SendLogout(Handlers.OnAppLogout);
                            dontexit = false;
                            return;
                        case "U":
                            //get user details
                            nApi.SendGetUserDetails(Handlers.OnUserDetailsResponse);
                            break;
                        case "V":
                            DateTime today = DateTime.Now.Date;
                            double start = ConvertToUnixTimestamp(today);

                            //start and end time are optional
                            //here we are getting one day's data
                            nApi.SendGetTPSeries(Handlers.OnResponseNOP, "NSE", "22", start.ToString() );
                            //to check for 5 min interval
                            //nApi.SendGetTPSeries(Handlers.OnResponseNOP, "NSE", "22", start.ToString(), null , "5" );
                            break;
                        case "W":
                            Console.WriteLine("Enter exch:");
                            exch = Console.ReadLine();
                            Console.WriteLine("Enter Token:");
                            token = Console.ReadLine();
                            nApi.SendSearchScrip(Handlers.OnResponseNOP, exch, token);
                            break;
                        case "Y":
                            Console.WriteLine("Enter exch:");
                            exch = Console.ReadLine();
                            Console.WriteLine("Enter Token:");
                            token = Console.ReadLine();
                            nApi.SendGetQuote(Handlers.OnResponseNOP, exch, token);
                            break;

                        case "BM":
                            ActionGetBasketMargin();
                            break;
                        case "FP":                            
                            nApi.SendForgotPassword(Handlers.OnResponseNOP,endPoint, uid, pan, dob);
                            break;
                        case "WU":
                            nApi.UnSubscribeToken("NSE", "22");
                            break;
                        case "WL":
                            Quote quote = new Quote();
                            quote.exch = "NSE";
                            quote.token = "22";

                            List<Quote> l = new List<Quote>();
                            l.Add(quote);

                            nApi.UnSubscribe(l);
                            break;
                        case "ST":
                            NorenRestApi nApi_2 = new NorenRestApi();
                            nApi_2.SetSession(endPoint, uid, pwd, nApi.UserToken);
                            nApi_2.SendGetHoldings(Handlers.OnHoldingsResponse, actid, "C");
                            nApi_2.SendGetQuote(Handlers.OnResponseNOP, "NSE", "22");
                            break;
                        default:
                            // do other stuff...
                            ActionOptions();
                            break;
                    }
                }
                

                //var kp = Console.ReadKey();
                //if (kp.Key == ConsoleKey.Q)
                //    dontexit = false;
                //Console.WriteLine("Press q to exit.");
            }            
        }
        

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        #region actions
        public static void ActionPlaceCOorder()
        {
            //sample cover order
            PlaceOrder order = new PlaceOrder();
            order.uid = uid;
            order.actid = actid;
            order.exch = "CDS";
            order.tsym = "USDINR27JAN21F";
            order.qty = "10";
            order.dscqty = "0";
            order.prc = "76.0025";
            order.blprc = "74.0025";
            order.prd = "H";
            order.trantype = "B";
            order.prctyp = "LMT";
            order.ret = "DAY";
            order.ordersource = "API";

            nApi.SendPlaceOrder(Handlers.OnResponseNOP, order);
        }

        public static void ActionPlaceBOorder()
        {
            //sample cover order
            PlaceOrder order = new PlaceOrder();
            order.uid = uid;
            order.actid = actid;
            order.exch = "NSE";
            order.tsym = "INFY-EQ";
            order.qty = "10";
            order.dscqty = "0";
            order.prc = "2800";
            order.blprc = "2780";
            order.bpprc = "2820";
            order.prd = "B";
            order.trantype = "B";
            order.prctyp = "LMT";
            order.ret = "DAY";
            order.ordersource = "API";

            nApi.SendPlaceOrder(Handlers.OnResponseNOP, order);
        }

        public static void ActionPlaceBuyorder()
        {
            //sample cover order
            PlaceOrder order = new PlaceOrder();
            order.uid = uid;
            order.actid = actid;
            order.exch = "NSE";
            order.tsym = "M&M-EQ";
            order.qty = "10";
            order.dscqty = "0";
            order.prc = "100.5";
            
            order.prd = "I";
            order.trantype = "B";
            order.prctyp = "LMT";
            order.ret = "DAY";
            order.ordersource = "API";

            nApi.SendPlaceOrder(Handlers.OnResponseNOP, order);
        }

        public static void ActionGetOrderMargin()
        {
            //sample cover order
            OrderMargin order = new OrderMargin();
            order.uid = uid;
            order.actid = actid;
            order.exch = "NSE";
            order.tsym = "M&M-EQ";
            order.qty = "10";
            order.dscqty = "0";
            order.prc = "100.5";

            order.prd = "I";
            order.trantype = "B";
            order.prctyp = "LMT";           
            
            nApi.SendGetOrderMargin(Handlers.OnResponseNOP, order);
        }

        public static void ActionGetBasketMargin()
        {
            //sample cover order
            BasketMargin basket = new BasketMargin();
            BasketListItem item = new BasketListItem();

            //first order
            basket.uid = uid;
            basket.actid = actid;
            basket.exch = "NSE";
            basket.tsym = "ABB-EQ";
            basket.qty = "10";
            basket.prc = "100.5";

            basket.prd = "I";
            basket.trantype = "B";
            basket.prctyp = "LMT";


            //second order
            item.exch = "NSE";
            item.tsym = "ACC-EQ";
            item.qty = "20";
            item.prc = "100.5";

            item.prd = "I";
            item.trantype = "B";
            item.prctyp = "LMT";
            basket.basketlists = new List<BasketListItem>();
            basket.basketlists.Add(item);
            nApi.SendGetBasketMargin(Handlers.OnResponseNOP, basket);
        }

        public static void ActionGetOptionChain()
        {
            string exch;
            string tsym;
            string strike;
            Console.WriteLine("Enter exch:");
            exch = Console.ReadLine();
            Console.WriteLine("Enter TradingSymbol:");
            tsym = Console.ReadLine();
            Console.WriteLine("Enter Strike:");
            strike = Console.ReadLine();

            nApi.SendGetOptionChain(Handlers.OnResponseNOP, exch, tsym, strike, 1);

        }

        public static void ActionOptions()
        {
            Console.WriteLine("Q: logout.");
            Console.WriteLine("O: get OrderBook");
            Console.WriteLine("T: get TradeBook");
            Console.WriteLine("B: place a buy order");
            Console.WriteLine("C: place a cover order");
            Console.WriteLine("R: place a bracket order");
            Console.WriteLine("Y: get quote");
            Console.WriteLine("S: get security info");
            Console.WriteLine("H: get order history");
            Console.WriteLine("G: get holdings");
            Console.WriteLine("L: get limits");
            Console.WriteLine("M: get singleorder margin");
            Console.WriteLine("BM: get basket margin");
            Console.WriteLine("W: search for scrips (min 3 chars)");
            Console.WriteLine("P: position convert");
            Console.WriteLine("U: get user details");
            Console.WriteLine("V: get intraday 1 min price data");
            Console.WriteLine("I: get list of index names");
            Console.WriteLine("D: get Option Chain");
        }
        #endregion
    }

}
