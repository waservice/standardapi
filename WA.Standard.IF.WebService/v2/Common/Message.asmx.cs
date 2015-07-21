using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using WA.Standard.IF.Biz.v2.Common;
using WA.Standard.IF.Data.v2.Common.Message;

namespace WA.Standard.IF.WebService.v2.Common
{
    /// <summary>
    /// Message의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://wa.dms.webservice/", Description = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    [System.Web.Script.Services.ScriptService]
    public class Message : WA.Standard.IF.WebService.v2.Base.BaseWebService
    {
        WS_Notification_v2.Notification ws_notification;

        [WebMethod(Description = "IF-DMS-MSG-SEND01/Message Send")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public MessageSendResponse MessageSend(MessageSendRequest request)
        {
            MessageSendResponse response = new MessageSendResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.MessageSend);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                using (Message_Biz biz = new Message_Biz())
                {
                    response = biz.MessageSend(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("MessageSendResponse Error {0}: ", ex);
            }

            return response;
        }


        [WebMethod(Description = "IF-DMS-MSG-RECEIVE01/Message Receive")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public MessageReceiveResponse MessageReceive(MessageReceiveRequest request)
        {
            MessageReceiveResponse response = new MessageReceiveResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.MessageReceive);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                WS_Notification_v2.MessageReceiveRequest ws_request = new WS_Notification_v2.MessageReceiveRequest();

                #region//TransactionHeader
                WS_Notification_v2.TransactionHeader ws_transactionheader = new WS_Notification_v2.TransactionHeader();
                ws_transactionheader.CountryID = request.TransactionHeader.CountryID;
                ws_transactionheader.DealerID = request.TransactionHeader.DealerID;
                ws_transactionheader.DistributorID = request.TransactionHeader.DistributorID;
                ws_transactionheader.DMSCode = request.TransactionHeader.DMSCode;
                ws_transactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                ws_transactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                ws_transactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                ws_transactionheader.GroupID = request.TransactionHeader.GroupID;
                ws_transactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                ws_transactionheader.Password = request.TransactionHeader.Password;
                ws_transactionheader.PollingToken = request.TransactionHeader.PollingToken;
                ws_transactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                ws_transactionheader.RequestType = request.TransactionHeader.RequestType;
                ws_transactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                ws_transactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                ws_transactionheader.TransactionId = request.TransactionHeader.TransactionId;
                ws_transactionheader.TransactionType = request.TransactionHeader.TransactionType;
                ws_transactionheader.Username = request.TransactionHeader.Username;
                ws_transactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                ws_request.TransactionHeader = ws_transactionheader;
                #endregion

                #region//MessageReceive
                WS_Notification_v2.MessageReceive ws_messagereceive = new WS_Notification_v2.MessageReceive();
                ws_messagereceive.ActionType = request.MessageReceive.ActionType;
                ws_messagereceive.MessageID = request.MessageReceive.MessageID;
                ws_messagereceive.MessageType = request.MessageReceive.MessageType;
                ws_request.MessageReceive = ws_messagereceive;
                #endregion

                ws_notification = new WS_Notification_v2.Notification();
                ws_notification.ReceiverAsync(ws_request);

                response.TransactionHeader = request.TransactionHeader;
                response.ResultMessage = new Data.v2.Common.Common.ResultMessage() { 
                    Code = WA.Standard.IF.Data.v2.Common.Common.ResponseCode.Success, 
                    Message = WA.Standard.IF.Data.v2.Common.Common.ResponseMessage.Success };
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("MessageReceiveResponse Error {0}: ", ex);
            }

            return response;
        }
    }
}