using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Customer;
using WA.Standard.IF.Data.v2.Common.CustomerVehicle;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class CustomerVehicle_Proxy : Base.BaseProxy
    {
        public CustomerVehicleGetResponse CustomerVehicleGet(CustomerVehicleGetRequest request)
        {
            CustomerVehicleGetResponse response = new CustomerVehicleGetResponse();

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

                        #region CustomerVehicleGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.CustomerVehicle.CustomerVehicle proxyws = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicle(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with customervehicleget and transaction
                        _WA.Mapper.v2.CustomerVehicle.CustomerVehicleGetRequest proxyrequest = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicleGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.CustomerVehicle.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.CustomerVehicle.TransactionHeader();
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

                        //Create proxy customervehicleget
                        _WA.Mapper.v2.CustomerVehicle.CustomerVehicleGet proxycustomervehicleget = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicleGet();
                        if (request.CustomerVehicleGet != null)
                        {
                            #region//CustomerVehicleGet Customer
                            if (request.CustomerVehicleGet.Customer != null)
                            {
                                _WA.Mapper.v2.CustomerVehicle.Customer customerget = new _WA.Mapper.v2.CustomerVehicle.Customer();
                                customerget.CardNo = request.CustomerVehicleGet.Customer.CardNo;
                                customerget.DMSCustomerNo = request.CustomerVehicleGet.Customer.DMSCustomerNo;
                                customerget.Email = request.CustomerVehicleGet.Customer.Email;
                                customerget.LastName = request.CustomerVehicleGet.Customer.LastName;

                                if (request.CustomerVehicleGet.Customer.Contacts != null && request.CustomerVehicleGet.Customer.Contacts.Count > 0)
                                {
                                    int contactcnt = 0;
                                    _WA.Mapper.v2.CustomerVehicle.Contact[] proxycontacts = new _WA.Mapper.v2.CustomerVehicle.Contact[request.CustomerVehicleGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact contact in request.CustomerVehicleGet.Customer.Contacts)
                                    {
                                        _WA.Mapper.v2.CustomerVehicle.Contact proxycontact = new _WA.Mapper.v2.CustomerVehicle.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycontacts[contactcnt] = proxycontact;
                                        contactcnt++;
                                    }
                                    customerget.Contacts = proxycontacts;
                                }

                                proxycustomervehicleget.Customer = customerget;
                            }
                            #endregion

                            #region//CustomerVehicleGet Vehicle
                            if (request.CustomerVehicleGet.Vehicle != null)
                            {
                                _WA.Mapper.v2.CustomerVehicle.Vehicle proxyvehicle = new _WA.Mapper.v2.CustomerVehicle.Vehicle();
                                proxyvehicle.DMSVehicleNo = request.CustomerVehicleGet.Vehicle.DMSVehicleNo;
                                proxyvehicle.LastSixVIN = request.CustomerVehicleGet.Vehicle.LastSixVIN;
                                proxyvehicle.LicensePlateNo = request.CustomerVehicleGet.Vehicle.LicensePlateNo;
                                proxyvehicle.VIN = request.CustomerVehicleGet.Vehicle.VIN;
                                proxycustomervehicleget.Vehicle = proxyvehicle;
                            }
                            #endregion

                            proxyrequest.CustomerVehicleGet = proxycustomervehicleget;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.CustomerVehicle.CustomerVehicleGetResponse proxyresponse = proxyws.CustomerVehicleGet(proxyrequest);

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
                                foreach (_WA.Mapper.v2.CustomerVehicle.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //CustomerVehicleGetResponse Set

                                if (proxyresponse.CustomerVehicles != null && proxyresponse.CustomerVehicles.Length > 0)
                                {
                                    response.CustomerVehicles = new List<CustomerVehicle>();
                                    foreach (_WA.Mapper.v2.CustomerVehicle.CustomerVehicle1 proxycustomervehicle in proxyresponse.CustomerVehicles)
                                    {
                                        #region //CustomerVehicle Header
                                        CustomerVehicle customervehicle = new CustomerVehicle();
                                        #endregion

                                        #region //CustomerVehicle Customer & Vehicle
                                        if (proxycustomervehicle.Customer != null && proxycustomervehicle.Vehicle != null)
                                        {
                                            #region //CustomerVehicle Customer Header
                                            Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                            customer.CardNo = proxycustomervehicle.Customer.CardNo;
                                            customer.CustomerInfoType = proxycustomervehicle.Customer.CustomerInfoType;
                                            customer.DMSCustomerNo = proxycustomervehicle.Customer.DMSCustomerNo;
                                            customer.Email = proxycustomervehicle.Customer.Email;
                                            customer.FirstName = proxycustomervehicle.Customer.FirstName;
                                            customer.FullName = proxycustomervehicle.Customer.FullName;
                                            customer.Gender = proxycustomervehicle.Customer.Gender;
                                            customer.LastName = proxycustomervehicle.Customer.LastName;
                                            customer.MiddleName = proxycustomervehicle.Customer.MiddleName;
                                            customer.Salutation = proxycustomervehicle.Customer.Salutation;
                                            #endregion

                                            #region //CustomerVehicle Customer SpecialMessage
                                            if (proxycustomervehicle.Customer.SpecialMessage != null)
                                            {
                                                SpecialMessage specialmessage = new SpecialMessage();
                                                specialmessage.Message = proxycustomervehicle.Customer.SpecialMessage.Message;
                                                customer.SpecialMessage = specialmessage;
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer Addresses
                                            if (proxycustomervehicle.Customer.Addresses != null && proxycustomervehicle.Customer.Addresses.Length > 0)
                                            {
                                                customer.Addresses = new List<Address>();
                                                foreach (_WA.Mapper.v2.CustomerVehicle.Address proxyaddress in proxycustomervehicle.Customer.Addresses)
                                                {
                                                    Address address = new Address();
                                                    address.Address1 = proxyaddress.Address1;
                                                    address.Address2 = proxyaddress.Address2;
                                                    address.AddressType = proxyaddress.AddressType;
                                                    address.City = proxyaddress.City;
                                                    address.Country = proxyaddress.Country;
                                                    address.State = proxyaddress.State;
                                                    address.ZipCode = proxyaddress.ZipCode;
                                                    customer.Addresses.Add(address);
                                                }
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer Contacts
                                            if (proxycustomervehicle.Customer.Contacts != null && proxycustomervehicle.Customer.Contacts.Length > 0)
                                            {
                                                customer.Contacts = new List<WA.Standard.IF.Data.v2.Common.Customer.Contact>();
                                                foreach (_WA.Mapper.v2.CustomerVehicle.Contact1 proxycontact in proxycustomervehicle.Customer.Contacts)
                                                {
                                                    WA.Standard.IF.Data.v2.Common.Customer.Contact contact = new WA.Standard.IF.Data.v2.Common.Customer.Contact();
                                                    contact.ContactMethodYN = string.IsNullOrEmpty(proxycontact.ContactMethodYN) ? "" : proxycontact.ContactMethodYN;
                                                    contact.ContactType = string.IsNullOrEmpty(proxycontact.ContactType) ? "" : proxycontact.ContactType;
                                                    contact.ContactValue = string.IsNullOrEmpty(proxycontact.ContactValue) ? "" : proxycontact.ContactValue;
                                                    customer.Contacts.Add(contact);
                                                }
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer CorporateInfos
                                            if (proxycustomervehicle.Customer.CorporateInfos != null && proxycustomervehicle.Customer.CorporateInfos.Length > 0)
                                            {
                                                customer.CorporateInfos = new List<WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo>();
                                                foreach (_WA.Mapper.v2.CustomerVehicle.CorporateInfo proxycorporateinfo in proxycustomervehicle.Customer.CorporateInfos)
                                                {
                                                    WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo = new WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo();
                                                    corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                    corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                    customer.CorporateInfos.Add(corporateinfo);
                                                }
                                            }
                                            #endregion

                                            customervehicle.Customer = customer;

                                            #region//CustomerVehicle Vehicle Header
                                            Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                            vehicle.Color = proxycustomervehicle.Vehicle.Color;
                                            vehicle.Cylinders = proxycustomervehicle.Vehicle.Cylinders;
                                            vehicle.DateDelivered = proxycustomervehicle.Vehicle.DateDelivered;
                                            vehicle.DateInService = proxycustomervehicle.Vehicle.DateInService;
                                            vehicle.DeclinedJob = proxycustomervehicle.Vehicle.DeclinedJob;
                                            vehicle.DisplayDescription = proxycustomervehicle.Vehicle.DisplayDescription;
                                            vehicle.DMSVehicleNo = proxycustomervehicle.Vehicle.DMSVehicleNo;
                                            vehicle.EngineType = proxycustomervehicle.Vehicle.EngineType;
                                            vehicle.ExtendedWarranty = proxycustomervehicle.Vehicle.ExtendedWarranty;
                                            vehicle.FuelType = proxycustomervehicle.Vehicle.FuelType;
                                            vehicle.FullModelName = proxycustomervehicle.Vehicle.FullModelName;
                                            vehicle.InsuranceDate = proxycustomervehicle.Vehicle.InsuranceDate;
                                            vehicle.LastMileage = proxycustomervehicle.Vehicle.LastMileage;
                                            vehicle.LastServiceDate = proxycustomervehicle.Vehicle.LastServiceDate;
                                            //vehicle.LastSixVIN = proxycustomervehicle.Vehicle.VIN;  // not exists ??????
                                            vehicle.LicenseNumber = proxycustomervehicle.Vehicle.LicenseNumber;
                                            vehicle.LicensePlateNo = proxycustomervehicle.Vehicle.LicensePlateNo;
                                            vehicle.Make = proxycustomervehicle.Vehicle.Make;
                                            vehicle.ModelCode = proxycustomervehicle.Vehicle.ModelCode;
                                            vehicle.ModelName = proxycustomervehicle.Vehicle.ModelName;
                                            vehicle.ModelYear = proxycustomervehicle.Vehicle.ModelYear;
                                            vehicle.PendingJob = proxycustomervehicle.Vehicle.PendingJob;
                                            vehicle.StockNumber = proxycustomervehicle.Vehicle.StockNumber;
                                            vehicle.Trim = proxycustomervehicle.Vehicle.Trim;
                                            vehicle.VehicleType = proxycustomervehicle.Vehicle.VehicleType;
                                            vehicle.VIN = proxycustomervehicle.Vehicle.VIN;
                                            vehicle.WarrantyMiles = proxycustomervehicle.Vehicle.WarrantyMiles;
                                            vehicle.WarrantyMonths = proxycustomervehicle.Vehicle.WarrantyMonths;
                                            vehicle.WarrantyStartDate = proxycustomervehicle.Vehicle.WarrantyStartDate;
                                            #endregion

                                            #region//CustomerVehicle Vehicle Campaigns
                                            if (proxycustomervehicle.Vehicle.Campaigns != null && proxycustomervehicle.Vehicle.Campaigns.Length > 0)
                                            {
                                                vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                foreach (_WA.Mapper.v2.CustomerVehicle.Campaign proxycampaign in proxycustomervehicle.Vehicle.Campaigns)
                                                {
                                                    Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                    campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                    campaign.CampaignID = proxycampaign.CampaignID;
                                                    campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                    vehicle.Campaigns.Add(campaign);
                                                }
                                            }
                                            #endregion

                                            customervehicle.Vehicle = vehicle;

                                            response.CustomerVehicles.Add(customervehicle);
                                        }
                                        #endregion
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

                        #region CustomerVehicleGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.CustomerVehicle.CustomerVehicle proxyws = new _1C.v4.CustomerVehicle.CustomerVehicle(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with customervehicleget and transaction
                        _1C.v4.CustomerVehicle.CustomerVehicleGetRequest proxyrequest = new _1C.v4.CustomerVehicle.CustomerVehicleGetRequest();

                        //Create proxy transaction
                        _1C.v4.CustomerVehicle.TransactionHeader proxytransactionheader = new _1C.v4.CustomerVehicle.TransactionHeader();
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

                        //Create proxy customervehicleget
                        _1C.v4.CustomerVehicle.CustomerVehicleGet proxycustomervehicleget = new _1C.v4.CustomerVehicle.CustomerVehicleGet();
                        if (request.CustomerVehicleGet != null)
                        {
                            #region//CustomerVehicleGet Customer
                            if (request.CustomerVehicleGet.Customer != null)
                            {
                                _1C.v4.CustomerVehicle.CustomerGet customerget = new _1C.v4.CustomerVehicle.CustomerGet();
                                customerget.CardNo = request.CustomerVehicleGet.Customer.CardNo;
                                customerget.DMSCustomerNo = request.CustomerVehicleGet.Customer.DMSCustomerNo;
                                customerget.Email = request.CustomerVehicleGet.Customer.Email;
                                customerget.LastName = request.CustomerVehicleGet.Customer.LastName;

                                if (request.CustomerVehicleGet.Customer.Contacts != null && request.CustomerVehicleGet.Customer.Contacts.Count > 0)
                                {
                                    int contactcnt = 0;
                                    _1C.v4.CustomerVehicle.Contact[] proxycontacts = new _1C.v4.CustomerVehicle.Contact[request.CustomerVehicleGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact contact in request.CustomerVehicleGet.Customer.Contacts)
                                    {
                                        _1C.v4.CustomerVehicle.Contact proxycontact = new _1C.v4.CustomerVehicle.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycontacts[contactcnt] = proxycontact;
                                        contactcnt++;
                                    }
                                    customerget.Contacts = proxycontacts;
                                }

                                proxycustomervehicleget.CustomerGet = customerget;
                            }
                            #endregion

                            #region//CustomerVehicleGet Vehicle
                            if (request.CustomerVehicleGet.Vehicle != null)
                            {
                                _1C.v4.CustomerVehicle.VehicleGet proxyvehicle = new _1C.v4.CustomerVehicle.VehicleGet();
                                proxyvehicle.DMSVehicleNo = request.CustomerVehicleGet.Vehicle.DMSVehicleNo;
                                proxyvehicle.LastSixVIN = request.CustomerVehicleGet.Vehicle.LastSixVIN;
                                proxyvehicle.LicensePlateNo = request.CustomerVehicleGet.Vehicle.LicensePlateNo;
                                proxyvehicle.VIN = request.CustomerVehicleGet.Vehicle.VIN;
                                proxycustomervehicleget.VehicleGet = proxyvehicle;
                            }
                            #endregion

                            proxyrequest.CustomerVehicleGet = proxycustomervehicleget;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.CustomerVehicle.CustomerVehicleGetResponse proxyresponse = proxyws.CustomerVehicleGet(proxyrequest);

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
                                foreach (_1C.v4.CustomerVehicle.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //CustomerVehicleGetResponse Set

                                if (proxyresponse.CustomerVehicles != null && proxyresponse.CustomerVehicles.Length > 0)
                                {
                                    response.CustomerVehicles = new List<CustomerVehicle>();
                                    foreach (_1C.v4.CustomerVehicle.CustomerVehicle1 proxycustomervehicle in proxyresponse.CustomerVehicles)
                                    {
                                        #region //CustomerVehicle Header
                                        CustomerVehicle customervehicle = new CustomerVehicle();
                                        #endregion

                                        #region //CustomerVehicle Customer & Vehicle
                                        if (proxycustomervehicle.Customer != null && proxycustomervehicle.Vehicle != null)
                                        {
                                            #region //CustomerVehicle Customer Header
                                            Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                            customer.CardNo = proxycustomervehicle.Customer.CustomerCardNo;
                                            customer.CustomerInfoType = proxycustomervehicle.Customer.CustomerInfoType;
                                            customer.DMSCustomerNo = proxycustomervehicle.Customer.DMSCustomerNo;
                                            customer.Email = proxycustomervehicle.Customer.CustomerEmail;
                                            customer.FirstName = proxycustomervehicle.Customer.CustomerFirstName;
                                            customer.FullName = proxycustomervehicle.Customer.CustomerFullName;
                                            customer.Gender = proxycustomervehicle.Customer.Gender;
                                            customer.LastName = proxycustomervehicle.Customer.CustomerLastName;
                                            customer.MiddleName = proxycustomervehicle.Customer.CustomerMiddleName;
                                            customer.Salutation = proxycustomervehicle.Customer.Salutation;
                                            #endregion

                                            #region //CustomerVehicle Customer SpecialMessage
                                            if (proxycustomervehicle.Customer.CustomerSpecialMessage != null)
                                            {
                                                SpecialMessage specialmessage = new SpecialMessage();
                                                specialmessage.Message = proxycustomervehicle.Customer.CustomerSpecialMessage.Message;
                                                customer.SpecialMessage = specialmessage;
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer Addresses
                                            if (proxycustomervehicle.Customer.Addresses != null && proxycustomervehicle.Customer.Addresses.Length > 0)
                                            {
                                                customer.Addresses = new List<Address>();
                                                foreach (_1C.v4.CustomerVehicle.Address proxyaddress in proxycustomervehicle.Customer.Addresses)
                                                {
                                                    Address address = new Address();
                                                    address.Address1 = proxyaddress.Address1;
                                                    address.Address2 = proxyaddress.Address2;
                                                    address.AddressType = proxyaddress.AddressType;
                                                    address.City = proxyaddress.City;
                                                    address.Country = proxyaddress.Country;
                                                    address.State = proxyaddress.State;
                                                    address.ZipCode = proxyaddress.ZipCode;
                                                    customer.Addresses.Add(address);
                                                }
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer Contacts
                                            if (proxycustomervehicle.Customer.Contacts != null && proxycustomervehicle.Customer.Contacts.Length > 0)
                                            {
                                                customer.Contacts = new List<WA.Standard.IF.Data.v2.Common.Customer.Contact>();
                                                foreach (_1C.v4.CustomerVehicle.Contact proxycontact in proxycustomervehicle.Customer.Contacts)
                                                {
                                                    WA.Standard.IF.Data.v2.Common.Customer.Contact contact = new WA.Standard.IF.Data.v2.Common.Customer.Contact();
                                                    contact.ContactMethodYN = string.IsNullOrEmpty(proxycontact.ContactMethodYN) ? "" : proxycontact.ContactMethodYN;
                                                    contact.ContactType = string.IsNullOrEmpty(proxycontact.ContactType) ? "" : proxycontact.ContactType;
                                                    contact.ContactValue = string.IsNullOrEmpty(proxycontact.ContactValue) ? "" : proxycontact.ContactValue;
                                                    customer.Contacts.Add(contact);
                                                }
                                            }
                                            #endregion

                                            #region //CustomerVehicle Customer CorporateInfos
                                            if (proxycustomervehicle.Customer.CorporateInfos != null && proxycustomervehicle.Customer.CorporateInfos.Length > 0)
                                            {
                                                customer.CorporateInfos = new List<WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo>();
                                                foreach (_1C.v4.CustomerVehicle.CorporateInfo proxycorporateinfo in proxycustomervehicle.Customer.CorporateInfos)
                                                {
                                                    WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo = new WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo();
                                                    corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                    corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                    customer.CorporateInfos.Add(corporateinfo);
                                                }
                                            }
                                            #endregion

                                            customervehicle.Customer = customer;

                                            #region//CustomerVehicle Vehicle Header
                                            Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                            vehicle.Color = proxycustomervehicle.Vehicle.Color;
                                            vehicle.Cylinders = proxycustomervehicle.Vehicle.Cylinders;
                                            vehicle.DateDelivered = proxycustomervehicle.Vehicle.DateDelivered;
                                            vehicle.DateInService = proxycustomervehicle.Vehicle.DateInService;
                                            vehicle.DeclinedJob = proxycustomervehicle.Vehicle.DeclinedJob;
                                            vehicle.DisplayDescription = proxycustomervehicle.Vehicle.DisplayDescription;
                                            vehicle.DMSVehicleNo = proxycustomervehicle.Vehicle.DMSVehicleNo;
                                            vehicle.EngineType = proxycustomervehicle.Vehicle.EngineType;
                                            vehicle.ExtendedWarranty = proxycustomervehicle.Vehicle.ExtendedWarranty;
                                            vehicle.FuelType = proxycustomervehicle.Vehicle.FuelType;
                                            vehicle.FullModelName = proxycustomervehicle.Vehicle.FullModelName;
                                            vehicle.InsuranceDate = proxycustomervehicle.Vehicle.InsuranceDate;
                                            vehicle.LastMileage = proxycustomervehicle.Vehicle.LastMileage;
                                            vehicle.LastServiceDate = proxycustomervehicle.Vehicle.LastServiceDate;
                                            //vehicle.LastSixVIN = proxycustomervehicle.Vehicle.VIN;  // not exists ??????
                                            vehicle.LicenseNumber = proxycustomervehicle.Vehicle.LicenseNumber;
                                            vehicle.LicensePlateNo = proxycustomervehicle.Vehicle.LicensePlateNo;
                                            vehicle.Make = proxycustomervehicle.Vehicle.Make;
                                            vehicle.ModelCode = proxycustomervehicle.Vehicle.ModelCode;
                                            vehicle.ModelName = proxycustomervehicle.Vehicle.ModelName;
                                            vehicle.ModelYear = proxycustomervehicle.Vehicle.ModelYear;
                                            vehicle.PendingJob = proxycustomervehicle.Vehicle.PendingJob;
                                            vehicle.StockNumber = proxycustomervehicle.Vehicle.StockNumber;
                                            vehicle.Trim = proxycustomervehicle.Vehicle.Trim;
                                            vehicle.VehicleType = proxycustomervehicle.Vehicle.VehicleType;
                                            vehicle.VIN = proxycustomervehicle.Vehicle.VIN;
                                            vehicle.WarrantyMiles = proxycustomervehicle.Vehicle.WarrantyMiles;
                                            vehicle.WarrantyMonths = proxycustomervehicle.Vehicle.WarrantyMonths;
                                            vehicle.WarrantyStartDate = proxycustomervehicle.Vehicle.WarrantyStartDate;
                                            #endregion

                                            #region//CustomerVehicle Vehicle Campaigns
                                            if (proxycustomervehicle.Vehicle.Campaigns != null && proxycustomervehicle.Vehicle.Campaigns.Length > 0)
                                            {
                                                vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                foreach (_1C.v4.CustomerVehicle.Campaign proxycampaign in proxycustomervehicle.Vehicle.Campaigns)
                                                {
                                                    Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                    campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                    campaign.CampaignID = proxycampaign.CampaignID;
                                                    campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                    vehicle.Campaigns.Add(campaign);
                                                }
                                            }
                                            #endregion

                                            customervehicle.Vehicle = vehicle;

                                            response.CustomerVehicles.Add(customervehicle);
                                        }
                                        #endregion
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
                case "v2.HMES.SERAUTO.v1":

                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = ResponseCode.NoMatchedProxy, Message = ResponseMessage.NoMatchedProxy } };
                    break;
            }

            return response;
        }

        public CustomerVehicleChangeResponse CustomerVehiclChange(CustomerVehicleChangeRequest request)
        {
            CustomerVehicleChangeResponse response = new CustomerVehicleChangeResponse();

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

                            #region CustomerVehicleChange Request Set

                            //Create proxy credential
                            NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                            //Create proxy web service from dms web service with credential
                            _WA.Mapper.v2.CustomerVehicle.CustomerVehicle proxyws = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicle(request.TransactionHeader.DMSServerUrl);
                            proxyws.Credentials = proxycredential;

                            //Create proxy request with customervehiclechange and transaction
                            _WA.Mapper.v2.CustomerVehicle.CustomerVehicleChangeRequest proxyrequest = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicleChangeRequest();

                            //Create proxy transaction
                            _WA.Mapper.v2.CustomerVehicle.TransactionHeader2 proxytransactionheader = new _WA.Mapper.v2.CustomerVehicle.TransactionHeader2();
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

                            //Create proxy customervehiclechange
                            _WA.Mapper.v2.CustomerVehicle.CustomerVehicleChange proxycustomervehiclechange = new _WA.Mapper.v2.CustomerVehicle.CustomerVehicleChange();
                            if (request.CustomerVehicleChange != null)
                            {
                                #region//CustomerVehicleChange Customer
                                if (request.CustomerVehicleChange.Customer != null)
                                {
                                    _WA.Mapper.v2.CustomerVehicle.Customer2 customerchange = new _WA.Mapper.v2.CustomerVehicle.Customer2();

                                    proxycustomervehiclechange.Customer = customerchange;
                                }
                                #endregion

                                #region//CustomerVehicleChange Vehicle
                                if (request.CustomerVehicleChange.Vehicle != null)
                                {
                                    _WA.Mapper.v2.CustomerVehicle.Vehicle2 proxyvehicle = new _WA.Mapper.v2.CustomerVehicle.Vehicle2();

                                    proxycustomervehiclechange.Vehicle = proxyvehicle;
                                }
                                #endregion

                                proxyrequest.CustomerVehicleChange = proxycustomervehiclechange;
                            }
                            #endregion

                            //Run proxy web method with proxy request
                            _WA.Mapper.v2.CustomerVehicle.CustomerVehicleChangeResponse proxyresponse = proxyws.CustomerVehicleChange(proxyrequest);

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
                                    foreach (_WA.Mapper.v2.CustomerVehicle.Error1 proxyerror in proxyresponse.Errors)
                                    {
                                        if (response.Errors != null)
                                            response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                        else
                                            response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                    }
                                }
                                else
                                {
                                    #region //CustomerVehicleChangeResponse Set

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

                            //#region CustomerVehicleChange Request Set

                            ////Create proxy credential
                            //NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                            ////Create proxy web service from dms web service with credential
                            //_1C.v4.CustomerVehicle.CustomerVehicle proxyws = new _1C.v4.CustomerVehicle.CustomerVehicle(request.TransactionHeader.DMSServerUrl);
                            //proxyws.Credentials = proxycredential;

                            ////Create proxy request with customervehiclechange and transaction
                            //_1C.v4.CustomerVehicle.CustomerVehicleChangeRequest proxyrequest = new _1C.v4.CustomerVehicle.CustomerVehicleChangeRequest();

                            ////Create proxy transaction
                            //_1C.v4.CustomerVehicle.TransactionHeader proxytransactionheader = new _1C.v4.CustomerVehicle.TransactionHeader();
                            //if (request.TransactionHeader != null)
                            //{
                            //    #region//TransactionHeader Set
                            //    proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            //    proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            //    proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            //    proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            //    proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            //    proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            //    proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            //    proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            //    proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            //    proxytransactionheader.Password = request.TransactionHeader.Password;
                            //    proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            //    proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            //    proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            //    proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            //    proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            //    proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            //    proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            //    proxytransactionheader.Username = request.TransactionHeader.Username;
                            //    proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            //    proxyrequest.TransactionHeader = proxytransactionheader;
                            //    #endregion
                            //}

                            ////Create proxy customervehiclechange
                            //_1C.v4.CustomerVehicle.CustomerVehicleChange proxycustomervehiclechange = new _1C.v4.CustomerVehicle.CustomerVehicleChange();
                            //if (request.CustomerVehicleChange != null)
                            //{
                            //    #region//CustomerVehicleChange Customer
                            //    if (request.CustomerVehicleChange.Customer != null)
                            //    {
                            //        _1C.v4.CustomerVehicle.CustomerChange customerchange = new _1C.v4.CustomerVehicle.CustomerChange();
                            //        customerchange.CardNo = request.CustomerVehicleChange.Customer.CardNo;
                            //        customerchange.DMSCustomerNo = request.CustomerVehicleChange.Customer.DMSCustomerNo;
                            //        customerchange.Email = request.CustomerVehicleChange.Customer.Email;
                            //        customerchange.LastName = request.CustomerVehicleChange.Customer.LastName;

                            //        if (request.CustomerVehicleChange.Customer.Contacts != null && request.CustomerVehicleChange.Customer.Contacts.Count > 0)
                            //        {
                            //            int contactcnt = 0;
                            //            _1C.v4.CustomerVehicle.Contact[] proxycontacts = new _1C.v4.CustomerVehicle.Contact[request.CustomerVehicleChange.Customer.Contacts.Count];
                            //            foreach (WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact contact in request.CustomerVehicleChange.Customer.Contacts)
                            //            {
                            //                _1C.v4.CustomerVehicle.Contact proxycontact = new _1C.v4.CustomerVehicle.Contact();
                            //                proxycontact.ContactType = contact.ContactType;
                            //                proxycontact.ContactValue = contact.ContactValue;
                            //                proxycontacts[contactcnt] = proxycontact;
                            //                contactcnt++;
                            //            }
                            //            customerchange.Contacts = proxycontacts;
                            //        }

                            //        proxycustomervehiclechange.CustomerChange = customerchange;
                            //    }
                            //    #endregion

                            //    #region//CustomerVehicleChange Vehicle
                            //    if (request.CustomerVehicleChange.Vehicle != null)
                            //    {
                            //        _1C.v4.CustomerVehicle.VehicleChange proxyvehicle = new _1C.v4.CustomerVehicle.VehicleChange();
                            //        proxyvehicle.DMSVehicleNo = request.CustomerVehicleChange.Vehicle.DMSVehicleNo;
                            //        proxyvehicle.LastSixVIN = request.CustomerVehicleChange.Vehicle.LastSixVIN;
                            //        proxyvehicle.LicensePlateNo = request.CustomerVehicleChange.Vehicle.LicensePlateNo;
                            //        proxyvehicle.VIN = request.CustomerVehicleChange.Vehicle.VIN;
                            //        proxycustomervehiclechange.VehicleChange = proxyvehicle;
                            //    }
                            //    #endregion

                            //    proxyrequest.CustomerVehicleChange = proxycustomervehiclechange;
                            //}
                            //#endregion

                            ////Run proxy web method with proxy request
                            //_1C.v4.CustomerVehicle.CustomerVehicleChangeResponse proxyresponse = proxyws.CustomerVehicleChange(proxyrequest);

                            ////Mapping with Standard Interface Specification Object
                            //if (proxyresponse != null)
                            //{
                            //    //ResultMessage Set
                            //    if (proxyresponse.ResultMessage != null)
                            //    {
                            //        response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            //    }

                            //    if (proxyresponse.Errors != null)
                            //    {
                            //        //Error List Set
                            //        foreach (_1C.v4.CustomerVehicle.Error proxyerror in proxyresponse.Errors)
                            //        {
                            //            if (response.Errors != null)
                            //                response.Errors.Add(ChangeErrorData(proxyerror.Code, proxyerror.Message));
                            //            else
                            //                response.Errors = ChangeErrorDataList(proxyerror.Code, proxyerror.Message);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        #region //CustomerVehicleChangeResponse Set

                            //        if (proxyresponse.TransactionHeader != null)
                            //        {
                            //            #region//TransactionHeader Set
                            //            TransactionHeader transactionheader = new TransactionHeader();
                            //            transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                            //            transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                            //            transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                            //            transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                            //            transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                            //            transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                            //            transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                            //            transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                            //            transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                            //            transactionheader.Password = proxyresponse.TransactionHeader.Password;
                            //            transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                            //            transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                            //            transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                            //            transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                            //            transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                            //            transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                            //            transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                            //            transactionheader.Username = proxyresponse.TransactionHeader.Username;
                            //            transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                            //            response.TransactionHeader = transactionheader;
                            //            #endregion
                            //        }

                            //        if (proxyresponse.CustomerVehicles != null && proxyresponse.CustomerVehicles.Length > 0)
                            //        {
                            //            response.CustomerVehicles = new List<CustomerVehicle>();
                            //            foreach (_1C.v4.CustomerVehicle.CustomerVehicle1 proxycustomervehicle in proxyresponse.CustomerVehicles)
                            //            {
                            //                #region //CustomerVehicle Header
                            //                CustomerVehicle customervehicle = new CustomerVehicle();
                            //                #endregion

                            //                #region //CustomerVehicle Customer & Vehicle
                            //                if (proxycustomervehicle.Customer != null && proxycustomervehicle.Vehicle != null)
                            //                {
                            //                    #region //CustomerVehicle Customer Header
                            //                    Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                            //                    customer.CardNo = proxycustomervehicle.Customer.CustomerCardNo;
                            //                    customer.CustomerInfoType = proxycustomervehicle.Customer.CustomerInfoType;
                            //                    customer.DMSCustomerNo = proxycustomervehicle.Customer.DMSCustomerNo;
                            //                    customer.Email = proxycustomervehicle.Customer.CustomerEmail;
                            //                    customer.FirstName = proxycustomervehicle.Customer.CustomerFirstName;
                            //                    customer.FullName = proxycustomervehicle.Customer.CustomerFullName;
                            //                    customer.Gender = proxycustomervehicle.Customer.Gender;
                            //                    customer.LastName = proxycustomervehicle.Customer.CustomerLastName;
                            //                    customer.MiddleName = proxycustomervehicle.Customer.CustomerMiddleName;
                            //                    customer.Salutation = proxycustomervehicle.Customer.Salutation;
                            //                    #endregion

                            //                    #region //CustomerVehicle Customer SpecialMessage
                            //                    if (proxycustomervehicle.Customer.CustomerSpecialMessage != null)
                            //                    {
                            //                        SpecialMessage specialmessage = new SpecialMessage();
                            //                        specialmessage.Message = proxycustomervehicle.Customer.CustomerSpecialMessage.Message;
                            //                        customer.SpecialMessage = specialmessage;
                            //                    }
                            //                    #endregion

                            //                    #region //CustomerVehicle Customer Addresses
                            //                    if (proxycustomervehicle.Customer.Addresses != null && proxycustomervehicle.Customer.Addresses.Length > 0)
                            //                    {
                            //                        customer.Addresses = new List<Address>();
                            //                        foreach (_1C.v4.CustomerVehicle.Address proxyaddress in proxycustomervehicle.Customer.Addresses)
                            //                        {
                            //                            Address address = new Address();
                            //                            address.Address1 = proxyaddress.Address1;
                            //                            address.Address2 = proxyaddress.Address2;
                            //                            address.AddressType = proxyaddress.AddressType;
                            //                            address.City = proxyaddress.City;
                            //                            address.Country = proxyaddress.Country;
                            //                            address.State = proxyaddress.State;
                            //                            address.ZipCode = proxyaddress.ZipCode;
                            //                            customer.Addresses.Add(address);
                            //                        }
                            //                    }
                            //                    #endregion

                            //                    #region //CustomerVehicle Customer Contacts
                            //                    if (proxycustomervehicle.Customer.Contacts != null && proxycustomervehicle.Customer.Contacts.Length > 0)
                            //                    {
                            //                        customer.Contacts = new List<WA.Standard.IF.Data.v2.Common.Customer.Contact>();
                            //                        foreach (_1C.v4.CustomerVehicle.Contact proxycontact in proxycustomervehicle.Customer.Contacts)
                            //                        {
                            //                            WA.Standard.IF.Data.v2.Common.Customer.Contact contact = new WA.Standard.IF.Data.v2.Common.Customer.Contact();
                            //                            contact.ContactMethodYN = string.IsNullOrEmpty(proxycontact.ContactMethodYN) ? "" : proxycontact.ContactMethodYN;
                            //                            contact.ContactType = string.IsNullOrEmpty(proxycontact.ContactType) ? "" : proxycontact.ContactType;
                            //                            contact.ContactValue = string.IsNullOrEmpty(proxycontact.ContactValue) ? "" : proxycontact.ContactValue;
                            //                            customer.Contacts.Add(contact);
                            //                        }
                            //                    }
                            //                    #endregion

                            //                    #region //CustomerVehicle Customer CorporateInfos
                            //                    if (proxycustomervehicle.Customer.CorporateInfos != null && proxycustomervehicle.Customer.CorporateInfos.Length > 0)
                            //                    {
                            //                        customer.CorporateInfos = new List<WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo>();
                            //                        foreach (_1C.v4.CustomerVehicle.CorporateInfo proxycorporateinfo in proxycustomervehicle.Customer.CorporateInfos)
                            //                        {
                            //                            WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo = new WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo();
                            //                            corporateinfo.Name = proxycorporateinfo.Name;
                            //                            corporateinfo.Value = proxycorporateinfo.Value;
                            //                            customer.CorporateInfos.Add(corporateinfo);
                            //                        }
                            //                    }
                            //                    #endregion

                            //                    customervehicle.Customer = customer;

                            //                    #region//CustomerVehicle Vehicle Header
                            //                    Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                            //                    vehicle.Color = proxycustomervehicle.Vehicle.Color;
                            //                    vehicle.Cylinders = proxycustomervehicle.Vehicle.Cylinders;
                            //                    vehicle.DateDelivered = proxycustomervehicle.Vehicle.DateDelivered;
                            //                    vehicle.DateInService = proxycustomervehicle.Vehicle.DateInService;
                            //                    vehicle.DeclinedJob = proxycustomervehicle.Vehicle.DeclinedJob;
                            //                    vehicle.DisplayDescription = proxycustomervehicle.Vehicle.DisplayDescription;
                            //                    vehicle.DMSVehicleNo = proxycustomervehicle.Vehicle.DMSVehicleNo;
                            //                    vehicle.EngineType = proxycustomervehicle.Vehicle.EngineType;
                            //                    vehicle.ExtendedWarranty = proxycustomervehicle.Vehicle.ExtendedWarranty;
                            //                    vehicle.FuelType = proxycustomervehicle.Vehicle.FuelType;
                            //                    vehicle.FullModelName = proxycustomervehicle.Vehicle.FullModelName;
                            //                    vehicle.InsuranceDate = proxycustomervehicle.Vehicle.InsuranceDate;
                            //                    vehicle.LastMileage = proxycustomervehicle.Vehicle.LastMileage;
                            //                    vehicle.LastServiceDate = proxycustomervehicle.Vehicle.LastServiceDate;
                            //                    //vehicle.LastSixVIN = proxycustomervehicle.Vehicle.VIN;  // not exists ??????
                            //                    vehicle.LicenseNumber = proxycustomervehicle.Vehicle.LicenseNumber;
                            //                    vehicle.LicensePlateNo = proxycustomervehicle.Vehicle.LicensePlateNo;
                            //                    vehicle.Make = proxycustomervehicle.Vehicle.Make;
                            //                    vehicle.ModelCode = proxycustomervehicle.Vehicle.ModelCode;
                            //                    vehicle.ModelName = proxycustomervehicle.Vehicle.ModelName;
                            //                    vehicle.ModelYear = proxycustomervehicle.Vehicle.ModelYear;
                            //                    vehicle.PendingJob = proxycustomervehicle.Vehicle.PendingJob;
                            //                    vehicle.StockNumber = proxycustomervehicle.Vehicle.StockNumber;
                            //                    vehicle.Trim = proxycustomervehicle.Vehicle.Trim;
                            //                    vehicle.VehicleType = proxycustomervehicle.Vehicle.VehicleType;
                            //                    vehicle.VIN = proxycustomervehicle.Vehicle.VIN;
                            //                    vehicle.WarrantyMiles = proxycustomervehicle.Vehicle.WarrantyMiles;
                            //                    vehicle.WarrantyMonths = proxycustomervehicle.Vehicle.WarrantyMonths;
                            //                    vehicle.WarrantyStartDate = proxycustomervehicle.Vehicle.WarrantyStartDate;
                            //                    #endregion

                            //                    #region//CustomerVehicle Vehicle Campaigns
                            //                    if (proxycustomervehicle.Vehicle.Campaigns != null && proxycustomervehicle.Vehicle.Campaigns.Length > 0)
                            //                    {
                            //                        vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                            //                        foreach (_1C.v4.CustomerVehicle.Campaign proxycampaign in proxycustomervehicle.Vehicle.Campaigns)
                            //                        {
                            //                            Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                            //                            campaign.CampaignDescription = proxycampaign.CampaignDescription;
                            //                            campaign.CampaignID = proxycampaign.CampaignID;
                            //                            campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                            //                            vehicle.Campaigns.Add(campaign);
                            //                        }
                            //                    }
                            //                    #endregion

                            //                    customervehicle.Vehicle = vehicle;

                            //                    response.CustomerVehicles.Add(customervehicle);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion
                            //    }
                            //}
                            //else
                            //{
                            //    if (response.Errors != null)
                            //        response.Errors.Add(GetErrorData(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult));
                            //    else
                            //        response.Errors = GetErrorDataList(PredefinedCode._ErrorNoResult, PredefinedMessage._ErrorNoResult);
                            //}
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
