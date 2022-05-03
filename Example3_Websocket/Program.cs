using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorenRestApiWrapper;
using System.Threading;
using System.Configuration;

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
    public static class NorenFeedExtension
    {
        public static NorenFeed Add (NorenFeed f1, NorenFeed f2)
        {
            NorenFeed temp = new NorenFeed();
            temp = f1;
            if(String.IsNullOrEmpty(f2.e  ) == false) temp.e   = f2.e;
            if(String.IsNullOrEmpty(f2.bp5) == false) temp.bp5 =  f2.bp5;
            if(String.IsNullOrEmpty(f2.bo1) == false) temp.bo1 =  f2.bo1;
            if(String.IsNullOrEmpty(f2.bo2) == false) temp.bo2 =  f2.bo2;
            if(String.IsNullOrEmpty(f2.bo3) == false) temp.bo3 =  f2.bo3;
            if(String.IsNullOrEmpty(f2.bo4) == false) temp.bo4 =  f2.bo4;
            if(String.IsNullOrEmpty(f2.bo5) == false) temp.bo5 =  f2.bo5;
            if(String.IsNullOrEmpty(f2.sq1) == false) temp.sq1 =  f2.sq1;
            if(String.IsNullOrEmpty(f2.sq2) == false) temp.sq2 =  f2.sq2;
            if(String.IsNullOrEmpty(f2.sq3) == false) temp.sq3 =  f2.sq3;
            if(String.IsNullOrEmpty(f2.sq4) == false) temp.sq4 =  f2.sq4;
            if(String.IsNullOrEmpty(f2.sq5) == false) temp.sq5 =  f2.sq5;
            if(String.IsNullOrEmpty(f2.bp4) == false) temp.bp4 =  f2.bp4;
            if(String.IsNullOrEmpty(f2.sp1) == false) temp.sp1 =  f2.sp1;
            if(String.IsNullOrEmpty(f2.sp3) == false) temp.sp3 =  f2.sp3;
            if(String.IsNullOrEmpty(f2.sp4) == false) temp.sp4 =  f2.sp4;
            if(String.IsNullOrEmpty(f2.sp5) == false) temp.sp5 =  f2.sp5;
            if(String.IsNullOrEmpty(f2.so1) == false) temp.so1 =  f2.so1;
            if(String.IsNullOrEmpty(f2.so2) == false) temp.so2 =  f2.so2;
            if(String.IsNullOrEmpty(f2.so3) == false) temp.so3 =  f2.so3;
            if(String.IsNullOrEmpty(f2.so4) == false) temp.so4 =  f2.so4;
            if(String.IsNullOrEmpty(f2.so5) == false) temp.so5 =  f2.so5;
            if(String.IsNullOrEmpty(f2.lc ) == false) temp.lc  =  f2.lc;
            if(String.IsNullOrEmpty(f2.uc ) == false) temp.uc  =  f2.uc;            
            if(String.IsNullOrEmpty(f2.h52) == false) temp.h52 =  f2.h52;
            if(String.IsNullOrEmpty(f2.sp2) == false) temp.sp2 =  f2.sp2;
            if(String.IsNullOrEmpty(f2.bp3) == false) temp.bp3 =  f2.bp3;
            if(String.IsNullOrEmpty(f2.bp2) == false) temp.bp2 =  f2.bp2;
            if(String.IsNullOrEmpty(f2.bp1) == false) temp.bp1 =  f2.bp1;
            if(String.IsNullOrEmpty(f2.tk ) == false) temp.tk  =  f2.tk;
            if(String.IsNullOrEmpty(f2.pp ) == false) temp.pp  =  f2.pp;
            if(String.IsNullOrEmpty(f2.ts ) == false) temp.ts  =  f2.ts;
            if(String.IsNullOrEmpty(f2.ti ) == false) temp.ti  =  f2.ti;
            if(String.IsNullOrEmpty(f2.ls ) == false) temp.ls  =  f2.ls;
            if(String.IsNullOrEmpty(f2.lp ) == false) temp.lp  =  f2.lp;
            if(String.IsNullOrEmpty(f2.pc ) == false) temp.pc  =  f2.pc;
            if(String.IsNullOrEmpty(f2.v  ) == false) temp.v   =  f2.v;
            if(String.IsNullOrEmpty(f2.o  ) == false) temp.o   =  f2.o;
            if(String.IsNullOrEmpty(f2.h  ) == false) temp.h   =  f2.h;
            if(String.IsNullOrEmpty(f2.l  ) == false) temp.l   =  f2.l;
            if(String.IsNullOrEmpty(f2.c  ) == false) temp.c   =  f2.c;
            if(String.IsNullOrEmpty(f2.ap ) == false) temp.ap  =  f2.ap;
            if(String.IsNullOrEmpty(f2.oi ) == false) temp.oi  =  f2.oi;
            if(String.IsNullOrEmpty(f2.poi) == false) temp.poi =  f2.poi;
            if(String.IsNullOrEmpty(f2.toi) == false) temp.toi =  f2.toi;
            if(String.IsNullOrEmpty(f2.ltt) == false) temp.ltt =  f2.ltt;
            if(String.IsNullOrEmpty(f2.ltq) == false) temp.ltq =  f2.ltq;
            if(String.IsNullOrEmpty(f2.tbq) == false) temp.tbq =  f2.tbq;
            if(String.IsNullOrEmpty(f2.tsq) == false) temp.tsq =  f2.tsq;
            if(String.IsNullOrEmpty(f2.bq1) == false) temp.bq1 =  f2.bq1;
            if(String.IsNullOrEmpty(f2.bq2) == false) temp.bq2 =  f2.bq2;
            if(String.IsNullOrEmpty(f2.bq3) == false) temp.bq3 =  f2.bq3;
            if(String.IsNullOrEmpty(f2.bq4) == false) temp.bq4 =  f2.bq4;
            if(String.IsNullOrEmpty(f2.bq5) == false) temp.bq5 =  f2.bq5;
            if(String.IsNullOrEmpty(f2.l52) == false) temp.l52 =  f2.l52;
                   
            return temp;
        }
        
    }
    class Program
    {
        #region dev  credentials

        public static string endPoint = "";
        public static string wsendpoint = "";
        public static string uid = "";
        public static string actid = "";
        public static string pwd = "";
        public static string dob = "";  // this is shared by AMith along with id?
        public static string factor2 = dob;
        public static string pan = "";
        public static string imei = "";
        public static string vc = "";
                
        public static string appkey = "";
        public static string newpwd = "";
        #endregion      

        public static NorenRestApi nApi = new NorenRestApi();
        public static Dictionary<string, NorenFeed> mapMarketData = new Dictionary<string, NorenFeed>();

        static bool ReadConfig()
        {
            if (ConfigurationManager.AppSettings.Get("endpoint") == null)
            {
                return false;                
            }
            if (ConfigurationManager.AppSettings.Get("wsendpoint") == null)
            {
                return false;
            }
            if (ConfigurationManager.AppSettings.Get("uid") == null)
            {
                return false;                
            }
            if (ConfigurationManager.AppSettings.Get("pwd") == null)
            {
                return false;                
            }
            if (ConfigurationManager.AppSettings.Get("factor2") == null)
            {
                return false;
            }
            if (ConfigurationManager.AppSettings.Get("vc") == null)
            {
                return false;                
            }
            if (ConfigurationManager.AppSettings.Get("appkey") == null)
            {
                return false;
            }
            Program.endPoint = ConfigurationManager.AppSettings.Get("endpoint");
            Program.wsendpoint = ConfigurationManager.AppSettings.Get("wsendpoint");
            Program.uid = ConfigurationManager.AppSettings.Get("uid");
            Program.actid = Program.uid;
            Program.pwd = ConfigurationManager.AppSettings.Get("pwd");
            Program.factor2 = ConfigurationManager.AppSettings.Get("factor2");
            Program.vc = ConfigurationManager.AppSettings.Get("vc");
            Program.appkey = ConfigurationManager.AppSettings.Get("appkey");
            return true;
        }

        static void Main(string[] args)
        {
            if (ReadConfig() == false)
            {
                Console.WriteLine("config file values failed");
                return;
            }

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
            nApi.onStreamConnectCallback = Program.OnStreamConnect;
            nApi.onStreamCloseCallback = Program.onStreamClose;
            nApi.onStreamErrorCallback = Program.onStreamError;
            //only after login success connect to websocket for market/order updates
            if (nApi.ConnectWatcher(wsendpoint, Program.OnFeed, null)) 
            { 
                //wait for connection
                //Thread.Sleep(2000);
                //send subscription for reliance
                //nApi.SubscribeToken("NSE", "2885");
            }
            
            Console.ReadLine();
            nApi.CloseWatcher();
        }
        public static void OnStreamConnect(NorenStreamMessage msg)
        {
            nApi.SubscribeTokenDepth("NSE", "22");

        }

        public static void onStreamError(string msg)
        {
            Console.WriteLine($"App WS error: {msg}");

        }

        public static void onStreamClose()
        {
            Console.WriteLine("App Webscoket close");

        }

        public static void OnFeed(NorenFeed Feed)
        {
            NorenFeed feedmsg = Feed as NorenFeed;

            Console.WriteLine($"Feed received: {Feed.toJson()}");

            if (feedmsg.t == "dk" || feedmsg.t == "tk")
            {
                //acknowledgment
                var key = Feed.e + "|" + Feed.tk;
                
                mapMarketData[key] = feedmsg;
                
            }
            if (feedmsg.t == "df" || feedmsg.t == "tf")
            {
                //feed
                

                var key = Feed.e + "|" + Feed.tk;
                // See whether Dictionary contains this string.
                if (mapMarketData.ContainsKey(key))
                {
                    var cachevalue = mapMarketData[key];

                    mapMarketData[key] = NorenFeedExtension.Add(cachevalue, Feed);
                    Console.WriteLine($"Feed processed: {mapMarketData[key].toJson()}"); 
                }
            }
            
        }
    }
}
