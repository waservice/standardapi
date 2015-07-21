using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Biz.v2.Base
{
    public class BaseBiz : IDisposable
    {
        bool disposed = false;

        //Application Running Type : DMS, Mapper
        public string RunningMode { get {return System.Configuration.ConfigurationManager.AppSettings["RunningMode"].ToString();} }

        //Loggin Type : File, DB, None
        public string LoggingMode { get {return System.Configuration.ConfigurationManager.AppSettings["LoggingMode"].ToString();} }

        public ResultMessage GetResultMessageData(string resultCode, string resultMessage)
        {
            ResultMessage resultMessageData = new ResultMessage();
            resultMessageData.Code = resultCode;
            resultMessageData.Message = resultMessage;

            //DB or File Logging ???

            return resultMessageData;
        }

        public Error GetErrorData(string resultCode, string resultMessage)
        {
            Error errorData = new Error();
            errorData.Code = resultCode;
            errorData.Message = resultMessage;

            //DB or File Logging ???

            return errorData;
        }

        public List<Error> GetErrorDataList(string resultCode, string resultMessage)
        {
            List<Error> errorDataList = new List<Error>();
            Error errorData = new Error();
            errorData.Code = resultCode;
            errorData.Message = resultMessage;
            errorDataList.Add(errorData);

            //DB or File Logging ???

            return errorDataList;
        }

        public Error GetErrorDataFromException(Exception ex)
        {
            Error errorData = new Error();
            errorData.Code = ResponseCode.UnHandledError;
            errorData.Message = string.Format("{0}:\r\n{1}", ex.Message, ex.StackTrace);

            //DB or File Logging ???

            return errorData;
        }

        public List<Error> GetErrorDataListFromException(Exception ex)
        {
            List<Error> errorDataList = new List<Error>();
            Error errorData = new Error();
            errorData.Code = ResponseCode.UnHandledError;
            errorData.Message = string.Format("{0}:\r\n{1}", ex.Message, ex.StackTrace);
            errorDataList.Add(errorData);

            //DB or File Logging ???

            return errorDataList;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            { 
                //do something
            }

            disposed = true;
        }
    }
}
