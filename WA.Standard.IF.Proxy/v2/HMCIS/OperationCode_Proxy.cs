using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.HMCIS.OperationCode;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.HMCIS
{
    public class OperationCode_Proxy : Base.BaseProxy
    {
        public OperationCodeGetResponse OperationCodeGet(OperationCodeGetRequest request)
        {
            OperationCodeGetResponse response = new OperationCodeGetResponse();

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
                        #region v2.Common.WA.v2 - Standard (Proxy Class Dll Name : _WA.v2)

                        #region OperationCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.v4.OperationCode.OperationCode proxyws = new _WA.v4.OperationCode.OperationCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with operationcodeget and transaction
                        _WA.v4.OperationCode.OperationCodeGetRequest proxyrequest = new _WA.v4.OperationCode.OperationCodeGetRequest();

                        //Create proxy transaction
                        _WA.v4.OperationCode.TransactionHeader proxytransactionheader = new _WA.v4.OperationCode.TransactionHeader();
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
                            proxytransactionheader.TansactionId = request.TransactionHeader.TansactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy operationcodeget
                        _WA.v4.OperationCode.OperationCodeGet proxyoperationcodeget = new _WA.v4.OperationCode.OperationCodeGet();
                        if (request.OperationCodeGet != null)
                        {
                            #region//OperationCodeGet Set
                            proxyoperationcodeget.Category = request.OperationCodeGet.Category;
                            proxyoperationcodeget.Code = request.OperationCodeGet.Code;
                            proxyoperationcodeget.Description = request.OperationCodeGet.Description;
                            proxyoperationcodeget.Engine = request.OperationCodeGet.Engine;
                            proxyoperationcodeget.LastModifiedDateTimeFromUTC = request.OperationCodeGet.LastModifiedDateTimeFromUTC;
                            proxyoperationcodeget.LastModifiedDateTimeToUTC = request.OperationCodeGet.LastModifiedDateTimeToUTC;
                            proxyoperationcodeget.Make = request.OperationCodeGet.Make;
                            proxyoperationcodeget.Mileage = request.OperationCodeGet.Mileage;
                            proxyoperationcodeget.Model = request.OperationCodeGet.Model;
                            proxyoperationcodeget.Year = request.OperationCodeGet.Year;
                            proxyrequest.OperationCodeGet = proxyoperationcodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.v4.OperationCode.OperationCodeGetResponse proxyresponse = proxyws.OperationCodeGet(proxyrequest);

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
                                transactionheader.TansactionId = proxyresponse.TransactionHeader.TansactionId;
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
                                foreach (_WA.v4.OperationCode.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //OperationCodeGetResponse Set

                                if (proxyresponse.OperationCodes != null && proxyresponse.OperationCodes.Length > 0)
                                {
                                    #region//OperationCodesGetResponse Set
                                    response.OperationCodes = new List<OperationCode>();
                                    foreach (_WA.v4.OperationCode.OperationCode1 proxyoperationcode in proxyresponse.OperationCodes)
                                    {
                                        #region //OperationCodes Header
                                        OperationCode operationcode = new OperationCode();
                                        operationcode.Code = proxyoperationcode.Code;
                                        operationcode.DefLinePaymentMethod = proxyoperationcode.DefLinePaymentMethod;
                                        operationcode.Description = proxyoperationcode.Description;
                                        operationcode.DisplayOperationCode = proxyoperationcode.DisplayOperationCode;
                                        operationcode.DisplayOperationDescription = proxyoperationcode.DisplayOperationDescription;
                                        operationcode.Engine = proxyoperationcode.Engine;
                                        operationcode.EstimatedHours = proxyoperationcode.EstimatedHours;
                                        operationcode.Make = proxyoperationcode.Make;
                                        operationcode.Mileage = proxyoperationcode.Mileage;
                                        operationcode.Model = proxyoperationcode.Model;
                                        operationcode.Period = proxyoperationcode.Period;
                                        operationcode.Year = proxyoperationcode.Year;
                                        #endregion

                                        #region //OperationCodes ManagementFields
                                        if (proxyoperationcode.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxyoperationcode.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyoperationcode.ManagementFields.LastModifiedDateTimeUTC;
                                            operationcode.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region //OperationCodes PriceType
                                        if (proxyoperationcode.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxyoperationcode.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxyoperationcode.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxyoperationcode.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxyoperationcode.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxyoperationcode.PriceType.UnitPrice;
                                            operationcode.PriceType = pricetype;
                                        }
                                        #endregion

                                        if (proxyoperationcode.OPCodes != null && proxyoperationcode.OPCodes.Length > 0)
                                        {
                                            #region//OperationCodes OPCode
                                            operationcode.OPCodes = new List<Data.v2.Common.OPCode.OPCode>();
                                            foreach (_WA.v4.OperationCode.OPCode proxyopcode in proxyoperationcode.OPCodes)
                                            {
                                                #region //OperationCodes OPCode Header
                                                Data.v2.Common.OPCode.OPCode opcode = new Data.v2.Common.OPCode.OPCode();
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

                                                #region //OperationCodes OPCode PriceType
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

                                                #region //OperationCodes OPCode Parts
                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                {
                                                    opcode.Parts = new List<Data.v2.Common.Part.Part>();
                                                    foreach (_WA.v4.OperationCode.Part proxypart in proxyopcode.Parts)
                                                    {
                                                        #region //OperationCodes OPCode Part Header
                                                        Data.v2.Common.Part.Part part = new Data.v2.Common.Part.Part();
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

                                                        #region //OperationCodes OPCode Part PriceType
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

                                                operationcode.OPCodes.Add(opcode);
                                            }
                                            #endregion
                                        }
                                        response.OperationCodes.Add(operationcode);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult));
                            else
                                response.Errors = GetErrorDataList(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult);
                        }
                        #endregion
                    }
                    break;
                case "v2.HMCIS.1C.v4":
                    {
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region OperationCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.OperationCode.OperationCode proxyws = new _1C.v4.OperationCode.OperationCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with operationcodeget and transaction
                        _1C.v4.OperationCode.OperationCodeGetRequest proxyrequest = new _1C.v4.OperationCode.OperationCodeGetRequest();

                        //Create proxy transaction
                        _1C.v4.OperationCode.TransactionHeader proxytransactionheader = new _1C.v4.OperationCode.TransactionHeader();
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
                            proxytransactionheader.TansactionId = request.TransactionHeader.TansactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy operationcodeget
                        _1C.v4.OperationCode.OperationCodeGet proxyoperationcodeget = new _1C.v4.OperationCode.OperationCodeGet();
                        if (request.OperationCodeGet != null)
                        {
                            #region//OperationCodeGet Set
                            proxyoperationcodeget.Category = request.OperationCodeGet.Category;
                            proxyoperationcodeget.Code = request.OperationCodeGet.Code;
                            proxyoperationcodeget.Description = request.OperationCodeGet.Description;
                            proxyoperationcodeget.Engine = request.OperationCodeGet.Engine;
                            proxyoperationcodeget.LastModifiedDateTimeFromUTC = request.OperationCodeGet.LastModifiedDateTimeFromUTC;
                            proxyoperationcodeget.LastModifiedDateTimeToUTC = request.OperationCodeGet.LastModifiedDateTimeToUTC;
                            proxyoperationcodeget.Make = request.OperationCodeGet.Make;
                            proxyoperationcodeget.Mileage = request.OperationCodeGet.Mileage;
                            proxyoperationcodeget.Model = request.OperationCodeGet.Model;
                            proxyoperationcodeget.Year = request.OperationCodeGet.Year;
                            proxyrequest.OperationCodeGet = proxyoperationcodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.OperationCode.OperationCodeGetResponse proxyresponse = proxyws.OperationCodeGet(proxyrequest);

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
                                transactionheader.TansactionId = proxyresponse.TransactionHeader.TansactionId;
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
                                foreach (_1C.v4.OperationCode.Error proxyerror in proxyresponse.Errors)
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

                                if (proxyresponse.OperationCodes != null && proxyresponse.OperationCodes.Length > 0)
                                {
                                    #region//OperationCodesGetResponse Set
                                    response.OperationCodes = new List<OperationCode>();
                                    foreach (_1C.v4.OperationCode.OperationCode1 proxyoperationcode in proxyresponse.OperationCodes)
                                    {
                                        #region //OperationCodes Header
                                        OperationCode operationcode = new OperationCode();
                                        operationcode.Code = proxyoperationcode.Code;
                                        operationcode.DefLinePaymentMethod = proxyoperationcode.DefLinePaymentMethod;
                                        operationcode.Description = proxyoperationcode.Description;
                                        operationcode.DisplayOperationCode = proxyoperationcode.DisplayOperationCode;
                                        operationcode.DisplayOperationDescription = proxyoperationcode.DisplayOperationDescription;
                                        operationcode.Engine = proxyoperationcode.Engine;
                                        operationcode.EstimatedHours = proxyoperationcode.EstimatedHours;
                                        operationcode.Make = proxyoperationcode.Make;
                                        operationcode.Mileage = proxyoperationcode.Mileage;
                                        operationcode.Model = proxyoperationcode.Model;
                                        operationcode.Period = proxyoperationcode.Period;
                                        operationcode.Year = proxyoperationcode.Year;
                                        #endregion

                                        #region //OperationCodes ManagementFields
                                        if (proxyoperationcode.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxyoperationcode.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyoperationcode.ManagementFields.LastModifiedDateTimeUTC;
                                            operationcode.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region //OperationCodes PriceType
                                        if (proxyoperationcode.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxyoperationcode.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxyoperationcode.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxyoperationcode.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxyoperationcode.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxyoperationcode.PriceType.UnitPrice;
                                            operationcode.PriceType = pricetype;
                                        }
                                        #endregion

                                        if (proxyoperationcode.OPCodes != null && proxyoperationcode.OPCodes.Length > 0)
                                        {
                                            #region//OperationCodes OPCode
                                            operationcode.OPCodes = new List<Data.v2.Common.OPCode.OPCode>();
                                            foreach (_1C.v4.OperationCode.OPCode proxyopcode in proxyoperationcode.OPCodes)
                                            {
                                                #region //OperationCodes OPCode Header
                                                Data.v2.Common.OPCode.OPCode opcode = new Data.v2.Common.OPCode.OPCode();
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

                                                #region //OperationCodes OPCode PriceType
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

                                                #region //OperationCodes OPCode Parts
                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                {
                                                    opcode.Parts = new List<Data.v2.Common.Part.Part>();
                                                    foreach (_1C.v4.OperationCode.Part proxypart in proxyopcode.Parts)
                                                    {
                                                        #region //OperationCodes OPCode Part Header
                                                        Data.v2.Common.Part.Part part = new Data.v2.Common.Part.Part();
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

                                                        #region //OperationCodes OPCode Part PriceType
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

                                                operationcode.OPCodes.Add(opcode);
                                            }
                                            #endregion
                                        }
                                        response.OperationCodes.Add(operationcode);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult));
                            else
                                response.Errors = GetErrorDataList(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult);
                        }
                        #endregion
                    }
                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = PredefinedCode._NoMatchedProxy, Message = PredefinedMessage._NoMatchedProxy } };
                    break;
            }

            return response;
        }
    }
}
