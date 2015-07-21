using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.Common.RepairOrder;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class RepairOrder_Proxy : Base.BaseProxy
    {
        public RepairOrderGetResponse RepairOrderGet(RepairOrderGetRequest request)
        {
            RepairOrderGetResponse response = new RepairOrderGetResponse();

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

                        #region RepairOrderGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.RepairOrder.RepairOrder proxyws = new _WA.Mapper.v2.RepairOrder.RepairOrder(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with repairorderget and transaction
                        _WA.Mapper.v2.RepairOrder.RepairOrderGetRequest proxyrequest = new _WA.Mapper.v2.RepairOrder.RepairOrderGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.RepairOrder.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.RepairOrder.TransactionHeader();
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

                        //Create proxy repairorderget
                        _WA.Mapper.v2.RepairOrder.RepairOrderGet proxyrepairorderget = new _WA.Mapper.v2.RepairOrder.RepairOrderGet();
                        if (request.RepairOrderGet != null)
                        {
                            #region//RepairOrderGet Set
                            proxyrepairorderget.OpenDateTimeFromLocal = request.RepairOrderGet.OpenDateTimeFromLocal;
                            proxyrepairorderget.OpenDateTimeToLocal = request.RepairOrderGet.OpenDateTimeToLocal;
                            proxyrepairorderget.DMSROID = request.RepairOrderGet.DMSROID;
                            proxyrepairorderget.DMSRONo = request.RepairOrderGet.DMSRONo;
                            proxyrepairorderget.DMSAppointmentID = request.RepairOrderGet.DMSAppointmentID;
                            proxyrepairorderget.DMSAppointmentNo = request.RepairOrderGet.DMSAppointmentNo;
                            proxyrepairorderget.DMSROStatus = request.RepairOrderGet.DMSROStatus;
                            proxyrepairorderget.LastModifiedDateTimeFromUTC = request.RepairOrderGet.LastModifiedDateTimeFromUTC;
                            proxyrepairorderget.LastModifiedDateTimeToUTC = request.RepairOrderGet.LastModifiedDateTimeToUTC;
                            proxyrepairorderget.SAEmployeeID = request.RepairOrderGet.SAEmployeeID;
                            proxyrepairorderget.SAEmployeeName = request.RepairOrderGet.SAEmployeeName;
                            proxyrepairorderget.TCEmployeeID = request.RepairOrderGet.TCEmployeeID;
                            proxyrepairorderget.TCEmployeeName = request.RepairOrderGet.TCEmployeeName;
                            if (request.RepairOrderGet.Customer != null)
                            {
                                _WA.Mapper.v2.RepairOrder.Customer proxycustomer = new _WA.Mapper.v2.RepairOrder.Customer();
                                proxycustomer.DMSCustomerNo = request.RepairOrderGet.Customer.DMSCustomerNo;
                                proxycustomer.LastName = request.RepairOrderGet.Customer.LastName;

                                if (request.RepairOrderGet.Customer.Contacts != null && request.RepairOrderGet.Customer.Contacts.Count > 0)
                                {
                                    int cnt = 0;
                                    proxycustomer.Contacts = new _WA.Mapper.v2.RepairOrder.Contact[request.RepairOrderGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.RepairOrder.Contact contact in request.RepairOrderGet.Customer.Contacts)
                                    {
                                        _WA.Mapper.v2.RepairOrder.Contact proxycontact = new _WA.Mapper.v2.RepairOrder.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycustomer.Contacts[cnt] = proxycontact;
                                        cnt++;
                                    }
                                }
                                proxyrepairorderget.Customer = proxycustomer;
                            }
                            proxyrequest.RepairOrderGet = proxyrepairorderget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.RepairOrder.RepairOrderGetResponse proxyresponse = proxyws.RepairOrderGet(proxyrequest);

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
                                foreach (_WA.Mapper.v2.RepairOrder.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//RepairOrderGetResponse Set

                                if (proxyresponse.RepairOrderDocuments != null && proxyresponse.RepairOrderDocuments.Length > 0)
                                {
                                    response.RepairOrderDocuments = new List<RepairOrderDocument>();
                                    foreach (_WA.Mapper.v2.RepairOrder.RepairOrderDocument proxyrepairorderdocument in proxyresponse.RepairOrderDocuments)
                                    {
                                        #region //RepairOrderDocuments Header
                                        RepairOrderDocument repairorderdocument = new RepairOrderDocument();
                                        repairorderdocument.DMSRODocumentNo = proxyrepairorderdocument.DMSRODocumentNo;
                                        repairorderdocument.DMSRODocumentStatus = proxyrepairorderdocument.DMSRODocumentStatus;
                                        #endregion

                                        if (proxyrepairorderdocument.RepairOrders != null && proxyrepairorderdocument.RepairOrders.Length > 0)
                                        {
                                            repairorderdocument.RepairOrders = new List<RepairOrder>();
                                            foreach (_WA.Mapper.v2.RepairOrder.RepairOrder1 proxyrepairorder in proxyrepairorderdocument.RepairOrders)
                                            {
                                                #region //RepairOrder Header
                                                RepairOrder repairorder = new RepairOrder();
                                                repairorder.CloseDateTimeLocal = proxyrepairorder.CloseDateTimeLocal;
                                                repairorder.DeliveryDateTimeLocal = proxyrepairorder.DeliveryDateTimeLocal;
                                                repairorder.DMSROID = proxyrepairorder.DMSROID;
                                                repairorder.DMSRONo = proxyrepairorder.DMSRONo;
                                                repairorder.DMSROStatus = proxyrepairorder.DMSROStatus;
                                                repairorder.HangTagColor = proxyrepairorder.HangTagColor;
                                                repairorder.HangTagNo = proxyrepairorder.HangTagNo;
                                                repairorder.InMileage = proxyrepairorder.InMileage;
                                                repairorder.OpenDateTimeLocal = proxyrepairorder.OpenDateTimeLocal;
                                                repairorder.OutMileage = proxyrepairorder.OutMileage;
                                                repairorder.PaymentMethod = proxyrepairorder.PaymentMethod;
                                                repairorder.ROChannel = proxyrepairorder.ROChannel;
                                                repairorder.SAEmployeeID = proxyrepairorder.SAEmployeeID;
                                                repairorder.SAEmployeeName = proxyrepairorder.SAEmployeeName;
                                                repairorder.ServiceType = proxyrepairorder.ServiceType;
                                                repairorder.TCEmployeeID = proxyrepairorder.TCEmployeeID;
                                                repairorder.TCEmployeeName = proxyrepairorder.TCEmployeeName;
                                                repairorder.WorkType = proxyrepairorder.WorkType;
                                                #endregion

                                                #region//RepairOrder CustomerParts
                                                if (proxyrepairorder.CustomerParts != null && proxyrepairorder.CustomerParts.Length > 0)
                                                {
                                                    repairorder.CustomerParts = new List<CustomerPart>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.CustomerPart proxycustomerpart in proxyrepairorder.CustomerParts)
                                                    {
                                                        CustomerPart customerpart = new CustomerPart();
                                                        customerpart.Comment = proxycustomerpart.Comment;
                                                        customerpart.PartDescription = proxycustomerpart.PartDescription;
                                                        customerpart.PartNumber = proxycustomerpart.PartNumber;
                                                        customerpart.Quantity = proxycustomerpart.Quantity;
                                                        customerpart.UnitOfMeasure = proxycustomerpart.UnitOfMeasure;
                                                        repairorder.CustomerParts.Add(customerpart);
                                                    }
                                                }
                                                #endregion

                                                #region //RepairOrder AdditionalFields
                                                if (proxyrepairorder.AdditionalFields != null && proxyrepairorder.AdditionalFields.Length > 0)
                                                {
                                                    repairorder.AdditionalFields = new List<AdditionalField>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.AdditionalField proxyadditionalfield in proxyrepairorder.AdditionalFields)
                                                    {
                                                        AdditionalField additionalfield = new AdditionalField();
                                                        additionalfield.AdditionalFieldName = proxyadditionalfield.Name;
                                                        additionalfield.AdditionalFieldValue = proxyadditionalfield.Value;
                                                        repairorder.AdditionalFields.Add(additionalfield);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder JobRefs
                                                if (proxyrepairorder.JobRefs != null && proxyrepairorder.JobRefs.Length > 0)
                                                {
                                                    repairorder.JobRefs = new List<JobRef>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.JobRef proxyjobref in proxyrepairorder.JobRefs)
                                                    {
                                                        JobRef jobref = new JobRef();
                                                        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                                        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                                        repairorder.JobRefs.Add(jobref);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder ManagementFields
                                                if (proxyrepairorder.ManagementFields != null)
                                                {
                                                    ManagementFields managementfields = new ManagementFields();
                                                    managementfields.CreateDateTimeUTC = proxyrepairorder.ManagementFields.CreateDateTimeUTC;
                                                    managementfields.LastModifiedDateTimeUTC = proxyrepairorder.ManagementFields.LastModifiedDateTimeUTC;
                                                    repairorder.ManagementFields = managementfields;
                                                }
                                                #endregion

                                                #region//RepairOrder Options
                                                if (proxyrepairorder.Options != null && proxyrepairorder.Options.Length > 0)
                                                {
                                                    repairorder.Options = new List<Option>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.Option proxyoption in proxyrepairorder.Options)
                                                    {
                                                        Option option = new Option();
                                                        option.OptionName = proxyoption.Name;
                                                        option.OptionValue = proxyoption.Value;
                                                        repairorder.Options.Add(option);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder PriceType
                                                if (proxyrepairorder.PriceType != null)
                                                {
                                                    PriceType pricetype = new PriceType();
                                                    pricetype.DiscountPrice = proxyrepairorder.PriceType.DiscountPrice;
                                                    pricetype.DiscountRate = proxyrepairorder.PriceType.DiscountRate;
                                                    pricetype.TotalPrice = proxyrepairorder.PriceType.TotalPrice;
                                                    pricetype.TotalPriceIncludeTax = proxyrepairorder.PriceType.TotalPriceIncludeTax;
                                                    pricetype.UnitPrice = proxyrepairorder.PriceType.UnitPrice;
                                                    repairorder.PriceType = pricetype;
                                                }
                                                #endregion

                                                #region//RepairOrder AppointmentRef
                                                if (proxyrepairorder.AppointmentRef != null)
                                                {
                                                    AppointmentRef appointmentref = new AppointmentRef();
                                                    appointmentref.DMSAppointmentNo = proxyrepairorder.AppointmentRef.DMSAppointmentNo;
                                                    appointmentref.DMSAppointmentStatus = proxyrepairorder.AppointmentRef.DMSAppointmentStatus;
                                                    repairorder.AppointmentRef = appointmentref;
                                                }
                                                #endregion

                                                #region//RepairOrder Customers
                                                if (proxyrepairorder.Customers != null && proxyrepairorder.Customers.Length > 0)
                                                {
                                                    repairorder.Customers = new List<Data.v2.Common.Customer.Customer>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.Customer1 proxycustomer in proxyrepairorder.Customers)
                                                    {
                                                        #region//RepairOrder Customer Header
                                                        WA.Standard.IF.Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                                        customer.CardNo = proxycustomer.CardNo;
                                                        customer.CorporateInfos = customer.CorporateInfos;
                                                        customer.CustomerInfoType = customer.CustomerInfoType;
                                                        customer.DMSCustomerNo = proxycustomer.DMSCustomerNo;
                                                        customer.Email = proxycustomer.Email;
                                                        customer.FirstName = proxycustomer.FirstName;
                                                        customer.FullName = proxycustomer.FullName;
                                                        customer.Gender = proxycustomer.Gender;
                                                        customer.LastName = proxycustomer.LastName;
                                                        customer.MiddleName = proxycustomer.MiddleName;
                                                        customer.Salutation = proxycustomer.Salutation;
                                                        #endregion

                                                        #region//RepairOrder Customer Addresses
                                                        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                                        {
                                                            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.Address proxyaddress in proxycustomer.Addresses)
                                                            {
                                                                Data.v2.Common.Customer.Address address = new Data.v2.Common.Customer.Address();
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

                                                        #region//RepairOrder Customer Contacts
                                                        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                                        {
                                                            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.Contact1 proxycontact in proxycustomer.Contacts)
                                                            {
                                                                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                                                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                                                contact.ContactType = proxycontact.ContactType;
                                                                contact.ContactValue = proxycontact.ContactValue;
                                                                customer.Contacts.Add(contact);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder Customer SpecialMessage
                                                        if (proxycustomer.SpecialMessage != null)
                                                        {
                                                            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                                            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                                            customer.SpecialMessage = specialmessage;
                                                        }
                                                        #endregion

                                                        #region//RepairOrder Customer CorporateInfos
                                                        if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                                        {
                                                            customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.CorporateInfo proxycorporateinfo in proxycustomer.CorporateInfos)
                                                            {
                                                                Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                                                corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                                corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                                customer.CorporateInfos.Add(corporateinfo);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.Customers.Add(customer);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder Vehicle
                                                if (proxyrepairorder.Vehicle != null)
                                                {
                                                    if (proxyrepairorder.Vehicle != null)
                                                    {
                                                        #region//RepairOrder Vehicle Header
                                                        Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                                        vehicle.Color = proxyrepairorder.Vehicle.Color;
                                                        vehicle.Cylinders = proxyrepairorder.Vehicle.Cylinders;
                                                        vehicle.DateDelivered = proxyrepairorder.Vehicle.DateDelivered;
                                                        vehicle.DateInService = proxyrepairorder.Vehicle.DateInService;
                                                        vehicle.DeclinedJob = proxyrepairorder.Vehicle.DeclinedJob;
                                                        vehicle.DisplayDescription = proxyrepairorder.Vehicle.DisplayDescription;
                                                        vehicle.DMSVehicleNo = proxyrepairorder.Vehicle.DMSVehicleNo;
                                                        vehicle.EngineType = proxyrepairorder.Vehicle.EngineType;
                                                        vehicle.ExtendedWarranty = proxyrepairorder.Vehicle.ExtendedWarranty;
                                                        vehicle.FuelType = proxyrepairorder.Vehicle.FuelType;
                                                        vehicle.FullModelName = proxyrepairorder.Vehicle.FullModelName;
                                                        vehicle.InsuranceDate = proxyrepairorder.Vehicle.InsuranceDate;
                                                        vehicle.LastMileage = proxyrepairorder.Vehicle.LastMileage;
                                                        vehicle.LastServiceDate = proxyrepairorder.Vehicle.LastServiceDate;
                                                        vehicle.LastSixVIN = proxyrepairorder.Vehicle.LastSixVIN;
                                                        vehicle.LicenseNumber = proxyrepairorder.Vehicle.LicenseNumber;
                                                        vehicle.LicensePlateNo = proxyrepairorder.Vehicle.LicensePlateNo;
                                                        vehicle.Make = proxyrepairorder.Vehicle.Make;
                                                        vehicle.ModelCode = proxyrepairorder.Vehicle.ModelCode;
                                                        vehicle.ModelName = proxyrepairorder.Vehicle.ModelName;
                                                        vehicle.ModelYear = proxyrepairorder.Vehicle.ModelYear;
                                                        vehicle.PendingJob = proxyrepairorder.Vehicle.PendingJob;
                                                        vehicle.StockNumber = proxyrepairorder.Vehicle.StockNumber;
                                                        vehicle.Trim = proxyrepairorder.Vehicle.Trim;
                                                        vehicle.VehicleType = proxyrepairorder.Vehicle.VehicleType;
                                                        vehicle.VIN = proxyrepairorder.Vehicle.VIN;
                                                        vehicle.WarrantyMiles = proxyrepairorder.Vehicle.WarrantyMiles;
                                                        vehicle.WarrantyMonths = proxyrepairorder.Vehicle.WarrantyMonths;
                                                        vehicle.WarrantyStartDate = proxyrepairorder.Vehicle.WarrantyStartDate;
                                                        #endregion

                                                        #region//RepairOrder Vehicle Campaigns
                                                        if (proxyrepairorder.Vehicle.Campaigns != null && proxyrepairorder.Vehicle.Campaigns.Length > 0)
                                                        {
                                                            vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.Campaign proxycampaign in proxyrepairorder.Vehicle.Campaigns)
                                                            {
                                                                Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                                campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                                campaign.CampaignID = proxycampaign.CampaignID;
                                                                campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                                vehicle.Campaigns.Add(campaign);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.Vehicle = vehicle;
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder RequestItems
                                                if (proxyrepairorder.RequestItems != null && proxyrepairorder.RequestItems.Length > 0)
                                                {
                                                    repairorder.RequestItems = new List<RequestItem>();
                                                    foreach (_WA.Mapper.v2.RepairOrder.RequestItem proxyrequestitem in proxyrepairorder.RequestItems)
                                                    {
                                                        #region//RepairOrder RequestItem Header
                                                        RequestItem requestitem = new RequestItem();
                                                        requestitem.CPSIND = proxyrequestitem.CPSIND;
                                                        requestitem.RequestCode = proxyrequestitem.RequestCode;
                                                        requestitem.RequestDescription = proxyrequestitem.RequestDescription;
                                                        requestitem.ServiceLineNumber = proxyrequestitem.ServiceLineNumber;
                                                        requestitem.ServiceLineStatus = proxyrequestitem.ServiceLineStatus;
                                                        requestitem.ServiceType = proxyrequestitem.ServiceType;
                                                        requestitem.TCEmployeeID = proxyrequestitem.TCEmployeeID;
                                                        requestitem.TCEmployeeName = proxyrequestitem.TCEmployeeName;
                                                        requestitem.WorkType = proxyrequestitem.WorkType;
                                                        #endregion

                                                        #region//RepairOrder RequestItem Comments
                                                        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                                        {
                                                            requestitem.Comments = new List<Comment>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.Comment proxycomment in proxyrequestitem.Comments)
                                                            {
                                                                Comment comment = new Comment();
                                                                comment.DescriptionComment = proxycomment.DescriptionComment;
                                                                comment.SequenceNumber = proxycomment.SequenceNumber;
                                                                requestitem.Comments.Add(comment);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder RequestItem Descriptions
                                                        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                                        {
                                                            requestitem.Descriptions = new List<Description>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.Description proxydescription in proxyrequestitem.Descriptions)
                                                            {
                                                                Description description = new Description();
                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                requestitem.Descriptions.Add(description);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder RequestItem OPCodes
                                                        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                                        {
                                                            requestitem.OPCodes = new List<OPCode>();
                                                            foreach (_WA.Mapper.v2.RepairOrder.OPCode proxyopcode in proxyrequestitem.OPCodes)
                                                            {
                                                                #region//RepairOrder RequestItem OPCode Header
                                                                OPCode opcode = new OPCode();
                                                                opcode.ActualHours = proxyopcode.ActualHours;
                                                                opcode.Code = proxyopcode.Code;
                                                                opcode.Description = proxyopcode.Description;
                                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                                                opcode.ServiceType = proxyopcode.ServiceType;
                                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Descriptions
                                                                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                                {
                                                                    opcode.Descriptions = new List<Description>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.Description proxydescription in proxyopcode.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        opcode.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Causes
                                                                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                                {
                                                                    opcode.Causes = new List<Cause>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.Cause proxycause in proxyopcode.Causes)
                                                                    {
                                                                        Cause cause = new Cause();
                                                                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                                        cause.Comment = proxycause.Comment;
                                                                        cause.SequenceNumber = proxycause.SequenceNumber;
                                                                        opcode.Causes.Add(cause);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Corrections
                                                                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                                {
                                                                    opcode.Corrections = new List<Correction>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.Correction proxycorrection in proxyopcode.Corrections)
                                                                    {
                                                                        Correction correction = new Correction();
                                                                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                                        correction.Comment = proxycorrection.Comment;
                                                                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                                        opcode.Corrections.Add(correction);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode PriceType
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

                                                                #region//RepairOrder RequestItem OPCode Parts
                                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                                {
                                                                    opcode.Parts = new List<Part>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.Part proxypart in proxyopcode.Parts)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode Parts Header
                                                                        Part part = new Part();
                                                                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                                                        part.PartDescription = proxypart.PartDescription;
                                                                        part.PartNumber = proxypart.PartNumber;
                                                                        part.PartType = proxypart.PartType;
                                                                        part.Quantity = proxypart.Quantity;
                                                                        part.SequenceNumber = proxypart.SequenceNumber;
                                                                        part.ServiceType = proxypart.ServiceType;
                                                                        part.StockQuantity = proxypart.StockQuantity;
                                                                        part.StockStatus = proxypart.StockStatus;
                                                                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Parts Descriptions
                                                                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                                                        {
                                                                            part.Descriptions = new List<Description>();
                                                                            foreach (_WA.Mapper.v2.RepairOrder.Description proxydescription in proxypart.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                part.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Parts PriceType
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

                                                                #region//RepairOrder RequestItem OPCode Sublets
                                                                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                                                {
                                                                    opcode.Sublets = new List<Sublet>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.Sublet proxysublet in proxyopcode.Sublets)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode Sublet Header
                                                                        Sublet sublet = new Sublet();
                                                                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                                                        sublet.ServiceType = proxysublet.ServiceType;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                                                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                                                        {
                                                                            sublet.Descriptions = new List<Description>();
                                                                            foreach (_WA.Mapper.v2.RepairOrder.Description proxydescription in proxysublet.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                sublet.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Sublets PriceType
                                                                        if (proxysublet.PriceType != null)
                                                                        {
                                                                            PriceType pricetype = new PriceType();
                                                                            pricetype.DiscountPrice = proxysublet.PriceType.DiscountPrice;
                                                                            pricetype.DiscountRate = proxysublet.PriceType.DiscountRate;
                                                                            pricetype.TotalPrice = proxysublet.PriceType.TotalPrice;
                                                                            pricetype.TotalPriceIncludeTax = proxysublet.PriceType.TotalPriceIncludeTax;
                                                                            pricetype.UnitPrice = proxysublet.PriceType.UnitPrice;
                                                                            sublet.PriceType = pricetype;
                                                                        }
                                                                        #endregion

                                                                        opcode.Sublets.Add(sublet);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode MISCs
                                                                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                                                {
                                                                    opcode.MISCs = new List<MISC>();
                                                                    foreach (_WA.Mapper.v2.RepairOrder.MISC proxymisc in proxyopcode.MISCs)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode MISC Header
                                                                        MISC misc = new MISC();
                                                                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                                                        misc.ServiceType = proxymisc.ServiceType;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                                                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                                                        {
                                                                            misc.Descriptions = new List<Description>();
                                                                            foreach (_WA.Mapper.v2.RepairOrder.Description proxydescription in proxymisc.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                misc.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode MISCs PriceType
                                                                        if (proxymisc.PriceType != null)
                                                                        {
                                                                            PriceType pricetype = new PriceType();
                                                                            pricetype.DiscountPrice = proxymisc.PriceType.DiscountPrice;
                                                                            pricetype.DiscountRate = proxymisc.PriceType.DiscountRate;
                                                                            pricetype.TotalPrice = proxymisc.PriceType.TotalPrice;
                                                                            pricetype.TotalPriceIncludeTax = proxymisc.PriceType.TotalPriceIncludeTax;
                                                                            pricetype.UnitPrice = proxymisc.PriceType.UnitPrice;
                                                                            misc.PriceType = pricetype;
                                                                        }
                                                                        #endregion

                                                                        opcode.MISCs.Add(misc);
                                                                    }
                                                                }
                                                                #endregion

                                                                requestitem.OPCodes.Add(opcode);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.RequestItems.Add(requestitem);
                                                    }
                                                }
                                                #endregion

                                                repairorderdocument.RepairOrders.Add(repairorder);
                                            }
                                        }
                                        response.RepairOrderDocuments.Add(repairorderdocument);
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

                        #region RepairOrderGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.RepairOrder.RepairOrder proxyws = new _1C.v4.RepairOrder.RepairOrder(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with repairorderget and transaction
                        _1C.v4.RepairOrder.RepairOrderGetRequest proxyrequest = new _1C.v4.RepairOrder.RepairOrderGetRequest();

                        //Create proxy transaction
                        _1C.v4.RepairOrder.TransactionHeader proxytransactionheader = new _1C.v4.RepairOrder.TransactionHeader();
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

                        //Create proxy repairorderget
                        _1C.v4.RepairOrder.RepairOrderGet proxyrepairorderget = new _1C.v4.RepairOrder.RepairOrderGet();
                        if (request.RepairOrderGet != null)
                        {
                            #region//RepairOrderGet Set
                            proxyrepairorderget.OpenDateTimeFromLocal = request.RepairOrderGet.OpenDateTimeFromLocal;
                            proxyrepairorderget.OpenDateTimeToLocal = request.RepairOrderGet.OpenDateTimeToLocal;
                            proxyrepairorderget.DMSROID = request.RepairOrderGet.DMSROID;
                            proxyrepairorderget.DMSRONo = request.RepairOrderGet.DMSRONo;
                            proxyrepairorderget.DMSAppointmentID = request.RepairOrderGet.DMSAppointmentID;
                            proxyrepairorderget.DMSAppointmentNo = request.RepairOrderGet.DMSAppointmentNo;
                            proxyrepairorderget.DMSROStatus = request.RepairOrderGet.DMSROStatus;
                            proxyrepairorderget.LastModifiedDateTimeFromUTC = request.RepairOrderGet.LastModifiedDateTimeFromUTC;
                            proxyrepairorderget.LastModifiedDateTimeToUTC = request.RepairOrderGet.LastModifiedDateTimeToUTC;
                            proxyrepairorderget.SAEmployeeID = request.RepairOrderGet.SAEmployeeID;
                            proxyrepairorderget.SAEmployeeName = request.RepairOrderGet.SAEmployeeName;
                            proxyrepairorderget.TCEmployeeID = request.RepairOrderGet.TCEmployeeID;
                            proxyrepairorderget.TCEmployeeName = request.RepairOrderGet.TCEmployeeName;
                            if (request.RepairOrderGet.Customer != null)
                            {
                                _1C.v4.RepairOrder.Customer proxycustomer = new _1C.v4.RepairOrder.Customer();
                                proxycustomer.DMSCustomerNo = request.RepairOrderGet.Customer.DMSCustomerNo;
                                proxycustomer.LastName = request.RepairOrderGet.Customer.LastName;

                                if (request.RepairOrderGet.Customer.Contacts != null && request.RepairOrderGet.Customer.Contacts.Count > 0)
                                {
                                    int cnt = 0;
                                    proxycustomer.Contacts = new _1C.v4.RepairOrder.Contact[request.RepairOrderGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.RepairOrder.Contact contact in request.RepairOrderGet.Customer.Contacts)
                                    {
                                        _1C.v4.RepairOrder.Contact proxycontact = new _1C.v4.RepairOrder.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycustomer.Contacts[cnt] = proxycontact;
                                        cnt++;
                                    }
                                }
                                proxyrepairorderget.Customer = proxycustomer;
                            }
                            proxyrequest.RepairOrderGet = proxyrepairorderget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.RepairOrder.RepairOrderGetResponse proxyresponse = proxyws.RepairOrderGet(proxyrequest);

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
                                foreach (_1C.v4.RepairOrder.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//RepairOrderGetResponse Set

                                if (proxyresponse.RepairOrderDocuments != null && proxyresponse.RepairOrderDocuments.Length > 0)
                                {
                                    response.RepairOrderDocuments = new List<RepairOrderDocument>();
                                    foreach (_1C.v4.RepairOrder.RepairOrderDocument proxyrepairorderdocument in proxyresponse.RepairOrderDocuments)
                                    {
                                        #region //RepairOrderDocuments Header
                                        RepairOrderDocument repairorderdocument = new RepairOrderDocument();
                                        repairorderdocument.DMSRODocumentNo = proxyrepairorderdocument.DMSRODocumentNo;
                                        repairorderdocument.DMSRODocumentStatus = proxyrepairorderdocument.DMSRODocumentStatus;
                                        #endregion

                                        if (proxyrepairorderdocument.RepairOrders != null && proxyrepairorderdocument.RepairOrders.Length > 0)
                                        {
                                            repairorderdocument.RepairOrders = new List<RepairOrder>();
                                            foreach (_1C.v4.RepairOrder.RepairOrder1 proxyrepairorder in proxyrepairorderdocument.RepairOrders)
                                            {
                                                #region //RepairOrder Header
                                                RepairOrder repairorder = new RepairOrder();
                                                repairorder.CloseDateTimeLocal = proxyrepairorder.CloseDateTimeLocal;
                                                repairorder.DeliveryDateTimeLocal = proxyrepairorder.DeliveryDateTimeLocal;
                                                repairorder.DMSROID = proxyrepairorder.DMSROID;
                                                repairorder.DMSRONo = proxyrepairorder.DMSRONo;
                                                repairorder.DMSROStatus = proxyrepairorder.DMSROStatus;
                                                repairorder.HangTagColor = proxyrepairorder.HangTagColor;
                                                repairorder.HangTagNo = proxyrepairorder.HangTagNo;
                                                repairorder.InMileage = proxyrepairorder.InMileage;
                                                repairorder.OpenDateTimeLocal = proxyrepairorder.OpenDateTimeLocal;
                                                repairorder.OutMileage = proxyrepairorder.OutMileage;
                                                repairorder.PaymentMethod = proxyrepairorder.PaymentMethod;
                                                repairorder.ROChannel = proxyrepairorder.ROChannel;
                                                repairorder.SAEmployeeID = proxyrepairorder.SAEmployeeID;
                                                repairorder.SAEmployeeName = proxyrepairorder.SAEmployeeName;
                                                repairorder.ServiceType = proxyrepairorder.ServiceType;
                                                repairorder.TCEmployeeID = proxyrepairorder.TCEmployeeID;
                                                repairorder.TCEmployeeName = proxyrepairorder.TCEmployeeName;
                                                repairorder.WorkType = proxyrepairorder.WorkType;
                                                #endregion

                                                #region//RepairOrder CustomerParts
                                                if (proxyrepairorder.CustomerParts != null && proxyrepairorder.CustomerParts.Length > 0)
                                                {
                                                    repairorder.CustomerParts = new List<CustomerPart>();
                                                    foreach (_1C.v4.RepairOrder.CustomerPart proxycustomerpart in proxyrepairorder.CustomerParts)
                                                    {
                                                        CustomerPart customerpart = new CustomerPart();
                                                        customerpart.Comment = proxycustomerpart.Comment;
                                                        customerpart.PartDescription = proxycustomerpart.PartDescription;
                                                        customerpart.PartNumber = proxycustomerpart.PartNumber;
                                                        customerpart.Quantity = proxycustomerpart.Quantity;
                                                        customerpart.UnitOfMeasure = proxycustomerpart.UnitOfMeasure;
                                                        repairorder.CustomerParts.Add(customerpart);
                                                    }
                                                }
                                                #endregion

                                                #region //RepairOrder AdditionalFields
                                                if (proxyrepairorder.AdditionalFields != null && proxyrepairorder.AdditionalFields.Length > 0)
                                                {
                                                    repairorder.AdditionalFields = new List<AdditionalField>();
                                                    foreach (_1C.v4.RepairOrder.AdditionalField proxyadditionalfield in proxyrepairorder.AdditionalFields)
                                                    {
                                                        AdditionalField additionalfield = new AdditionalField();
                                                        additionalfield.AdditionalFieldName = proxyadditionalfield.Name;
                                                        additionalfield.AdditionalFieldValue = proxyadditionalfield.Value;
                                                        repairorder.AdditionalFields.Add(additionalfield);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder JobRefs
                                                if (proxyrepairorder.JobRefs != null && proxyrepairorder.JobRefs.Length > 0)
                                                {
                                                    repairorder.JobRefs = new List<JobRef>();
                                                    foreach (_1C.v4.RepairOrder.JobRef proxyjobref in proxyrepairorder.JobRefs)
                                                    {
                                                        JobRef jobref = new JobRef();
                                                        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                                        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                                        repairorder.JobRefs.Add(jobref);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder ManagementFields
                                                if (proxyrepairorder.ManagementFields != null)
                                                {
                                                    ManagementFields managementfields = new ManagementFields();
                                                    managementfields.CreateDateTimeUTC = proxyrepairorder.ManagementFields.CreateDateTimeUTC;
                                                    managementfields.LastModifiedDateTimeUTC = proxyrepairorder.ManagementFields.LastModifiedDateTimeUTC;
                                                    repairorder.ManagementFields = managementfields;
                                                }
                                                #endregion

                                                #region//RepairOrder Options
                                                if (proxyrepairorder.Options != null && proxyrepairorder.Options.Length > 0)
                                                {
                                                    repairorder.Options = new List<Option>();
                                                    foreach (_1C.v4.RepairOrder.Option proxyoption in proxyrepairorder.Options)
                                                    {
                                                        Option option = new Option();
                                                        option.OptionName = proxyoption.Name;
                                                        option.OptionValue = proxyoption.Value;
                                                        repairorder.Options.Add(option);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder PriceType
                                                if (proxyrepairorder.PriceType != null)
                                                {
                                                    PriceType pricetype = new PriceType();
                                                    pricetype.DiscountPrice = proxyrepairorder.PriceType.DiscountPrice;
                                                    pricetype.DiscountRate = proxyrepairorder.PriceType.DiscountRate;
                                                    pricetype.TotalPrice = proxyrepairorder.PriceType.TotalPrice;
                                                    pricetype.TotalPriceIncludeTax = proxyrepairorder.PriceType.TotalPriceIncludeTax;
                                                    pricetype.UnitPrice = proxyrepairorder.PriceType.UnitPrice;
                                                    repairorder.PriceType = pricetype;
                                                }
                                                #endregion

                                                #region//RepairOrder AppointmentRef
                                                if (proxyrepairorder.AppointmentRef != null)
                                                {
                                                    AppointmentRef appointmentref = new AppointmentRef();
                                                    appointmentref.DMSAppointmentNo = proxyrepairorder.AppointmentRef.DMSAppointmentNo;
                                                    appointmentref.DMSAppointmentStatus = proxyrepairorder.AppointmentRef.DMSAppointmentStatus;
                                                    repairorder.AppointmentRef = appointmentref;
                                                }
                                                #endregion

                                                #region//RepairOrder Customers
                                                if (proxyrepairorder.Customers != null && proxyrepairorder.Customers.Length > 0)
                                                {
                                                    repairorder.Customers = new List<Data.v2.Common.Customer.Customer>();
                                                    foreach (_1C.v4.RepairOrder.Customer1 proxycustomer in proxyrepairorder.Customers)
                                                    {
                                                        #region//RepairOrder Customer Header
                                                        WA.Standard.IF.Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                                        customer.CardNo = proxycustomer.CardNo;
                                                        customer.CorporateInfos = customer.CorporateInfos;
                                                        customer.CustomerInfoType = customer.CustomerInfoType;
                                                        customer.DMSCustomerNo = proxycustomer.DMSCustomerNo;
                                                        customer.Email = proxycustomer.Email;
                                                        customer.FirstName = proxycustomer.FirstName;
                                                        customer.FullName = proxycustomer.FullName;
                                                        customer.Gender = proxycustomer.Gender;
                                                        customer.LastName = proxycustomer.LastName;
                                                        customer.MiddleName = proxycustomer.MiddleName;
                                                        customer.Salutation = proxycustomer.Salutation;
                                                        #endregion

                                                        #region//RepairOrder Customer Addresses
                                                        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                                        {
                                                            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                                            foreach (_1C.v4.RepairOrder.Address proxyaddress in proxycustomer.Addresses)
                                                            {
                                                                Data.v2.Common.Customer.Address address = new Data.v2.Common.Customer.Address();
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

                                                        #region//RepairOrder Customer Contacts
                                                        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                                        {
                                                            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                                            foreach (_1C.v4.RepairOrder.Contact1 proxycontact in proxycustomer.Contacts)
                                                            {
                                                                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                                                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                                                contact.ContactType = proxycontact.ContactType;
                                                                contact.ContactValue = proxycontact.ContactValue;
                                                                customer.Contacts.Add(contact);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder Customer SpecialMessage
                                                        if (proxycustomer.SpecialMessage != null)
                                                        {
                                                            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                                            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                                            customer.SpecialMessage = specialmessage;
                                                        }
                                                        #endregion

                                                        #region//RepairOrder Customer CorporateInfos
                                                        if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                                        {
                                                            customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                                            foreach (_1C.v4.RepairOrder.CorporateInfo proxycorporateinfo in proxycustomer.CorporateInfos)
                                                            {
                                                                Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                                                corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                                corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                                customer.CorporateInfos.Add(corporateinfo);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.Customers.Add(customer);
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder Vehicle
                                                if (proxyrepairorder.Vehicle != null)
                                                {
                                                    if (proxyrepairorder.Vehicle != null)
                                                    {
                                                        #region//RepairOrder Vehicle Header
                                                        Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                                        vehicle.Color = proxyrepairorder.Vehicle.Color;
                                                        vehicle.Cylinders = proxyrepairorder.Vehicle.Cylinders;
                                                        vehicle.DateDelivered = proxyrepairorder.Vehicle.DateDelivered;
                                                        vehicle.DateInService = proxyrepairorder.Vehicle.DateInService;
                                                        vehicle.DeclinedJob = proxyrepairorder.Vehicle.DeclinedJob;
                                                        vehicle.DisplayDescription = proxyrepairorder.Vehicle.DisplayDescription;
                                                        vehicle.DMSVehicleNo = proxyrepairorder.Vehicle.DMSVehicleNo;
                                                        vehicle.EngineType = proxyrepairorder.Vehicle.EngineType;
                                                        vehicle.ExtendedWarranty = proxyrepairorder.Vehicle.ExtendedWarranty;
                                                        vehicle.FuelType = proxyrepairorder.Vehicle.FuelType;
                                                        vehicle.FullModelName = proxyrepairorder.Vehicle.FullModelName;
                                                        vehicle.InsuranceDate = proxyrepairorder.Vehicle.InsuranceDate;
                                                        vehicle.LastMileage = proxyrepairorder.Vehicle.LastMileage;
                                                        vehicle.LastServiceDate = proxyrepairorder.Vehicle.LastServiceDate;
                                                        vehicle.LastSixVIN = proxyrepairorder.Vehicle.LastSixVIN;
                                                        vehicle.LicenseNumber = proxyrepairorder.Vehicle.LicenseNumber;
                                                        vehicle.LicensePlateNo = proxyrepairorder.Vehicle.LicensePlateNo;
                                                        vehicle.Make = proxyrepairorder.Vehicle.Make;
                                                        vehicle.ModelCode = proxyrepairorder.Vehicle.ModelCode;
                                                        vehicle.ModelName = proxyrepairorder.Vehicle.ModelName;
                                                        vehicle.ModelYear = proxyrepairorder.Vehicle.ModelYear;
                                                        vehicle.PendingJob = proxyrepairorder.Vehicle.PendingJob;
                                                        vehicle.StockNumber = proxyrepairorder.Vehicle.StockNumber;
                                                        vehicle.Trim = proxyrepairorder.Vehicle.Trim;
                                                        vehicle.VehicleType = proxyrepairorder.Vehicle.VehicleType;
                                                        vehicle.VIN = proxyrepairorder.Vehicle.VIN;
                                                        vehicle.WarrantyMiles = proxyrepairorder.Vehicle.WarrantyMiles;
                                                        vehicle.WarrantyMonths = proxyrepairorder.Vehicle.WarrantyMonths;
                                                        vehicle.WarrantyStartDate = proxyrepairorder.Vehicle.WarrantyStartDate;
                                                        #endregion

                                                        #region//RepairOrder Vehicle Campaigns
                                                        if (proxyrepairorder.Vehicle.Campaigns != null && proxyrepairorder.Vehicle.Campaigns.Length > 0)
                                                        {
                                                            vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                            foreach (_1C.v4.RepairOrder.Campaign proxycampaign in proxyrepairorder.Vehicle.Campaigns)
                                                            {
                                                                Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                                campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                                campaign.CampaignID = proxycampaign.CampaignID;
                                                                campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                                vehicle.Campaigns.Add(campaign);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.Vehicle = vehicle;
                                                    }
                                                }
                                                #endregion

                                                #region//RepairOrder RequestItems
                                                if (proxyrepairorder.RequestItems != null && proxyrepairorder.RequestItems.Length > 0)
                                                {
                                                    repairorder.RequestItems = new List<RequestItem>();
                                                    foreach (_1C.v4.RepairOrder.RequestItem proxyrequestitem in proxyrepairorder.RequestItems)
                                                    {
                                                        #region//RepairOrder RequestItem Header
                                                        RequestItem requestitem = new RequestItem();
                                                        requestitem.CPSIND = proxyrequestitem.CPSIND;
                                                        requestitem.RequestCode = proxyrequestitem.RequestCode;
                                                        requestitem.RequestDescription = proxyrequestitem.RequestDescription;
                                                        requestitem.ServiceLineNumber = proxyrequestitem.ServiceLineNumber;
                                                        requestitem.ServiceLineStatus = proxyrequestitem.ServiceLineStatus;
                                                        requestitem.ServiceType = proxyrequestitem.ServiceType;
                                                        requestitem.TCEmployeeID = proxyrequestitem.TCEmployeeID;
                                                        requestitem.TCEmployeeName = proxyrequestitem.TCEmployeeName;
                                                        requestitem.WorkType = proxyrequestitem.WorkType;
                                                        #endregion

                                                        #region//RepairOrder RequestItem Comments
                                                        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                                        {
                                                            requestitem.Comments = new List<Comment>();
                                                            foreach (_1C.v4.RepairOrder.Comment proxycomment in proxyrequestitem.Comments)
                                                            {
                                                                Comment comment = new Comment();
                                                                comment.DescriptionComment = proxycomment.DescriptionComment;
                                                                comment.SequenceNumber = proxycomment.SequenceNumber;
                                                                requestitem.Comments.Add(comment);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder RequestItem Descriptions
                                                        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                                        {
                                                            requestitem.Descriptions = new List<Description>();
                                                            foreach (_1C.v4.RepairOrder.Description proxydescription in proxyrequestitem.Descriptions)
                                                            {
                                                                Description description = new Description();
                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                requestitem.Descriptions.Add(description);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//RepairOrder RequestItem OPCodes
                                                        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                                        {
                                                            requestitem.OPCodes = new List<OPCode>();
                                                            foreach (_1C.v4.RepairOrder.OPCode proxyopcode in proxyrequestitem.OPCodes)
                                                            {
                                                                #region//RepairOrder RequestItem OPCode Header
                                                                OPCode opcode = new OPCode();
                                                                opcode.ActualHours = proxyopcode.ActualHours;
                                                                opcode.Code = proxyopcode.Code;
                                                                opcode.Description = proxyopcode.Description;
                                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                                                opcode.ServiceType = proxyopcode.ServiceType;
                                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Descriptions
                                                                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                                {
                                                                    opcode.Descriptions = new List<Description>();
                                                                    foreach (_1C.v4.RepairOrder.Description proxydescription in proxyopcode.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        opcode.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Causes
                                                                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                                {
                                                                    opcode.Causes = new List<Cause>();
                                                                    foreach (_1C.v4.RepairOrder.Cause proxycause in proxyopcode.Causes)
                                                                    {
                                                                        Cause cause = new Cause();
                                                                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                                        cause.Comment = proxycause.Comment;
                                                                        cause.SequenceNumber = proxycause.SequenceNumber;
                                                                        opcode.Causes.Add(cause);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode Corrections
                                                                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                                {
                                                                    opcode.Corrections = new List<Correction>();
                                                                    foreach (_1C.v4.RepairOrder.Correction proxycorrection in proxyopcode.Corrections)
                                                                    {
                                                                        Correction correction = new Correction();
                                                                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                                        correction.Comment = proxycorrection.Comment;
                                                                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                                        opcode.Corrections.Add(correction);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode PriceType
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

                                                                #region//RepairOrder RequestItem OPCode Parts
                                                                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                                {
                                                                    opcode.Parts = new List<Part>();
                                                                    foreach (_1C.v4.RepairOrder.Part proxypart in proxyopcode.Parts)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode Parts Header
                                                                        Part part = new Part();
                                                                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                                                        part.PartDescription = proxypart.PartDescription;
                                                                        part.PartNumber = proxypart.PartNumber;
                                                                        part.PartType = proxypart.PartType;
                                                                        part.Quantity = proxypart.Quantity;
                                                                        part.SequenceNumber = proxypart.SequenceNumber;
                                                                        part.ServiceType = proxypart.ServiceType;
                                                                        part.StockQuantity = proxypart.StockQuantity;
                                                                        part.StockStatus = proxypart.StockStatus;
                                                                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Parts Descriptions
                                                                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                                                        {
                                                                            part.Descriptions = new List<Description>();
                                                                            foreach (_1C.v4.RepairOrder.Description proxydescription in proxypart.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                part.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Parts PriceType
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

                                                                #region//RepairOrder RequestItem OPCode Sublets
                                                                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                                                {
                                                                    opcode.Sublets = new List<Sublet>();
                                                                    foreach (_1C.v4.RepairOrder.Sublet proxysublet in proxyopcode.Sublets)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode Sublet Header
                                                                        Sublet sublet = new Sublet();
                                                                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                                                        sublet.ServiceType = proxysublet.ServiceType;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                                                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                                                        {
                                                                            sublet.Descriptions = new List<Description>();
                                                                            foreach (_1C.v4.RepairOrder.Description proxydescription in proxysublet.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                sublet.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode Sublets PriceType
                                                                        if (proxysublet.PriceType != null)
                                                                        {
                                                                            PriceType pricetype = new PriceType();
                                                                            pricetype.DiscountPrice = proxysublet.PriceType.DiscountPrice;
                                                                            pricetype.DiscountRate = proxysublet.PriceType.DiscountRate;
                                                                            pricetype.TotalPrice = proxysublet.PriceType.TotalPrice;
                                                                            pricetype.TotalPriceIncludeTax = proxysublet.PriceType.TotalPriceIncludeTax;
                                                                            pricetype.UnitPrice = proxysublet.PriceType.UnitPrice;
                                                                            sublet.PriceType = pricetype;
                                                                        }
                                                                        #endregion

                                                                        opcode.Sublets.Add(sublet);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//RepairOrder RequestItem OPCode MISCs
                                                                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                                                {
                                                                    opcode.MISCs = new List<MISC>();
                                                                    foreach (_1C.v4.RepairOrder.MISC proxymisc in proxyopcode.MISCs)
                                                                    {
                                                                        #region//RepairOrder RequestItem OPCode MISC Header
                                                                        MISC misc = new MISC();
                                                                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                                                        misc.ServiceType = proxymisc.ServiceType;
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                                                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                                                        {
                                                                            misc.Descriptions = new List<Description>();
                                                                            foreach (_1C.v4.RepairOrder.Description proxydescription in proxymisc.Descriptions)
                                                                            {
                                                                                Description description = new Description();
                                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                                misc.Descriptions.Add(description);
                                                                            }
                                                                        }
                                                                        #endregion

                                                                        #region//RepairOrder RequestItem OPCode MISCs PriceType
                                                                        if (proxymisc.PriceType != null)
                                                                        {
                                                                            PriceType pricetype = new PriceType();
                                                                            pricetype.DiscountPrice = proxymisc.PriceType.DiscountPrice;
                                                                            pricetype.DiscountRate = proxymisc.PriceType.DiscountRate;
                                                                            pricetype.TotalPrice = proxymisc.PriceType.TotalPrice;
                                                                            pricetype.TotalPriceIncludeTax = proxymisc.PriceType.TotalPriceIncludeTax;
                                                                            pricetype.UnitPrice = proxymisc.PriceType.UnitPrice;
                                                                            misc.PriceType = pricetype;
                                                                        }
                                                                        #endregion

                                                                        opcode.MISCs.Add(misc);
                                                                    }
                                                                }
                                                                #endregion

                                                                requestitem.OPCodes.Add(opcode);
                                                            }
                                                        }
                                                        #endregion

                                                        repairorder.RequestItems.Add(requestitem);
                                                    }
                                                }
                                                #endregion

                                                repairorderdocument.RepairOrders.Add(repairorder);
                                            }
                                        }
                                        response.RepairOrderDocuments.Add(repairorderdocument);
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

        public RepairOrderChangeResponse RepairOrderChange(RepairOrderChangeRequest request)
        {
            RepairOrderChangeResponse response = new RepairOrderChangeResponse();

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

                        #region RepairOrderChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.RepairOrder.RepairOrder proxyws = new _WA.Mapper.v2.RepairOrder.RepairOrder(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with repairorderchange and transaction
                        _WA.Mapper.v2.RepairOrder.RepairOrderChangeRequest proxyrequest = new _WA.Mapper.v2.RepairOrder.RepairOrderChangeRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.RepairOrder.TransactionHeader2 proxytransactionheader = new _WA.Mapper.v2.RepairOrder.TransactionHeader2();
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

                        //Create proxy repairorderchange
                        _WA.Mapper.v2.RepairOrder.RepairOrderChange proxyrepairorderchange = new _WA.Mapper.v2.RepairOrder.RepairOrderChange();
                        if (request.RepairOrderChange != null)
                        {
                            #region//RepairOrder Header
                            proxyrepairorderchange.CloseDateTimeLocal = request.RepairOrderChange.CloseDateTimeLocal;
                            proxyrepairorderchange.DeliveryDateTimeLocal = request.RepairOrderChange.DeliveryDateTimeLocal;
                            proxyrepairorderchange.DMSROID = request.RepairOrderChange.DMSROID;
                            proxyrepairorderchange.DMSRONo = request.RepairOrderChange.DMSRONo;
                            proxyrepairorderchange.DMSROStatus = request.RepairOrderChange.DMSROStatus;
                            proxyrepairorderchange.HangTagColor = request.RepairOrderChange.HangTagColor;
                            proxyrepairorderchange.HangTagNo = request.RepairOrderChange.HangTagNo;
                            proxyrepairorderchange.HangTagNo = request.RepairOrderChange.HangTagNo;
                            proxyrepairorderchange.OpenDateTimeLocal = request.RepairOrderChange.OpenDateTimeLocal;
                            proxyrepairorderchange.OutMileage = request.RepairOrderChange.OutMileage;
                            proxyrepairorderchange.PaymentMethod = request.RepairOrderChange.PaymentMethod;
                            proxyrepairorderchange.ROChannel = request.RepairOrderChange.ROChannel;
                            proxyrepairorderchange.SAEmployeeID = request.RepairOrderChange.SAEmployeeID;
                            proxyrepairorderchange.SAEmployeeName = request.RepairOrderChange.SAEmployeeName;
                            proxyrepairorderchange.ServiceType = request.RepairOrderChange.ServiceType;
                            proxyrepairorderchange.TCEmployeeID = request.RepairOrderChange.TCEmployeeID;
                            proxyrepairorderchange.TCEmployeeName = request.RepairOrderChange.TCEmployeeName;
                            proxyrepairorderchange.WorkType = request.RepairOrderChange.WorkType;
                            #endregion

                            #region//RepairOrder AppointmentRef
                            if (request.RepairOrderChange.AppointmentRef != null)
                            {
                                _WA.Mapper.v2.RepairOrder.AppointmentRef1 proxyappointmentref = new _WA.Mapper.v2.RepairOrder.AppointmentRef1();
                                proxyappointmentref.DMSAppointmentNo = request.RepairOrderChange.AppointmentRef.DMSAppointmentNo;
                                proxyappointmentref.DMSAppointmentStatus = request.RepairOrderChange.AppointmentRef.DMSAppointmentStatus;
                                proxyrepairorderchange.AppointmentRef = proxyappointmentref;
                            }
                            #endregion

                            #region//RepairOrder CustomerParts
                            if (request.RepairOrderChange.CustomerParts != null && request.RepairOrderChange.CustomerParts.Count > 0)
                            {
                                int customerpartscnt = 0;
                                _WA.Mapper.v2.RepairOrder.CustomerPart1[] proxycustomerparts = new _WA.Mapper.v2.RepairOrder.CustomerPart1[request.RepairOrderChange.CustomerParts.Count];
                                foreach (CustomerPart customerpart in request.RepairOrderChange.CustomerParts)
                                {
                                    _WA.Mapper.v2.RepairOrder.CustomerPart1 proxycustomerpart = new _WA.Mapper.v2.RepairOrder.CustomerPart1();
                                    proxycustomerpart.Comment = customerpart.Comment;
                                    proxycustomerpart.PartDescription = customerpart.PartDescription;
                                    proxycustomerpart.PartNumber = customerpart.PartNumber;
                                    proxycustomerpart.Quantity = customerpart.Quantity;
                                    proxycustomerpart.UnitOfMeasure = customerpart.UnitOfMeasure;
                                    proxycustomerparts[customerpartscnt] = proxycustomerpart;
                                    customerpartscnt++;
                                }
                            }
                            #endregion

                            #region //RepairOrder AdditionalFields
                            if (request.RepairOrderChange.AdditionalFields != null && request.RepairOrderChange.AdditionalFields.Count > 0)
                            {
                                int additionalfieldscnt = 0;
                                _WA.Mapper.v2.RepairOrder.AdditionalField1[] proxyadditionalfields = new _WA.Mapper.v2.RepairOrder.AdditionalField1[request.RepairOrderChange.AdditionalFields.Count];
                                foreach (AdditionalField additionalfield in request.RepairOrderChange.AdditionalFields)
                                {
                                    _WA.Mapper.v2.RepairOrder.AdditionalField1 proxyadditionalfield = new _WA.Mapper.v2.RepairOrder.AdditionalField1();
                                    proxyadditionalfield.Name = additionalfield.AdditionalFieldName;
                                    proxyadditionalfield.Value = additionalfield.AdditionalFieldValue;
                                    proxyadditionalfields[additionalfieldscnt] = proxyadditionalfield;
                                    additionalfieldscnt++;
                                }
                                proxyrepairorderchange.AdditionalFields = proxyadditionalfields;
                            }
                            #endregion

                            #region//RepairOrder Options
                            if (request.RepairOrderChange.Options != null && request.RepairOrderChange.Options.Count > 0)
                            {
                                int optionscnt = 0;
                                _WA.Mapper.v2.RepairOrder.Option1[] proxyoptions = new _WA.Mapper.v2.RepairOrder.Option1[request.RepairOrderChange.Options.Count];
                                foreach (Option option in request.RepairOrderChange.Options)
                                {
                                    _WA.Mapper.v2.RepairOrder.Option1 proxyoption = new _WA.Mapper.v2.RepairOrder.Option1();
                                    proxyoption.Name = option.OptionName;
                                    proxyoption.Value = option.OptionValue;
                                    proxyoptions[optionscnt] = proxyoption;
                                    optionscnt++;
                                }
                                proxyrepairorderchange.Options = proxyoptions;
                            }
                            #endregion

                            #region//RepairOrder PriceType
                            if (request.RepairOrderChange.PriceType != null)
                            {
                                _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                proxypricetype.DiscountPrice = request.RepairOrderChange.PriceType.DiscountPrice;
                                proxypricetype.DiscountRate = request.RepairOrderChange.PriceType.DiscountRate;
                                proxypricetype.TotalPrice = request.RepairOrderChange.PriceType.TotalPrice;
                                proxypricetype.TotalPriceIncludeTax = request.RepairOrderChange.PriceType.TotalPriceIncludeTax;
                                proxypricetype.UnitPrice = request.RepairOrderChange.PriceType.UnitPrice;
                                proxyrepairorderchange.PriceType = proxypricetype;
                            }
                            #endregion

                            #region//RepairOrder Customers
                            if (request.RepairOrderChange.Customers != null && request.RepairOrderChange.Customers.Count > 0)
                            {
                                int customerscnt = 0;
                                _WA.Mapper.v2.RepairOrder.Customer2[] proxycustomers = new _WA.Mapper.v2.RepairOrder.Customer2[request.RepairOrderChange.Customers.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Customer.Customer customer in request.RepairOrderChange.Customers)
                                {
                                    #region//RepairOrder Customer Header
                                    _WA.Mapper.v2.RepairOrder.Customer2 proxycustomer = new _WA.Mapper.v2.RepairOrder.Customer2();
                                    proxycustomer.CardNo = customer.CardNo;
                                    proxycustomer.CustomerInfoType = customer.CustomerInfoType;
                                    proxycustomer.DMSCustomerNo = customer.DMSCustomerNo;
                                    proxycustomer.Email = customer.Email;
                                    proxycustomer.FirstName = customer.FirstName;
                                    proxycustomer.FullName = customer.FullName;
                                    proxycustomer.Gender = customer.Gender;
                                    proxycustomer.LastName = customer.LastName;
                                    proxycustomer.MiddleName = customer.MiddleName;
                                    proxycustomer.Salutation = customer.Salutation;
                                    #endregion

                                    #region//RepairOrder Customer Addresses
                                    if (customer.Addresses != null && customer.Addresses.Count > 0)
                                    {
                                        int addressescnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Address1[] proxyaddresses = new _WA.Mapper.v2.RepairOrder.Address1[customer.Addresses.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Address address in customer.Addresses)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Address1 proxyaddress = new _WA.Mapper.v2.RepairOrder.Address1();
                                            proxyaddress.Address11 = address.Address1;
                                            proxyaddress.Address2 = address.Address2;
                                            proxyaddress.AddressType = address.AddressType;
                                            proxyaddress.City = address.City;
                                            proxyaddress.Country = address.Country;
                                            proxyaddress.State = address.State;
                                            proxyaddress.ZipCode = address.ZipCode;
                                            proxyaddresses[addressescnt] = proxyaddress;
                                            addressescnt++;
                                        }
                                        proxycustomer.Addresses = proxyaddresses;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer Contacts
                                    if (customer.Contacts != null && customer.Contacts.Count > 0)
                                    {
                                        int contactscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Contact2[] proxycontacts = new _WA.Mapper.v2.RepairOrder.Contact2[customer.Contacts.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Contact contact in customer.Contacts)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Contact2 proxycontact = new _WA.Mapper.v2.RepairOrder.Contact2();
                                            proxycontact.ContactMethodYN = contact.ContactMethodYN;
                                            proxycontact.ContactType = contact.ContactType;
                                            proxycontact.ContactValue = contact.ContactValue;
                                            proxycontacts[contactscnt] = proxycontact;
                                            contactscnt++;
                                        }
                                        proxycustomer.Contacts = proxycontacts;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer SpecialMessage
                                    if (customer.SpecialMessage != null)
                                    {
                                        _WA.Mapper.v2.RepairOrder.SpecialMessage1 proxyspecialmessage = new _WA.Mapper.v2.RepairOrder.SpecialMessage1();
                                        proxyspecialmessage.Message = customer.SpecialMessage.Message;
                                        proxycustomer.SpecialMessage = proxyspecialmessage;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer CorporateInfos
                                    if (customer.CorporateInfos != null && customer.CorporateInfos.Count > 0)
                                    {
                                        int corporateinfoscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.CorporateInfo1[] proxycorporateinfos = new _WA.Mapper.v2.RepairOrder.CorporateInfo1[customer.CorporateInfos.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo in customer.CorporateInfos)
                                        {
                                            _WA.Mapper.v2.RepairOrder.CorporateInfo1 proxycorporateinfo = new _WA.Mapper.v2.RepairOrder.CorporateInfo1();
                                            proxycorporateinfo.Name = corporateinfo.CorporateInfoName;
                                            proxycorporateinfo.Value = corporateinfo.CorporateInfoValue;
                                            proxycorporateinfos[corporateinfoscnt] = proxycorporateinfo;
                                            corporateinfoscnt++;
                                        }
                                        proxycustomer.CorporateInfos = proxycorporateinfos;
                                    }
                                    #endregion

                                    proxycustomers[customerscnt] = proxycustomer;
                                }
                                proxyrepairorderchange.Customers = proxycustomers;
                            }
                            #endregion

                            #region//RepairOrder Vehicle
                            if (request.RepairOrderChange.Vehicle != null)
                            {
                                #region//RepairOrder Vehicle Header
                                _WA.Mapper.v2.RepairOrder.Vehicle2 proxyvehicle = new _WA.Mapper.v2.RepairOrder.Vehicle2();
                                proxyvehicle.Color = request.RepairOrderChange.Vehicle.Color;
                                proxyvehicle.Cylinders = request.RepairOrderChange.Vehicle.Cylinders;
                                proxyvehicle.DateDelivered = request.RepairOrderChange.Vehicle.DateDelivered;
                                proxyvehicle.DateInService = request.RepairOrderChange.Vehicle.DateInService;
                                proxyvehicle.DeclinedJob = request.RepairOrderChange.Vehicle.DeclinedJob;
                                proxyvehicle.DisplayDescription = request.RepairOrderChange.Vehicle.DisplayDescription;
                                proxyvehicle.DMSVehicleNo = request.RepairOrderChange.Vehicle.DMSVehicleNo;
                                proxyvehicle.EngineType = request.RepairOrderChange.Vehicle.EngineType;
                                proxyvehicle.ExtendedWarranty = request.RepairOrderChange.Vehicle.ExtendedWarranty;
                                proxyvehicle.FuelType = request.RepairOrderChange.Vehicle.FuelType;
                                proxyvehicle.FullModelName = request.RepairOrderChange.Vehicle.FullModelName;
                                proxyvehicle.InsuranceDate = request.RepairOrderChange.Vehicle.InsuranceDate;
                                proxyvehicle.LastMileage = request.RepairOrderChange.Vehicle.LastMileage;
                                proxyvehicle.LastServiceDate = request.RepairOrderChange.Vehicle.LastServiceDate;
                                proxyvehicle.LastSixVIN = request.RepairOrderChange.Vehicle.LastSixVIN;
                                proxyvehicle.LicenseNumber = request.RepairOrderChange.Vehicle.LicenseNumber;
                                proxyvehicle.LicensePlateNo = request.RepairOrderChange.Vehicle.LicensePlateNo;
                                proxyvehicle.Make = request.RepairOrderChange.Vehicle.Make;
                                proxyvehicle.ModelCode = request.RepairOrderChange.Vehicle.ModelCode;
                                proxyvehicle.ModelName = request.RepairOrderChange.Vehicle.ModelName;
                                proxyvehicle.ModelYear = request.RepairOrderChange.Vehicle.ModelYear;
                                proxyvehicle.PendingJob = request.RepairOrderChange.Vehicle.PendingJob;
                                proxyvehicle.StockNumber = request.RepairOrderChange.Vehicle.StockNumber;
                                proxyvehicle.Trim = request.RepairOrderChange.Vehicle.Trim;
                                proxyvehicle.VehicleType = request.RepairOrderChange.Vehicle.VehicleType;
                                proxyvehicle.VIN = request.RepairOrderChange.Vehicle.VIN;
                                proxyvehicle.WarrantyMiles = request.RepairOrderChange.Vehicle.WarrantyMiles;
                                proxyvehicle.WarrantyMonths = request.RepairOrderChange.Vehicle.WarrantyMonths;
                                proxyvehicle.WarrantyStartDate = request.RepairOrderChange.Vehicle.WarrantyStartDate;
                                #endregion

                                #region//RepairOrder Vehicle Campaigns
                                if (request.RepairOrderChange.Vehicle.Campaigns != null && request.RepairOrderChange.Vehicle.Campaigns.Count > 0)
                                {
                                    int campaignscnt = 0;
                                    _WA.Mapper.v2.RepairOrder.Campaign1[] proxycampaigns = new _WA.Mapper.v2.RepairOrder.Campaign1[request.RepairOrderChange.Vehicle.Campaigns.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Vehicle.Campaign campaign in request.RepairOrderChange.Vehicle.Campaigns)
                                    {
                                        _WA.Mapper.v2.RepairOrder.Campaign1 proxycampaign = new _WA.Mapper.v2.RepairOrder.Campaign1();
                                        proxycampaign.CampaignDescription = campaign.CampaignDescription;
                                        proxycampaign.CampaignID = campaign.CampaignID;
                                        proxycampaign.CampaignPerformed = campaign.CampaignPerformed;
                                        proxycampaigns[campaignscnt] = proxycampaign;
                                        campaignscnt++;
                                    }
                                    proxyvehicle.Campaigns = proxycampaigns;
                                }
                                #endregion

                                proxyrepairorderchange.Vehicle = proxyvehicle;
                            }
                            #endregion

                            #region//RepairOrder RequestItems
                            if (request.RepairOrderChange.RequestItems != null && request.RepairOrderChange.RequestItems.Count > 0)
                            {
                                int requestitemscnt = 0;
                                _WA.Mapper.v2.RepairOrder.RequestItem1[] proxyrequestitems = new _WA.Mapper.v2.RepairOrder.RequestItem1[request.RepairOrderChange.RequestItems.Count];
                                foreach (RequestItem requestitem in request.RepairOrderChange.RequestItems)
                                {
                                    #region//RepairOrder RequestItem Header
                                    _WA.Mapper.v2.RepairOrder.RequestItem1 proxyrequestitem = new _WA.Mapper.v2.RepairOrder.RequestItem1();
                                    proxyrequestitem.CPSIND = requestitem.CPSIND;
                                    proxyrequestitem.RequestCode = requestitem.RequestCode;
                                    proxyrequestitem.RequestDescription = requestitem.RequestDescription;
                                    proxyrequestitem.ServiceLineNumber = requestitem.ServiceLineNumber;
                                    proxyrequestitem.ServiceLineStatus = requestitem.ServiceLineStatus;
                                    proxyrequestitem.ServiceType = requestitem.ServiceType;
                                    proxyrequestitem.TCEmployeeID = requestitem.TCEmployeeID;
                                    proxyrequestitem.TCEmployeeName = requestitem.TCEmployeeName;
                                    proxyrequestitem.WorkType = requestitem.WorkType;
                                    #endregion

                                    #region//RepairOrder RequestItem Comments
                                    if (requestitem.Comments != null && requestitem.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Comment1[] proxycomments = new _WA.Mapper.v2.RepairOrder.Comment1[requestitem.Comments.Count];
                                        foreach (Comment Comment in requestitem.Comments)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Comment1 proxycomment = new _WA.Mapper.v2.RepairOrder.Comment1();
                                            proxycomment.DescriptionComment = Comment.DescriptionComment;
                                            proxycomment.SequenceNumber = Comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyrequestitem.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//RepairOrder RequestItem Descriptions
                                    if (requestitem.Descriptions != null && requestitem.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[requestitem.Descriptions.Count];
                                        foreach (Description description in requestitem.Descriptions)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyrequestitem.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//RepairOrder RequestItem OPCodes
                                    if (requestitem.OPCodes != null && requestitem.OPCodes.Count > 0)
                                    {
                                        int opcodescnt = 0;
                                        _WA.Mapper.v2.RepairOrder.OPCode1[] proxyopcodes = new _WA.Mapper.v2.RepairOrder.OPCode1[requestitem.OPCodes.Count];
                                        foreach (OPCode opcode in requestitem.OPCodes)
                                        {
                                            #region//RepairOrder RequestItem OPCode Header
                                            _WA.Mapper.v2.RepairOrder.OPCode1 proxyopcode = new _WA.Mapper.v2.RepairOrder.OPCode1();
                                            proxyopcode.ActualHours = opcode.ActualHours;
                                            proxyopcode.Code = opcode.Code;
                                            proxyopcode.Description = opcode.Description;
                                            proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                            proxyopcode.SequenceNumber = opcode.SequenceNumber;
                                            proxyopcode.ServiceType = opcode.ServiceType;
                                            proxyopcode.SkillLevel = opcode.SkillLevel;
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Descriptions
                                            if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                            {
                                                int descriptionscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[opcode.Descriptions.Count];
                                                foreach (Description description in opcode.Descriptions)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                                    proxydescriptions[descriptionscnt] = proxydescription;
                                                    descriptionscnt++;
                                                }
                                                proxyopcode.Descriptions = proxydescriptions;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Causes
                                            if (opcode.Causes != null && opcode.Causes.Count > 0)
                                            {
                                                int causescnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Cause1[] proxycauses = new _WA.Mapper.v2.RepairOrder.Cause1[opcode.Causes.Count];
                                                foreach (Cause cause in opcode.Causes)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Cause1 proxycause = new _WA.Mapper.v2.RepairOrder.Cause1();
                                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                                    proxycause.Comment = cause.Comment;
                                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                                    proxycauses[causescnt] = proxycause;
                                                    causescnt++;
                                                }
                                                proxyopcode.Causes = proxycauses;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Corrections
                                            if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                            {
                                                int correctionscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Correction1[] proxycorrections = new _WA.Mapper.v2.RepairOrder.Correction1[opcode.Corrections.Count];
                                                foreach (Correction Correction in opcode.Corrections)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Correction1 proxycorrection = new _WA.Mapper.v2.RepairOrder.Correction1();
                                                    proxycorrection.CorrectionLaborOpCode = Correction.CorrectionLaborOpCode;
                                                    proxycorrection.Comment = Correction.Comment;
                                                    proxycorrection.SequenceNumber = Correction.SequenceNumber;
                                                    proxycorrections[correctionscnt] = proxycorrection;
                                                    correctionscnt++;
                                                }
                                                proxyopcode.Corrections = proxycorrections;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode PriceType
                                            if (opcode.PriceType != null)
                                            {
                                                _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                                proxyopcode.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Parts
                                            if (opcode.Parts != null && opcode.Parts.Count > 0)
                                            {
                                                int partscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Part1[] proxyparts = new _WA.Mapper.v2.RepairOrder.Part1[opcode.Parts.Count];
                                                foreach (Part part in opcode.Parts)
                                                {
                                                    #region//RepairOrder RequestItem OPCode Parts Header
                                                    _WA.Mapper.v2.RepairOrder.Part1 proxypart = new _WA.Mapper.v2.RepairOrder.Part1();
                                                    proxypart.DisplayPartNumber = part.DisplayPartNumber;
                                                    proxypart.PartDescription = part.PartDescription;
                                                    proxypart.PartNumber = part.PartNumber;
                                                    proxypart.PartType = part.PartType;
                                                    proxypart.Quantity = part.Quantity;
                                                    proxypart.SequenceNumber = part.SequenceNumber;
                                                    proxypart.ServiceType = part.ServiceType;
                                                    proxypart.StockQuantity = part.StockQuantity;
                                                    proxypart.StockStatus = part.StockStatus;
                                                    proxypart.UnitOfMeasure = part.UnitOfMeasure;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Parts Descriptions
                                                    if (part.Descriptions != null && part.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[part.Descriptions.Count];
                                                        foreach (Description description in part.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxypart.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Parts PriceType
                                                    if (part.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
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

                                            #region//RepairOrder RequestItem OPCode Sublets
                                            if (opcode.Sublets != null && opcode.Sublets.Count > 0)
                                            {
                                                int subletscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Sublet1[] proxysublets = new _WA.Mapper.v2.RepairOrder.Sublet1[opcode.Sublets.Count];
                                                foreach (Sublet sublet in opcode.Sublets)
                                                {
                                                    #region//RepairOrder RequestItem OPCode Sublets Header
                                                    _WA.Mapper.v2.RepairOrder.Sublet1 proxysublet = new _WA.Mapper.v2.RepairOrder.Sublet1();
                                                    proxysublet.SequenceNumber = sublet.SequenceNumber;
                                                    proxysublet.ServiceType = sublet.ServiceType;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                                    if (sublet.Descriptions != null && sublet.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[sublet.Descriptions.Count];
                                                        foreach (Description description in sublet.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxysublet.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Sublets PriceType
                                                    if (sublet.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                        proxypricetype.DiscountPrice = sublet.PriceType.DiscountPrice;
                                                        proxypricetype.DiscountRate = sublet.PriceType.DiscountRate;
                                                        proxypricetype.TotalPrice = sublet.PriceType.TotalPrice;
                                                        proxypricetype.TotalPriceIncludeTax = sublet.PriceType.TotalPriceIncludeTax;
                                                        proxypricetype.UnitPrice = sublet.PriceType.UnitPrice;
                                                        proxysublet.PriceType = proxypricetype;
                                                    }
                                                    #endregion

                                                    proxysublets[subletscnt] = proxysublet;
                                                    subletscnt++;
                                                }
                                                proxyopcode.Sublets = proxysublets;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode MISCs
                                            if (opcode.MISCs != null && opcode.MISCs.Count > 0)
                                            {
                                                int miscscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.MISC1[] proxymiscs = new _WA.Mapper.v2.RepairOrder.MISC1[opcode.MISCs.Count];
                                                foreach (MISC misc in opcode.MISCs)
                                                {
                                                    #region//RepairOrder RequestItem OPCode MISCs Header
                                                    _WA.Mapper.v2.RepairOrder.MISC1 proxymisc = new _WA.Mapper.v2.RepairOrder.MISC1();
                                                    proxymisc.SequenceNumber = misc.SequenceNumber;
                                                    proxymisc.ServiceType = misc.ServiceType;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                                    if (misc.Descriptions != null && misc.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[misc.Descriptions.Count];
                                                        foreach (Description description in misc.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxymisc.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode MISCs PriceType
                                                    if (misc.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                        proxypricetype.DiscountPrice = misc.PriceType.DiscountPrice;
                                                        proxypricetype.DiscountRate = misc.PriceType.DiscountRate;
                                                        proxypricetype.TotalPrice = misc.PriceType.TotalPrice;
                                                        proxypricetype.TotalPriceIncludeTax = misc.PriceType.TotalPriceIncludeTax;
                                                        proxypricetype.UnitPrice = misc.PriceType.UnitPrice;
                                                        proxymisc.PriceType = proxypricetype;
                                                    }
                                                    #endregion

                                                    proxymiscs[miscscnt] = proxymisc;
                                                    miscscnt++;
                                                }
                                                proxyopcode.MISCs = proxymiscs;
                                            }
                                            #endregion

                                            proxyopcodes[opcodescnt] = proxyopcode;
                                            opcodescnt++;
                                        }
                                        proxyrequestitem.OPCodes = proxyopcodes;
                                    }
                                    #endregion

                                    proxyrequestitems[requestitemscnt] = proxyrequestitem;
                                    requestitemscnt++;
                                }
                                proxyrepairorderchange.RequestItems = proxyrequestitems;
                            }
                            #endregion

                            proxyrequest.RepairOrderChange = proxyrepairorderchange;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.RepairOrder.RepairOrderChangeResponse proxyresponse = proxyws.RepairOrderChange(proxyrequest);

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
                                foreach (_WA.Mapper.v2.RepairOrder.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//RepairOrderChangeResponse Set

                                //if (proxyresponse.RepairOrder != null)
                                //{
                                //_WA.Mapper.v2.RepairOrder.RepairOrder2 proxyrepairorder = proxyresponse.RepairOrder;

                                //#region //RepairOrder Header
                                //RepairOrder repairorder = new RepairOrder();
                                //repairorder.CloseDateTimeLocal = proxyrepairorder.CloseDateTimeLocal;
                                //repairorder.DeliveryDateTimeLocal = proxyrepairorder.DeliveryDateTimeLocal;
                                //repairorder.DMSROID = proxyrepairorder.DMSROID;
                                //repairorder.DMSRONo = proxyrepairorder.DMSRONo;
                                //repairorder.DMSROStatus = proxyrepairorder.DMSROStatus;
                                //repairorder.HangTagColor = proxyrepairorder.HangTagColor;
                                //repairorder.HangTagNo = proxyrepairorder.HangTagNo;
                                //repairorder.InMileage = proxyrepairorder.InMileage;
                                //repairorder.OpenDateTimeLocal = proxyrepairorder.OpenDateTimeLocal;
                                //repairorder.OutMileage = proxyrepairorder.OutMileage;
                                //repairorder.PaymentMethod = proxyrepairorder.PaymentMethod;
                                //repairorder.ROChannel = proxyrepairorder.ROChannel;
                                //repairorder.SAEmployeeID = proxyrepairorder.SAEmployeeID;
                                //repairorder.SAEmployeeName = proxyrepairorder.SAEmployeeName;
                                //repairorder.ServiceType = proxyrepairorder.ServiceType;
                                //repairorder.TCEmployeeID = proxyrepairorder.TCEmployeeID;
                                //repairorder.TCEmployeeName = proxyrepairorder.TCEmployeeName;
                                //repairorder.WorkType = proxyrepairorder.WorkType;
                                //#endregion

                                //#region//RepairOrder CustomerParts
                                //if (proxyrepairorder.CustomerParts != null && proxyrepairorder.CustomerParts.Length > 0)
                                //{
                                //    repairorder.CustomerParts = new List<CustomerPart>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.CustomerPart2 proxycustomerpart in proxyrepairorder.CustomerParts)
                                //    {
                                //        CustomerPart customerpart = new CustomerPart();
                                //        customerpart.Comment = proxycustomerpart.Comment;
                                //        customerpart.PartDescription = proxycustomerpart.PartDescription;
                                //        customerpart.PartNumber = proxycustomerpart.PartNumber;
                                //        customerpart.Quantity = proxycustomerpart.Quantity;
                                //        customerpart.UnitOfMeasure = proxycustomerpart.UnitOfMeasure;
                                //        repairorder.CustomerParts.Add(customerpart);
                                //    }
                                //}
                                //#endregion

                                //#region //RepairOrder AdditionalFields
                                //if (proxyrepairorder.AdditionalFields != null && proxyrepairorder.AdditionalFields.Length > 0)
                                //{
                                //    repairorder.AdditionalFields = new List<AdditionalField>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.AdditionalField2 proxyadditionalfield in proxyrepairorder.AdditionalFields)
                                //    {
                                //        AdditionalField additionalfield = new AdditionalField();
                                //        additionalfield.Name = proxyadditionalfield.Name;
                                //        additionalfield.Value = proxyadditionalfield.Value;
                                //        repairorder.AdditionalFields.Add(additionalfield);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder JobRefs
                                //if (proxyrepairorder.JobRefs != null && proxyrepairorder.JobRefs.Length > 0)
                                //{
                                //    repairorder.JobRefs = new List<JobRef>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.JobRef2 proxyjobref in proxyrepairorder.JobRefs)
                                //    {
                                //        JobRef jobref = new JobRef();
                                //        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                //        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                //        repairorder.JobRefs.Add(jobref);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder ManagementFields
                                //if (proxyrepairorder.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyrepairorder.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyrepairorder.ManagementFields.LastModifiedDateTimeUTC;
                                //    repairorder.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//RepairOrder Options
                                //if (proxyrepairorder.Options != null && proxyrepairorder.Options.Length > 0)
                                //{
                                //    repairorder.Options = new List<Option>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.Option2 proxyoption in proxyrepairorder.Options)
                                //    {
                                //        Option option = new Option();
                                //        option.Name = proxyoption.Name;
                                //        option.Value = proxyoption.Value;
                                //        repairorder.Options.Add(option);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder PriceType
                                //if (proxyrepairorder.PriceType != null)
                                //{
                                //    PriceType pricetype = new PriceType();
                                //    pricetype.DiscountPrice = proxyrepairorder.PriceType.DiscountPrice;
                                //    pricetype.DiscountRate = proxyrepairorder.PriceType.DiscountRate;
                                //    pricetype.TotalPrice = proxyrepairorder.PriceType.TotalPrice;
                                //    pricetype.TotalPriceIncludeTax = proxyrepairorder.PriceType.TotalPriceIncludeTax;
                                //    pricetype.UnitPrice = proxyrepairorder.PriceType.UnitPrice;
                                //    repairorder.PriceType = pricetype;
                                //}
                                //#endregion

                                //#region//RepairOrder AppointmentRef
                                //if (proxyrepairorder.AppointmentRef != null)
                                //{
                                //    AppointmentRef appointmentref = new AppointmentRef();
                                //    appointmentref.DMSAppointmentNo = proxyrepairorder.AppointmentRef.DMSAppointmentNo;
                                //    appointmentref.DMSAppointmentStatus = proxyrepairorder.AppointmentRef.DMSAppointmentStatus;
                                //    repairorder.AppointmentRef = appointmentref;
                                //}
                                //#endregion

                                //#region//RepairOrder Customers
                                //if (proxyrepairorder.Customers != null && proxyrepairorder.Customers.Length > 0)
                                //{
                                //    repairorder.Customers = new List<Data.v2.Common.Customer.Customer>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.Customer3 proxycustomer in proxyrepairorder.Customers)
                                //    {
                                //        #region//RepairOrder Customer Header
                                //        WA.Standard.IF.Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                //        customer.CardNo = proxycustomer.CardNo;
                                //        customer.CorporateInfos = customer.CorporateInfos;
                                //        customer.CustomerInfoType = customer.CustomerInfoType;
                                //        customer.DMSCustomerNo = proxycustomer.DMSCustomerNo;
                                //        customer.Email = proxycustomer.Email;
                                //        customer.FirstName = proxycustomer.FirstName;
                                //        customer.FullName = proxycustomer.FullName;
                                //        customer.Gender = proxycustomer.Gender;
                                //        customer.LastName = proxycustomer.LastName;
                                //        customer.MiddleName = proxycustomer.MiddleName;
                                //        customer.Salutation = proxycustomer.Salutation;
                                //        #endregion

                                //        #region//RepairOrder Customer Addresses
                                //        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                //        {
                                //            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Address2 proxyaddress in proxycustomer.Addresses)
                                //            {
                                //                Data.v2.Common.Customer.Address address = new Data.v2.Common.Customer.Address();
                                //                address.Address1 = proxyaddress.Address1;
                                //                address.Address2 = proxyaddress.Address21;
                                //                address.AddressType = proxyaddress.AddressType;
                                //                address.City = proxyaddress.City;
                                //                address.Country = proxyaddress.Country;
                                //                address.State = proxyaddress.State;
                                //                address.ZipCode = proxyaddress.ZipCode;
                                //                customer.Addresses.Add(address);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer Contacts
                                //        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                //        {
                                //            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Contact3 proxycontact in proxycustomer.Contacts)
                                //            {
                                //                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                //                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                //                contact.ContactType = proxycontact.ContactType;
                                //                contact.ContactValue = proxycontact.ContactValue;
                                //                customer.Contacts.Add(contact);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer SpecialMessage
                                //        if (proxycustomer.SpecialMessage != null)
                                //        {
                                //            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                //            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                //            customer.SpecialMessage = specialmessage;
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer CorporateInfos
                                //        if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                //        {
                                //            customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.CorporateInfo2 proxycorporateinfo in proxycustomer.CorporateInfos)
                                //            {
                                //                Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                //                corporateinfo.Name = proxycorporateinfo.Name;
                                //                corporateinfo.Value = proxycorporateinfo.Value;
                                //                customer.CorporateInfos.Add(corporateinfo);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.Customers.Add(customer);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder Vehicle
                                //if (proxyrepairorder.Vehicle != null)
                                //{
                                //    if (proxyrepairorder.Vehicle != null)
                                //    {
                                //        #region//RepairOrder Vehicle Header
                                //        Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                //        vehicle.Color = proxyrepairorder.Vehicle.Color;
                                //        vehicle.Cylinders = proxyrepairorder.Vehicle.Cylinders;
                                //        vehicle.DateDelivered = proxyrepairorder.Vehicle.DateDelivered;
                                //        vehicle.DateInService = proxyrepairorder.Vehicle.DateInService;
                                //        vehicle.DeclinedJob = proxyrepairorder.Vehicle.DeclinedJob;
                                //        vehicle.DisplayDescription = proxyrepairorder.Vehicle.DisplayDescription;
                                //        vehicle.DMSVehicleNo = proxyrepairorder.Vehicle.DMSVehicleNo;
                                //        vehicle.EngineType = proxyrepairorder.Vehicle.EngineType;
                                //        vehicle.ExtendedWarranty = proxyrepairorder.Vehicle.ExtendedWarranty;
                                //        vehicle.FuelType = proxyrepairorder.Vehicle.FuelType;
                                //        vehicle.FullModelName = proxyrepairorder.Vehicle.FullModelName;
                                //        vehicle.InsuranceDate = proxyrepairorder.Vehicle.InsuranceDate;
                                //        vehicle.LastMileage = proxyrepairorder.Vehicle.LastMileage;
                                //        vehicle.LastServiceDate = proxyrepairorder.Vehicle.LastServiceDate;
                                //        vehicle.LastSixVIN = proxyrepairorder.Vehicle.LastSixVIN;
                                //        vehicle.LicenseNumber = proxyrepairorder.Vehicle.LicenseNumber;
                                //        vehicle.LicensePlateNo = proxyrepairorder.Vehicle.LicensePlateNo;
                                //        vehicle.Make = proxyrepairorder.Vehicle.Make;
                                //        vehicle.ModelCode = proxyrepairorder.Vehicle.ModelCode;
                                //        vehicle.ModelName = proxyrepairorder.Vehicle.ModelName;
                                //        vehicle.ModelYear = proxyrepairorder.Vehicle.ModelYear;
                                //        vehicle.PendingJob = proxyrepairorder.Vehicle.PendingJob;
                                //        vehicle.StockNumber = proxyrepairorder.Vehicle.StockNumber;
                                //        vehicle.Trim = proxyrepairorder.Vehicle.Trim;
                                //        vehicle.VehicleType = proxyrepairorder.Vehicle.VehicleType;
                                //        vehicle.VIN = proxyrepairorder.Vehicle.VIN;
                                //        vehicle.WarrantyMiles = proxyrepairorder.Vehicle.WarrantyMiles;
                                //        vehicle.WarrantyMonths = proxyrepairorder.Vehicle.WarrantyMonths;
                                //        vehicle.WarrantyStartDate = proxyrepairorder.Vehicle.WarrantyStartDate;
                                //        #endregion

                                //        #region//RepairOrder Vehicle Campaigns
                                //        if (proxyrepairorder.Vehicle.Campaigns != null && proxyrepairorder.Vehicle.Campaigns.Length > 0)
                                //        {
                                //            vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Campaign2 proxycampaign in proxyrepairorder.Vehicle.Campaigns)
                                //            {
                                //                Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                //                campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                //                campaign.CampaignID = proxycampaign.CampaignID;
                                //                campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                //                vehicle.Campaigns.Add(campaign);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.Vehicle = vehicle;
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder RequestItems
                                //if (proxyrepairorder.RequestItems != null && proxyrepairorder.RequestItems.Length > 0)
                                //{
                                //    repairorder.RequestItems = new List<RequestItem>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.RequestItem2 proxyrequestitem in proxyrepairorder.RequestItems)
                                //    {
                                //        #region//RepairOrder RequestItem Header
                                //        RequestItem requestitem = new RequestItem();
                                //        requestitem.CPSIND = proxyrequestitem.CPSIND;
                                //        requestitem.RequestCode = proxyrequestitem.RequestCode;
                                //        requestitem.RequestDescription = proxyrequestitem.RequestDescription;
                                //        requestitem.ServiceLineNumber = proxyrequestitem.ServiceLineNumber;
                                //        requestitem.ServiceLineStatus = proxyrequestitem.ServiceLineStatus;
                                //        requestitem.ServiceType = proxyrequestitem.ServiceType;
                                //        requestitem.TCEmployeeID = proxyrequestitem.TCEmployeeID;
                                //        requestitem.TCEmployeeName = proxyrequestitem.TCEmployeeName;
                                //        requestitem.WorkType = proxyrequestitem.WorkType;
                                //        #endregion

                                //        #region//RepairOrder RequestItem Comments
                                //        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                //        {
                                //            requestitem.Comments = new List<Comment>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Comment2 proxycomment in proxyrequestitem.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                requestitem.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder RequestItem Descriptions
                                //        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                //        {
                                //            requestitem.Descriptions = new List<Description>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxyrequestitem.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                requestitem.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder RequestItem OPCodes
                                //        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                //        {
                                //            requestitem.OPCodes = new List<OPCode>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.OPCode2 proxyopcode in proxyrequestitem.OPCodes)
                                //            {
                                //                #region//RepairOrder RequestItem OPCode Header
                                //                OPCode opcode = new OPCode();
                                //                opcode.ActualHours = proxyopcode.ActualHours;
                                //                opcode.Code = proxyopcode.Code;
                                //                opcode.Description = proxyopcode.Description;
                                //                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                //                opcode.ServiceType = proxyopcode.ServiceType;
                                //                opcode.SkillLevel = proxyopcode.SkillLevel;
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Descriptions
                                //                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //                {
                                //                    opcode.Descriptions = new List<Description>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxyopcode.Descriptions)
                                //                    {
                                //                        Description description = new Description();
                                //                        description.DescriptionComment = proxydescription.DescriptionComment;
                                //                        description.SequenceNumber = proxydescription.SequenceNumber;
                                //                        opcode.Descriptions.Add(description);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Causes
                                //                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //                {
                                //                    opcode.Causes = new List<Cause>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Cause2 proxycause in proxyopcode.Causes)
                                //                    {
                                //                        Cause cause = new Cause();
                                //                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                        cause.Comment = proxycause.Comment;
                                //                        cause.SequenceNumber = proxycause.SequenceNumber;
                                //                        opcode.Causes.Add(cause);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Corrections
                                //                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //                {
                                //                    opcode.Corrections = new List<Correction>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Correction2 proxycorrection in proxyopcode.Corrections)
                                //                    {
                                //                        Correction correction = new Correction();
                                //                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                        correction.Comment = proxycorrection.Comment;
                                //                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                        opcode.Corrections.Add(correction);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode PriceType
                                //                if (proxyopcode.PriceType != null)
                                //                {
                                //                    PriceType pricetype = new PriceType();
                                //                    pricetype.DiscountPrice = proxyopcode.PriceType.DiscountPrice;
                                //                    pricetype.DiscountRate = proxyopcode.PriceType.DiscountRate;
                                //                    pricetype.TotalPrice = proxyopcode.PriceType.TotalPrice;
                                //                    pricetype.TotalPriceIncludeTax = proxyopcode.PriceType.TotalPriceIncludeTax;
                                //                    pricetype.UnitPrice = proxyopcode.PriceType.UnitPrice;
                                //                    opcode.PriceType = pricetype;
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Parts
                                //                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                //                {
                                //                    opcode.Parts = new List<Part>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Part2 proxypart in proxyopcode.Parts)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode Parts Header
                                //                        Part part = new Part();
                                //                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                //                        part.PartDescription = proxypart.PartDescription;
                                //                        part.PartNumber = proxypart.PartNumber;
                                //                        part.PartType = proxypart.PartType;
                                //                        part.Quantity = proxypart.Quantity;
                                //                        part.SequenceNumber = proxypart.SequenceNumber;
                                //                        part.ServiceType = proxypart.ServiceType;
                                //                        part.StockQuantity = proxypart.StockQuantity;
                                //                        part.StockStatus = proxypart.StockStatus;
                                //                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Parts Descriptions
                                //                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                //                        {
                                //                            part.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxypart.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                part.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Parts PriceType
                                //                        if (proxypart.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxypart.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxypart.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxypart.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxypart.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxypart.PriceType.UnitPrice;
                                //                            part.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.Parts.Add(part);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Sublets
                                //                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                //                {
                                //                    opcode.Sublets = new List<Sublet>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Sublet2 proxysublet in proxyopcode.Sublets)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode Sublet Header
                                //                        Sublet sublet = new Sublet();
                                //                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                //                        sublet.ServiceType = proxysublet.ServiceType;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                //                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                //                        {
                                //                            sublet.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxysublet.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                sublet.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Sublets PriceType
                                //                        if (proxysublet.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxysublet.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxysublet.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxysublet.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxysublet.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxysublet.PriceType.UnitPrice;
                                //                            sublet.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.Sublets.Add(sublet);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode MISCs
                                //                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                //                {
                                //                    opcode.MISCs = new List<MISC>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.MISC2 proxymisc in proxyopcode.MISCs)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode MISC Header
                                //                        MISC misc = new MISC();
                                //                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                //                        misc.ServiceType = proxymisc.ServiceType;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                //                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                //                        {
                                //                            misc.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxymisc.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                misc.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode MISCs PriceType
                                //                        if (proxymisc.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxymisc.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxymisc.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxymisc.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxymisc.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxymisc.PriceType.UnitPrice;
                                //                            misc.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.MISCs.Add(misc);
                                //                    }
                                //                }
                                //                #endregion

                                //                requestitem.OPCodes.Add(opcode);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.RequestItems.Add(requestitem);
                                //    }
                                //}
                                //#endregion

                                //response.RepairOrder = repairorder;
                                //}
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
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region RepairOrderChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.RepairOrder.RepairOrder proxyws = new _WA.Mapper.v2.RepairOrder.RepairOrder(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with repairorderchange and transaction
                        _WA.Mapper.v2.RepairOrder.RepairOrderChangeRequest proxyrequest = new _WA.Mapper.v2.RepairOrder.RepairOrderChangeRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.RepairOrder.TransactionHeader2 proxytransactionheader = new _WA.Mapper.v2.RepairOrder.TransactionHeader2();
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

                        //Create proxy repairorderchange
                        _WA.Mapper.v2.RepairOrder.RepairOrderChange proxyrepairorderchange = new _WA.Mapper.v2.RepairOrder.RepairOrderChange();
                        if (request.RepairOrderChange != null)
                        {
                            #region//RepairOrder Header
                            proxyrepairorderchange.CloseDateTimeLocal = request.RepairOrderChange.CloseDateTimeLocal;
                            proxyrepairorderchange.DeliveryDateTimeLocal = request.RepairOrderChange.DeliveryDateTimeLocal;
                            proxyrepairorderchange.DMSROID = request.RepairOrderChange.DMSROID;
                            proxyrepairorderchange.DMSRONo = request.RepairOrderChange.DMSRONo;
                            proxyrepairorderchange.DMSROStatus = request.RepairOrderChange.DMSROStatus;
                            proxyrepairorderchange.HangTagColor = request.RepairOrderChange.HangTagColor;
                            proxyrepairorderchange.HangTagNo = request.RepairOrderChange.HangTagNo;
                            proxyrepairorderchange.HangTagNo = request.RepairOrderChange.HangTagNo;
                            proxyrepairorderchange.OpenDateTimeLocal = request.RepairOrderChange.OpenDateTimeLocal;
                            proxyrepairorderchange.OutMileage = request.RepairOrderChange.OutMileage;
                            proxyrepairorderchange.PaymentMethod = request.RepairOrderChange.PaymentMethod;
                            proxyrepairorderchange.ROChannel = request.RepairOrderChange.ROChannel;
                            proxyrepairorderchange.SAEmployeeID = request.RepairOrderChange.SAEmployeeID;
                            proxyrepairorderchange.SAEmployeeName = request.RepairOrderChange.SAEmployeeName;
                            proxyrepairorderchange.ServiceType = request.RepairOrderChange.ServiceType;
                            proxyrepairorderchange.TCEmployeeID = request.RepairOrderChange.TCEmployeeID;
                            proxyrepairorderchange.TCEmployeeName = request.RepairOrderChange.TCEmployeeName;
                            proxyrepairorderchange.WorkType = request.RepairOrderChange.WorkType;
                            #endregion

                            #region//RepairOrder AppointmentRef
                            if (request.RepairOrderChange.AppointmentRef != null)
                            {
                                _WA.Mapper.v2.RepairOrder.AppointmentRef1 proxyappointmentref = new _WA.Mapper.v2.RepairOrder.AppointmentRef1();
                                proxyappointmentref.DMSAppointmentNo = request.RepairOrderChange.AppointmentRef.DMSAppointmentNo;
                                proxyappointmentref.DMSAppointmentStatus = request.RepairOrderChange.AppointmentRef.DMSAppointmentStatus;
                                proxyrepairorderchange.AppointmentRef = proxyappointmentref;
                            }
                            #endregion

                            #region//RepairOrder CustomerParts
                            if (request.RepairOrderChange.CustomerParts != null && request.RepairOrderChange.CustomerParts.Count > 0)
                            {
                                int customerpartscnt = 0;
                                _WA.Mapper.v2.RepairOrder.CustomerPart1[] proxycustomerparts = new _WA.Mapper.v2.RepairOrder.CustomerPart1[request.RepairOrderChange.CustomerParts.Count];
                                foreach (CustomerPart customerpart in request.RepairOrderChange.CustomerParts)
                                {
                                    _WA.Mapper.v2.RepairOrder.CustomerPart1 proxycustomerpart = new _WA.Mapper.v2.RepairOrder.CustomerPart1();
                                    proxycustomerpart.Comment = customerpart.Comment;
                                    proxycustomerpart.PartDescription = customerpart.PartDescription;
                                    proxycustomerpart.PartNumber = customerpart.PartNumber;
                                    proxycustomerpart.Quantity = customerpart.Quantity;
                                    proxycustomerpart.UnitOfMeasure = customerpart.UnitOfMeasure;
                                    proxycustomerparts[customerpartscnt] = proxycustomerpart;
                                    customerpartscnt++;
                                }
                            }
                            #endregion

                            #region //RepairOrder AdditionalFields
                            if (request.RepairOrderChange.AdditionalFields != null && request.RepairOrderChange.AdditionalFields.Count > 0)
                            {
                                int additionalfieldscnt = 0;
                                _WA.Mapper.v2.RepairOrder.AdditionalField1[] proxyadditionalfields = new _WA.Mapper.v2.RepairOrder.AdditionalField1[request.RepairOrderChange.AdditionalFields.Count];
                                foreach (AdditionalField additionalfield in request.RepairOrderChange.AdditionalFields)
                                {
                                    _WA.Mapper.v2.RepairOrder.AdditionalField1 proxyadditionalfield = new _WA.Mapper.v2.RepairOrder.AdditionalField1();
                                    proxyadditionalfield.Name = additionalfield.AdditionalFieldName;
                                    proxyadditionalfield.Value = additionalfield.AdditionalFieldValue;
                                    proxyadditionalfields[additionalfieldscnt] = proxyadditionalfield;
                                    additionalfieldscnt++;
                                }
                                proxyrepairorderchange.AdditionalFields = proxyadditionalfields;
                            }
                            #endregion

                            #region//RepairOrder Options
                            if (request.RepairOrderChange.Options != null && request.RepairOrderChange.Options.Count > 0)
                            {
                                int optionscnt = 0;
                                _WA.Mapper.v2.RepairOrder.Option1[] proxyoptions = new _WA.Mapper.v2.RepairOrder.Option1[request.RepairOrderChange.Options.Count];
                                foreach (Option option in request.RepairOrderChange.Options)
                                {
                                    _WA.Mapper.v2.RepairOrder.Option1 proxyoption = new _WA.Mapper.v2.RepairOrder.Option1();
                                    proxyoption.Name = option.OptionName;
                                    proxyoption.Value = option.OptionValue;
                                    proxyoptions[optionscnt] = proxyoption;
                                    optionscnt++;
                                }
                                proxyrepairorderchange.Options = proxyoptions;
                            }
                            #endregion

                            #region//RepairOrder PriceType
                            if (request.RepairOrderChange.PriceType != null)
                            {
                                _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                proxypricetype.DiscountPrice = request.RepairOrderChange.PriceType.DiscountPrice;
                                proxypricetype.DiscountRate = request.RepairOrderChange.PriceType.DiscountRate;
                                proxypricetype.TotalPrice = request.RepairOrderChange.PriceType.TotalPrice;
                                proxypricetype.TotalPriceIncludeTax = request.RepairOrderChange.PriceType.TotalPriceIncludeTax;
                                proxypricetype.UnitPrice = request.RepairOrderChange.PriceType.UnitPrice;
                                proxyrepairorderchange.PriceType = proxypricetype;
                            }
                            #endregion

                            #region//RepairOrder Customers
                            if (request.RepairOrderChange.Customers != null && request.RepairOrderChange.Customers.Count > 0)
                            {
                                int customerscnt = 0;
                                _WA.Mapper.v2.RepairOrder.Customer2[] proxycustomers = new _WA.Mapper.v2.RepairOrder.Customer2[request.RepairOrderChange.Customers.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Customer.Customer customer in request.RepairOrderChange.Customers)
                                {
                                    #region//RepairOrder Customer Header
                                    _WA.Mapper.v2.RepairOrder.Customer2 proxycustomer = new _WA.Mapper.v2.RepairOrder.Customer2();
                                    proxycustomer.CardNo = customer.CardNo;
                                    proxycustomer.CustomerInfoType = customer.CustomerInfoType;
                                    proxycustomer.DMSCustomerNo = customer.DMSCustomerNo;
                                    proxycustomer.Email = customer.Email;
                                    proxycustomer.FirstName = customer.FirstName;
                                    proxycustomer.FullName = customer.FullName;
                                    proxycustomer.Gender = customer.Gender;
                                    proxycustomer.LastName = customer.LastName;
                                    proxycustomer.MiddleName = customer.MiddleName;
                                    proxycustomer.Salutation = customer.Salutation;
                                    #endregion

                                    #region//RepairOrder Customer Addresses
                                    if (customer.Addresses != null && customer.Addresses.Count > 0)
                                    {
                                        int addressescnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Address1[] proxyaddresses = new _WA.Mapper.v2.RepairOrder.Address1[customer.Addresses.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Address address in customer.Addresses)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Address1 proxyaddress = new _WA.Mapper.v2.RepairOrder.Address1();
                                            proxyaddress.Address11 = address.Address1;
                                            proxyaddress.Address2 = address.Address2;
                                            proxyaddress.AddressType = address.AddressType;
                                            proxyaddress.City = address.City;
                                            proxyaddress.Country = address.Country;
                                            proxyaddress.State = address.State;
                                            proxyaddress.ZipCode = address.ZipCode;
                                            proxyaddresses[addressescnt] = proxyaddress;
                                            addressescnt++;
                                        }
                                        proxycustomer.Addresses = proxyaddresses;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer Contacts
                                    if (customer.Contacts != null && customer.Contacts.Count > 0)
                                    {
                                        int contactscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Contact2[] proxycontacts = new _WA.Mapper.v2.RepairOrder.Contact2[customer.Contacts.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Contact contact in customer.Contacts)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Contact2 proxycontact = new _WA.Mapper.v2.RepairOrder.Contact2();
                                            proxycontact.ContactMethodYN = contact.ContactMethodYN;
                                            proxycontact.ContactType = contact.ContactType;
                                            proxycontact.ContactValue = contact.ContactValue;
                                            proxycontacts[contactscnt] = proxycontact;
                                            contactscnt++;
                                        }
                                        proxycustomer.Contacts = proxycontacts;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer SpecialMessage
                                    if (customer.SpecialMessage != null)
                                    {
                                        _WA.Mapper.v2.RepairOrder.SpecialMessage1 proxyspecialmessage = new _WA.Mapper.v2.RepairOrder.SpecialMessage1();
                                        proxyspecialmessage.Message = customer.SpecialMessage.Message;
                                        proxycustomer.SpecialMessage = proxyspecialmessage;
                                    }
                                    #endregion

                                    #region//RepairOrder Customer CorporateInfos
                                    if (customer.CorporateInfos != null && customer.CorporateInfos.Count > 0)
                                    {
                                        int corporateinfoscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.CorporateInfo1[] proxycorporateinfos = new _WA.Mapper.v2.RepairOrder.CorporateInfo1[customer.CorporateInfos.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo in customer.CorporateInfos)
                                        {
                                            _WA.Mapper.v2.RepairOrder.CorporateInfo1 proxycorporateinfo = new _WA.Mapper.v2.RepairOrder.CorporateInfo1();
                                            proxycorporateinfo.Name = corporateinfo.CorporateInfoName;
                                            proxycorporateinfo.Value = corporateinfo.CorporateInfoValue;
                                            proxycorporateinfos[corporateinfoscnt] = proxycorporateinfo;
                                            corporateinfoscnt++;
                                        }
                                        proxycustomer.CorporateInfos = proxycorporateinfos;
                                    }
                                    #endregion

                                    proxycustomers[customerscnt] = proxycustomer;
                                }
                                proxyrepairorderchange.Customers = proxycustomers;
                            }
                            #endregion

                            #region//RepairOrder Vehicle
                            if (request.RepairOrderChange.Vehicle != null)
                            {
                                #region//RepairOrder Vehicle Header
                                _WA.Mapper.v2.RepairOrder.Vehicle2 proxyvehicle = new _WA.Mapper.v2.RepairOrder.Vehicle2();
                                proxyvehicle.Color = request.RepairOrderChange.Vehicle.Color;
                                proxyvehicle.Cylinders = request.RepairOrderChange.Vehicle.Cylinders;
                                proxyvehicle.DateDelivered = request.RepairOrderChange.Vehicle.DateDelivered;
                                proxyvehicle.DateInService = request.RepairOrderChange.Vehicle.DateInService;
                                proxyvehicle.DeclinedJob = request.RepairOrderChange.Vehicle.DeclinedJob;
                                proxyvehicle.DisplayDescription = request.RepairOrderChange.Vehicle.DisplayDescription;
                                proxyvehicle.DMSVehicleNo = request.RepairOrderChange.Vehicle.DMSVehicleNo;
                                proxyvehicle.EngineType = request.RepairOrderChange.Vehicle.EngineType;
                                proxyvehicle.ExtendedWarranty = request.RepairOrderChange.Vehicle.ExtendedWarranty;
                                proxyvehicle.FuelType = request.RepairOrderChange.Vehicle.FuelType;
                                proxyvehicle.FullModelName = request.RepairOrderChange.Vehicle.FullModelName;
                                proxyvehicle.InsuranceDate = request.RepairOrderChange.Vehicle.InsuranceDate;
                                proxyvehicle.LastMileage = request.RepairOrderChange.Vehicle.LastMileage;
                                proxyvehicle.LastServiceDate = request.RepairOrderChange.Vehicle.LastServiceDate;
                                proxyvehicle.LastSixVIN = request.RepairOrderChange.Vehicle.LastSixVIN;
                                proxyvehicle.LicenseNumber = request.RepairOrderChange.Vehicle.LicenseNumber;
                                proxyvehicle.LicensePlateNo = request.RepairOrderChange.Vehicle.LicensePlateNo;
                                proxyvehicle.Make = request.RepairOrderChange.Vehicle.Make;
                                proxyvehicle.ModelCode = request.RepairOrderChange.Vehicle.ModelCode;
                                proxyvehicle.ModelName = request.RepairOrderChange.Vehicle.ModelName;
                                proxyvehicle.ModelYear = request.RepairOrderChange.Vehicle.ModelYear;
                                proxyvehicle.PendingJob = request.RepairOrderChange.Vehicle.PendingJob;
                                proxyvehicle.StockNumber = request.RepairOrderChange.Vehicle.StockNumber;
                                proxyvehicle.Trim = request.RepairOrderChange.Vehicle.Trim;
                                proxyvehicle.VehicleType = request.RepairOrderChange.Vehicle.VehicleType;
                                proxyvehicle.VIN = request.RepairOrderChange.Vehicle.VIN;
                                proxyvehicle.WarrantyMiles = request.RepairOrderChange.Vehicle.WarrantyMiles;
                                proxyvehicle.WarrantyMonths = request.RepairOrderChange.Vehicle.WarrantyMonths;
                                proxyvehicle.WarrantyStartDate = request.RepairOrderChange.Vehicle.WarrantyStartDate;
                                #endregion

                                #region//RepairOrder Vehicle Campaigns
                                if (request.RepairOrderChange.Vehicle.Campaigns != null && request.RepairOrderChange.Vehicle.Campaigns.Count > 0)
                                {
                                    int campaignscnt = 0;
                                    _WA.Mapper.v2.RepairOrder.Campaign1[] proxycampaigns = new _WA.Mapper.v2.RepairOrder.Campaign1[request.RepairOrderChange.Vehicle.Campaigns.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Vehicle.Campaign campaign in request.RepairOrderChange.Vehicle.Campaigns)
                                    {
                                        _WA.Mapper.v2.RepairOrder.Campaign1 proxycampaign = new _WA.Mapper.v2.RepairOrder.Campaign1();
                                        proxycampaign.CampaignDescription = campaign.CampaignDescription;
                                        proxycampaign.CampaignID = campaign.CampaignID;
                                        proxycampaign.CampaignPerformed = campaign.CampaignPerformed;
                                        proxycampaigns[campaignscnt] = proxycampaign;
                                        campaignscnt++;
                                    }
                                    proxyvehicle.Campaigns = proxycampaigns;
                                }
                                #endregion

                                proxyrepairorderchange.Vehicle = proxyvehicle;
                            }
                            #endregion

                            #region//RepairOrder RequestItems
                            if (request.RepairOrderChange.RequestItems != null && request.RepairOrderChange.RequestItems.Count > 0)
                            {
                                int requestitemscnt = 0;
                                _WA.Mapper.v2.RepairOrder.RequestItem1[] proxyrequestitems = new _WA.Mapper.v2.RepairOrder.RequestItem1[request.RepairOrderChange.RequestItems.Count];
                                foreach (RequestItem requestitem in request.RepairOrderChange.RequestItems)
                                {
                                    #region//RepairOrder RequestItem Header
                                    _WA.Mapper.v2.RepairOrder.RequestItem1 proxyrequestitem = new _WA.Mapper.v2.RepairOrder.RequestItem1();
                                    proxyrequestitem.CPSIND = requestitem.CPSIND;
                                    proxyrequestitem.RequestCode = requestitem.RequestCode;
                                    proxyrequestitem.RequestDescription = requestitem.RequestDescription;
                                    proxyrequestitem.ServiceLineNumber = requestitem.ServiceLineNumber;
                                    proxyrequestitem.ServiceLineStatus = requestitem.ServiceLineStatus;
                                    proxyrequestitem.ServiceType = requestitem.ServiceType;
                                    proxyrequestitem.TCEmployeeID = requestitem.TCEmployeeID;
                                    proxyrequestitem.TCEmployeeName = requestitem.TCEmployeeName;
                                    proxyrequestitem.WorkType = requestitem.WorkType;
                                    #endregion

                                    #region//RepairOrder RequestItem Comments
                                    if (requestitem.Comments != null && requestitem.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Comment1[] proxycomments = new _WA.Mapper.v2.RepairOrder.Comment1[requestitem.Comments.Count];
                                        foreach (Comment Comment in requestitem.Comments)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Comment1 proxycomment = new _WA.Mapper.v2.RepairOrder.Comment1();
                                            proxycomment.DescriptionComment = Comment.DescriptionComment;
                                            proxycomment.SequenceNumber = Comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyrequestitem.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//RepairOrder RequestItem Descriptions
                                    if (requestitem.Descriptions != null && requestitem.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[requestitem.Descriptions.Count];
                                        foreach (Description description in requestitem.Descriptions)
                                        {
                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyrequestitem.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//RepairOrder RequestItem OPCodes
                                    if (requestitem.OPCodes != null && requestitem.OPCodes.Count > 0)
                                    {
                                        int opcodescnt = 0;
                                        _WA.Mapper.v2.RepairOrder.OPCode1[] proxyopcodes = new _WA.Mapper.v2.RepairOrder.OPCode1[requestitem.OPCodes.Count];
                                        foreach (OPCode opcode in requestitem.OPCodes)
                                        {
                                            #region//RepairOrder RequestItem OPCode Header
                                            _WA.Mapper.v2.RepairOrder.OPCode1 proxyopcode = new _WA.Mapper.v2.RepairOrder.OPCode1();
                                            proxyopcode.ActualHours = opcode.ActualHours;
                                            proxyopcode.Code = opcode.Code;
                                            proxyopcode.Description = opcode.Description;
                                            proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                            proxyopcode.SequenceNumber = opcode.SequenceNumber;
                                            proxyopcode.ServiceType = opcode.ServiceType;
                                            proxyopcode.SkillLevel = opcode.SkillLevel;
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Descriptions
                                            if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                            {
                                                int descriptionscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[opcode.Descriptions.Count];
                                                foreach (Description description in opcode.Descriptions)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                                    proxydescriptions[descriptionscnt] = proxydescription;
                                                    descriptionscnt++;
                                                }
                                                proxyopcode.Descriptions = proxydescriptions;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Causes
                                            if (opcode.Causes != null && opcode.Causes.Count > 0)
                                            {
                                                int causescnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Cause1[] proxycauses = new _WA.Mapper.v2.RepairOrder.Cause1[opcode.Causes.Count];
                                                foreach (Cause cause in opcode.Causes)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Cause1 proxycause = new _WA.Mapper.v2.RepairOrder.Cause1();
                                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                                    proxycause.Comment = cause.Comment;
                                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                                    proxycauses[causescnt] = proxycause;
                                                    causescnt++;
                                                }
                                                proxyopcode.Causes = proxycauses;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Corrections
                                            if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                            {
                                                int correctionscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Correction1[] proxycorrections = new _WA.Mapper.v2.RepairOrder.Correction1[opcode.Corrections.Count];
                                                foreach (Correction Correction in opcode.Corrections)
                                                {
                                                    _WA.Mapper.v2.RepairOrder.Correction1 proxycorrection = new _WA.Mapper.v2.RepairOrder.Correction1();
                                                    proxycorrection.CorrectionLaborOpCode = Correction.CorrectionLaborOpCode;
                                                    proxycorrection.Comment = Correction.Comment;
                                                    proxycorrection.SequenceNumber = Correction.SequenceNumber;
                                                    proxycorrections[correctionscnt] = proxycorrection;
                                                    correctionscnt++;
                                                }
                                                proxyopcode.Corrections = proxycorrections;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode PriceType
                                            if (opcode.PriceType != null)
                                            {
                                                _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                                proxyopcode.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode Parts
                                            if (opcode.Parts != null && opcode.Parts.Count > 0)
                                            {
                                                int partscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Part1[] proxyparts = new _WA.Mapper.v2.RepairOrder.Part1[opcode.Parts.Count];
                                                foreach (Part part in opcode.Parts)
                                                {
                                                    #region//RepairOrder RequestItem OPCode Parts Header
                                                    _WA.Mapper.v2.RepairOrder.Part1 proxypart = new _WA.Mapper.v2.RepairOrder.Part1();
                                                    proxypart.DisplayPartNumber = part.DisplayPartNumber;
                                                    proxypart.PartDescription = part.PartDescription;
                                                    proxypart.PartNumber = part.PartNumber;
                                                    proxypart.PartType = part.PartType;
                                                    proxypart.Quantity = part.Quantity;
                                                    proxypart.SequenceNumber = part.SequenceNumber;
                                                    proxypart.ServiceType = part.ServiceType;
                                                    proxypart.StockQuantity = part.StockQuantity;
                                                    proxypart.StockStatus = part.StockStatus;
                                                    proxypart.UnitOfMeasure = part.UnitOfMeasure;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Parts Descriptions
                                                    if (part.Descriptions != null && part.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[part.Descriptions.Count];
                                                        foreach (Description description in part.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxypart.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Parts PriceType
                                                    if (part.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
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

                                            #region//RepairOrder RequestItem OPCode Sublets
                                            if (opcode.Sublets != null && opcode.Sublets.Count > 0)
                                            {
                                                int subletscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.Sublet1[] proxysublets = new _WA.Mapper.v2.RepairOrder.Sublet1[opcode.Sublets.Count];
                                                foreach (Sublet sublet in opcode.Sublets)
                                                {
                                                    #region//RepairOrder RequestItem OPCode Sublets Header
                                                    _WA.Mapper.v2.RepairOrder.Sublet1 proxysublet = new _WA.Mapper.v2.RepairOrder.Sublet1();
                                                    proxysublet.SequenceNumber = sublet.SequenceNumber;
                                                    proxysublet.ServiceType = sublet.ServiceType;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                                    if (sublet.Descriptions != null && sublet.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[sublet.Descriptions.Count];
                                                        foreach (Description description in sublet.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxysublet.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode Sublets PriceType
                                                    if (sublet.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                        proxypricetype.DiscountPrice = sublet.PriceType.DiscountPrice;
                                                        proxypricetype.DiscountRate = sublet.PriceType.DiscountRate;
                                                        proxypricetype.TotalPrice = sublet.PriceType.TotalPrice;
                                                        proxypricetype.TotalPriceIncludeTax = sublet.PriceType.TotalPriceIncludeTax;
                                                        proxypricetype.UnitPrice = sublet.PriceType.UnitPrice;
                                                        proxysublet.PriceType = proxypricetype;
                                                    }
                                                    #endregion

                                                    proxysublets[subletscnt] = proxysublet;
                                                    subletscnt++;
                                                }
                                                proxyopcode.Sublets = proxysublets;
                                            }
                                            #endregion

                                            #region//RepairOrder RequestItem OPCode MISCs
                                            if (opcode.MISCs != null && opcode.MISCs.Count > 0)
                                            {
                                                int miscscnt = 0;
                                                _WA.Mapper.v2.RepairOrder.MISC1[] proxymiscs = new _WA.Mapper.v2.RepairOrder.MISC1[opcode.MISCs.Count];
                                                foreach (MISC misc in opcode.MISCs)
                                                {
                                                    #region//RepairOrder RequestItem OPCode MISCs Header
                                                    _WA.Mapper.v2.RepairOrder.MISC1 proxymisc = new _WA.Mapper.v2.RepairOrder.MISC1();
                                                    proxymisc.SequenceNumber = misc.SequenceNumber;
                                                    proxymisc.ServiceType = misc.ServiceType;
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                                    if (misc.Descriptions != null && misc.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.RepairOrder.Description1[] proxydescriptions = new _WA.Mapper.v2.RepairOrder.Description1[misc.Descriptions.Count];
                                                        foreach (Description description in misc.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.RepairOrder.Description1 proxydescription = new _WA.Mapper.v2.RepairOrder.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxymisc.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//RepairOrder RequestItem OPCode MISCs PriceType
                                                    if (misc.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.RepairOrder.PriceType1 proxypricetype = new _WA.Mapper.v2.RepairOrder.PriceType1();
                                                        proxypricetype.DiscountPrice = misc.PriceType.DiscountPrice;
                                                        proxypricetype.DiscountRate = misc.PriceType.DiscountRate;
                                                        proxypricetype.TotalPrice = misc.PriceType.TotalPrice;
                                                        proxypricetype.TotalPriceIncludeTax = misc.PriceType.TotalPriceIncludeTax;
                                                        proxypricetype.UnitPrice = misc.PriceType.UnitPrice;
                                                        proxymisc.PriceType = proxypricetype;
                                                    }
                                                    #endregion

                                                    proxymiscs[miscscnt] = proxymisc;
                                                    miscscnt++;
                                                }
                                                proxyopcode.MISCs = proxymiscs;
                                            }
                                            #endregion

                                            proxyopcodes[opcodescnt] = proxyopcode;
                                            opcodescnt++;
                                        }
                                        proxyrequestitem.OPCodes = proxyopcodes;
                                    }
                                    #endregion

                                    proxyrequestitems[requestitemscnt] = proxyrequestitem;
                                    requestitemscnt++;
                                }
                                proxyrepairorderchange.RequestItems = proxyrequestitems;
                            }
                            #endregion

                            proxyrequest.RepairOrderChange = proxyrepairorderchange;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.RepairOrder.RepairOrderChangeResponse proxyresponse = proxyws.RepairOrderChange(proxyrequest);

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
                                foreach (_WA.Mapper.v2.RepairOrder.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//RepairOrderChangeResponse Set

                                //if (proxyresponse.RepairOrder != null)
                                //{
                                //_WA.Mapper.v2.RepairOrder.RepairOrder2 proxyrepairorder = proxyresponse.RepairOrder;

                                //#region //RepairOrder Header
                                //RepairOrder repairorder = new RepairOrder();
                                //repairorder.CloseDateTimeLocal = proxyrepairorder.CloseDateTimeLocal;
                                //repairorder.DeliveryDateTimeLocal = proxyrepairorder.DeliveryDateTimeLocal;
                                //repairorder.DMSROID = proxyrepairorder.DMSROID;
                                //repairorder.DMSRONo = proxyrepairorder.DMSRONo;
                                //repairorder.DMSROStatus = proxyrepairorder.DMSROStatus;
                                //repairorder.HangTagColor = proxyrepairorder.HangTagColor;
                                //repairorder.HangTagNo = proxyrepairorder.HangTagNo;
                                //repairorder.InMileage = proxyrepairorder.InMileage;
                                //repairorder.OpenDateTimeLocal = proxyrepairorder.OpenDateTimeLocal;
                                //repairorder.OutMileage = proxyrepairorder.OutMileage;
                                //repairorder.PaymentMethod = proxyrepairorder.PaymentMethod;
                                //repairorder.ROChannel = proxyrepairorder.ROChannel;
                                //repairorder.SAEmployeeID = proxyrepairorder.SAEmployeeID;
                                //repairorder.SAEmployeeName = proxyrepairorder.SAEmployeeName;
                                //repairorder.ServiceType = proxyrepairorder.ServiceType;
                                //repairorder.TCEmployeeID = proxyrepairorder.TCEmployeeID;
                                //repairorder.TCEmployeeName = proxyrepairorder.TCEmployeeName;
                                //repairorder.WorkType = proxyrepairorder.WorkType;
                                //#endregion

                                //#region//RepairOrder CustomerParts
                                //if (proxyrepairorder.CustomerParts != null && proxyrepairorder.CustomerParts.Length > 0)
                                //{
                                //    repairorder.CustomerParts = new List<CustomerPart>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.CustomerPart2 proxycustomerpart in proxyrepairorder.CustomerParts)
                                //    {
                                //        CustomerPart customerpart = new CustomerPart();
                                //        customerpart.Comment = proxycustomerpart.Comment;
                                //        customerpart.PartDescription = proxycustomerpart.PartDescription;
                                //        customerpart.PartNumber = proxycustomerpart.PartNumber;
                                //        customerpart.Quantity = proxycustomerpart.Quantity;
                                //        customerpart.UnitOfMeasure = proxycustomerpart.UnitOfMeasure;
                                //        repairorder.CustomerParts.Add(customerpart);
                                //    }
                                //}
                                //#endregion

                                //#region //RepairOrder AdditionalFields
                                //if (proxyrepairorder.AdditionalFields != null && proxyrepairorder.AdditionalFields.Length > 0)
                                //{
                                //    repairorder.AdditionalFields = new List<AdditionalField>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.AdditionalField2 proxyadditionalfield in proxyrepairorder.AdditionalFields)
                                //    {
                                //        AdditionalField additionalfield = new AdditionalField();
                                //        additionalfield.Name = proxyadditionalfield.Name;
                                //        additionalfield.Value = proxyadditionalfield.Value;
                                //        repairorder.AdditionalFields.Add(additionalfield);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder JobRefs
                                //if (proxyrepairorder.JobRefs != null && proxyrepairorder.JobRefs.Length > 0)
                                //{
                                //    repairorder.JobRefs = new List<JobRef>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.JobRef2 proxyjobref in proxyrepairorder.JobRefs)
                                //    {
                                //        JobRef jobref = new JobRef();
                                //        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                //        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                //        repairorder.JobRefs.Add(jobref);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder ManagementFields
                                //if (proxyrepairorder.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyrepairorder.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyrepairorder.ManagementFields.LastModifiedDateTimeUTC;
                                //    repairorder.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//RepairOrder Options
                                //if (proxyrepairorder.Options != null && proxyrepairorder.Options.Length > 0)
                                //{
                                //    repairorder.Options = new List<Option>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.Option2 proxyoption in proxyrepairorder.Options)
                                //    {
                                //        Option option = new Option();
                                //        option.Name = proxyoption.Name;
                                //        option.Value = proxyoption.Value;
                                //        repairorder.Options.Add(option);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder PriceType
                                //if (proxyrepairorder.PriceType != null)
                                //{
                                //    PriceType pricetype = new PriceType();
                                //    pricetype.DiscountPrice = proxyrepairorder.PriceType.DiscountPrice;
                                //    pricetype.DiscountRate = proxyrepairorder.PriceType.DiscountRate;
                                //    pricetype.TotalPrice = proxyrepairorder.PriceType.TotalPrice;
                                //    pricetype.TotalPriceIncludeTax = proxyrepairorder.PriceType.TotalPriceIncludeTax;
                                //    pricetype.UnitPrice = proxyrepairorder.PriceType.UnitPrice;
                                //    repairorder.PriceType = pricetype;
                                //}
                                //#endregion

                                //#region//RepairOrder AppointmentRef
                                //if (proxyrepairorder.AppointmentRef != null)
                                //{
                                //    AppointmentRef appointmentref = new AppointmentRef();
                                //    appointmentref.DMSAppointmentNo = proxyrepairorder.AppointmentRef.DMSAppointmentNo;
                                //    appointmentref.DMSAppointmentStatus = proxyrepairorder.AppointmentRef.DMSAppointmentStatus;
                                //    repairorder.AppointmentRef = appointmentref;
                                //}
                                //#endregion

                                //#region//RepairOrder Customers
                                //if (proxyrepairorder.Customers != null && proxyrepairorder.Customers.Length > 0)
                                //{
                                //    repairorder.Customers = new List<Data.v2.Common.Customer.Customer>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.Customer3 proxycustomer in proxyrepairorder.Customers)
                                //    {
                                //        #region//RepairOrder Customer Header
                                //        WA.Standard.IF.Data.v2.Common.Customer.Customer customer = new Data.v2.Common.Customer.Customer();
                                //        customer.CardNo = proxycustomer.CardNo;
                                //        customer.CorporateInfos = customer.CorporateInfos;
                                //        customer.CustomerInfoType = customer.CustomerInfoType;
                                //        customer.DMSCustomerNo = proxycustomer.DMSCustomerNo;
                                //        customer.Email = proxycustomer.Email;
                                //        customer.FirstName = proxycustomer.FirstName;
                                //        customer.FullName = proxycustomer.FullName;
                                //        customer.Gender = proxycustomer.Gender;
                                //        customer.LastName = proxycustomer.LastName;
                                //        customer.MiddleName = proxycustomer.MiddleName;
                                //        customer.Salutation = proxycustomer.Salutation;
                                //        #endregion

                                //        #region//RepairOrder Customer Addresses
                                //        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                //        {
                                //            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Address2 proxyaddress in proxycustomer.Addresses)
                                //            {
                                //                Data.v2.Common.Customer.Address address = new Data.v2.Common.Customer.Address();
                                //                address.Address1 = proxyaddress.Address1;
                                //                address.Address2 = proxyaddress.Address21;
                                //                address.AddressType = proxyaddress.AddressType;
                                //                address.City = proxyaddress.City;
                                //                address.Country = proxyaddress.Country;
                                //                address.State = proxyaddress.State;
                                //                address.ZipCode = proxyaddress.ZipCode;
                                //                customer.Addresses.Add(address);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer Contacts
                                //        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                //        {
                                //            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Contact3 proxycontact in proxycustomer.Contacts)
                                //            {
                                //                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                //                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                //                contact.ContactType = proxycontact.ContactType;
                                //                contact.ContactValue = proxycontact.ContactValue;
                                //                customer.Contacts.Add(contact);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer SpecialMessage
                                //        if (proxycustomer.SpecialMessage != null)
                                //        {
                                //            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                //            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                //            customer.SpecialMessage = specialmessage;
                                //        }
                                //        #endregion

                                //        #region//RepairOrder Customer CorporateInfos
                                //        if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                //        {
                                //            customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.CorporateInfo2 proxycorporateinfo in proxycustomer.CorporateInfos)
                                //            {
                                //                Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                //                corporateinfo.Name = proxycorporateinfo.Name;
                                //                corporateinfo.Value = proxycorporateinfo.Value;
                                //                customer.CorporateInfos.Add(corporateinfo);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.Customers.Add(customer);
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder Vehicle
                                //if (proxyrepairorder.Vehicle != null)
                                //{
                                //    if (proxyrepairorder.Vehicle != null)
                                //    {
                                //        #region//RepairOrder Vehicle Header
                                //        Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                //        vehicle.Color = proxyrepairorder.Vehicle.Color;
                                //        vehicle.Cylinders = proxyrepairorder.Vehicle.Cylinders;
                                //        vehicle.DateDelivered = proxyrepairorder.Vehicle.DateDelivered;
                                //        vehicle.DateInService = proxyrepairorder.Vehicle.DateInService;
                                //        vehicle.DeclinedJob = proxyrepairorder.Vehicle.DeclinedJob;
                                //        vehicle.DisplayDescription = proxyrepairorder.Vehicle.DisplayDescription;
                                //        vehicle.DMSVehicleNo = proxyrepairorder.Vehicle.DMSVehicleNo;
                                //        vehicle.EngineType = proxyrepairorder.Vehicle.EngineType;
                                //        vehicle.ExtendedWarranty = proxyrepairorder.Vehicle.ExtendedWarranty;
                                //        vehicle.FuelType = proxyrepairorder.Vehicle.FuelType;
                                //        vehicle.FullModelName = proxyrepairorder.Vehicle.FullModelName;
                                //        vehicle.InsuranceDate = proxyrepairorder.Vehicle.InsuranceDate;
                                //        vehicle.LastMileage = proxyrepairorder.Vehicle.LastMileage;
                                //        vehicle.LastServiceDate = proxyrepairorder.Vehicle.LastServiceDate;
                                //        vehicle.LastSixVIN = proxyrepairorder.Vehicle.LastSixVIN;
                                //        vehicle.LicenseNumber = proxyrepairorder.Vehicle.LicenseNumber;
                                //        vehicle.LicensePlateNo = proxyrepairorder.Vehicle.LicensePlateNo;
                                //        vehicle.Make = proxyrepairorder.Vehicle.Make;
                                //        vehicle.ModelCode = proxyrepairorder.Vehicle.ModelCode;
                                //        vehicle.ModelName = proxyrepairorder.Vehicle.ModelName;
                                //        vehicle.ModelYear = proxyrepairorder.Vehicle.ModelYear;
                                //        vehicle.PendingJob = proxyrepairorder.Vehicle.PendingJob;
                                //        vehicle.StockNumber = proxyrepairorder.Vehicle.StockNumber;
                                //        vehicle.Trim = proxyrepairorder.Vehicle.Trim;
                                //        vehicle.VehicleType = proxyrepairorder.Vehicle.VehicleType;
                                //        vehicle.VIN = proxyrepairorder.Vehicle.VIN;
                                //        vehicle.WarrantyMiles = proxyrepairorder.Vehicle.WarrantyMiles;
                                //        vehicle.WarrantyMonths = proxyrepairorder.Vehicle.WarrantyMonths;
                                //        vehicle.WarrantyStartDate = proxyrepairorder.Vehicle.WarrantyStartDate;
                                //        #endregion

                                //        #region//RepairOrder Vehicle Campaigns
                                //        if (proxyrepairorder.Vehicle.Campaigns != null && proxyrepairorder.Vehicle.Campaigns.Length > 0)
                                //        {
                                //            vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Campaign2 proxycampaign in proxyrepairorder.Vehicle.Campaigns)
                                //            {
                                //                Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                //                campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                //                campaign.CampaignID = proxycampaign.CampaignID;
                                //                campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                //                vehicle.Campaigns.Add(campaign);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.Vehicle = vehicle;
                                //    }
                                //}
                                //#endregion

                                //#region//RepairOrder RequestItems
                                //if (proxyrepairorder.RequestItems != null && proxyrepairorder.RequestItems.Length > 0)
                                //{
                                //    repairorder.RequestItems = new List<RequestItem>();
                                //    foreach (_WA.Mapper.v2.RepairOrder.RequestItem2 proxyrequestitem in proxyrepairorder.RequestItems)
                                //    {
                                //        #region//RepairOrder RequestItem Header
                                //        RequestItem requestitem = new RequestItem();
                                //        requestitem.CPSIND = proxyrequestitem.CPSIND;
                                //        requestitem.RequestCode = proxyrequestitem.RequestCode;
                                //        requestitem.RequestDescription = proxyrequestitem.RequestDescription;
                                //        requestitem.ServiceLineNumber = proxyrequestitem.ServiceLineNumber;
                                //        requestitem.ServiceLineStatus = proxyrequestitem.ServiceLineStatus;
                                //        requestitem.ServiceType = proxyrequestitem.ServiceType;
                                //        requestitem.TCEmployeeID = proxyrequestitem.TCEmployeeID;
                                //        requestitem.TCEmployeeName = proxyrequestitem.TCEmployeeName;
                                //        requestitem.WorkType = proxyrequestitem.WorkType;
                                //        #endregion

                                //        #region//RepairOrder RequestItem Comments
                                //        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                //        {
                                //            requestitem.Comments = new List<Comment>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Comment2 proxycomment in proxyrequestitem.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                requestitem.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder RequestItem Descriptions
                                //        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                //        {
                                //            requestitem.Descriptions = new List<Description>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxyrequestitem.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                requestitem.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//RepairOrder RequestItem OPCodes
                                //        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                //        {
                                //            requestitem.OPCodes = new List<OPCode>();
                                //            foreach (_WA.Mapper.v2.RepairOrder.OPCode2 proxyopcode in proxyrequestitem.OPCodes)
                                //            {
                                //                #region//RepairOrder RequestItem OPCode Header
                                //                OPCode opcode = new OPCode();
                                //                opcode.ActualHours = proxyopcode.ActualHours;
                                //                opcode.Code = proxyopcode.Code;
                                //                opcode.Description = proxyopcode.Description;
                                //                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                //                opcode.ServiceType = proxyopcode.ServiceType;
                                //                opcode.SkillLevel = proxyopcode.SkillLevel;
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Descriptions
                                //                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //                {
                                //                    opcode.Descriptions = new List<Description>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxyopcode.Descriptions)
                                //                    {
                                //                        Description description = new Description();
                                //                        description.DescriptionComment = proxydescription.DescriptionComment;
                                //                        description.SequenceNumber = proxydescription.SequenceNumber;
                                //                        opcode.Descriptions.Add(description);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Causes
                                //                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //                {
                                //                    opcode.Causes = new List<Cause>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Cause2 proxycause in proxyopcode.Causes)
                                //                    {
                                //                        Cause cause = new Cause();
                                //                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                        cause.Comment = proxycause.Comment;
                                //                        cause.SequenceNumber = proxycause.SequenceNumber;
                                //                        opcode.Causes.Add(cause);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Corrections
                                //                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //                {
                                //                    opcode.Corrections = new List<Correction>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Correction2 proxycorrection in proxyopcode.Corrections)
                                //                    {
                                //                        Correction correction = new Correction();
                                //                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                        correction.Comment = proxycorrection.Comment;
                                //                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                        opcode.Corrections.Add(correction);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode PriceType
                                //                if (proxyopcode.PriceType != null)
                                //                {
                                //                    PriceType pricetype = new PriceType();
                                //                    pricetype.DiscountPrice = proxyopcode.PriceType.DiscountPrice;
                                //                    pricetype.DiscountRate = proxyopcode.PriceType.DiscountRate;
                                //                    pricetype.TotalPrice = proxyopcode.PriceType.TotalPrice;
                                //                    pricetype.TotalPriceIncludeTax = proxyopcode.PriceType.TotalPriceIncludeTax;
                                //                    pricetype.UnitPrice = proxyopcode.PriceType.UnitPrice;
                                //                    opcode.PriceType = pricetype;
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Parts
                                //                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                //                {
                                //                    opcode.Parts = new List<Part>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Part2 proxypart in proxyopcode.Parts)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode Parts Header
                                //                        Part part = new Part();
                                //                        part.DisplayPartNumber = proxypart.DisplayPartNumber;
                                //                        part.PartDescription = proxypart.PartDescription;
                                //                        part.PartNumber = proxypart.PartNumber;
                                //                        part.PartType = proxypart.PartType;
                                //                        part.Quantity = proxypart.Quantity;
                                //                        part.SequenceNumber = proxypart.SequenceNumber;
                                //                        part.ServiceType = proxypart.ServiceType;
                                //                        part.StockQuantity = proxypart.StockQuantity;
                                //                        part.StockStatus = proxypart.StockStatus;
                                //                        part.UnitOfMeasure = proxypart.UnitOfMeasure;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Parts Descriptions
                                //                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                //                        {
                                //                            part.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxypart.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                part.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Parts PriceType
                                //                        if (proxypart.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxypart.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxypart.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxypart.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxypart.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxypart.PriceType.UnitPrice;
                                //                            part.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.Parts.Add(part);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode Sublets
                                //                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                //                {
                                //                    opcode.Sublets = new List<Sublet>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.Sublet2 proxysublet in proxyopcode.Sublets)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode Sublet Header
                                //                        Sublet sublet = new Sublet();
                                //                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                //                        sublet.ServiceType = proxysublet.ServiceType;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Sublets Descriptions
                                //                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                //                        {
                                //                            sublet.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxysublet.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                sublet.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode Sublets PriceType
                                //                        if (proxysublet.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxysublet.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxysublet.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxysublet.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxysublet.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxysublet.PriceType.UnitPrice;
                                //                            sublet.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.Sublets.Add(sublet);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//RepairOrder RequestItem OPCode MISCs
                                //                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                //                {
                                //                    opcode.MISCs = new List<MISC>();
                                //                    foreach (_WA.Mapper.v2.RepairOrder.MISC2 proxymisc in proxyopcode.MISCs)
                                //                    {
                                //                        #region//RepairOrder RequestItem OPCode MISC Header
                                //                        MISC misc = new MISC();
                                //                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                //                        misc.ServiceType = proxymisc.ServiceType;
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode MISCs Descriptions
                                //                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                //                        {
                                //                            misc.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.RepairOrder.Description2 proxydescription in proxymisc.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                misc.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//RepairOrder RequestItem OPCode MISCs PriceType
                                //                        if (proxymisc.PriceType != null)
                                //                        {
                                //                            PriceType pricetype = new PriceType();
                                //                            pricetype.DiscountPrice = proxymisc.PriceType.DiscountPrice;
                                //                            pricetype.DiscountRate = proxymisc.PriceType.DiscountRate;
                                //                            pricetype.TotalPrice = proxymisc.PriceType.TotalPrice;
                                //                            pricetype.TotalPriceIncludeTax = proxymisc.PriceType.TotalPriceIncludeTax;
                                //                            pricetype.UnitPrice = proxymisc.PriceType.UnitPrice;
                                //                            misc.PriceType = pricetype;
                                //                        }
                                //                        #endregion

                                //                        opcode.MISCs.Add(misc);
                                //                    }
                                //                }
                                //                #endregion

                                //                requestitem.OPCodes.Add(opcode);
                                //            }
                                //        }
                                //        #endregion

                                //        repairorder.RequestItems.Add(requestitem);
                                //    }
                                //}
                                //#endregion

                                //response.RepairOrder = repairorder;
                                //}
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
