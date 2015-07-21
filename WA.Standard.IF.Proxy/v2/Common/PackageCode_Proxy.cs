using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.Common.PackageCode;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class PackageCode_Proxy : Base.BaseProxy
    {
        public PackageCodeGetResponse PackageCodeGet(PackageCodeGetRequest request)
        {
            PackageCodeGetResponse response = new PackageCodeGetResponse();

            //DMS information set by dealer information
            string proxypath = string.Format("{0}.{1}.{2}.{3}",
                request.TransactionHeader.DocumentVersion,
                request.TransactionHeader.DistributorID,
                request.TransactionHeader.DMSCode,
                request.TransactionHeader.DMSVersion);

            switch (proxypath)
            {
                case "v2.Common.WA.v2":
                    {
                        #region v2.Common.WA.v2 - RTR (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region PackageCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.PackageCode.PackageCode proxyws = new _WA.Mapper.v2.PackageCode.PackageCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with packagecodeget and transaction
                        _WA.Mapper.v2.PackageCode.PackageCodeGetRequest proxyrequest = new _WA.Mapper.v2.PackageCode.PackageCodeGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.PackageCode.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.PackageCode.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy packagecodeget
                        _WA.Mapper.v2.PackageCode.PackageCodeGet proxypackagecodeget = new _WA.Mapper.v2.PackageCode.PackageCodeGet();
                        if (request.PackageCodeGet != null)
                        {
                            #region//PackageCodeGet Set
                            proxypackagecodeget.Category = request.PackageCodeGet.Category;
                            proxypackagecodeget.Code = request.PackageCodeGet.Code;
                            proxypackagecodeget.Description = request.PackageCodeGet.Description;
                            proxypackagecodeget.Engine = request.PackageCodeGet.Engine;
                            proxypackagecodeget.LastModifiedDateTimeFromUTC = request.PackageCodeGet.LastModifiedDateTimeFromUTC;
                            proxypackagecodeget.LastModifiedDateTimeToUTC = request.PackageCodeGet.LastModifiedDateTimeToUTC;
                            proxypackagecodeget.Make = request.PackageCodeGet.Make;
                            proxypackagecodeget.Mileage = request.PackageCodeGet.Mileage;
                            proxypackagecodeget.Model = request.PackageCodeGet.Model;
                            proxypackagecodeget.Year = request.PackageCodeGet.Year;
                            proxyrequest.PackageCodeGet = proxypackagecodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.PackageCode.PackageCodeGetResponse proxyresponse = proxyws.PackageCodeGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_WA.Mapper.v2.PackageCode.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //PackageCodeGetResponse Set

                                if (proxyresponse.PackageCodes != null && proxyresponse.PackageCodes.Length > 0)
                                {
                                    #region//PackageCodesGetResponse Set
                                    response.PackageCodes = new List<PackageCode>();
                                    foreach (_WA.Mapper.v2.PackageCode.PackageCode1 proxypackagecode in proxyresponse.PackageCodes)
                                    {
                                        #region //PackageCodes Header
                                        PackageCode packagecode = new PackageCode();
                                        packagecode.Code = proxypackagecode.Code;
                                        packagecode.DefLinePaymentMethod = proxypackagecode.DefLinePaymentMethod;
                                        packagecode.Description = proxypackagecode.Description;
                                        packagecode.DisplayPackageCode = proxypackagecode.DisplayPackageCode;
                                        packagecode.DisplayOperationDescription = proxypackagecode.DisplayOperationDescription;
                                        packagecode.Engine = proxypackagecode.Engine;
                                        packagecode.EstimatedHours = proxypackagecode.EstimatedHours;
                                        packagecode.Make = proxypackagecode.Make;
                                        packagecode.Mileage = proxypackagecode.Mileage;
                                        packagecode.Model = proxypackagecode.Model;
                                        packagecode.Period = proxypackagecode.Period;
                                        packagecode.Year = proxypackagecode.Year;
                                        #endregion

                                        #region //PackageCodes ManagementFields
                                        if (proxypackagecode.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxypackagecode.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxypackagecode.ManagementFields.LastModifiedDateTimeUTC;
                                            packagecode.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region //PackageCodes PriceType
                                        if (proxypackagecode.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxypackagecode.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxypackagecode.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxypackagecode.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxypackagecode.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxypackagecode.PriceType.UnitPrice;
                                            packagecode.PriceType = pricetype;
                                        }
                                        #endregion

                                        if (proxypackagecode.OPCodes != null && proxypackagecode.OPCodes.Length > 0)
                                        {
                                            #region//PackageCodes OPCode
                                            packagecode.OPCodes = new List<Data.v2.Common.PackageCode.OPCode>();
                                            foreach (_WA.Mapper.v2.PackageCode.OPCode proxyopcode in proxypackagecode.OPCodes)
                                            {
                                                #region //PackageCodes OPCode Header
                                                Data.v2.Common.PackageCode.OPCode opcode = new Data.v2.Common.PackageCode.OPCode();
                                                opcode.Code = proxyopcode.Code;
                                                opcode.CorrectionLOP = proxyopcode.CorrectionLOP;
                                                opcode.CPSIND = proxyopcode.CPSIND;
                                                opcode.DefLinePaymentMethod = proxyopcode.DefLinePaymentMethod;
                                                opcode.Description = proxyopcode.Description;
                                                opcode.DisplayOPCode = proxyopcode.DisplayOPCode;
                                                opcode.DisplayOPDescription = proxyopcode.DisplayOPDescription;
                                                opcode.Engine = proxyopcode.Engine;
                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                opcode.HazardMaterialCharge = proxyopcode.HazardMaterialCharge;
                                                opcode.Make = proxyopcode.Make;
                                                opcode.Mileage = proxyopcode.Mileage;
                                                opcode.Model = proxyopcode.Model;
                                                opcode.Period = proxyopcode.Period;
                                                opcode.PredefinedCauseDescription = proxyopcode.PredefinedCauseDescription;
                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                opcode.Year = proxyopcode.Year;
                                                #endregion

                                                #region //PackageCodes OPCode PriceType
                                                if (proxyopcode.PriceType != null)
                                                {
                                                    PriceType pricetype = new PriceType();
                                                    pricetype.DiscountPrice = proxyopcode.PriceType.DiscountPrice;
                                                    pricetype.DiscountRate = proxyopcode.PriceType.DiscountRate;
                                                    pricetype.TotalPrice = proxyopcode.PriceType.TotalPrice;
                                                    pricetype.TotalPriceIncludeTax = proxyopcode.PriceType.TotalPriceIncludeTax;
                                                    pricetype.UnitPrice = proxyopcode.PriceType.UnitPrice;
                                                    opcode.PriceType = pricetype;
                                                }
                                                #endregion

                                                #region //PackageCodes OPCode Parts
                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                {
                                                    opcode.Parts = new List<Data.v2.Common.PackageCode.Part>();
                                                    foreach (_WA.Mapper.v2.PackageCode.Part proxypart in proxyopcode.Parts)
                                                    {
                                                        #region //PackageCodes OPCode Part Header
                                                        Data.v2.Common.PackageCode.Part part = new Data.v2.Common.PackageCode.Part();
                                                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                                        part.PartDescription = proxypart.PartDescription;
                                                        part.PartNumber = proxypart.PartNumber;
                                                        part.PartType = proxypart.PartType;
                                                        part.Quantity = proxypart.Quantity;
                                                        part.ServiceType = proxypart.ServiceType;
                                                        part.StockQuantity = proxypart.StockQuantity;
                                                        part.StockStatus = proxypart.StockStatus;
                                                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                                        #endregion

                                                        #region //PackageCodes OPCode Part PriceType
                                                        if (proxypart.PriceType != null)
                                                        {
                                                            PriceType pricetype = new PriceType();
                                                            pricetype.DiscountPrice = proxypart.PriceType.DiscountPrice;
                                                            pricetype.DiscountRate = proxypart.PriceType.DiscountRate;
                                                            pricetype.TotalPrice = proxypart.PriceType.TotalPrice;
                                                            pricetype.TotalPriceIncludeTax = proxypart.PriceType.TotalPriceIncludeTax;
                                                            pricetype.UnitPrice = proxypart.PriceType.UnitPrice;
                                                            part.PriceType = pricetype;
                                                        }
                                                        #endregion

                                                        opcode.Parts.Add(part);
                                                    }
                                                }
                                                #endregion

                                                packagecode.OPCodes.Add(opcode);
                                            }
                                            #endregion
                                        }
                                        response.PackageCodes.Add(packagecode);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                case "v2.HMCIS.1C.v4":
                    {
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region PackageCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.PackageCode.PackageCode proxyws = new _1C.v4.PackageCode.PackageCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with packagecodeget and transaction
                        _1C.v4.PackageCode.PackageCodeGetRequest proxyrequest = new _1C.v4.PackageCode.PackageCodeGetRequest();

                        //Create proxy transaction
                        _1C.v4.PackageCode.TransactionHeader proxytransactionheader = new _1C.v4.PackageCode.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy packagecodeget
                        _1C.v4.PackageCode.PackageCodeGet proxypackagecodeget = new _1C.v4.PackageCode.PackageCodeGet();
                        if (request.PackageCodeGet != null)
                        {
                            #region//PackageCodeGet Set
                            proxypackagecodeget.Category = request.PackageCodeGet.Category;
                            proxypackagecodeget.Code = request.PackageCodeGet.Code;
                            proxypackagecodeget.Description = request.PackageCodeGet.Description;
                            proxypackagecodeget.Engine = request.PackageCodeGet.Engine;
                            proxypackagecodeget.LastModifiedDateTimeFromUTC = request.PackageCodeGet.LastModifiedDateTimeFromUTC;
                            proxypackagecodeget.LastModifiedDateTimeToUTC = request.PackageCodeGet.LastModifiedDateTimeToUTC;
                            proxypackagecodeget.Make = request.PackageCodeGet.Make;
                            proxypackagecodeget.Mileage = request.PackageCodeGet.Mileage;
                            proxypackagecodeget.Model = request.PackageCodeGet.Model;
                            proxypackagecodeget.Year = request.PackageCodeGet.Year;
                            proxyrequest.PackageCodeGet = proxypackagecodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.PackageCode.PackageCodeGetResponse proxyresponse = proxyws.PackageCodeGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_1C.v4.PackageCode.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //OPCodeGetResponse Set

                                if (proxyresponse.PackageCodes != null && proxyresponse.PackageCodes.Length > 0)
                                {
                                    #region//PackageCodesGetResponse Set
                                    response.PackageCodes = new List<PackageCode>();
                                    foreach (_1C.v4.PackageCode.PackageCode1 proxypackagecode in proxyresponse.PackageCodes)
                                    {
                                        #region //PackageCodes Header
                                        PackageCode packagecode = new PackageCode();
                                        packagecode.Code = proxypackagecode.Code;
                                        packagecode.DefLinePaymentMethod = proxypackagecode.DefLinePaymentMethod;
                                        packagecode.Description = proxypackagecode.Description;
                                        packagecode.DisplayPackageCode = proxypackagecode.DisplayPackageCode;
                                        packagecode.DisplayOperationDescription = proxypackagecode.DisplayOperationDescription;
                                        packagecode.Engine = proxypackagecode.Engine;
                                        packagecode.EstimatedHours = proxypackagecode.EstimatedHours;
                                        packagecode.Make = proxypackagecode.Make;
                                        packagecode.Mileage = proxypackagecode.Mileage;
                                        packagecode.Model = proxypackagecode.Model;
                                        packagecode.Period = proxypackagecode.Period;
                                        packagecode.Year = proxypackagecode.Year;
                                        #endregion

                                        #region //PackageCodes ManagementFields
                                        if (proxypackagecode.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxypackagecode.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxypackagecode.ManagementFields.LastModifiedDateTimeUTC;
                                            packagecode.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region //PackageCodes PriceType
                                        if (proxypackagecode.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxypackagecode.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxypackagecode.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxypackagecode.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxypackagecode.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxypackagecode.PriceType.UnitPrice;
                                            packagecode.PriceType = pricetype;
                                        }
                                        #endregion

                                        if (proxypackagecode.OPCodes != null && proxypackagecode.OPCodes.Length > 0)
                                        {
                                            #region//PackageCodes OPCode
                                            packagecode.OPCodes = new List<Data.v2.Common.PackageCode.OPCode>();
                                            foreach (_1C.v4.PackageCode.OPCode proxyopcode in proxypackagecode.OPCodes)
                                            {
                                                #region //PackageCodes OPCode Header
                                                Data.v2.Common.PackageCode.OPCode opcode = new Data.v2.Common.PackageCode.OPCode();
                                                opcode.Code = proxyopcode.Code;
                                                opcode.CorrectionLOP = proxyopcode.CorrectionLOP;
                                                opcode.CPSIND = proxyopcode.CPSIND;
                                                opcode.DefLinePaymentMethod = proxyopcode.DefLinePaymentMethod;
                                                opcode.Description = proxyopcode.Description;
                                                opcode.DisplayOPCode = proxyopcode.DisplayOPCode;
                                                opcode.DisplayOPDescription = proxyopcode.DisplayOPDescription;
                                                opcode.Engine = proxyopcode.Engine;
                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                opcode.HazardMaterialCharge = proxyopcode.HazardMaterialCharge;
                                                opcode.Make = proxyopcode.Make;
                                                opcode.Mileage = proxyopcode.Mileage;
                                                opcode.Model = proxyopcode.Model;
                                                opcode.Period = proxyopcode.Period;
                                                opcode.PredefinedCauseDescription = proxyopcode.PredefinedCauseDescription;
                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                opcode.Year = proxyopcode.Year;
                                                #endregion

                                                #region //PackageCodes OPCode PriceType
                                                if (proxyopcode.PriceType != null)
                                                {
                                                    PriceType pricetype = new PriceType();
                                                    pricetype.DiscountPrice = proxyopcode.PriceType.DiscountPrice;
                                                    pricetype.DiscountRate = proxyopcode.PriceType.DiscountRate;
                                                    pricetype.TotalPrice = proxyopcode.PriceType.TotalPrice;
                                                    pricetype.TotalPriceIncludeTax = proxyopcode.PriceType.TotalPriceIncludeTax;
                                                    pricetype.UnitPrice = proxyopcode.PriceType.UnitPrice;
                                                    opcode.PriceType = pricetype;
                                                }
                                                #endregion

                                                #region //PackageCodes OPCode Parts
                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                {
                                                    opcode.Parts = new List<Data.v2.Common.PackageCode.Part>();
                                                    foreach (_1C.v4.PackageCode.Part proxypart in proxyopcode.Parts)
                                                    {
                                                        #region //PackageCodes OPCode Part Header
                                                        Data.v2.Common.PackageCode.Part part = new Data.v2.Common.PackageCode.Part();
                                                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                                        part.PartDescription = proxypart.PartDescription;
                                                        part.PartNumber = proxypart.PartNumber;
                                                        part.PartType = proxypart.PartType;
                                                        part.Quantity = proxypart.Quantity;
                                                        part.ServiceType = proxypart.ServiceType;
                                                        part.StockQuantity = proxypart.StockQuantity;
                                                        part.StockStatus = proxypart.StockStatus;
                                                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                                        #endregion

                                                        #region //PackageCodes OPCode Part PriceType
                                                        if (proxypart.PriceType != null)
                                                        {
                                                            PriceType pricetype = new PriceType();
                                                            pricetype.DiscountPrice = proxypart.PriceType.DiscountPrice;
                                                            pricetype.DiscountRate = proxypart.PriceType.DiscountRate;
                                                            pricetype.TotalPrice = proxypart.PriceType.TotalPrice;
                                                            pricetype.TotalPriceIncludeTax = proxypart.PriceType.TotalPriceIncludeTax;
                                                            pricetype.UnitPrice = proxypart.PriceType.UnitPrice;
                                                            part.PriceType = pricetype;
                                                        }
                                                        #endregion

                                                        opcode.Parts.Add(part);
                                                    }
                                                }
                                                #endregion

                                                packagecode.OPCodes.Add(opcode);
                                            }
                                            #endregion
                                        }
                                        response.PackageCodes.Add(packagecode);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = ResponseCode.NoMatchedProxy, Message = ResponseMessage.NoMatchedProxy } };
                    break;
            }

            return response;
        }
    }
}
