using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using WA.Standard.IF.Biz.v2.Common;
using WA.Standard.IF.Data.v2.Common.Appointment;

namespace WA.Standard.IF.WebService.v2.Common
{
    /// <summary>
    /// Appointment의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://wa.dms.webservice/", Description = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    [System.Web.Script.Services.ScriptService]
    public class Appointment : WA.Standard.IF.WebService.v2.Base.BaseWebService
    {
        [WebMethod(Description = "IF-DMS-AP-R01/Appointment Get")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public AppointmentGetResponse AppointmentGet(AppointmentGetRequest request)
        {
            AppointmentGetResponse response = new AppointmentGetResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.AppointmentGet);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                using (Appointment_Biz biz = new Appointment_Biz())
                {
                    response = biz.AppointmentGet(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("AppointmentGetResponse Error {0}: ", ex);
            }

            return response;
        }


        [WebMethod(Description = "IF-DMS-AP-U01/Appointment Change")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public AppointmentChangeResponse AppointmentChange(AppointmentChangeRequest request)
        {
            AppointmentChangeResponse response = new AppointmentChangeResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.AppointmentChange);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                using (Appointment_Biz biz = new Appointment_Biz())
                {
                    response = biz.AppointmentChange(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("AppointmentChangeResponse Error {0}: ", ex);
            }

            return response;
        }
    }
}
