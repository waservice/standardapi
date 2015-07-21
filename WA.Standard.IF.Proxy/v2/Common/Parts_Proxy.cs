using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.Common.Part;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class Parts_Proxy : Base.BaseProxy
    {
        public PartsGetResponse PartsGet(PartsGetRequest request)
        {
            PartsGetResponse response = new PartsGetResponse();

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

                        #region PartGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Parts.Parts proxyws = new _WA.Mapper.v2.Parts.Parts(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with partget and transaction
                        _WA.Mapper.v2.Parts.PartsGetRequest proxyrequest = new _WA.Mapper.v2.Parts.PartsGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Parts.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.Parts.TransactionHeader();
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

                        //Create proxy partget
                        _WA.Mapper.v2.Parts.PartsGet proxypartsget = new _WA.Mapper.v2.Parts.PartsGet();
                        if (request.PartsGet != null)
                        {
                            #region//PartsGet Set
                            proxypartsget.Category = request.PartsGet.Category;
                            proxypartsget.Engine = request.PartsGet.Engine;
                            proxypartsget.Make = request.PartsGet.Make;
                            proxypartsget.Manufacturer = request.PartsGet.Manufacturer;
                            proxypartsget.Mileage = request.PartsGet.Mileage;
                            proxypartsget.Model = request.PartsGet.Model;
                            proxypartsget.PartDescription = request.PartsGet.PartDescription;
                            proxypartsget.PartNumber = request.PartsGet.PartNumber;
                            proxypartsget.Year = request.PartsGet.Year;
                            proxyrequest.PartsGet = proxypartsget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Parts.PartsGetResponse proxyresponse = proxyws.PartsGet(proxyrequest);

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
                                foreach (_WA.Mapper.v2.Parts.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //PartsGetResponse Set

                                if (proxyresponse.Parts != null && proxyresponse.Parts.Length > 0)
                                {
                                    #region //PartsGetResponse Parts
                                    response.Parts = new List<Data.v2.Common.Part.Part>();
                                    foreach (_WA.Mapper.v2.Parts.Part proxypart in proxyresponse.Parts)
                                    {
                                        #region //Part Header
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

                                        #region //Part PriceType
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

                                        response.Parts.Add(part);
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

                        #region PartGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Parts.Parts proxyws = new _1C.v4.Parts.Parts(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with partget and transaction
                        _1C.v4.Parts.PartsGetRequest proxyrequest = new _1C.v4.Parts.PartsGetRequest();

                        //Create proxy transaction
                        _1C.v4.Parts.TransactionHeader proxytransactionheader = new _1C.v4.Parts.TransactionHeader();
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

                        //Create proxy partget
                        _1C.v4.Parts.PartsGet proxypartsget = new _1C.v4.Parts.PartsGet();
                        if (request.PartsGet != null)
                        {
                            #region//PartsGet Set
                            proxypartsget.Category = request.PartsGet.Category;
                            proxypartsget.Engine = request.PartsGet.Engine;
                            proxypartsget.Make = request.PartsGet.Make;
                            proxypartsget.Manufacturer = request.PartsGet.Manufacturer;
                            proxypartsget.Mileage = request.PartsGet.Mileage;
                            proxypartsget.Model = request.PartsGet.Model;
                            proxypartsget.PartDescription = request.PartsGet.PartDescription;
                            proxypartsget.PartNumber = request.PartsGet.PartNumber;
                            proxypartsget.Year = request.PartsGet.Year;
                            proxyrequest.PartsGet = proxypartsget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Parts.PartsGetResponse proxyresponse = proxyws.PartsGet(proxyrequest);

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
                                foreach (_1C.v4.Parts.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //PartsGetResponse Set

                                if (proxyresponse.Parts != null && proxyresponse.Parts.Length > 0)
                                {
                                    #region //PartsGetResponse Parts
                                    response.Parts = new List<Data.v2.Common.Part.Part>();
                                    foreach (_1C.v4.Parts.Part proxypart in proxyresponse.Parts)
                                    {
                                        #region //Part Header
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

                                        #region //Part PriceType
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

                                        response.Parts.Add(part);
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
