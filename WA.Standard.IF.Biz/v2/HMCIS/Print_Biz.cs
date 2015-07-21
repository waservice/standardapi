using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.HMCIS;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.HMCIS.Print;

namespace WA.Standard.IF.Biz.v2.HMCIS
{
    public class Print_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public PrintResponse PrintRequest(PrintRequest request)
        {
            PrintResponse response = new PrintResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.HMCIS.Print_Proxy proxy = new Proxy.v2.HMCIS.Print_Proxy();
                response = proxy.PrintRequest(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }

            return response;
        }
    }
}
