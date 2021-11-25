using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorenRestApiWrapper;
using System.Threading;

namespace dotNetExample_InlineHandler
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

        public const string endPoint = "https://shoonyatrade.finvasia.com/NorenWClientTP/";
        public const string wsendpoint = "wss://shoonyatrade.finvasia.com/NorenWSTP/";
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

            Console.ReadLine();
        }
    }
}
