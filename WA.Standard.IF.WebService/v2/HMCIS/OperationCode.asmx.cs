using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using WA.Standard.IF.Biz.v2.HMCIS;
using WA.Standard.IF.Data.v2.HMCIS.OperationCode;

namespace WA.Standard.IF.WebService.v2.HMCIS
{
    /// <summary>
    /// OperationCode의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://wa.dms.webservice/", Description = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    [System.Web.Script.Services.ScriptService]
    public class OperationCode : WA.Standard.IF.WebService.v2.Base.BaseWebService
    {
        [WebMethod(Description = "IF-DMS-MC-R01/OperationCode Get")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public OperationCodeGetResponse OperationCodeGet(OperationCodeGetRequest request)
        {
            OperationCodeGetResponse response = new OperationCodeGetResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                    return response;
                response.Errors = GetErrorDataListFromRequest(request.OperationCodeGet);
                if (response.Errors != null)
                    return response;

                using (OperationCode_Biz biz = new OperationCode_Biz())
                {
                    response = biz.OperationCodeGet(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("OperationCodeGetResponse Error : ", ex);
            }

            return response;
        }
    }
}