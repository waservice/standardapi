using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Part;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class Parts_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public PartsGetResponse PartsGet(PartsGetRequest request)
        {
            PartsGetResponse response = new PartsGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Parts_Proxy proxy = new Proxy.v2.Common.Parts_Proxy();
                response = proxy.PartsGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;

                #region For XML Process
                List<WA.Standard.IF.Data.v2.Common.Part.Part> Parts = Util.DataHelper.GetListByElementName<WA.Standard.IF.Data.v2.Common.Part.Part>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Parts.xml"), "Part");

                if (Parts != null && Parts.Count > 0)
                {
                    List<WA.Standard.IF.Data.v2.Common.Part.Part> resultlist = Parts
                        .Where(item =>
                        (string.IsNullOrEmpty(request.PartsGet.Category) || true)
                        && (string.IsNullOrEmpty(request.PartsGet.Engine) || true)
                        && (string.IsNullOrEmpty(request.PartsGet.Make) || true)
                        && (string.IsNullOrEmpty(request.PartsGet.Manufacturer) || request.PartsGet.Year == item.Manufacturer)
                        && (string.IsNullOrEmpty(request.PartsGet.Mileage) || true)
                        && (string.IsNullOrEmpty(request.PartsGet.Model) || true)
                        && (string.IsNullOrEmpty(request.PartsGet.PartDescription) || item.PartDescription.Contains(request.PartsGet.PartDescription))
                        && (string.IsNullOrEmpty(request.PartsGet.PartNumber) || item.PartNumber.Contains(request.PartsGet.PartNumber))
                        && (string.IsNullOrEmpty(request.PartsGet.Year) || true)
                        ).ToList<WA.Standard.IF.Data.v2.Common.Part.Part>();

                    response.Parts = resultlist;

                    if (resultlist.Count > 0)
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                    else
                        response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process

                /*
                DataSet resultDS = new DataSet();
                using (Parts_Dac dac = new Parts_Dac())
                {
                    resultDS = dac.SelectPart(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language
                                                        , request.PartsGet
                        );

                }

                //0. Parts Data

                if (resultDS.Tables != null && resultDS.Tables.Count == 1)
                {
                    List<WA.Standard.IF.Data.v2.Common.Part.Part> Parts = null;
                    if (resultDS.Tables[0].Rows.Count > 0)
                    {
                        #region Part
                        Parts = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new WA.Standard.IF.Data.v2.Common.Part.Part
                        {

                            DisplayPartNumber = Util.DataHelper.ConvertObjectToString(row["DisplayPartNumber"]),
                            DisplayRemarks = Util.DataHelper.ConvertObjectToString(row["DisplayRemarks"]),
                            Manufacturer = Util.DataHelper.ConvertObjectToString(row["Manufacturer"]),
                            PartDescription = Util.DataHelper.ConvertObjectToString(row["PartDescription"]),
                            PartNumber = Util.DataHelper.ConvertObjectToString(row["PartNumber"]),
                            PartStatus = Util.DataHelper.ConvertObjectToString(row["PartStatus"]),
                            PartType = Util.DataHelper.ConvertObjectToString(row["PartType"]),
                            Quantity = Util.DataHelper.ConvertObjectToDouble(row["Quantity"]),
                            QuantityOnHand = Util.DataHelper.ConvertObjectToDouble(row["QuantityOnHand"]),
                            Remarks = Util.DataHelper.ConvertObjectToString(row["Remarks"]),
                            ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                            StockQuantity = Util.DataHelper.ConvertObjectToDouble(row["StockQuantity"]),
                            StockStatus = Util.DataHelper.ConvertObjectToString(row["StockStatus"]),
                            UnitOfMeasure = Util.DataHelper.ConvertObjectToString(row["UnitOfMeasure"]),
                            PriceType = new PriceType()
                            {
                                DiscountPrice = Util.DataHelper.ConvertObjectToDouble(row["DiscountPrice"]),
                                DiscountRate = Util.DataHelper.ConvertObjectToDouble(row["DiscountRate"]),
                                TotalPrice = Util.DataHelper.ConvertObjectToDouble(row["TotalPrice"]),
                                TotalPriceIncludeTax = Util.DataHelper.ConvertObjectToDouble(row["TotalPriceIncludeTax"]),
                                UnitPrice = Util.DataHelper.ConvertObjectToDouble(row["UnitPrice"])
                            },
                        }).ToList();

                        if (Parts != null)
                        {
                            response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                            response.Parts = Parts;
                        }
                        else
                        {
                            response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                        }
                        #endregion
                    }
                    else
                    {
                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                    }
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                }
                 */
                #endregion
            }

            return response;
        }
    }
}
