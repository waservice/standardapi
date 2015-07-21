using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.HMCIS;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.HMCIS.OperationCode;

namespace WA.Standard.IF.Biz.v2.HMCIS
{
    public class OperationCode_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public OperationCodeGetResponse OperationCodeGet(OperationCodeGetRequest request)
        {
            OperationCodeGetResponse response = new OperationCodeGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode._Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.HMCIS.OperationCode_Proxy proxy = new Proxy.v2.HMCIS.OperationCode_Proxy();
                response = proxy.OperationCodeGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode._XMLDMS))
            {
                #region For XML Process
                List<OperationCode> OperationCodes = Util.DataHelper.GetListByElementName<OperationCode>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/OperationCodes.xml"), "OperationCode");

                if (OperationCodes != null && OperationCodes.Count > 0)
                {
                    List<OperationCode> resultlist = OperationCodes
                       .Where(item =>
                       (string.IsNullOrEmpty(request.OperationCodeGet.Category) || true)
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Code) || item.Code.Contains(request.OperationCodeGet.Code))
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Description) || item.Description.Contains(request.OperationCodeGet.Description))
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Engine) || request.OperationCodeGet.Engine == item.Engine)
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Make) || request.OperationCodeGet.Make == item.Make)
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Mileage) || request.OperationCodeGet.Mileage == item.Mileage)
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Model) || request.OperationCodeGet.Model == item.Model)
                       && (string.IsNullOrEmpty(request.OperationCodeGet.Year) || request.OperationCodeGet.Year == item.Year)
                       && (request.OperationCodeGet.LastModifiedDateTimeFromUTC == null || request.OperationCodeGet.LastModifiedDateTimeFromUTC <= item.ManagementFields.LastModifiedDateTimeUTC)
                       && (request.OperationCodeGet.LastModifiedDateTimeToUTC == null || request.OperationCodeGet.LastModifiedDateTimeToUTC >= item.ManagementFields.LastModifiedDateTimeUTC)
                       ).ToList<OperationCode>();

                    response.OperationCodes = resultlist;
                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode._DBDMS))
            {
                #region For DB Process

                /*
                DataSet resultDS = new DataSet();
                using (OperationCode_Dac dac = new OperationCode_Dac())
                {
                    resultDS = dac.SelectOperationCode(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language
                                                        , request.OperationCodeGet
                        );

                }

                if (resultDS.Tables != null && resultDS.Tables.Count > 0)
                {
                    #region OperationCodes
                    List<OperationCode> OperationCodes = null;
                    OperationCodes = resultDS.Tables[0].AsEnumerable()
                        .Select(row =>
                    new OperationCode
                    {
                        Code = Util.DataHelper.ConvertObjectToString(row["DMSOperationCodeNo"]),
                        DefLinePaymentMethod = Util.DataHelper.ConvertObjectToString(row["DefLinePaymentMethod"]),
                        Description = Util.DataHelper.ConvertObjectToString(row["Description"]),
                        DisplayOperationCode = Util.DataHelper.ConvertObjectToString(row["DisplayOperationCode"]),
                        DisplayOperationDescription = Util.DataHelper.ConvertObjectToString(row["DisplayOperationDescription"]),
                        Engine = Util.DataHelper.ConvertObjectToString(row["Engine"]),
                        EstimatedHours = Util.DataHelper.ConvertObjectToDouble(row["EstimatedHours"]),
                        Make = Util.DataHelper.ConvertObjectToString(row["Make"]),
                        Mileage = Util.DataHelper.ConvertObjectToString(row["Mileage"]),
                        Model = Util.DataHelper.ConvertObjectToString(row["Model"]),
                        Period = Util.DataHelper.ConvertObjectToString(row["Period"]),
                        Year = Util.DataHelper.ConvertObjectToString(row["Year"]),
                        PriceType = new PriceType()
                        {
                            DiscountPrice = Util.DataHelper.ConvertObjectToDouble(row["DiscountPrice"]),
                            DiscountRate = Util.DataHelper.ConvertObjectToDouble(row["DiscountRate"]),
                            TotalPrice = Util.DataHelper.ConvertObjectToDouble(row["TotalPrice"]),
                            TotalPriceIncludeTax = Util.DataHelper.ConvertObjectToDouble(row["TotalPriceIncludeTax"]),
                            UnitPrice = Util.DataHelper.ConvertObjectToDouble(row["UnitPrice"])
                        },
                        ManagementFields = new ManagementFields()
                        {
                            CreateDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["CreateDateTimeUTC"]),
                            LastModifiedDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["LastModifiedDateTimeUTC"])
                        },
                        OPCodes = new List<Data.v2.Common.OPCode.OPCode>(),
                    }).ToList();
                    #endregion

                    if (OperationCodes != null && OperationCodes.Count > 0 && resultDS.Tables.Count > 1 && resultDS.Tables[1].Rows.Count > 0)
                    {
                        foreach (OperationCode operationcode in OperationCodes)
                        {
                            #region OPCodes
                            List<WA.Standard.IF.Data.v2.Common.OPCode.OPCode> OPCodes = null;
                            OPCodes = resultDS.Tables[1].AsEnumerable()
                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSOperationCodeNo"]) == operationcode.DMSOperationCodeNo)
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
                            #endregion

                            if (OPCodes != null && OPCodes.Count > 0 && resultDS.Tables.Count > 2 && resultDS.Tables[1].Rows.Count > 0)
                            {
                                foreach (WA.Standard.IF.Data.v2.Common.OPCode.OPCode opcode in OPCodes)
                                {
                                    #region Parts
                                    List<WA.Standard.IF.Data.v2.Common.Part.Part> Parts = null;
                                    Parts = resultDS.Tables[2].AsEnumerable()
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

                                operationcode.OPCodes = OPCodes;
                            }
                        }

                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        response.OperationCodes = OperationCodes;
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
