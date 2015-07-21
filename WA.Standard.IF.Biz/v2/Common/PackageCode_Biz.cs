using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.PackageCode;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class PackageCode_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public PackageCodeGetResponse PackageCodeGet(PackageCodeGetRequest request)
        {
            PackageCodeGetResponse response = new PackageCodeGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.PackageCode_Proxy proxy = new Proxy.v2.Common.PackageCode_Proxy();
                response = proxy.PackageCodeGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;

                #region For XML Process
                List<PackageCode> PackageCodes = Util.DataHelper.GetListByElementName<PackageCode>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/PackageCodes.xml"), "PackageCode");

                if (PackageCodes != null && PackageCodes.Count > 0)
                {
                    List<PackageCode> resultlist = PackageCodes
                       .Where(item =>
                       (string.IsNullOrEmpty(request.PackageCodeGet.Category) || true)
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Code) || item.Code.Contains(request.PackageCodeGet.Code))
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Description) || item.Description.Contains(request.PackageCodeGet.Description))
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Engine) || request.PackageCodeGet.Engine == item.Engine)
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Make) || request.PackageCodeGet.Make == item.Make)
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Mileage) || request.PackageCodeGet.Mileage == item.Mileage)
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Model) || request.PackageCodeGet.Model == item.Model)
                       && (string.IsNullOrEmpty(request.PackageCodeGet.Year) || request.PackageCodeGet.Year == item.Year)
                       && (request.PackageCodeGet.LastModifiedDateTimeFromUTC == null || request.PackageCodeGet.LastModifiedDateTimeFromUTC <= item.ManagementFields.LastModifiedDateTimeUTC)
                       && (request.PackageCodeGet.LastModifiedDateTimeToUTC == null || request.PackageCodeGet.LastModifiedDateTimeToUTC >= item.ManagementFields.LastModifiedDateTimeUTC)
                       ).ToList<PackageCode>();

                    response.PackageCodes = resultlist;

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
                using (PackageCode_Dac dac = new PackageCode_Dac())
                {
                    resultDS = dac.SelectPackageCode(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language
                                                        , request.PackageCodeGet
                        );

                }

                if (resultDS.Tables != null && resultDS.Tables.Count > 0)
                {
                    #region PackageCodes
                    List<PackageCode> PackageCodes = null;
                    PackageCodes = resultDS.Tables[0].AsEnumerable()
                        .Select(row =>
                    new PackageCode
                    {
                        Code = Util.DataHelper.ConvertObjectToString(row["DMSPackageCodeNo"]),
                        DefLinePaymentMethod = Util.DataHelper.ConvertObjectToString(row["DefLinePaymentMethod"]),
                        Description = Util.DataHelper.ConvertObjectToString(row["Description"]),
                        DisplayPackageCode = Util.DataHelper.ConvertObjectToString(row["DisplayPackageCode"]),
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

                    if (PackageCodes != null && PackageCodes.Count > 0 && resultDS.Tables.Count > 1 && resultDS.Tables[1].Rows.Count > 0)
                    {
                        foreach (PackageCode packagecode in PackageCodes)
                        {
                            #region OPCodes
                            List<WA.Standard.IF.Data.v2.Common.OPCode.OPCode> OPCodes = null;
                            OPCodes = resultDS.Tables[1].AsEnumerable()
                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSPackageCodeNo"]) == packagecode.DMSPackageCodeNo)
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

                                packagecode.OPCodes = OPCodes;
                            }
                        }

                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        response.PackageCodes = PackageCodes;
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
