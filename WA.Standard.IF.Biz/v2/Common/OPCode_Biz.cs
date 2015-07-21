using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.OPCode;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class OPCode_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public OPCodeGetResponse OPCodeGet(OPCodeGetRequest request)
        {
            OPCodeGetResponse response = new OPCodeGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.OPCode_Proxy proxy = new Proxy.v2.Common.OPCode_Proxy();
                response = proxy.OPCodeGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;

                #region For XML Process
                List<WA.Standard.IF.Data.v2.Common.OPCode.OPCode> OPCodes = Util.DataHelper.GetListByElementName<WA.Standard.IF.Data.v2.Common.OPCode.OPCode>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/OPCodes.xml"), "OPCode");

                if (OPCodes != null && OPCodes.Count > 0)
                {
                    List<WA.Standard.IF.Data.v2.Common.OPCode.OPCode> resultlist = OPCodes
                        .Where(item =>
                        (string.IsNullOrEmpty(request.OPCodeGet.Category) || true)
                        && (string.IsNullOrEmpty(request.OPCodeGet.Code) || item.Code.Contains(request.OPCodeGet.Code))
                        && (string.IsNullOrEmpty(request.OPCodeGet.Description) || item.Description.Contains(request.OPCodeGet.Description))
                        && (string.IsNullOrEmpty(request.OPCodeGet.Engine) || request.OPCodeGet.Engine == item.Engine)
                        && (string.IsNullOrEmpty(request.OPCodeGet.Make) || request.OPCodeGet.Make == item.Make)
                        && (string.IsNullOrEmpty(request.OPCodeGet.Mileage) || request.OPCodeGet.Mileage == item.Mileage)
                        && (string.IsNullOrEmpty(request.OPCodeGet.Model) || request.OPCodeGet.Model == item.Model)
                        && (string.IsNullOrEmpty(request.OPCodeGet.Year) || request.OPCodeGet.Year == item.Year)
                        ).ToList<WA.Standard.IF.Data.v2.Common.OPCode.OPCode>();

                    response.OPCodes = resultlist;

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
                using (OPCode_Dac opCode_Dac = new OPCode_Dac())
                {
                    resultDS = opCode_Dac.SelectOPCode(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language
                                                        , request.OPCodeGet
                        );

                }

                //0. OPCode Data
                //1. Parts Data - Not Used

                if (resultDS.Tables != null && resultDS.Tables.Count > 0)
                {
                    #region OPCode
                    List<WA.Standard.IF.Data.v2.Common.OPCode.OPCode> OPCodes = null;
                    OPCodes = resultDS.Tables[0].AsEnumerable()
                        .Select(row =>
                    new WA.Standard.IF.Data.v2.Common.OPCode.OPCode
                    {
                        DMSOPCodeNo = Util.DataHelper.ConvertObjectToString(row["DMSOPCodeNo"]),
                        Code = Util.DataHelper.ConvertObjectToString(row["Code"]),
                        CorrectionLOP = Util.DataHelper.ConvertObjectToString(row["CorrectionLOP"]),
                        CPSIND = Util.DataHelper.ConvertObjectToString(row["CPSIND"]),
                        DefLinePaymentMethod = Util.DataHelper.ConvertObjectToString(row["DefLinePaymentMethod"]),
                        Description = Util.DataHelper.ConvertObjectToString(row["Description"]),
                        DisplayOPCode = Util.DataHelper.ConvertObjectToString(row["DisplayOPCode"]),
                        DisplayOPDescription = Util.DataHelper.ConvertObjectToString(row["DisplayOPDescription"]),
                        Engine = Util.DataHelper.ConvertObjectToString(row["Engine"]),
                        EstimatedHours = Util.DataHelper.ConvertObjectToDouble(row["EstimatedHours"]),
                        HazardMaterialCharge = Util.DataHelper.ConvertObjectToDouble(row["HazardMaterialCharge"]),
                        Make = Util.DataHelper.ConvertObjectToString(row["Make"]),
                        Mileage = Util.DataHelper.ConvertObjectToString(row["Mileage"]),
                        Model = Util.DataHelper.ConvertObjectToString(row["Model"]),
                        Period = Util.DataHelper.ConvertObjectToString(row["Period"]),
                        PredefinedCauseDescription = Util.DataHelper.ConvertObjectToString(row["PredefinedCauseDescription"]),
                        SkillLevel = Util.DataHelper.ConvertObjectToString(row["SkillLevel"]),
                        Year = Util.DataHelper.ConvertObjectToString(row["Year"]),
                        PriceType = new PriceType()
                        {
                            DiscountPrice = Util.DataHelper.ConvertObjectToDouble(row["DiscountPrice"]),
                            DiscountRate = Util.DataHelper.ConvertObjectToDouble(row["DiscountRate"]),
                            TotalPrice = Util.DataHelper.ConvertObjectToDouble(row["TotalPrice"]),
                            TotalPriceIncludeTax = Util.DataHelper.ConvertObjectToDouble(row["TotalPriceIncludeTax"]),
                            UnitPrice = Util.DataHelper.ConvertObjectToDouble(row["UnitPrice"])
                        },
                        Parts = new List<Data.v2.Common.Part.Part>(),
                    }).ToList();

                    if (OPCodes != null && OPCodes.Count > 0 && resultDS.Tables.Count > 1 && resultDS.Tables[1].Rows.Count > 0)
                    {
                        foreach (WA.Standard.IF.Data.v2.Common.OPCode.OPCode opcode in OPCodes)
                        {
                            #region Parts
                            List<WA.Standard.IF.Data.v2.Common.Part.Part> Parts = null;
                            Parts = resultDS.Tables[1].AsEnumerable()
                                .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSOPCodeNo"]) == opcode.DMSOPCodeNo)
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
                            if (Parts != null && Parts.Count > 0)
                                opcode.Parts = Parts;
                            #endregion
                        }

                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        response.OPCodes = OPCodes;
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
                 */
                #endregion
            }

            return response;
        }
    }
}
