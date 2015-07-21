using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.Common.OPCode;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class OPCode_Proxy : Base.BaseProxy
    {
        public OPCodeGetResponse OPCodeGet(OPCodeGetRequest request)
        {
            OPCodeGetResponse response = new OPCodeGetResponse();

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
                        #region v2.Common.WA.v2 - Standard (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region OPCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.OPCode.OPCode proxyws = new _WA.Mapper.v2.OPCode.OPCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with opcodeget and transaction
                        _WA.Mapper.v2.OPCode.OPCodeGetRequest proxyrequest = new _WA.Mapper.v2.OPCode.OPCodeGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.OPCode.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.OPCode.TransactionHeader();
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

                        //Create proxy opcodeget
                        _WA.Mapper.v2.OPCode.OPCodeGet proxyopcodeget = new _WA.Mapper.v2.OPCode.OPCodeGet();
                        if (request.OPCodeGet != null)
                        {
                            #region//OPCodeGet Set
                            proxyopcodeget.Category = request.OPCodeGet.Category;
                            proxyopcodeget.Code = request.OPCodeGet.Code;
                            proxyopcodeget.Description = request.OPCodeGet.Description;
                            proxyopcodeget.Engine = request.OPCodeGet.Engine;
                            proxyopcodeget.Make = request.OPCodeGet.Make;
                            proxyopcodeget.Mileage = request.OPCodeGet.Mileage;
                            proxyopcodeget.Model = request.OPCodeGet.Model;
                            proxyopcodeget.Year = request.OPCodeGet.Year;
                            proxyrequest.OPCodeGet = proxyopcodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.OPCode.OPCodeGetResponse proxyresponse = proxyws.OPCodeGet(proxyrequest);

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
                                foreach (_WA.Mapper.v2.OPCode.Error proxyerror in proxyresponse.Errors)
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

                                if (proxyresponse.OPCodes != null && proxyresponse.OPCodes.Length > 0)
                                {
                                    response.OPCodes = new List<Data.v2.Common.OPCode.OPCode>();
                                    foreach (_WA.Mapper.v2.OPCode.OPCode1 proxyopcode in proxyresponse.OPCodes)
                                    {
                                        #region //OPCode Header
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

                                        #region //OPCode PriceType
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

                                        #region //OPCode Parts
                                        if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                        {
                                            opcode.Parts = new List<Data.v2.Common.Part.Part>();
                                            foreach (_WA.Mapper.v2.OPCode.Part proxypart in proxyopcode.Parts)
                                            {
                                                #region //OPCode Part Header
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

                                                #region //OPCode Part PriceType
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

                                        response.OPCodes.Add(opcode);
                                    }
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

                        #region OPCodeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.OPCode.OPCode proxyws = new _1C.v4.OPCode.OPCode(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with opcodeget and transaction
                        _1C.v4.OPCode.OPCodeGetRequest proxyrequest = new _1C.v4.OPCode.OPCodeGetRequest();

                        //Create proxy transaction
                        _1C.v4.OPCode.TransactionHeader proxytransactionheader = new _1C.v4.OPCode.TransactionHeader();
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

                        //Create proxy opcodeget
                        _1C.v4.OPCode.OPCodeGet proxyopcodeget = new _1C.v4.OPCode.OPCodeGet();
                        if (request.OPCodeGet != null)
                        {
                            #region//OPCodeGet Set
                            proxyopcodeget.Category = request.OPCodeGet.Category;
                            proxyopcodeget.Code = request.OPCodeGet.Code;
                            proxyopcodeget.Description = request.OPCodeGet.Description;
                            proxyopcodeget.Engine = request.OPCodeGet.Engine;
                            proxyopcodeget.Make = request.OPCodeGet.Make;
                            proxyopcodeget.Mileage = request.OPCodeGet.Mileage;
                            proxyopcodeget.Model = request.OPCodeGet.Model;
                            proxyopcodeget.Year = request.OPCodeGet.Year;
                            proxyrequest.OPCodeGet = proxyopcodeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.OPCode.OPCodeGetResponse proxyresponse = proxyws.OPCodeGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_1C.v4.OPCode.Error proxyerror in proxyresponse.Errors)
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

                                if (proxyresponse.OPCodes != null && proxyresponse.OPCodes.Length > 0)
                                {
                                    response.OPCodes = new List<Data.v2.Common.OPCode.OPCode>();
                                    foreach (_1C.v4.OPCode.OPCode1 proxyopcode in proxyresponse.OPCodes)
                                    {
                                        #region //OPCode Header
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

                                        #region //OPCode PriceType
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

                                        #region //OPCode Parts
                                        if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                        {
                                            opcode.Parts = new List<Data.v2.Common.Part.Part>();
                                            foreach (_1C.v4.OPCode.Part proxypart in proxyopcode.Parts)
                                            {
                                                #region //OPCode Part Header
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

                                                #region //OPCode Part PriceType
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

                                        response.OPCodes.Add(opcode);
                                    }
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
