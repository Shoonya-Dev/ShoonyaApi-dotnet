using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorenRestApiWrapper;
using System.Threading;

namespace dotNetExample
{
    public class BaseResponseHandler
    {
        public AutoResetEvent ResponseEvent = new AutoResetEvent(false);

        public NorenResponseMsg baseResponse;

        public void OnResponse(NorenResponseMsg Response, bool ok)
        {
            baseResponse = Response;

            ResponseEvent.Set();
        }
    }
    class Program
    {
        #region dev  credentials

        public const string endPoint = "";
        public const string wsendpoint = "";
        public const string uid = "";
        public const string actid = "";
        public const string pwd = "";
        public const string factor2 = dob;
        public const string pan = "";
        public const string dob = "";
        public const string imei = "";
        public const string vc = "";


        public const string appkey = "";
        public const string newpwd = "";
        #endregion      

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
            BaseResponseHandler responseHandler = new BaseResponseHandler();

            nApi.SendLogin(responseHandler.OnResponse, endPoint, loginMessage);

            responseHandler.ResponseEvent.WaitOne();

            LoginResponse loginResponse = responseHandler.baseResponse as LoginResponse;
            Console.WriteLine("app handler :" + responseHandler.baseResponse.toJson());
            
            //only after login success connect to websocket for market/order updates
            if (nApi.ConnectWatcher(wsendpoint, Program.OnFeed, null))
            { 
                //wait for connection
                Thread.Sleep(2000);
                //send subscription for reliance
                nApi.SubscribeToken("NSE", "2885");
            }

            Console.ReadLine();
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
    }
}
