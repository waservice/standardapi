using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.HMCIS.Price;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.HMCIS
{
    public class Price_Proxy : Base.BaseProxy
    {
        public PriceCheckResponse PriceCheck(PriceCheckRequest request)
        {
            PriceCheckResponse response = new PriceCheckResponse();

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

                        #region PriceCheck Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Price.Price proxyws = new _WA.Mapper.v2.Price.Price(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with pricecheck and transaction
                        _WA.Mapper.v2.Price.PriceCheckRequest proxyrequest = new _WA.Mapper.v2.Price.PriceCheckRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Price.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.Price.TransactionHeader();
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

                        //Create proxy pricecheck
                        _WA.Mapper.v2.Price.PriceCheck proxypricecheck = new _WA.Mapper.v2.Price.PriceCheck();
                        if (request.PriceCheck != null)
                        {
                            #region//PriceCheck Header
                            proxypricecheck.DMSRONo = request.PriceCheck.DMSRONo;
                            #endregion

                            #region//PriceCheck OPCodes
                            if (request.PriceCheck.OPCodes != null && request.PriceCheck.OPCodes.Count > 0)
                            {
                                int opcodescnt = 0;
                                _WA.Mapper.v2.Price.OPCode[] proxyopcodes = new _WA.Mapper.v2.Price.OPCode[request.PriceCheck.OPCodes.Count];
                                foreach (Data.v2.HMCIS.Price.OPCode opcode in request.PriceCheck.OPCodes)
                                {
                                    #region//PriceCheck OPCode Header
                                    _WA.Mapper.v2.Price.OPCode proxyopcode = new _WA.Mapper.v2.Price.OPCode();
                                    proxyopcode.Code = opcode.Code;
                                    proxyopcode.Engine = opcode.Engine;
                                    proxyopcode.Make = opcode.Make;
                                    proxyopcode.Mileage = opcode.Mileage;
                                    proxyopcode.Model = opcode.Model;
                                    proxyopcode.Period = opcode.Period;
                                    proxyopcode.Year = opcode.Year;
                                    #endregion

                                    #region//PriceCheck OPCode PriceType
                                    if (opcode.PriceType != null)
                                    {
                                        _WA.Mapper.v2.Price.PriceType proxypricetype = new _WA.Mapper.v2.Price.PriceType();
                                        proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                        proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                        proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                        proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                        proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                        proxyopcode.PriceType = proxypricetype;
                                    }
                                    #endregion

                                    #region//PriceCheck OPCode Parts
                                    if (opcode.Parts != null && opcode.Parts.Count > 0)
                                    {
                                        int partscnt = 0;
                                        _WA.Mapper.v2.Price.Part[] proxyparts = new _WA.Mapper.v2.Price.Part[opcode.Parts.Count];
                                        foreach (Data.v2.HMCIS.Price.Part part in opcode.Parts)
                                        {
                                            #region//PriceCheck OPCode Parts Header
                                            _WA.Mapper.v2.Price.Part proxypart = new _WA.Mapper.v2.Price.Part();
                                            proxypart.Manufacturer = part.Manufacturer;
                                            proxypart.PartNumber = part.PartNumber;
                                            proxypart.Quantity = part.Quantity;
                                            proxypart.ServiceType = part.ServiceType;
                                            #endregion

                                            #region//PriceCheck OPCode Parts PriceType
                                            if (part.PriceType != null)
                                            {
                                                _WA.Mapper.v2.Price.PriceType proxypricetype = new _WA.Mapper.v2.Price.PriceType();
                                                proxypricetype.DiscountPrice = part.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = part.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = part.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = part.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = part.PriceType.UnitPrice;
                                                proxypart.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            proxyparts[partscnt] = proxypart;
                                            partscnt++;
                                        }

                                        proxyopcode.Parts = proxyparts;
                                    }
                                    #endregion

                                    proxyopcodes[opcodescnt] = proxyopcode;
                                    opcodescnt++;
                                }

                                proxypricecheck.OPCodes = proxyopcodes;
                            }
                            #endregion

                            proxyrequest.PriceCheck = proxypricecheck;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Price.PriceCheckResponse proxyresponse = proxyws.PriceCheck(proxyrequest);

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
                                foreach (_WA.Mapper.v2.Price.Error proxyerror in proxyresponse.Errors)
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

                                if (proxyresponse.Price != null)
                                {
                                    #region//PricesGetResponse Set

                                    _WA.Mapper.v2.Price.Price1 proxyprice = proxyresponse.Price;

                                    #region //Prices Header
                                    Price price = new Price();
                                    price.LaborCampaignDiscountAmount = proxyprice.LaborCampaignDiscountAmount;
                                    price.PartsCampaignDiscountAmount = proxyprice.PartsCampaignDiscountAmount;
                                    price.TotalAmount = proxyprice.TotalAmount;
                                    price.TotalCampaignDiscountAmount = proxyprice.TotalCampaignDiscountAmount;
                                    price.VATAmount = proxyprice.VATAmount;
                                    #endregion

                                    if (proxyprice.OPCodes != null && proxyprice.OPCodes.Length > 0)
                                    {
                                        #region//Prices OPCode
                                        price.OPCodes = new List<Data.v2.HMCIS.Price.OPCode>();
                                        foreach (_WA.Mapper.v2.Price.OPCode1 proxyopcode in proxyprice.OPCodes)
                                        {
                                            #region //Prices OPCode Header
                                            Data.v2.HMCIS.Price.OPCode opcode = new Data.v2.HMCIS.Price.OPCode();
                                            opcode.Code = proxyopcode.Code;
                                            opcode.Engine = proxyopcode.Engine;
                                            opcode.Make = proxyopcode.Make;
                                            opcode.Mileage = proxyopcode.Mileage;
                                            opcode.Model = proxyopcode.Model;
                                            opcode.Period = proxyopcode.Period;
                                            opcode.Year = proxyopcode.Year;
                                            //opcode.Quantity = proxyopcode.Quantity;
                                            #endregion

                                            #region //Prices OPCode PriceType
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

                                            #region //Prices OPCode Parts
                                            if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                            {
                                                opcode.Parts = new List<Data.v2.HMCIS.Price.Part>();
                                                foreach (_WA.Mapper.v2.Price.Part1 proxypart in proxyopcode.Parts)
                                                {
                                                    #region //Prices OPCode Part Header
                                                    Data.v2.HMCIS.Price.Part part = new Data.v2.HMCIS.Price.Part();
                                                    part.Manufacturer = proxypart.Manufacturer;
                                                    part.PartNumber = proxypart.PartNumber;
                                                    part.Quantity = proxypart.Quantity;
                                                    part.ServiceType = proxypart.ServiceType;
                                                    #endregion

                                                    #region //Prices OPCode Part PriceType
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

                                            price.OPCodes.Add(opcode);
                                        }
                                        #endregion
                                    }

                                    response.Price = price;

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

                        #region PriceCheck Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Price.Price proxyws = new _1C.v4.Price.Price(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with pricecheck and transaction
                        _1C.v4.Price.PriceCheckRequest proxyrequest = new _1C.v4.Price.PriceCheckRequest();

                        //Create proxy transaction
                        _1C.v4.Price.TransactionHeader proxytransactionheader = new _1C.v4.Price.TransactionHeader();
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

                        //Create proxy pricecheck
                        _1C.v4.Price.PriceCheck proxypricecheck = new _1C.v4.Price.PriceCheck();
                        if (request.PriceCheck != null)
                        {
                            #region//PriceCheck Header
                            proxypricecheck.DMSRONo = request.PriceCheck.DMSRONo;
                            #endregion

                            #region//PriceCheck OPCodes
                            if (request.PriceCheck.OPCodes != null && request.PriceCheck.OPCodes.Count > 0)
                            {
                                int opcodescnt = 0;
                                _1C.v4.Price.OPCode[] proxyopcodes = new _1C.v4.Price.OPCode[request.PriceCheck.OPCodes.Count];
                                foreach (Data.v2.HMCIS.Price.OPCode opcode in request.PriceCheck.OPCodes)
                                {
                                    #region//PriceCheck OPCode Header
                                    _1C.v4.Price.OPCode proxyopcode = new _1C.v4.Price.OPCode();
                                    proxyopcode.Code = opcode.Code;
                                    proxyopcode.Engine = opcode.Engine;
                                    proxyopcode.Make = opcode.Make;
                                    proxyopcode.Mileage = opcode.Mileage;
                                    proxyopcode.Model = opcode.Model;
                                    proxyopcode.Period = opcode.Period;
                                    proxyopcode.Year = opcode.Year;
                                    #endregion

                                    #region//PriceCheck OPCode PriceType
                                    if (opcode.PriceType != null)
                                    {
                                        _1C.v4.Price.PriceType proxypricetype = new _1C.v4.Price.PriceType();
                                        proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                        proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                        proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                        proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                        proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                        proxyopcode.PriceType = proxypricetype;
                                    }
                                    #endregion

                                    #region//PriceCheck OPCode Parts
                                    if (opcode.Parts != null && opcode.Parts.Count > 0)
                                    {
                                        int partscnt = 0;
                                        _1C.v4.Price.Part[] proxyparts = new _1C.v4.Price.Part[opcode.Parts.Count];
                                        foreach (Data.v2.HMCIS.Price.Part part in opcode.Parts)
                                        {
                                            #region//PriceCheck OPCode Parts Header
                                            _1C.v4.Price.Part proxypart = new _1C.v4.Price.Part();
                                            proxypart.Manufacturer = part.Manufacturer;
                                            proxypart.PartNumber = part.PartNumber;
                                            proxypart.Quantity = part.Quantity;
                                            proxypart.ServiceType = part.ServiceType;
                                            #endregion

                                            #region//PriceCheck OPCode Parts PriceType
                                            if (part.PriceType != null)
                                            {
                                                _1C.v4.Price.PriceType proxypricetype = new _1C.v4.Price.PriceType();
                                                proxypricetype.DiscountPrice = part.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = part.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = part.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = part.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = part.PriceType.UnitPrice;
                                                proxypart.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            proxyparts[partscnt] = proxypart;
                                            partscnt++;
                                        }

                                        proxyopcode.Parts = proxyparts;
                                    }
                                    #endregion

                                    proxyopcodes[opcodescnt] = proxyopcode;
                                    opcodescnt++;
                                }

                                proxypricecheck.OPCodes = proxyopcodes;
                            }
                            #endregion

                            proxyrequest.PriceCheck = proxypricecheck;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Price.PriceCheckResponse proxyresponse = proxyws.PriceCheck(proxyrequest);

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
                                foreach (_1C.v4.Price.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //PriceCheckResponse Set

                                if (proxyresponse.Price != null)
                                {
                                    #region//PricesGetResponse Set

                                    _1C.v4.Price.Price1 proxyprice = proxyresponse.Price;

                                    #region //Prices Header
                                    Price price = new Price();
                                    price.LaborCampaignDiscountAmount = proxyprice.LaborCampaignDiscountAmount;
                                    price.PartsCampaignDiscountAmount = proxyprice.PartsCampaignDiscountAmount;
                                    price.TotalAmount = proxyprice.TotalAmount;
                                    price.TotalCampaignDiscountAmount = proxyprice.TotalCampaignDiscountAmount;
                                    price.VATAmount = proxyprice.VATAmount;
                                    #endregion

                                    if (proxyprice.OPCodes != null && proxyprice.OPCodes.Length > 0)
                                    {
                                        #region//Prices OPCode
                                        price.OPCodes = new List<Data.v2.HMCIS.Price.OPCode>();
                                        foreach (_1C.v4.Price.OPCode1 proxyopcode in proxyprice.OPCodes)
                                        {
                                            #region //Prices OPCode Header
                                            Data.v2.HMCIS.Price.OPCode opcode = new Data.v2.HMCIS.Price.OPCode();
                                            opcode.Code = proxyopcode.Code;
                                            opcode.Engine = proxyopcode.Engine;
                                            opcode.Make = proxyopcode.Make;
                                            opcode.Mileage = proxyopcode.Mileage;
                                            opcode.Model = proxyopcode.Model;
                                            opcode.Period = proxyopcode.Period;
                                            opcode.Year = proxyopcode.Year;
                                            //opcode.Quantity = proxyopcode.Quantity;
                                            #endregion

                                            #region //Prices OPCode PriceType
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

                                            #region //Prices OPCode Parts
                                            if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                            {
                                                opcode.Parts = new List<Data.v2.HMCIS.Price.Part>();
                                                foreach (_1C.v4.Price.Part1 proxypart in proxyopcode.Parts)
                                                {
                                                    #region //Prices OPCode Part Header
                                                    Data.v2.HMCIS.Price.Part part = new Data.v2.HMCIS.Price.Part();
                                                    part.Manufacturer = proxypart.Manufacturer;
                                                    part.PartNumber = proxypart.PartNumber;
                                                    part.Quantity = proxypart.Quantity;
                                                    part.ServiceType = proxypart.ServiceType;
                                                    #endregion

                                                    #region //Prices OPCode Part PriceType
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

                                            price.OPCodes.Add(opcode);
                                        }
                                        #endregion
                                    }

                                    response.Price = price;

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
