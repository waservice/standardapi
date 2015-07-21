using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using WA.Standard.IF.Biz.v2.Common;
using WA.Standard.IF.Data.v2.Common.Job;

namespace WA.Standard.IF.WebService.v2.Common
{
    /// <summary>
    /// Job의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://wa.dms.webservice/", Description = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    [System.Web.Script.Services.ScriptService]
    public class Job : WA.Standard.IF.WebService.v2.Base.BaseWebService
    {
        [WebMethod(Description = "IF-DMS-JOB-R01/Job Get")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public JobGetResponse JobGet(JobGetRequest request)
        {
            JobGetResponse response = new JobGetResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.JobGet);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                using (Job_Biz biz = new Job_Biz())
                {
                    response = biz.JobGet(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("JobGetResponse Error {0}: ", ex);
            }

            return response;
        }


        [WebMethod(Description = "IF-DMS-JOB-U01/Job Change")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        //[SoapHeader("TransactionHeader", Direction = SoapHeaderDirection.InOut)] // TransactionHeader move from Header to Body 2015.05.30
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
        public JobChangeResponse JobChange(JobChangeRequest request)
        {
            JobChangeResponse response = new JobChangeResponse();

            try
            {
                //Request body-header object validation
                response.Errors = GetErrorDataListFromRequestTransactionHeader(request.TransactionHeader);
                if (response.Errors != null)
                {
                    response.TransactionHeader = new Data.v2.Common.Common.TransactionHeader();
                    return response;
                }
                response.Errors = GetErrorDataListFromRequest(request.JobChange);
                if (response.Errors != null)
                {
                    response.TransactionHeader = request.TransactionHeader;
                    return response;
                }

                using (Job_Biz biz = new Job_Biz())
                {
                    response = biz.JobChange(request);
                }
            }
            catch (Exception ex)
            {
                response.Errors = GetErrorDataListFromException(ex);
                WA.Standard.IF.Logger.Log.Log.RootLogger.ErrorFormat("JobChangeResponse Error {0}: ", ex);
            }

            return response;
        }
    }
}
