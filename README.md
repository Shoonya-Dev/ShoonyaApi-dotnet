# StarApi-dotnet

[INTRODUCTION](#md_introduction)

[Login and Session](#md_session)
- [Login](#md_login)
- [ForgotPassword](#md_forgot)
- [ChangePassword](#md_changepwd)
- [Logout](#md_logout)

[WatchLists](#md_watchlist)
- [UserDetails](#md_userdetails)
- [GetWatchLists](#md_getwatchlist)
- [AddScriptoWatchList](#_TOC_250032)
- [DeleteScriptoWatchList](#_TOC_250031)

[Market](#md_market)
- [SearchScrips](#_TOC_250033)
- [GetSecurityInfo](#_TOC_250030)
- [GetQuote](#_TOC_250012)
- [GetTimePriceData(Chartdata)](#_TOC_250008)
- [GetOptionChain](#_TOC_250007)
- [GetIndexList](#_TOC_250011)
- [ExchMsg](#_TOC_250019)

[Orders and Trades](#md_ordersntrades)
- [PlaceOrder](#_TOC_250028)
- [ModifyOrder](#_TOC_250027)
- [CancelOrder](#_TOC_250026)
- [ExitSNOOrder](#_TOC_250025)
- [ProductConversion](#_TOC_250016)
- [OrderMargin](#_TOC_250024)
- [OrderBook](#_TOC_250023)
- [TradeBook](#_TOC_250020)
- [SingleOrderHistory](#_TOC_250021)
- [MultiLegOrderBook](#_TOC_250022)
- [BasketOrderMargin](#_TOC_250024)
- [PositionsBook](#_TOC_250017)
- [Holdings](#_TOC_250014)
- [Limits](#_TOC_250013)

[Order and MarketData Update](#_TOC_250006)

- [Connect](#_TOC_250005)
- [SubscribeMarketData](#_TOC_250004)
- [UnSubscribeMarketData](#_TOC_250003)
- [SubscribeOrderUpdate](#_TOC_250000)


# History

| Date | Version | Changes | Details |
| --- | --- | --- | --- |
| 15-11-2021 | 1.0.11.0 | SearchScrips | search text is encoded for M&M etc  |
| 19-04-2021 | 1.0.0.1 | TouchlineBroker | TouchlineFeedadded  |
| 01-01-2021 | 1.0.0.0 | InitialRelease | Based on NorenRestAPI v1.10.0 |

### <a name="md_introduction"></a> INTRODUCTION: About the API

The Api is a dotNet wrapper of the StarWebAPI whichoffers a combination of Rest calls and WebSocket for the purposes of Trading.

API is developed on VisualStudio2019 and uses .NetStandard 2.0 
The dependency libraries are 
  Newtonsoft.Json 9.0.1
  Websocket.Client4.3.21
  
The namespace NorenRestApiWrapper and class NorenRestApi are of primary use and interest

### Initialize

To initialize the api the following are needed 

endPoint:The api end point as instructed by ProStocks
Appkey:The secretkey issued to you,donot append the userid to it.

### MakingRequests

We will be creating an object of NorenRestApi to make requests the callback is taken as an argument in the requestmethod.

```
LoginMessage loginMessage = new LoginMessage();
loginMessage.uid = uid;
loginMessage.pwd = pwd;
loginMessage.factor2 = pan;
loginMessage.imei = "134243434";
loginMessage.source = "API";
loginMessage.appkey = appkey;

nApi.SendLogin(Program.OnAppLoginResponse, endPoint, loginMessage);
```

In the above example we are sending the Loginrequest,this method takes three arguments

1. Callback: this is the function where the application will be handling the response
2. Endpoint: NorenOMSaddress
3. MessageData: parameters of the request being made.

The Callback is of signature

 ###### public delegate void OnResponse(NorenResponseMsg Response,bool ok)

A Typical callback will be handled as below

```
public static voidOnAppLoginResponse(NorenResponseMsg Response, bool ok)
{
   LoginResponse loginResp= Response as LoginResponse;

   if(loginResp.stat=="Ok")
   {
       //do all work here
   }
}
```

The Response is casted to expected DataType ie in this example being LoginResponse, stat is checked to see if the request was successful.

##  <a name="md_login"></a> Login

###### public bool SendLogin(OnResponse response,string endPoint,LoginMessage login)
connect to the broker, only once this function has returned successfully can any other operations be performed

##### ResponseDetails:LoginResponse

## <a name="md_logout"></a> Logout

###### public bool SendLogout(OnResponse response)

##### RequestDetails:NoParams

##### ResponseDetails:LogoutResponse

## <a name="md_forgot"></a> ForgotPassword

###### public bool SendForgotPassword(OnResponse response,string endpoint,string user,string pan,string dob)

##### RequestDetails: As Arguments

##### ResponseDetails:ForgotPasswordResponse

## <a name="md_changepwd"></a> ChangePassword

###### public bool Changepwd(OnResponse response,Changepwd changepwd)

##### RequestDetails:Changepwd

##### ResponseDetails:ChangepwdResponse

## <a name="md_userdetails"></a> UserDetails

###### public bool SendGetUserDetails(OnResponse response)

##### RequestDetails:NoParams

##### ResponseDetails:UserDetailsResponse

# WatchLists

## GetWatchListNames

###### publicboolSendGetMWList(OnResponseresponse)

##### Request Details : No Params
##### ResponseDetails:MWListResponse 

## GetWatchList

###### public bool SendGetMarketWatch(OnResponse response,string wlname)

##### RequestDetails:NoParams

##### ResponseDetails:MarketWatchResponse

## SearchScrips

###### public bool SendSearchScrip(OnResponse response,string exch,string searchtxt)

##### RequestDetails:

##### ResponseDetails:SearchScripResponse

## AddScriptoWatchList

###### public bool SendAddMultiScripsToMW(OnResponse response,string watchlist,string scrips)

##### RequestDetails:

##### ResponseDetails:StandardResponse

## DeleteScriptoWatchList

###### public bool SendDeleteMultiMWScrips( OnResponse response,string watchlist,string  scrips)

##### RequestDetails:

##### ResponseDetails:StandardResponse

## GetSecurityInfo

###### public bool SendGetSecurityInfo( OnResponse response,string exch,string token)

##### RequestDetails:

##### ResponseDetails:GetSecurityInfoResponse

# Order and Trades

## PlaceOrder

###### public bool SendPlaceOrder( OnResponse response,PlaceOrder order  )

##### RequestDetails:PlaceOrder

##### ResponseDetails:PlaceOrderResponse


## ModifyOrder

###### bool SendModifyOrder( OnResponse response,ModifyOrder order  )

##### RequestDetails:ModifyOrder
##### ResponseDetails:ModifyOrderResponse

## CancelOrder

###### public bool SendCancelOrder( OnResponse response,string norenordno)

##### RequestDetails:
##### ResponseDetails:CancelOrderResponse

## ExitSNOOrder

###### public bool SendExitSNOOrder( OnResponse response,string norenordno,string product)

##### RequestDetails:
##### ResponseDetails:ExitSNOOrderResponse

## OrderMargin

###### public bool SendGetOrderMargin( OnResponse response,OrderMargin ordermargin)

##### RequestDetails:OrderMargin
##### ResponseDetails:OrderMarginResponse

## OrderBook

###### public bool SendGetOrderBook( OnResponse response,string product)

##### RequestDetails:
##### ResponseDetails:OrderBookResponselistofOrderBookItem

## MultiLegOrderBook

###### public bool SendGetMultiLegOrderBook( OnResponse response,string product)

##### RequestDetails:
##### ResponseDetails:MultiLegOrderBookResponselistofMultiLegOrderBookItem

## SingleOrderHistory

###### public bool SendGetOrderHistory( OnResponse response,string norenordno)

##### RequestDetails:
##### ResponseDetails:OrderHistoryResponselistofSingleOrdHistItem

## TradeBook

###### public bool SendGetTradeBook( OnResponse response,string account)

##### RequestDetails:
##### ResponseDetails:TradeBookResponselistofTradeBookItem

## ExchMsg

###### public bool SendGetExchMsg( OnResponse response,ExchMsg exchmsg)

##### RequestDetails:ExchMsg
##### ResponseDetails:ExchMsgResponselistofExchMsgItem

## OrderMargin

###### public bool SendGetOrderMargin( OnResponse response,OrderMargin ordermargin)

##### RequestDetails:OrderMargin
##### ResponseDetails:OrderMarginResponse

## PositionsBook

###### public bool SendGetPositionBook( OnResponse response,string account)

##### RequestDetails:
##### ResponseDetails:PositionBookResponselistofPositionBookItem

## ProductConversion

###### public bool SendGetOrderMargin( OnResponse response,ProductConversion prdConv)

##### RequestDetails:ProductConversion
##### ResponseDetails:ProductConversionResponse

# Holdings and Limits

## Holdings

###### public bool SendGetHoldings( OnResponse response,string account,string product)

##### RequestDetails:
##### ResponseDetails:HoldingsResponselistofHoldingsItem
## Limits

###### public bool SendGetLimits(OnResponse response,string account,string product = "", string segment = "";  string exchange = "")

##### RequestDetails:
##### ResponseDetails:LimitsResponse

# MarketInfo

## GetIndexList

##### RequestDetails:
##### ResponseDetails:

## GetTopListNames

##### RequestDetails:
##### ResponseDetails:

## GetTopList

##### RequestDetails:
##### ResponseDetails:
## GetTimePriceData(Chartdata)

##### RequestDetails:
##### ResponseDetails:
## GetOptionChain

##### RequestDetails:
##### ResponseDetails:

# OrderUpdates and MarketDataUpdate

This Api allows you to receive updates receivethe marketdata and order updates in the application callbacks as an option, to do so connect as follows.

Api.OnFeedCallback  += Application.OnFeedHandler;
Api.OnOrderCallback += Application.OnOrderHandler;

## Connect

###### public bool ConnectWatcher(string uri,OnFeed marketdata Handler,OnOrderFeed orderHandler)


## SubscribeMarketData

###### public bool SubscribeToken(string exch,string token)

##### Request:
|Fields |Possible  value| Description |
| --- | --- | --- |
| exch | NSE,BSE,NFO... | Exchange |
| token |
| ScripToken |

##### MarketDataUpdates:

Accept for t, e,and tk other fields may/may not be present.

|Fields |Possible  value| Description |
| --- | --- | --- |
| t | tf | tf representstouchlinefeed |
| e | NSE,BSE,NFO.. | Exchangename |
| tk | 22 | ScripToken |
| lp || LTP |
| pc || Percentagechange |
| v || volume |
| o || Openprice |
| h || Highprice |
| l || Lowprice |
| c || Closeprice |
| ap || Averagetradeprice |
| oi || Open interest |
| poi || Previous day closing Open Interest |
| to1 || Total open interest for underlying |
| bq1 || Best Buy Quantity 1 |
| bp1 || Best Buy Price 1 |
| sq1 || Best Sell Quantity 1 |
| sp1 || Best Sell Price 1 |

## UnSubscribeMarketData

###### public bool UnSubscribeToken(string exch,string token)

##### Request:

|Fields |Possible  value| Description |
| --- | --- | --- |
| exch | NSE,BSE,NFO... | Exchange |
| token || ScripToken |

## SubscribeOrderUpdate

###### public bool SubscribeOrders(OnOrderFeed orderFeed,string account)

##### Request:

|Fields|Possible  value| Description |
| --- | --- | --- |
| actid | | Account id based on which order updated to be sent. |

##### OrderUpdatesubscriptionUpdates:NorenOrderFeed

|Fields |Possible  value| Description |
| --- | --- | --- |
| t | om | "om" represents touchlinefeed |
| norenordno | | NorenOrderNumber |
| uid | | UserId |
| actid | | AccountID |
| exch | | Exchange |
| tsym | |  | | |  T |radingsymbol |
| qty | | Orderquantity |
| prc | | OrderPrice |
| prd | | Product |
| status | | Orderstatus(open,complete,rejectedetc) |
| reporttype | | Ordereventforwhichthismessageissentout.(fill,rejected,canceled) |
| trantype | | Ordertransactiontype,buyorsell |
| prctyp | | Orderpricetype(LMT,MKT,SL-LMT,SL-MKT) |
| ret | | Orderretentiontype(DAY,EOS,IOC,...) |
| fillshares | | Filledshares |
| avgprc | | Averagefillprice |
| rejreason | | Orderrejectionreason,ifrejected |
| exchordid | | ExchangeOrderID |
| cancelqty | | Canceledquantity,incaseofcanceledorder |
| remarks | | Useraddedtag,whileplacingorder |
| dscqty | | Disclosedquantity |
| trgprc | | TriggerpriceforSLorders |
