using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.HMCIS;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.HMCIS.Price;

namespace WA.Standard.IF.Biz.v2.HMCIS
{
    public class Price_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public PriceCheckResponse PriceCheck(PriceCheckRequest request)
        {
            PriceCheckResponse response = new PriceCheckResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.HMCIS.Price_Proxy proxy = new Proxy.v2.HMCIS.Price_Proxy();
                response = proxy.PriceCheck(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
                
                #region For XML Process
                List<Price> Prices = Util.DataHelper.GetListByElementName<Price>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Prices.xml"), "Price");

                if (Prices != null && Prices.Count > 0)
                {
                    response.Price = Prices[0];
                    response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet

                #endregion
            }

            return response;
        }
    }
}
