using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Appointment;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class Appointment_Proxy : Base.BaseProxy
    {
        public AppointmentGetResponse AppointmentGet(AppointmentGetRequest request)
        {
            AppointmentGetResponse response = new AppointmentGetResponse();

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

                        #region AppointmentGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Appointment.Appointment proxyws = new _WA.Mapper.v2.Appointment.Appointment(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with appointmentget and transaction
                        _WA.Mapper.v2.Appointment.AppointmentGetRequest proxyrequest = new _WA.Mapper.v2.Appointment.AppointmentGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Appointment.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.Appointment.TransactionHeader();
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

                        //Create proxy appointmentget
                        _WA.Mapper.v2.Appointment.AppointmentGet proxyappointmentget = new _WA.Mapper.v2.Appointment.AppointmentGet();
                        if (request.AppointmentGet != null)
                        {
                            #region//AppointmentGet Set
                            proxyappointmentget.AppointmentDateTimeFromLocal = request.AppointmentGet.AppointmentDateTimeFromLocal;
                            proxyappointmentget.AppointmentDateTimeToLocal = request.AppointmentGet.AppointmentDateTimeFromLocal;
                            proxyappointmentget.DMSAppointmentID = request.AppointmentGet.DMSAppointmentID;
                            proxyappointmentget.DMSAppointmentNo = request.AppointmentGet.DMSAppointmentNo;
                            proxyappointmentget.DMSAppointmentStatus = request.AppointmentGet.DMSAppointmentStatus;
                            proxyappointmentget.LastModifiedDateTimeFromUTC = request.AppointmentGet.LastModifiedDateTimeFromUTC;
                            proxyappointmentget.LastModifiedDateTimeToUTC = request.AppointmentGet.LastModifiedDateTimeToUTC;
                            proxyappointmentget.SAEmployeeID = request.AppointmentGet.SAEmployeeID;
                            proxyappointmentget.SAEmployeeName = request.AppointmentGet.SAEmployeeName;
                            proxyappointmentget.TCEmployeeID = request.AppointmentGet.TCEmployeeID;
                            proxyappointmentget.TCEmployeeName = request.AppointmentGet.TCEmployeeName;
                            if (request.AppointmentGet.Customer != null)
                            {
                                _WA.Mapper.v2.Appointment.Customer proxycustomer = new _WA.Mapper.v2.Appointment.Customer();
                                proxycustomer.DMSCustomerNo = request.AppointmentGet.Customer.DMSCustomerNo;
                                proxycustomer.LastName = request.AppointmentGet.Customer.LastName;

                                if (request.AppointmentGet.Customer.Contacts != null && request.AppointmentGet.Customer.Contacts.Count > 0)
                                {
                                    int cnt = 0;
                                    proxycustomer.Contacts = new _WA.Mapper.v2.Appointment.Contact[request.AppointmentGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Appointment.Contact contact in request.AppointmentGet.Customer.Contacts)
                                    {
                                        _WA.Mapper.v2.Appointment.Contact proxycontact = new _WA.Mapper.v2.Appointment.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycustomer.Contacts[cnt] = proxycontact;
                                        cnt++;
                                    }
                                }
                                proxyappointmentget.Customer = proxycustomer;
                            }
                            proxyrequest.AppointmentGet = proxyappointmentget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Appointment.AppointmentGetResponse proxyresponse = proxyws.AppointmentGet(proxyrequest);

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
                                foreach (_WA.Mapper.v2.Appointment.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//AppointmentGetResponse Set

                                if (proxyresponse.Appointments != null && proxyresponse.Appointments.Length > 0)
                                {
                                    response.Appointments = new List<Appointment>();
                                    foreach (_WA.Mapper.v2.Appointment.Appointment1 proxyappointment in proxyresponse.Appointments)
                                    {
                                        #region //Appointment Header
                                        Appointment appointment = new Appointment();
                                        appointment.AppointmentDateTimeLocal = proxyappointment.AppointmentDateTimeLocal;
                                        appointment.CloseDateTimeLocal = proxyappointment.CloseDateTimeLocal;
                                        appointment.CustomerComment = proxyappointment.CustomerComment;
                                        appointment.DeliveryDateTimeLocal = proxyappointment.DeliveryDateTimeLocal;
                                        appointment.DMSAppointmentID = proxyappointment.DMSAppointmentID;
                                        appointment.DMSAppointmentNo = proxyappointment.DMSAppointmentNo;
                                        appointment.DMSAppointmentStatus = proxyappointment.DMSAppointmentStatus;
                                        appointment.InMileage = proxyappointment.InMileage;
                                        appointment.OpenDateTimeLocal = proxyappointment.OpenDateTimeLocal;
                                        appointment.PaymentMethod = proxyappointment.PaymentMethod;
                                        appointment.SAEmployeeID = proxyappointment.SAEmployeeID;
                                        appointment.SAEmployeeName = proxyappointment.SAEmployeeName;
                                        appointment.ServiceType = proxyappointment.ServiceType;
                                        appointment.TCEmployeeID = proxyappointment.TCEmployeeID;
                                        appointment.TCEmployeeName = proxyappointment.TCEmployeeName;
                                        appointment.WorkType = proxyappointment.WorkType;
                                        #endregion

                                        #region //Appointment AdditionalFields
                                        if (proxyappointment.AdditionalFields != null && proxyappointment.AdditionalFields.Length > 0)
                                        {
                                            appointment.AdditionalFields = new List<AdditionalField>();
                                            foreach (_WA.Mapper.v2.Appointment.AdditionalField proxyadditionalfield in proxyappointment.AdditionalFields)
                                            {
                                                AdditionalField additionalfield = new AdditionalField();
                                                additionalfield.AdditionalFieldName = proxyadditionalfield.Name;
                                                additionalfield.AdditionalFieldValue = proxyadditionalfield.Value;
                                                appointment.AdditionalFields.Add(additionalfield);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment JobRefs
                                        if (proxyappointment.JobRefs != null && proxyappointment.JobRefs.Length > 0)
                                        {
                                            appointment.JobRefs = new List<JobRef>();
                                            foreach (_WA.Mapper.v2.Appointment.JobRef proxyjobref in proxyappointment.JobRefs)
                                            {
                                                JobRef jobref = new JobRef();
                                                jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                                jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                                appointment.JobRefs.Add(jobref);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment ManagementFields
                                        if (proxyappointment.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.CreateDateTimeUTC = proxyappointment.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyappointment.ManagementFields.LastModifiedDateTimeUTC;
                                            appointment.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region//Appointment Options
                                        if (proxyappointment.Options != null && proxyappointment.Options.Length > 0)
                                        {
                                            appointment.Options = new List<Option>();
                                            foreach (_WA.Mapper.v2.Appointment.Option proxyoption in proxyappointment.Options)
                                            {
                                                Option option = new Option();
                                                option.OptionName = proxyoption.Name;
                                                option.OptionValue = proxyoption.Value;
                                                appointment.Options.Add(option);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment PriceType
                                        if (proxyappointment.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxyappointment.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxyappointment.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxyappointment.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxyappointment.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxyappointment.PriceType.UnitPrice;
                                            appointment.PriceType = pricetype;
                                        }
                                        #endregion

                                        #region//Appointment RORefs
                                        if (proxyappointment.RORefs != null && proxyappointment.RORefs.Length > 0)
                                        {
                                            appointment.RORefs = new List<RORef>();
                                            foreach (_WA.Mapper.v2.Appointment.RORef proxyroref in proxyappointment.RORefs)
                                            {
                                                RORef roref = new RORef();
                                                roref.DMSRONo = proxyroref.DMSRONo;
                                                roref.DMSROStatus = proxyroref.DMSROStatus;
                                                appointment.RORefs.Add(roref);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment Customers
                                        if (proxyappointment.Customers != null && proxyappointment.Customers.Length > 0)
                                        {
                                            appointment.Customers = new List<Data.v2.Common.Customer.Customer>();
                                            foreach (_WA.Mapper.v2.Appointment.Customer1 proxycustomer in proxyappointment.Customers)
                                            {
                                                #region//Appointment Customer Header
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

                                                #region//Appointment Customer Addresses
                                                if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                                {
                                                    customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                                    foreach (_WA.Mapper.v2.Appointment.Address proxyaddress in proxycustomer.Addresses)
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

                                                #region//Appointment Customer Contacts
                                                if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                                {
                                                    customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                                    foreach (_WA.Mapper.v2.Appointment.Contact1 proxycontact in proxycustomer.Contacts)
                                                    {
                                                        Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                                        contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                                        contact.ContactType = proxycontact.ContactType;
                                                        contact.ContactValue = proxycontact.ContactValue;
                                                        customer.Contacts.Add(contact);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment Customer SpecialMessage
                                                if (proxycustomer.SpecialMessage != null)
                                                {
                                                    Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                                    specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                                    customer.SpecialMessage = specialmessage;
                                                }
                                                #endregion

                                                #region//Appointment Customer CorporateInfos
                                                if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                                {
                                                    customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                                    foreach (_WA.Mapper.v2.Appointment.CorporateInfo proxycorporateinfo in proxycustomer.CorporateInfos)
                                                    {
                                                        Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                                        corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                        corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                        customer.CorporateInfos.Add(corporateinfo);
                                                    }
                                                }
                                                #endregion

                                                appointment.Customers.Add(customer);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment Vehicle
                                        if (proxyappointment.Vehicle != null)
                                        {
                                            if (proxyappointment.Vehicle != null)
                                            {
                                                #region//Appointment Vehicle Header
                                                Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                                vehicle.Color = proxyappointment.Vehicle.Color;
                                                vehicle.Cylinders = proxyappointment.Vehicle.Cylinders;
                                                vehicle.DateDelivered = proxyappointment.Vehicle.DateDelivered;
                                                vehicle.DateInService = proxyappointment.Vehicle.DateInService;
                                                vehicle.DeclinedJob = proxyappointment.Vehicle.DeclinedJob;
                                                vehicle.DisplayDescription = proxyappointment.Vehicle.DisplayDescription;
                                                vehicle.DMSVehicleNo = proxyappointment.Vehicle.DMSVehicleNo;
                                                vehicle.EngineType = proxyappointment.Vehicle.EngineType;
                                                vehicle.ExtendedWarranty = proxyappointment.Vehicle.ExtendedWarranty;
                                                vehicle.FuelType = proxyappointment.Vehicle.FuelType;
                                                vehicle.FullModelName = proxyappointment.Vehicle.FullModelName;
                                                vehicle.InsuranceDate = proxyappointment.Vehicle.InsuranceDate;
                                                vehicle.LastMileage = proxyappointment.Vehicle.LastMileage;
                                                vehicle.LastServiceDate = proxyappointment.Vehicle.LastServiceDate;
                                                vehicle.LastSixVIN = proxyappointment.Vehicle.LastSixVIN;
                                                vehicle.LicenseNumber = proxyappointment.Vehicle.LicenseNumber;
                                                vehicle.LicensePlateNo = proxyappointment.Vehicle.LicensePlateNo;
                                                vehicle.Make = proxyappointment.Vehicle.Make;
                                                vehicle.ModelCode = proxyappointment.Vehicle.ModelCode;
                                                vehicle.ModelName = proxyappointment.Vehicle.ModelName;
                                                vehicle.ModelYear = proxyappointment.Vehicle.ModelYear;
                                                vehicle.PendingJob = proxyappointment.Vehicle.PendingJob;
                                                vehicle.StockNumber = proxyappointment.Vehicle.StockNumber;
                                                vehicle.Trim = proxyappointment.Vehicle.Trim;
                                                vehicle.VehicleType = proxyappointment.Vehicle.VehicleType;
                                                vehicle.VIN = proxyappointment.Vehicle.VIN;
                                                vehicle.WarrantyMiles = proxyappointment.Vehicle.WarrantyMiles;
                                                vehicle.WarrantyMonths = proxyappointment.Vehicle.WarrantyMonths;
                                                vehicle.WarrantyStartDate = proxyappointment.Vehicle.WarrantyStartDate;
                                                #endregion

                                                #region//Appointment Vehicle Campaigns
                                                if (proxyappointment.Vehicle.Campaigns != null && proxyappointment.Vehicle.Campaigns.Length > 0)
                                                {
                                                    vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                    foreach (_WA.Mapper.v2.Appointment.Campaign proxycampaign in proxyappointment.Vehicle.Campaigns)
                                                    {
                                                        Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                        campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                        campaign.CampaignID = proxycampaign.CampaignID;
                                                        campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                        vehicle.Campaigns.Add(campaign);
                                                    }
                                                }
                                                #endregion

                                                appointment.Vehicle = vehicle;
                                            }
                                        }
                                        #endregion

                                        #region//Appointment RequestItems
                                        if (proxyappointment.RequestItems != null && proxyappointment.RequestItems.Length > 0)
                                        {
                                            appointment.RequestItems = new List<RequestItem>();
                                            foreach (_WA.Mapper.v2.Appointment.RequestItem proxyrequestitem in proxyappointment.RequestItems)
                                            {
                                                #region//Appointment RequestItem Header
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

                                                #region//Appointment RequestItem Comments
                                                if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                                {
                                                    requestitem.Comments = new List<Comment>();
                                                    foreach (_WA.Mapper.v2.Appointment.Comment proxycomment in proxyrequestitem.Comments)
                                                    {
                                                        Comment comment = new Comment();
                                                        comment.DescriptionComment = proxycomment.DescriptionComment;
                                                        comment.SequenceNumber = proxycomment.SequenceNumber;
                                                        requestitem.Comments.Add(comment);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment RequestItem Descriptions
                                                if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                                {
                                                    requestitem.Descriptions = new List<Description>();
                                                    foreach (_WA.Mapper.v2.Appointment.Description proxydescription in proxyrequestitem.Descriptions)
                                                    {
                                                        Description description = new Description();
                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                        requestitem.Descriptions.Add(description);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment RequestItem OPCodes
                                                if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                                {
                                                    requestitem.OPCodes = new List<OPCode>();
                                                    foreach (_WA.Mapper.v2.Appointment.OPCode proxyopcode in proxyrequestitem.OPCodes)
                                                    {
                                                        #region//Appointment RequestItem OPCode Header
                                                        OPCode opcode = new OPCode();
                                                        opcode.ActualHours = proxyopcode.ActualHours;
                                                        opcode.Code = proxyopcode.Code;
                                                        opcode.Description = proxyopcode.Description;
                                                        opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                        opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                                        opcode.ServiceType = proxyopcode.ServiceType;
                                                        opcode.SkillLevel = proxyopcode.SkillLevel;
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Descriptions
                                                        if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                        {
                                                            opcode.Descriptions = new List<Description>();
                                                            foreach (_WA.Mapper.v2.Appointment.Description proxydescription in proxyopcode.Descriptions)
                                                            {
                                                                Description description = new Description();
                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                opcode.Descriptions.Add(description);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Causes
                                                        if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                        {
                                                            opcode.Causes = new List<Cause>();
                                                            foreach (_WA.Mapper.v2.Appointment.Cause proxycause in proxyopcode.Causes)
                                                            {
                                                                Cause cause = new Cause();
                                                                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                                cause.Comment = proxycause.Comment;
                                                                cause.SequenceNumber = proxycause.SequenceNumber;
                                                                opcode.Causes.Add(cause);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Corrections
                                                        if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                        {
                                                            opcode.Corrections = new List<Correction>();
                                                            foreach (_WA.Mapper.v2.Appointment.Correction proxycorrection in proxyopcode.Corrections)
                                                            {
                                                                Correction correction = new Correction();
                                                                correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                                correction.Comment = proxycorrection.Comment;
                                                                correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                                opcode.Corrections.Add(correction);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode PriceType
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

                                                        #region//Appointment RequestItem OPCode Parts
                                                        if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                        {
                                                            opcode.Parts = new List<Part>();
                                                            foreach (_WA.Mapper.v2.Appointment.Part proxypart in proxyopcode.Parts)
                                                            {
                                                                #region//Appointment RequestItem OPCode Parts Header
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

                                                                #region//Appointment RequestItem OPCode Parts Descriptions
                                                                if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                                                {
                                                                    part.Descriptions = new List<Description>();
                                                                    foreach (_WA.Mapper.v2.Appointment.Description proxydescription in proxypart.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        part.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Parts PriceType
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

                                                        #region//Appointment RequestItem OPCode Sublets
                                                        if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                                        {
                                                            opcode.Sublets = new List<Sublet>();
                                                            foreach (_WA.Mapper.v2.Appointment.Sublet proxysublet in proxyopcode.Sublets)
                                                            {
                                                                #region//Appointment RequestItem OPCode Sublet Header
                                                                Sublet sublet = new Sublet();
                                                                sublet.SequenceNumber = proxysublet.SequenceNumber;
                                                                sublet.ServiceType = proxysublet.ServiceType;
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Sublets Descriptions
                                                                if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                                                {
                                                                    sublet.Descriptions = new List<Description>();
                                                                    foreach (_WA.Mapper.v2.Appointment.Description proxydescription in proxysublet.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        sublet.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Sublets PriceType
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

                                                        #region//Appointment RequestItem OPCode MISCs
                                                        if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                                        {
                                                            opcode.MISCs = new List<MISC>();
                                                            foreach (_WA.Mapper.v2.Appointment.MISC proxymisc in proxyopcode.MISCs)
                                                            {
                                                                #region//Appointment RequestItem OPCode MISC Header
                                                                MISC misc = new MISC();
                                                                misc.SequenceNumber = proxymisc.SequenceNumber;
                                                                misc.ServiceType = proxymisc.ServiceType;
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode MISCs Descriptions
                                                                if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                                                {
                                                                    misc.Descriptions = new List<Description>();
                                                                    foreach (_WA.Mapper.v2.Appointment.Description proxydescription in proxymisc.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        misc.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode MISCs PriceType
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

                                                appointment.RequestItems.Add(requestitem);
                                            }
                                        }
                                        #endregion

                                        response.Appointments.Add(appointment);
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

                        #region AppointmentGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Appointment.Appointment proxyws = new _1C.v4.Appointment.Appointment(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with appointmentget and transaction
                        _1C.v4.Appointment.AppointmentGetRequest proxyrequest = new _1C.v4.Appointment.AppointmentGetRequest();

                        //Create proxy transaction
                        _1C.v4.Appointment.TransactionHeader proxytransactionheader = new _1C.v4.Appointment.TransactionHeader();
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

                        //Create proxy appointmentget
                        _1C.v4.Appointment.AppointmentGet proxyappointmentget = new _1C.v4.Appointment.AppointmentGet();
                        if (request.AppointmentGet != null)
                        {
                            #region//AppointmentGet Set
                            proxyappointmentget.AppointmentDateTimeFromLocal = request.AppointmentGet.AppointmentDateTimeFromLocal;
                            proxyappointmentget.AppointmentDateTimeToLocal = request.AppointmentGet.AppointmentDateTimeFromLocal;
                            proxyappointmentget.DMSAppointmentID = request.AppointmentGet.DMSAppointmentID;
                            proxyappointmentget.DMSAppointmentNo = request.AppointmentGet.DMSAppointmentNo;
                            proxyappointmentget.DMSAppointmentStatus = request.AppointmentGet.DMSAppointmentStatus;
                            proxyappointmentget.LastModifiedDateTimeFromUTC = request.AppointmentGet.LastModifiedDateTimeFromUTC;
                            proxyappointmentget.LastModifiedDateTimeToUTC = request.AppointmentGet.LastModifiedDateTimeToUTC;
                            proxyappointmentget.SAEmployeeID = request.AppointmentGet.SAEmployeeID;
                            proxyappointmentget.SAEmployeeName = request.AppointmentGet.SAEmployeeName;
                            proxyappointmentget.TCEmployeeID = request.AppointmentGet.TCEmployeeID;
                            proxyappointmentget.TCEmployeeName = request.AppointmentGet.TCEmployeeName;
                            if (request.AppointmentGet.Customer != null)
                            {
                                _1C.v4.Appointment.Customer proxycustomer = new _1C.v4.Appointment.Customer();
                                proxycustomer.DMSCustomerNo = request.AppointmentGet.Customer.DMSCustomerNo;
                                proxycustomer.LastName = request.AppointmentGet.Customer.LastName;

                                if (request.AppointmentGet.Customer.Contacts != null && request.AppointmentGet.Customer.Contacts.Count > 0)
                                {
                                    int cnt = 0;
                                    proxycustomer.Contacts = new _1C.v4.Appointment.Contact[request.AppointmentGet.Customer.Contacts.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Appointment.Contact contact in request.AppointmentGet.Customer.Contacts)
                                    {
                                        _1C.v4.Appointment.Contact proxycontact = new _1C.v4.Appointment.Contact();
                                        proxycontact.ContactType = contact.ContactType;
                                        proxycontact.ContactValue = contact.ContactValue;
                                        proxycustomer.Contacts[cnt] = proxycontact;
                                        cnt++;
                                    }
                                }
                                proxyappointmentget.Customer = proxycustomer;
                            }
                            proxyrequest.AppointmentGet = proxyappointmentget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Appointment.AppointmentGetResponse proxyresponse = proxyws.AppointmentGet(proxyrequest);

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
                                foreach (_1C.v4.Appointment.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//AppointmentGetResponse Set

                                if (proxyresponse.Appointments != null && proxyresponse.Appointments.Length > 0)
                                {
                                    response.Appointments = new List<Appointment>();
                                    foreach (_1C.v4.Appointment.Appointment1 proxyappointment in proxyresponse.Appointments)
                                    {
                                        #region //Appointment Header
                                        Appointment appointment = new Appointment();
                                        appointment.AppointmentDateTimeLocal = proxyappointment.AppointmentDateTimeLocal;
                                        appointment.CloseDateTimeLocal = proxyappointment.CloseDateTimeLocal;
                                        appointment.CustomerComment = proxyappointment.CustomerComment;
                                        appointment.DeliveryDateTimeLocal = proxyappointment.DeliveryDateTimeLocal;
                                        appointment.DMSAppointmentID = proxyappointment.DMSAppointmentID;
                                        appointment.DMSAppointmentNo = proxyappointment.DMSAppointmentNo;
                                        appointment.DMSAppointmentStatus = proxyappointment.DMSAppointmentStatus;
                                        appointment.InMileage = proxyappointment.InMileage;
                                        appointment.OpenDateTimeLocal = proxyappointment.OpenDateTimeLocal;
                                        appointment.PaymentMethod = proxyappointment.PaymentMethod;
                                        appointment.SAEmployeeID = proxyappointment.SAEmployeeID;
                                        appointment.SAEmployeeName = proxyappointment.SAEmployeeName;
                                        appointment.ServiceType = proxyappointment.ServiceType;
                                        appointment.TCEmployeeID = proxyappointment.TCEmployeeID;
                                        appointment.TCEmployeeName = proxyappointment.TCEmployeeName;
                                        appointment.WorkType = proxyappointment.WorkType;
                                        #endregion

                                        #region //Appointment AdditionalFields
                                        if (proxyappointment.AdditionalFields != null && proxyappointment.AdditionalFields.Length > 0)
                                        {
                                            appointment.AdditionalFields = new List<AdditionalField>();
                                            foreach (_1C.v4.Appointment.AdditionalField proxyadditionalfield in proxyappointment.AdditionalFields)
                                            {
                                                AdditionalField additionalfield = new AdditionalField();
                                                additionalfield.AdditionalFieldName = proxyadditionalfield.Name;
                                                additionalfield.AdditionalFieldValue = proxyadditionalfield.Value;
                                                appointment.AdditionalFields.Add(additionalfield);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment JobRefs
                                        if (proxyappointment.JobRefs != null && proxyappointment.JobRefs.Length > 0)
                                        {
                                            appointment.JobRefs = new List<JobRef>();
                                            foreach (_1C.v4.Appointment.JobRef proxyjobref in proxyappointment.JobRefs)
                                            {
                                                JobRef jobref = new JobRef();
                                                jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                                jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                                appointment.JobRefs.Add(jobref);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment ManagementFields
                                        if (proxyappointment.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.CreateDateTimeUTC = proxyappointment.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyappointment.ManagementFields.LastModifiedDateTimeUTC;
                                            appointment.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region//Appointment Options
                                        if (proxyappointment.Options != null && proxyappointment.Options.Length > 0)
                                        {
                                            appointment.Options = new List<Option>();
                                            foreach (_1C.v4.Appointment.Option proxyoption in proxyappointment.Options)
                                            {
                                                Option option = new Option();
                                                option.OptionName = proxyoption.Name;
                                                option.OptionValue = proxyoption.Value;
                                                appointment.Options.Add(option);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment PriceType
                                        if (proxyappointment.PriceType != null)
                                        {
                                            PriceType pricetype = new PriceType();
                                            pricetype.DiscountPrice = proxyappointment.PriceType.DiscountPrice;
                                            pricetype.DiscountRate = proxyappointment.PriceType.DiscountRate;
                                            pricetype.TotalPrice = proxyappointment.PriceType.TotalPrice;
                                            pricetype.TotalPriceIncludeTax = proxyappointment.PriceType.TotalPriceIncludeTax;
                                            pricetype.UnitPrice = proxyappointment.PriceType.UnitPrice;
                                            appointment.PriceType = pricetype;
                                        }
                                        #endregion

                                        #region//Appointment RORefs
                                        if (proxyappointment.RORefs != null && proxyappointment.RORefs.Length > 0)
                                        {
                                            appointment.RORefs = new List<RORef>();
                                            foreach (_1C.v4.Appointment.RORef proxyroref in proxyappointment.RORefs)
                                            {
                                                RORef roref = new RORef();
                                                roref.DMSRONo = proxyroref.DMSRONo;
                                                roref.DMSROStatus = proxyroref.DMSROStatus;
                                                appointment.RORefs.Add(roref);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment Customers
                                        if (proxyappointment.Customers != null && proxyappointment.Customers.Length > 0)
                                        {
                                            appointment.Customers = new List<Data.v2.Common.Customer.Customer>();
                                            foreach (_1C.v4.Appointment.Customer1 proxycustomer in proxyappointment.Customers)
                                            {
                                                #region//Appointment Customer Header
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

                                                #region//Appointment Customer Addresses
                                                if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                                {
                                                    customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                                    foreach (_1C.v4.Appointment.Address proxyaddress in proxycustomer.Addresses)
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

                                                #region//Appointment Customer Contacts
                                                if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                                {
                                                    customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                                    foreach (_1C.v4.Appointment.Contact1 proxycontact in proxycustomer.Contacts)
                                                    {
                                                        Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                                        contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                                        contact.ContactType = proxycontact.ContactType;
                                                        contact.ContactValue = proxycontact.ContactValue;
                                                        customer.Contacts.Add(contact);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment Customer SpecialMessage
                                                if (proxycustomer.SpecialMessage != null)
                                                {
                                                    Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                                    specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                                    customer.SpecialMessage = specialmessage;
                                                }
                                                #endregion

                                                #region//Appointment Customer CorporateInfos
                                                if (proxycustomer.CorporateInfos != null && proxycustomer.CorporateInfos.Length > 0)
                                                {
                                                    customer.CorporateInfos = new List<Data.v2.Common.Customer.CorporateInfo>();
                                                    foreach (_1C.v4.Appointment.CorporateInfo proxycorporateinfo in proxycustomer.CorporateInfos)
                                                    {
                                                        Data.v2.Common.Customer.CorporateInfo corporateinfo = new Data.v2.Common.Customer.CorporateInfo();
                                                        corporateinfo.CorporateInfoName = proxycorporateinfo.Name;
                                                        corporateinfo.CorporateInfoValue = proxycorporateinfo.Value;
                                                        customer.CorporateInfos.Add(corporateinfo);
                                                    }
                                                }
                                                #endregion

                                                appointment.Customers.Add(customer);
                                            }
                                        }
                                        #endregion

                                        #region//Appointment Vehicle
                                        if (proxyappointment.Vehicle != null)
                                        {
                                            if (proxyappointment.Vehicle != null)
                                            {
                                                #region//Appointment Vehicle Header
                                                Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                                vehicle.Color = proxyappointment.Vehicle.Color;
                                                vehicle.Cylinders = proxyappointment.Vehicle.Cylinders;
                                                vehicle.DateDelivered = proxyappointment.Vehicle.DateDelivered;
                                                vehicle.DateInService = proxyappointment.Vehicle.DateInService;
                                                vehicle.DeclinedJob = proxyappointment.Vehicle.DeclinedJob;
                                                vehicle.DisplayDescription = proxyappointment.Vehicle.DisplayDescription;
                                                vehicle.DMSVehicleNo = proxyappointment.Vehicle.DMSVehicleNo;
                                                vehicle.EngineType = proxyappointment.Vehicle.EngineType;
                                                vehicle.ExtendedWarranty = proxyappointment.Vehicle.ExtendedWarranty;
                                                vehicle.FuelType = proxyappointment.Vehicle.FuelType;
                                                vehicle.FullModelName = proxyappointment.Vehicle.FullModelName;
                                                vehicle.InsuranceDate = proxyappointment.Vehicle.InsuranceDate;
                                                vehicle.LastMileage = proxyappointment.Vehicle.LastMileage;
                                                vehicle.LastServiceDate = proxyappointment.Vehicle.LastServiceDate;
                                                vehicle.LastSixVIN = proxyappointment.Vehicle.LastSixVIN;
                                                vehicle.LicenseNumber = proxyappointment.Vehicle.LicenseNumber;
                                                vehicle.LicensePlateNo = proxyappointment.Vehicle.LicensePlateNo;
                                                vehicle.Make = proxyappointment.Vehicle.Make;
                                                vehicle.ModelCode = proxyappointment.Vehicle.ModelCode;
                                                vehicle.ModelName = proxyappointment.Vehicle.ModelName;
                                                vehicle.ModelYear = proxyappointment.Vehicle.ModelYear;
                                                vehicle.PendingJob = proxyappointment.Vehicle.PendingJob;
                                                vehicle.StockNumber = proxyappointment.Vehicle.StockNumber;
                                                vehicle.Trim = proxyappointment.Vehicle.Trim;
                                                vehicle.VehicleType = proxyappointment.Vehicle.VehicleType;
                                                vehicle.VIN = proxyappointment.Vehicle.VIN;
                                                vehicle.WarrantyMiles = proxyappointment.Vehicle.WarrantyMiles;
                                                vehicle.WarrantyMonths = proxyappointment.Vehicle.WarrantyMonths;
                                                vehicle.WarrantyStartDate = proxyappointment.Vehicle.WarrantyStartDate;
                                                #endregion

                                                #region//Appointment Vehicle Campaigns
                                                if (proxyappointment.Vehicle.Campaigns != null && proxyappointment.Vehicle.Campaigns.Length > 0)
                                                {
                                                    vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                                    foreach (_1C.v4.Appointment.Campaign proxycampaign in proxyappointment.Vehicle.Campaigns)
                                                    {
                                                        Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                                        campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                                        campaign.CampaignID = proxycampaign.CampaignID;
                                                        campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                                        vehicle.Campaigns.Add(campaign);
                                                    }
                                                }
                                                #endregion

                                                appointment.Vehicle = vehicle;
                                            }
                                        }
                                        #endregion

                                        #region//Appointment RequestItems
                                        if (proxyappointment.RequestItems != null && proxyappointment.RequestItems.Length > 0)
                                        {
                                            appointment.RequestItems = new List<RequestItem>();
                                            foreach (_1C.v4.Appointment.RequestItem proxyrequestitem in proxyappointment.RequestItems)
                                            {
                                                #region//Appointment RequestItem Header
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

                                                #region//Appointment RequestItem Comments
                                                if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                                {
                                                    requestitem.Comments = new List<Comment>();
                                                    foreach (_1C.v4.Appointment.Comment proxycomment in proxyrequestitem.Comments)
                                                    {
                                                        Comment comment = new Comment();
                                                        comment.DescriptionComment = proxycomment.DescriptionComment;
                                                        comment.SequenceNumber = proxycomment.SequenceNumber;
                                                        requestitem.Comments.Add(comment);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment RequestItem Descriptions
                                                if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                                {
                                                    requestitem.Descriptions = new List<Description>();
                                                    foreach (_1C.v4.Appointment.Description proxydescription in proxyrequestitem.Descriptions)
                                                    {
                                                        Description description = new Description();
                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                        requestitem.Descriptions.Add(description);
                                                    }
                                                }
                                                #endregion

                                                #region//Appointment RequestItem OPCodes
                                                if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                                {
                                                    requestitem.OPCodes = new List<OPCode>();
                                                    foreach (_1C.v4.Appointment.OPCode proxyopcode in proxyrequestitem.OPCodes)
                                                    {
                                                        #region//Appointment RequestItem OPCode Header
                                                        OPCode opcode = new OPCode();
                                                        opcode.ActualHours = proxyopcode.ActualHours;
                                                        opcode.Code = proxyopcode.Code;
                                                        opcode.Description = proxyopcode.Description;
                                                        opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                        opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                                        opcode.ServiceType = proxyopcode.ServiceType;
                                                        opcode.SkillLevel = proxyopcode.SkillLevel;
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Descriptions
                                                        if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                        {
                                                            opcode.Descriptions = new List<Description>();
                                                            foreach (_1C.v4.Appointment.Description proxydescription in proxyopcode.Descriptions)
                                                            {
                                                                Description description = new Description();
                                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                                opcode.Descriptions.Add(description);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Causes
                                                        if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                        {
                                                            opcode.Causes = new List<Cause>();
                                                            foreach (_1C.v4.Appointment.Cause proxycause in proxyopcode.Causes)
                                                            {
                                                                Cause cause = new Cause();
                                                                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                                cause.Comment = proxycause.Comment;
                                                                cause.SequenceNumber = proxycause.SequenceNumber;
                                                                opcode.Causes.Add(cause);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode Corrections
                                                        if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                        {
                                                            opcode.Corrections = new List<Correction>();
                                                            foreach (_1C.v4.Appointment.Correction proxycorrection in proxyopcode.Corrections)
                                                            {
                                                                Correction correction = new Correction();
                                                                correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                                correction.Comment = proxycorrection.Comment;
                                                                correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                                opcode.Corrections.Add(correction);
                                                            }
                                                        }
                                                        #endregion

                                                        #region//Appointment RequestItem OPCode PriceType
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

                                                        #region//Appointment RequestItem OPCode Parts
                                                        if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                                        {
                                                            opcode.Parts = new List<Part>();
                                                            foreach (_1C.v4.Appointment.Part proxypart in proxyopcode.Parts)
                                                            {
                                                                #region//Appointment RequestItem OPCode Parts Header
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

                                                                #region//Appointment RequestItem OPCode Parts Descriptions
                                                                if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                                                {
                                                                    part.Descriptions = new List<Description>();
                                                                    foreach (_1C.v4.Appointment.Description proxydescription in proxypart.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        part.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Parts PriceType
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

                                                        #region//Appointment RequestItem OPCode Sublets
                                                        if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                                        {
                                                            opcode.Sublets = new List<Sublet>();
                                                            foreach (_1C.v4.Appointment.Sublet proxysublet in proxyopcode.Sublets)
                                                            {
                                                                #region//Appointment RequestItem OPCode Sublet Header
                                                                Sublet sublet = new Sublet();
                                                                sublet.SequenceNumber = proxysublet.SequenceNumber;
                                                                sublet.ServiceType = proxysublet.ServiceType;
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Sublets Descriptions
                                                                if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                                                {
                                                                    sublet.Descriptions = new List<Description>();
                                                                    foreach (_1C.v4.Appointment.Description proxydescription in proxysublet.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        sublet.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode Sublets PriceType
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

                                                        #region//Appointment RequestItem OPCode MISCs
                                                        if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                                        {
                                                            opcode.MISCs = new List<MISC>();
                                                            foreach (_1C.v4.Appointment.MISC proxymisc in proxyopcode.MISCs)
                                                            {
                                                                #region//Appointment RequestItem OPCode MISC Header
                                                                MISC misc = new MISC();
                                                                misc.SequenceNumber = proxymisc.SequenceNumber;
                                                                misc.ServiceType = proxymisc.ServiceType;
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode MISCs Descriptions
                                                                if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                                                {
                                                                    misc.Descriptions = new List<Description>();
                                                                    foreach (_1C.v4.Appointment.Description proxydescription in proxymisc.Descriptions)
                                                                    {
                                                                        Description description = new Description();
                                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                                        misc.Descriptions.Add(description);
                                                                    }
                                                                }
                                                                #endregion

                                                                #region//Appointment RequestItem OPCode MISCs PriceType
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

                                                appointment.RequestItems.Add(requestitem);
                                            }
                                        }
                                        #endregion

                                        response.Appointments.Add(appointment);
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

        public AppointmentChangeResponse AppointmentChange(AppointmentChangeRequest request)
        {
            AppointmentChangeResponse response = new AppointmentChangeResponse();

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
                        #region v2.HMCIS.1C.v4 - Standard (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region AppointmentChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Appointment.Appointment proxyws = new _WA.Mapper.v2.Appointment.Appointment(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with appointmentchange and transaction
                        _WA.Mapper.v2.Appointment.AppointmentChangeRequest proxyrequest = new _WA.Mapper.v2.Appointment.AppointmentChangeRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Appointment.TransactionHeader2 proxytransactionheader = new _WA.Mapper.v2.Appointment.TransactionHeader2();
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

                        //Create proxy appointmentchange
                        _WA.Mapper.v2.Appointment.AppointmentChange proxyappointmentchange = new _WA.Mapper.v2.Appointment.AppointmentChange();
                        if (request.AppointmentChange != null)
                        {
                            #region//Appointment Header
                            proxyappointmentchange.AppointmentChannel = request.AppointmentChange.AppointmentChannel;
                            proxyappointmentchange.AppointmentDateTimeLocal = request.AppointmentChange.AppointmentDateTimeLocal;
                            proxyappointmentchange.CloseDateTimeLocal = request.AppointmentChange.CloseDateTimeLocal;
                            proxyappointmentchange.CustomerComment = request.AppointmentChange.CustomerComment;
                            proxyappointmentchange.DeliveryDateTimeLocal = request.AppointmentChange.DeliveryDateTimeLocal;
                            proxyappointmentchange.DMSAppointmentID = request.AppointmentChange.DMSAppointmentID;
                            proxyappointmentchange.DMSAppointmentNo = request.AppointmentChange.DMSAppointmentNo;
                            proxyappointmentchange.DMSAppointmentStatus = request.AppointmentChange.DMSAppointmentStatus;
                            proxyappointmentchange.InMileage = request.AppointmentChange.InMileage;
                            proxyappointmentchange.OpenDateTimeLocal = request.AppointmentChange.OpenDateTimeLocal;
                            proxyappointmentchange.PaymentMethod = request.AppointmentChange.PaymentMethod;
                            proxyappointmentchange.SAEmployeeID = request.AppointmentChange.SAEmployeeID;
                            proxyappointmentchange.SAEmployeeName = request.AppointmentChange.SAEmployeeName;
                            proxyappointmentchange.ServiceType = request.AppointmentChange.ServiceType;
                            proxyappointmentchange.TCEmployeeID = request.AppointmentChange.TCEmployeeID;
                            proxyappointmentchange.TCEmployeeName = request.AppointmentChange.TCEmployeeName;
                            proxyappointmentchange.WorkType = request.AppointmentChange.WorkType;
                            #endregion

                            #region //Appointment AdditionalFields
                            if (request.AppointmentChange.AdditionalFields != null && request.AppointmentChange.AdditionalFields.Count > 0)
                            {
                                int additionalfieldscnt = 0;
                                _WA.Mapper.v2.Appointment.AdditionalField1[] proxyadditionalfields = new _WA.Mapper.v2.Appointment.AdditionalField1[request.AppointmentChange.AdditionalFields.Count];
                                foreach (AdditionalField additionalfield in request.AppointmentChange.AdditionalFields)
                                {
                                    _WA.Mapper.v2.Appointment.AdditionalField1 proxyadditionalfield = new _WA.Mapper.v2.Appointment.AdditionalField1();
                                    proxyadditionalfield.Name = additionalfield.AdditionalFieldName;
                                    proxyadditionalfield.Value = additionalfield.AdditionalFieldValue;
                                    proxyadditionalfields[additionalfieldscnt] = proxyadditionalfield;
                                    additionalfieldscnt++;
                                }
                                proxyappointmentchange.AdditionalFields = proxyadditionalfields;
                            }
                            #endregion

                            #region//Appointment Options
                            if (request.AppointmentChange.Options != null && request.AppointmentChange.Options.Count > 0)
                            {
                                int optionscnt = 0;
                                _WA.Mapper.v2.Appointment.Option1[] proxyoptions = new _WA.Mapper.v2.Appointment.Option1[request.AppointmentChange.Options.Count];
                                foreach (Option option in request.AppointmentChange.Options)
                                {
                                    _WA.Mapper.v2.Appointment.Option1 proxyoption = new _WA.Mapper.v2.Appointment.Option1();
                                    proxyoption.Name = option.OptionName;
                                    proxyoption.Value = option.OptionValue;
                                    proxyoptions[optionscnt] = proxyoption;
                                    optionscnt++;
                                }
                                proxyappointmentchange.Options = proxyoptions;
                            }
                            #endregion

                            #region//Appointment PriceType
                            if (request.AppointmentChange.PriceType != null)
                            {
                                _WA.Mapper.v2.Appointment.PriceType1 proxypricetype = new _WA.Mapper.v2.Appointment.PriceType1();
                                proxypricetype.DiscountPrice = request.AppointmentChange.PriceType.DiscountPrice;
                                proxypricetype.DiscountRate = request.AppointmentChange.PriceType.DiscountRate;
                                proxypricetype.TotalPrice = request.AppointmentChange.PriceType.TotalPrice;
                                proxypricetype.TotalPriceIncludeTax = request.AppointmentChange.PriceType.TotalPriceIncludeTax;
                                proxypricetype.UnitPrice = request.AppointmentChange.PriceType.UnitPrice;
                                proxyappointmentchange.PriceType = proxypricetype;
                            }
                            #endregion

                            #region//Appointment Customers
                            if (request.AppointmentChange.Customers != null && request.AppointmentChange.Customers.Count > 0)
                            {
                                int customerscnt = 0;
                                _WA.Mapper.v2.Appointment.Customer2[] proxycustomers = new _WA.Mapper.v2.Appointment.Customer2[request.AppointmentChange.Customers.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Customer.Customer customer in request.AppointmentChange.Customers)
                                {
                                    #region//Appointment Customer Header
                                    _WA.Mapper.v2.Appointment.Customer2 proxycustomer = new _WA.Mapper.v2.Appointment.Customer2();
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

                                    #region//Appointment Customer Addresses
                                    if (customer.Addresses != null && customer.Addresses.Count > 0)
                                    {
                                        int addressescnt = 0;
                                        _WA.Mapper.v2.Appointment.Address1[] proxyaddresses = new _WA.Mapper.v2.Appointment.Address1[customer.Addresses.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Address address in customer.Addresses)
                                        {
                                            _WA.Mapper.v2.Appointment.Address1 proxyaddress = new _WA.Mapper.v2.Appointment.Address1();
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

                                    #region//Appointment Customer Contacts
                                    if (customer.Contacts != null && customer.Contacts.Count > 0)
                                    {
                                        int contactscnt = 0;
                                        _WA.Mapper.v2.Appointment.Contact2[] proxycontacts = new _WA.Mapper.v2.Appointment.Contact2[customer.Contacts.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Contact contact in customer.Contacts)
                                        {
                                            _WA.Mapper.v2.Appointment.Contact2 proxycontact = new _WA.Mapper.v2.Appointment.Contact2();
                                            proxycontact.ContactMethodYN = contact.ContactMethodYN;
                                            proxycontact.ContactType = contact.ContactType;
                                            proxycontact.ContactValue = contact.ContactValue;
                                            proxycontacts[contactscnt] = proxycontact;
                                            contactscnt++;
                                        }
                                        proxycustomer.Contacts = proxycontacts;
                                    }
                                    #endregion

                                    #region//Appointment Customer SpecialMessage
                                    if (customer.SpecialMessage != null)
                                    {
                                        _WA.Mapper.v2.Appointment.SpecialMessage1 proxyspecialmessage = new _WA.Mapper.v2.Appointment.SpecialMessage1();
                                        proxyspecialmessage.Message = customer.SpecialMessage.Message;
                                        proxycustomer.SpecialMessage = proxyspecialmessage;
                                    }
                                    #endregion

                                    #region//Appointment Customer CorporateInfos
                                    if (customer.CorporateInfos != null && customer.CorporateInfos.Count > 0)
                                    {
                                        int corporateinfoscnt = 0;
                                        _WA.Mapper.v2.Appointment.CorporateInfo1[] proxycorporateinfos = new _WA.Mapper.v2.Appointment.CorporateInfo1[customer.CorporateInfos.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo in customer.CorporateInfos)
                                        {
                                            _WA.Mapper.v2.Appointment.CorporateInfo1 proxycorporateinfo = new _WA.Mapper.v2.Appointment.CorporateInfo1();
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
                                proxyappointmentchange.Customers = proxycustomers;
                            }
                            #endregion

                            #region//Appointment Vehicle
                            if (request.AppointmentChange.Vehicle != null)
                            {
                                #region//Appointment Vehicle Header
                                _WA.Mapper.v2.Appointment.Vehicle2 proxyvehicle = new _WA.Mapper.v2.Appointment.Vehicle2();
                                proxyvehicle.Color = request.AppointmentChange.Vehicle.Color;
                                proxyvehicle.Cylinders = request.AppointmentChange.Vehicle.Cylinders;
                                proxyvehicle.DateDelivered = request.AppointmentChange.Vehicle.DateDelivered;
                                proxyvehicle.DateInService = request.AppointmentChange.Vehicle.DateInService;
                                proxyvehicle.DeclinedJob = request.AppointmentChange.Vehicle.DeclinedJob;
                                proxyvehicle.DisplayDescription = request.AppointmentChange.Vehicle.DisplayDescription;
                                proxyvehicle.DMSVehicleNo = request.AppointmentChange.Vehicle.DMSVehicleNo;
                                proxyvehicle.EngineType = request.AppointmentChange.Vehicle.EngineType;
                                proxyvehicle.ExtendedWarranty = request.AppointmentChange.Vehicle.ExtendedWarranty;
                                proxyvehicle.FuelType = request.AppointmentChange.Vehicle.FuelType;
                                proxyvehicle.FullModelName = request.AppointmentChange.Vehicle.FullModelName;
                                proxyvehicle.InsuranceDate = request.AppointmentChange.Vehicle.InsuranceDate;
                                proxyvehicle.LastMileage = request.AppointmentChange.Vehicle.LastMileage;
                                proxyvehicle.LastServiceDate = request.AppointmentChange.Vehicle.LastServiceDate;
                                proxyvehicle.LastSixVIN = request.AppointmentChange.Vehicle.LastSixVIN;
                                proxyvehicle.LicenseNumber = request.AppointmentChange.Vehicle.LicenseNumber;
                                proxyvehicle.LicensePlateNo = request.AppointmentChange.Vehicle.LicensePlateNo;
                                proxyvehicle.Make = request.AppointmentChange.Vehicle.Make;
                                proxyvehicle.ModelCode = request.AppointmentChange.Vehicle.ModelCode;
                                proxyvehicle.ModelName = request.AppointmentChange.Vehicle.ModelName;
                                proxyvehicle.ModelYear = request.AppointmentChange.Vehicle.ModelYear;
                                proxyvehicle.PendingJob = request.AppointmentChange.Vehicle.PendingJob;
                                proxyvehicle.StockNumber = request.AppointmentChange.Vehicle.StockNumber;
                                proxyvehicle.Trim = request.AppointmentChange.Vehicle.Trim;
                                proxyvehicle.VehicleType = request.AppointmentChange.Vehicle.VehicleType;
                                proxyvehicle.VIN = request.AppointmentChange.Vehicle.VIN;
                                proxyvehicle.WarrantyMiles = request.AppointmentChange.Vehicle.WarrantyMiles;
                                proxyvehicle.WarrantyMonths = request.AppointmentChange.Vehicle.WarrantyMonths;
                                proxyvehicle.WarrantyStartDate = request.AppointmentChange.Vehicle.WarrantyStartDate;
                                #endregion

                                #region//Appointment Vehicle Campaigns
                                if (request.AppointmentChange.Vehicle.Campaigns != null && request.AppointmentChange.Vehicle.Campaigns.Count > 0)
                                {
                                    int campaignscnt = 0;
                                    _WA.Mapper.v2.Appointment.Campaign1[] proxycampaigns = new _WA.Mapper.v2.Appointment.Campaign1[request.AppointmentChange.Vehicle.Campaigns.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Vehicle.Campaign campaign in request.AppointmentChange.Vehicle.Campaigns)
                                    {
                                        _WA.Mapper.v2.Appointment.Campaign1 proxycampaign = new _WA.Mapper.v2.Appointment.Campaign1();
                                        proxycampaign.CampaignDescription = campaign.CampaignDescription;
                                        proxycampaign.CampaignID = campaign.CampaignID;
                                        proxycampaign.CampaignPerformed = campaign.CampaignPerformed;
                                        proxycampaigns[campaignscnt] = proxycampaign;
                                        campaignscnt++;
                                    }
                                    proxyvehicle.Campaigns = proxycampaigns;
                                }
                                #endregion

                                proxyappointmentchange.Vehicle = proxyvehicle;
                            }
                            #endregion

                            #region//Appointment RequestItems
                            if (request.AppointmentChange.RequestItems != null && request.AppointmentChange.RequestItems.Count > 0)
                            {
                                int requestitemscnt = 0;
                                _WA.Mapper.v2.Appointment.RequestItem1[] proxyrequestitems = new _WA.Mapper.v2.Appointment.RequestItem1[request.AppointmentChange.RequestItems.Count];
                                foreach (RequestItem requestitem in request.AppointmentChange.RequestItems)
                                {
                                    #region//Appointment RequestItem Header
                                    _WA.Mapper.v2.Appointment.RequestItem1 proxyrequestitem = new _WA.Mapper.v2.Appointment.RequestItem1();
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

                                    #region//Appointment RequestItem Comments
                                    if (requestitem.Comments != null && requestitem.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _WA.Mapper.v2.Appointment.Comment1[] proxycomments = new _WA.Mapper.v2.Appointment.Comment1[requestitem.Comments.Count];
                                        foreach (Comment Comment in requestitem.Comments)
                                        {
                                            _WA.Mapper.v2.Appointment.Comment1 proxycomment = new _WA.Mapper.v2.Appointment.Comment1();
                                            proxycomment.DescriptionComment = Comment.DescriptionComment;
                                            proxycomment.SequenceNumber = Comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyrequestitem.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//Appointment RequestItem Descriptions
                                    if (requestitem.Descriptions != null && requestitem.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _WA.Mapper.v2.Appointment.Description1[] proxydescriptions = new _WA.Mapper.v2.Appointment.Description1[requestitem.Descriptions.Count];
                                        foreach (Description description in requestitem.Descriptions)
                                        {
                                            _WA.Mapper.v2.Appointment.Description1 proxydescription = new _WA.Mapper.v2.Appointment.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyrequestitem.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//Appointment RequestItem OPCodes
                                    if (requestitem.OPCodes != null && requestitem.OPCodes.Count > 0)
                                    {
                                        int opcodescnt = 0;
                                        _WA.Mapper.v2.Appointment.OPCode1[] proxyopcodes = new _WA.Mapper.v2.Appointment.OPCode1[requestitem.OPCodes.Count];
                                        foreach (OPCode opcode in requestitem.OPCodes)
                                        {
                                            #region//Appointment RequestItem OPCode Header
                                            _WA.Mapper.v2.Appointment.OPCode1 proxyopcode = new _WA.Mapper.v2.Appointment.OPCode1();
                                            proxyopcode.ActualHours = opcode.ActualHours;
                                            proxyopcode.Code = opcode.Code;
                                            proxyopcode.Description = opcode.Description;
                                            proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                            proxyopcode.SequenceNumber = opcode.SequenceNumber;
                                            proxyopcode.ServiceType = opcode.ServiceType;
                                            proxyopcode.SkillLevel = opcode.SkillLevel;
                                            #endregion

                                            #region//Appointment RequestItem OPCode Descriptions
                                            if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                            {
                                                int descriptionscnt = 0;
                                                _WA.Mapper.v2.Appointment.Description1[] proxydescriptions = new _WA.Mapper.v2.Appointment.Description1[opcode.Descriptions.Count];
                                                foreach (Description description in opcode.Descriptions)
                                                {
                                                    _WA.Mapper.v2.Appointment.Description1 proxydescription = new _WA.Mapper.v2.Appointment.Description1();
                                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                                    proxydescriptions[descriptionscnt] = proxydescription;
                                                    descriptionscnt++;
                                                }
                                                proxyopcode.Descriptions = proxydescriptions;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Causes
                                            if (opcode.Causes != null && opcode.Causes.Count > 0)
                                            {
                                                int causescnt = 0;
                                                _WA.Mapper.v2.Appointment.Cause1[] proxycauses = new _WA.Mapper.v2.Appointment.Cause1[opcode.Causes.Count];
                                                foreach (Cause cause in opcode.Causes)
                                                {
                                                    _WA.Mapper.v2.Appointment.Cause1 proxycause = new _WA.Mapper.v2.Appointment.Cause1();
                                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                                    proxycause.Comment = cause.Comment;
                                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                                    proxycauses[causescnt] = proxycause;
                                                    causescnt++;
                                                }
                                                proxyopcode.Causes = proxycauses;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Corrections
                                            if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                            {
                                                int correctionscnt = 0;
                                                _WA.Mapper.v2.Appointment.Correction1[] proxycorrections = new _WA.Mapper.v2.Appointment.Correction1[opcode.Corrections.Count];
                                                foreach (Correction Correction in opcode.Corrections)
                                                {
                                                    _WA.Mapper.v2.Appointment.Correction1 proxycorrection = new _WA.Mapper.v2.Appointment.Correction1();
                                                    proxycorrection.CorrectionLaborOpCode = Correction.CorrectionLaborOpCode;
                                                    proxycorrection.Comment = Correction.Comment;
                                                    proxycorrection.SequenceNumber = Correction.SequenceNumber;
                                                    proxycorrections[correctionscnt] = proxycorrection;
                                                    correctionscnt++;
                                                }
                                                proxyopcode.Corrections = proxycorrections;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode PriceType
                                            if (opcode.PriceType != null)
                                            {
                                                _WA.Mapper.v2.Appointment.PriceType1 proxypricetype = new _WA.Mapper.v2.Appointment.PriceType1();
                                                proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                                proxyopcode.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Parts
                                            if (opcode.Parts != null && opcode.Parts.Count > 0)
                                            {
                                                int partscnt = 0;
                                                _WA.Mapper.v2.Appointment.Part1[] proxyparts = new _WA.Mapper.v2.Appointment.Part1[opcode.Parts.Count];
                                                foreach (Part part in opcode.Parts)
                                                {
                                                    #region//Appointment RequestItem OPCode Parts Header
                                                    _WA.Mapper.v2.Appointment.Part1 proxypart = new _WA.Mapper.v2.Appointment.Part1();
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

                                                    #region//Appointment RequestItem OPCode Parts Descriptions
                                                    if (part.Descriptions != null && part.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.Appointment.Description1[] proxydescriptions = new _WA.Mapper.v2.Appointment.Description1[part.Descriptions.Count];
                                                        foreach (Description description in part.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.Appointment.Description1 proxydescription = new _WA.Mapper.v2.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxypart.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Parts PriceType
                                                    if (part.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.Appointment.PriceType1 proxypricetype = new _WA.Mapper.v2.Appointment.PriceType1();
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

                                            #region//Appointment RequestItem OPCode Sublets
                                            if (opcode.Sublets != null && opcode.Sublets.Count > 0)
                                            {
                                                int subletscnt = 0;
                                                _WA.Mapper.v2.Appointment.Sublet1[] proxysublets = new _WA.Mapper.v2.Appointment.Sublet1[opcode.Sublets.Count];
                                                foreach (Sublet sublet in opcode.Sublets)
                                                {
                                                    #region//Appointment RequestItem OPCode Sublets Header
                                                    _WA.Mapper.v2.Appointment.Sublet1 proxysublet = new _WA.Mapper.v2.Appointment.Sublet1();
                                                    proxysublet.SequenceNumber = sublet.SequenceNumber;
                                                    proxysublet.ServiceType = sublet.ServiceType;
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Sublets Descriptions
                                                    if (sublet.Descriptions != null && sublet.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.Appointment.Description1[] proxydescriptions = new _WA.Mapper.v2.Appointment.Description1[sublet.Descriptions.Count];
                                                        foreach (Description description in sublet.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.Appointment.Description1 proxydescription = new _WA.Mapper.v2.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxysublet.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Sublets PriceType
                                                    if (sublet.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.Appointment.PriceType1 proxypricetype = new _WA.Mapper.v2.Appointment.PriceType1();
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

                                            #region//Appointment RequestItem OPCode MISCs
                                            if (opcode.MISCs != null && opcode.MISCs.Count > 0)
                                            {
                                                int miscscnt = 0;
                                                _WA.Mapper.v2.Appointment.MISC1[] proxymiscs = new _WA.Mapper.v2.Appointment.MISC1[opcode.MISCs.Count];
                                                foreach (MISC misc in opcode.MISCs)
                                                {
                                                    #region//Appointment RequestItem OPCode MISCs Header
                                                    _WA.Mapper.v2.Appointment.MISC1 proxymisc = new _WA.Mapper.v2.Appointment.MISC1();
                                                    proxymisc.SequenceNumber = misc.SequenceNumber;
                                                    proxymisc.ServiceType = misc.ServiceType;
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode MISCs Descriptions
                                                    if (misc.Descriptions != null && misc.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _WA.Mapper.v2.Appointment.Description1[] proxydescriptions = new _WA.Mapper.v2.Appointment.Description1[misc.Descriptions.Count];
                                                        foreach (Description description in misc.Descriptions)
                                                        {
                                                            _WA.Mapper.v2.Appointment.Description1 proxydescription = new _WA.Mapper.v2.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxymisc.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode MISCs PriceType
                                                    if (misc.PriceType != null)
                                                    {
                                                        _WA.Mapper.v2.Appointment.PriceType1 proxypricetype = new _WA.Mapper.v2.Appointment.PriceType1();
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
                                proxyappointmentchange.RequestItems = proxyrequestitems;
                            }
                            #endregion

                            proxyrequest.AppointmentChange = proxyappointmentchange;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Appointment.AppointmentChangeResponse proxyresponse = proxyws.AppointmentChange(proxyrequest);

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
                                foreach (_WA.Mapper.v2.Appointment.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//AppointmentChangeResponse Set

                                //if (proxyresponse.Appointment != null)
                                //{
                                //#region //Appointment Header
                                //_WA.Mapper.v2.Appointment.Appointment2 proxyappointment = proxyresponse.Appointment;

                                //Appointment appointment = new Appointment();
                                //appointment.AppointmentDateTimeLocal = proxyappointment.AppointmentDateTimeLocal;
                                //appointment.CloseDateTimeLocal = proxyappointment.CloseDateTimeLocal;
                                //appointment.CustomerComment = proxyappointment.CustomerComment;
                                //appointment.DeliveryDateTimeLocal = proxyappointment.DeliveryDateTimeLocal;
                                //appointment.DMSAppointmentID = proxyappointment.DMSAppointmentID;
                                //appointment.DMSAppointmentNo = proxyappointment.DMSAppointmentNo;
                                //appointment.DMSAppointmentStatus = proxyappointment.DMSAppointmentStatus;
                                //appointment.InMileage = proxyappointment.InMileage;
                                //appointment.OpenDateTimeLocal = proxyappointment.OpenDateTimeLocal;
                                //appointment.PaymentMethod = proxyappointment.PaymentMethod;
                                //appointment.SAEmployeeID = proxyappointment.SAEmployeeID;
                                //appointment.SAEmployeeName = proxyappointment.SAEmployeeName;
                                //appointment.ServiceType = proxyappointment.ServiceType;
                                //appointment.TCEmployeeID = proxyappointment.TCEmployeeID;
                                //appointment.TCEmployeeName = proxyappointment.TCEmployeeName;
                                //appointment.WorkType = proxyappointment.WorkType;
                                //#endregion

                                //#region //Appointment AdditionalFields
                                //if (proxyappointment.AdditionalFields != null && proxyappointment.AdditionalFields.Length > 0)
                                //{
                                //    appointment.AdditionalFields = new List<AdditionalField>();
                                //    foreach (_WA.Mapper.v2.Appointment.AdditionalField2 proxyadditionalfield in proxyappointment.AdditionalFields)
                                //    {
                                //        AdditionalField additionalfield = new AdditionalField();
                                //        additionalfield.Name = proxyadditionalfield.Name;
                                //        additionalfield.Value = proxyadditionalfield.Value;
                                //        appointment.AdditionalFields.Add(additionalfield);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment JobRefs
                                //if (proxyappointment.JobRefs != null && proxyappointment.JobRefs.Length > 0)
                                //{
                                //    appointment.JobRefs = new List<JobRef>();
                                //    foreach (_WA.Mapper.v2.Appointment.JobRef1 proxyjobref in proxyappointment.JobRefs)
                                //    {
                                //        JobRef jobref = new JobRef();
                                //        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                //        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                //        appointment.JobRefs.Add(jobref);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment ManagementFields
                                //if (proxyappointment.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyappointment.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyappointment.ManagementFields.LastModifiedDateTimeUTC;
                                //    appointment.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//Appointment Options
                                //if (proxyappointment.Options != null && proxyappointment.Options.Length > 0)
                                //{
                                //    appointment.Options = new List<Option>();
                                //    foreach (_WA.Mapper.v2.Appointment.Option2 proxyoption in proxyappointment.Options)
                                //    {
                                //        Option option = new Option();
                                //        option.Name = proxyoption.Name;
                                //        option.Value = proxyoption.Value;
                                //        appointment.Options.Add(option);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment PriceType
                                //if (proxyappointment.PriceType != null)
                                //{
                                //    PriceType pricetype = new PriceType();
                                //    pricetype.DiscountPrice = proxyappointment.PriceType.DiscountPrice;
                                //    pricetype.DiscountRate = proxyappointment.PriceType.DiscountRate;
                                //    pricetype.TotalPrice = proxyappointment.PriceType.TotalPrice;
                                //    pricetype.TotalPriceIncludeTax = proxyappointment.PriceType.TotalPriceIncludeTax;
                                //    pricetype.UnitPrice = proxyappointment.PriceType.UnitPrice;
                                //    appointment.PriceType = pricetype;
                                //}
                                //#endregion

                                //#region//Appointment RORefs
                                //if (proxyappointment.RORefs != null && proxyappointment.RORefs.Length > 0)
                                //{
                                //    appointment.RORefs = new List<RORef>();
                                //    foreach (_WA.Mapper.v2.Appointment.RORef1 proxyroref in proxyappointment.RORefs)
                                //    {
                                //        RORef roref = new RORef();
                                //        roref.DMSRONo = proxyroref.DMSRONo;
                                //        roref.DMSROStatus = proxyroref.DMSROStatus;
                                //        appointment.RORefs.Add(roref);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment Customers
                                //if (proxyappointment.Customers != null && proxyappointment.Customers.Length > 0)
                                //{
                                //    appointment.Customers = new List<Data.v2.Common.Customer.Customer>();
                                //    foreach (_WA.Mapper.v2.Appointment.Customer3 proxycustomer in proxyappointment.Customers)
                                //    {
                                //        #region//Appointment Customer Header
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

                                //        #region//Appointment Customer Addresses
                                //        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                //        {
                                //            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                //            foreach (_WA.Mapper.v2.Appointment.Address2 proxyaddress in proxycustomer.Addresses)
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

                                //        #region//Appointment Customer Contacts
                                //        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                //        {
                                //            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                //            foreach (_WA.Mapper.v2.Appointment.Contact3 proxycontact in proxycustomer.Contacts)
                                //            {
                                //                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                //                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                //                contact.ContactType = proxycontact.ContactType;
                                //                contact.ContactValue = proxycontact.ContactValue;
                                //                customer.Contacts.Add(contact);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment Customer SpecialMessage
                                //        if (proxycustomer.SpecialMessage != null)
                                //        {
                                //            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                //            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                //            customer.SpecialMessage = specialmessage;
                                //        }
                                //        #endregion

                                //        appointment.Customers.Add(customer);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment Vehicle
                                //if (proxyappointment.Vehicle != null)
                                //{
                                //    #region//Appointment Vehicle Header
                                //    Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                //    vehicle.Color = proxyappointment.Vehicle.Color;
                                //    vehicle.Cylinders = proxyappointment.Vehicle.Cylinders;
                                //    vehicle.DateDelivered = proxyappointment.Vehicle.DateDelivered;
                                //    vehicle.DateInService = proxyappointment.Vehicle.DateInService;
                                //    vehicle.DeclinedJob = proxyappointment.Vehicle.DeclinedJob;
                                //    vehicle.DisplayDescription = proxyappointment.Vehicle.DisplayDescription;
                                //    vehicle.DMSVehicleNo = proxyappointment.Vehicle.DMSVehicleNo;
                                //    vehicle.EngineType = proxyappointment.Vehicle.EngineType;
                                //    vehicle.ExtendedWarranty = proxyappointment.Vehicle.ExtendedWarranty;
                                //    vehicle.FuelType = proxyappointment.Vehicle.FuelType;
                                //    vehicle.FullModelName = proxyappointment.Vehicle.FullModelName;
                                //    vehicle.InsuranceDate = proxyappointment.Vehicle.InsuranceDate;
                                //    vehicle.LastMileage = proxyappointment.Vehicle.LastMileage;
                                //    vehicle.LastServiceDate = proxyappointment.Vehicle.LastServiceDate;
                                //    vehicle.LastSixVIN = proxyappointment.Vehicle.LastSixVIN;
                                //    vehicle.LicenseNumber = proxyappointment.Vehicle.LicenseNumber;
                                //    vehicle.LicensePlateNo = proxyappointment.Vehicle.LicensePlateNo;
                                //    vehicle.Make = proxyappointment.Vehicle.Make;
                                //    vehicle.ModelCode = proxyappointment.Vehicle.ModelCode;
                                //    vehicle.ModelName = proxyappointment.Vehicle.ModelName;
                                //    vehicle.ModelYear = proxyappointment.Vehicle.ModelYear;
                                //    vehicle.PendingJob = proxyappointment.Vehicle.PendingJob;
                                //    vehicle.StockNumber = proxyappointment.Vehicle.StockNumber;
                                //    vehicle.Trim = proxyappointment.Vehicle.Trim;
                                //    vehicle.VehicleType = proxyappointment.Vehicle.VehicleType;
                                //    vehicle.VIN = proxyappointment.Vehicle.VIN;
                                //    vehicle.WarrantyMiles = proxyappointment.Vehicle.WarrantyMiles;
                                //    vehicle.WarrantyMonths = proxyappointment.Vehicle.WarrantyMonths;
                                //    vehicle.WarrantyStartDate = proxyappointment.Vehicle.WarrantyStartDate;
                                //    #endregion

                                //    #region//Appointment Vehicle Campaigns
                                //    if (proxyappointment.Vehicle.Campaigns != null && proxyappointment.Vehicle.Campaigns.Length > 0)
                                //    {
                                //        vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                //        foreach (_WA.Mapper.v2.Appointment.Campaign2 proxycampaign in proxyappointment.Vehicle.Campaigns)
                                //        {
                                //            Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                //            campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                //            campaign.CampaignID = proxycampaign.CampaignID;
                                //            campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                //            vehicle.Campaigns.Add(campaign);
                                //        }
                                //    }
                                //    #endregion

                                //    appointment.Vehicle = vehicle;
                                //}
                                //#endregion

                                //#region//Appointment RequestItems
                                //if (proxyappointment.RequestItems != null && proxyappointment.RequestItems.Length > 0)
                                //{
                                //    appointment.RequestItems = new List<RequestItem>();
                                //    foreach (_WA.Mapper.v2.Appointment.RequestItem2 proxyrequestitem in proxyappointment.RequestItems)
                                //    {
                                //        #region//Appointment RequestItem Header
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

                                //        #region//Appointment RequestItem Comments
                                //        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                //        {
                                //            requestitem.Comments = new List<Comment>();
                                //            foreach (_WA.Mapper.v2.Appointment.Comment2 proxycomment in proxyrequestitem.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                requestitem.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment RequestItem Descriptions
                                //        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                //        {
                                //            requestitem.Descriptions = new List<Description>();
                                //            foreach (_WA.Mapper.v2.Appointment.Description2 proxydescription in proxyrequestitem.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                requestitem.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment RequestItem OPCodes
                                //        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                //        {
                                //            requestitem.OPCodes = new List<OPCode>();
                                //            foreach (_WA.Mapper.v2.Appointment.OPCode2 proxyopcode in proxyrequestitem.OPCodes)
                                //            {
                                //                #region//Appointment RequestItem OPCode Header
                                //                OPCode opcode = new OPCode();
                                //                opcode.ActualHours = proxyopcode.ActualHours;
                                //                opcode.Code = proxyopcode.Code;
                                //                opcode.Description = proxyopcode.Description;
                                //                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                //                opcode.ServiceType = proxyopcode.ServiceType;
                                //                opcode.SkillLevel = proxyopcode.SkillLevel;
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Descriptions
                                //                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //                {
                                //                    opcode.Descriptions = new List<Description>();
                                //                    foreach (_WA.Mapper.v2.Appointment.Description2 proxydescription in proxyopcode.Descriptions)
                                //                    {
                                //                        Description description = new Description();
                                //                        description.DescriptionComment = proxydescription.DescriptionComment;
                                //                        description.SequenceNumber = proxydescription.SequenceNumber;
                                //                        opcode.Descriptions.Add(description);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Causes
                                //                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //                {
                                //                    opcode.Causes = new List<Cause>();
                                //                    foreach (_WA.Mapper.v2.Appointment.Cause2 proxycause in proxyopcode.Causes)
                                //                    {
                                //                        Cause cause = new Cause();
                                //                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                        cause.Comment = proxycause.Comment;
                                //                        cause.SequenceNumber = proxycause.SequenceNumber;
                                //                        opcode.Causes.Add(cause);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Corrections
                                //                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //                {
                                //                    opcode.Corrections = new List<Correction>();
                                //                    foreach (_WA.Mapper.v2.Appointment.Correction2 proxycorrection in proxyopcode.Corrections)
                                //                    {
                                //                        Correction correction = new Correction();
                                //                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                        correction.Comment = proxycorrection.Comment;
                                //                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                        opcode.Corrections.Add(correction);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode PriceType
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

                                //                #region//Appointment RequestItem OPCode Parts
                                //                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                //                {
                                //                    opcode.Parts = new List<Part>();
                                //                    foreach (_WA.Mapper.v2.Appointment.Part2 proxypart in proxyopcode.Parts)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode Parts Header
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

                                //                        #region//Appointment RequestItem OPCode Parts Descriptions
                                //                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                //                        {
                                //                            part.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.Appointment.Description2 proxydescription in proxypart.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                part.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Parts PriceType
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

                                //                #region//Appointment RequestItem OPCode Sublets
                                //                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                //                {
                                //                    opcode.Sublets = new List<Sublet>();
                                //                    foreach (_WA.Mapper.v2.Appointment.Sublet2 proxysublet in proxyopcode.Sublets)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode Sublet Header
                                //                        Sublet sublet = new Sublet();
                                //                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                //                        sublet.ServiceType = proxysublet.ServiceType;
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Sublets Descriptions
                                //                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                //                        {
                                //                            sublet.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.Appointment.Description2 proxydescription in proxysublet.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                sublet.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Sublets PriceType
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

                                //                #region//Appointment RequestItem OPCode MISCs
                                //                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                //                {
                                //                    opcode.MISCs = new List<MISC>();
                                //                    foreach (_WA.Mapper.v2.Appointment.MISC2 proxymisc in proxyopcode.MISCs)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode MISC Header
                                //                        MISC misc = new MISC();
                                //                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                //                        misc.ServiceType = proxymisc.ServiceType;
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode MISCs Descriptions
                                //                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                //                        {
                                //                            misc.Descriptions = new List<Description>();
                                //                            foreach (_WA.Mapper.v2.Appointment.Description2 proxydescription in proxymisc.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                misc.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode MISCs PriceType
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

                                //        appointment.RequestItems.Add(requestitem);
                                //    }
                                //}
                                //#endregion

                                //response.Appointment = appointment;
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
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region AppointmentChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Appointment.Appointment proxyws = new _1C.v4.Appointment.Appointment(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with appointmentchange and transaction
                        _1C.v4.Appointment.AppointmentChangeRequest proxyrequest = new _1C.v4.Appointment.AppointmentChangeRequest();

                        //Create proxy transaction
                        _1C.v4.Appointment.TransactionHeader2 proxytransactionheader = new _1C.v4.Appointment.TransactionHeader2();
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

                        //Create proxy appointmentchange
                        _1C.v4.Appointment.AppointmentChange proxyappointmentchange = new _1C.v4.Appointment.AppointmentChange();
                        if (request.AppointmentChange != null)
                        {
                            #region//Appointment Header
                            proxyappointmentchange.AppointmentChannel = request.AppointmentChange.AppointmentChannel;
                            proxyappointmentchange.AppointmentDateTimeLocal = request.AppointmentChange.AppointmentDateTimeLocal;
                            proxyappointmentchange.CloseDateTimeLocal = request.AppointmentChange.CloseDateTimeLocal;
                            proxyappointmentchange.CustomerComment = request.AppointmentChange.CustomerComment;
                            proxyappointmentchange.DeliveryDateTimeLocal = request.AppointmentChange.DeliveryDateTimeLocal;
                            proxyappointmentchange.DMSAppointmentID = request.AppointmentChange.DMSAppointmentID;
                            proxyappointmentchange.DMSAppointmentNo = request.AppointmentChange.DMSAppointmentNo;
                            proxyappointmentchange.DMSAppointmentStatus = request.AppointmentChange.DMSAppointmentStatus;
                            proxyappointmentchange.InMileage = request.AppointmentChange.InMileage;
                            proxyappointmentchange.OpenDateTimeLocal = request.AppointmentChange.OpenDateTimeLocal;
                            proxyappointmentchange.PaymentMethod = request.AppointmentChange.PaymentMethod;
                            proxyappointmentchange.SAEmployeeID = request.AppointmentChange.SAEmployeeID;
                            proxyappointmentchange.SAEmployeeName = request.AppointmentChange.SAEmployeeName;
                            proxyappointmentchange.ServiceType = request.AppointmentChange.ServiceType;
                            proxyappointmentchange.TCEmployeeID = request.AppointmentChange.TCEmployeeID;
                            proxyappointmentchange.TCEmployeeName = request.AppointmentChange.TCEmployeeName;
                            proxyappointmentchange.WorkType = request.AppointmentChange.WorkType;
                            #endregion

                            #region //Appointment AdditionalFields
                            if (request.AppointmentChange.AdditionalFields != null && request.AppointmentChange.AdditionalFields.Count > 0)
                            {
                                int additionalfieldscnt = 0;
                                _1C.v4.Appointment.AdditionalField1[] proxyadditionalfields = new _1C.v4.Appointment.AdditionalField1[request.AppointmentChange.AdditionalFields.Count];
                                foreach (AdditionalField additionalfield in request.AppointmentChange.AdditionalFields)
                                {
                                    _1C.v4.Appointment.AdditionalField1 proxyadditionalfield = new _1C.v4.Appointment.AdditionalField1();
                                    proxyadditionalfield.Name = additionalfield.AdditionalFieldName;
                                    proxyadditionalfield.Value = additionalfield.AdditionalFieldValue;
                                    proxyadditionalfields[additionalfieldscnt] = proxyadditionalfield;
                                    additionalfieldscnt++;
                                }
                                proxyappointmentchange.AdditionalFields = proxyadditionalfields;
                            }
                            #endregion

                            #region//Appointment Options
                            if (request.AppointmentChange.Options != null && request.AppointmentChange.Options.Count > 0)
                            {
                                int optionscnt = 0;
                                _1C.v4.Appointment.Option1[] proxyoptions = new _1C.v4.Appointment.Option1[request.AppointmentChange.Options.Count];
                                foreach (Option option in request.AppointmentChange.Options)
                                {
                                    _1C.v4.Appointment.Option1 proxyoption = new _1C.v4.Appointment.Option1();
                                    proxyoption.Name = option.OptionName;
                                    proxyoption.Value = option.OptionValue;
                                    proxyoptions[optionscnt] = proxyoption;
                                    optionscnt++;
                                }
                                proxyappointmentchange.Options = proxyoptions;
                            }
                            #endregion

                            #region//Appointment PriceType
                            if (request.AppointmentChange.PriceType != null)
                            {
                                _1C.v4.Appointment.PriceType1 proxypricetype = new _1C.v4.Appointment.PriceType1();
                                proxypricetype.DiscountPrice = request.AppointmentChange.PriceType.DiscountPrice;
                                proxypricetype.DiscountRate = request.AppointmentChange.PriceType.DiscountRate;
                                proxypricetype.TotalPrice = request.AppointmentChange.PriceType.TotalPrice;
                                proxypricetype.TotalPriceIncludeTax = request.AppointmentChange.PriceType.TotalPriceIncludeTax;
                                proxypricetype.UnitPrice = request.AppointmentChange.PriceType.UnitPrice;
                                proxyappointmentchange.PriceType = proxypricetype;
                            }
                            #endregion

                            #region//Appointment Customers
                            if (request.AppointmentChange.Customers != null && request.AppointmentChange.Customers.Count > 0)
                            {
                                int customerscnt = 0;
                                _1C.v4.Appointment.Customer2[] proxycustomers = new _1C.v4.Appointment.Customer2[request.AppointmentChange.Customers.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Customer.Customer customer in request.AppointmentChange.Customers)
                                {
                                    #region//Appointment Customer Header
                                    _1C.v4.Appointment.Customer2 proxycustomer = new _1C.v4.Appointment.Customer2();
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

                                    #region//Appointment Customer Addresses
                                    if (customer.Addresses != null && customer.Addresses.Count > 0)
                                    {
                                        int addressescnt = 0;
                                        _1C.v4.Appointment.Address1[] proxyaddresses = new _1C.v4.Appointment.Address1[customer.Addresses.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Address address in customer.Addresses)
                                        {
                                            _1C.v4.Appointment.Address1 proxyaddress = new _1C.v4.Appointment.Address1();
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

                                    #region//Appointment Customer Contacts
                                    if (customer.Contacts != null && customer.Contacts.Count > 0)
                                    {
                                        int contactscnt = 0;
                                        _1C.v4.Appointment.Contact2[] proxycontacts = new _1C.v4.Appointment.Contact2[customer.Contacts.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Contact contact in customer.Contacts)
                                        {
                                            _1C.v4.Appointment.Contact2 proxycontact = new _1C.v4.Appointment.Contact2();
                                            proxycontact.ContactMethodYN = contact.ContactMethodYN;
                                            proxycontact.ContactType = contact.ContactType;
                                            proxycontact.ContactValue = contact.ContactValue;
                                            proxycontacts[contactscnt] = proxycontact;
                                            contactscnt++;
                                        }
                                        proxycustomer.Contacts = proxycontacts;
                                    }
                                    #endregion

                                    #region//Appointment Customer SpecialMessage
                                    if (customer.SpecialMessage != null)
                                    {
                                        _1C.v4.Appointment.SpecialMessage1 proxyspecialmessage = new _1C.v4.Appointment.SpecialMessage1();
                                        proxyspecialmessage.Message = customer.SpecialMessage.Message;
                                        proxycustomer.SpecialMessage = proxyspecialmessage;
                                    }
                                    #endregion

                                    #region//Appointment Customer CorporateInfos
                                    if (customer.CorporateInfos != null && customer.CorporateInfos.Count > 0)
                                    {
                                        int corporateinfoscnt = 0;
                                        _1C.v4.Appointment.CorporateInfo1[] proxycorporateinfos = new _1C.v4.Appointment.CorporateInfo1[customer.CorporateInfos.Count];
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo corporateinfo in customer.CorporateInfos)
                                        {
                                            _1C.v4.Appointment.CorporateInfo1 proxycorporateinfo = new _1C.v4.Appointment.CorporateInfo1();
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
                                proxyappointmentchange.Customers = proxycustomers;
                            }
                            #endregion

                            #region//Appointment Vehicle
                            if (request.AppointmentChange.Vehicle != null)
                            {
                                #region//Appointment Vehicle Header
                                _1C.v4.Appointment.Vehicle2 proxyvehicle = new _1C.v4.Appointment.Vehicle2();
                                proxyvehicle.Color = request.AppointmentChange.Vehicle.Color;
                                proxyvehicle.Cylinders = request.AppointmentChange.Vehicle.Cylinders;
                                proxyvehicle.DateDelivered = request.AppointmentChange.Vehicle.DateDelivered;
                                proxyvehicle.DateInService = request.AppointmentChange.Vehicle.DateInService;
                                proxyvehicle.DeclinedJob = request.AppointmentChange.Vehicle.DeclinedJob;
                                proxyvehicle.DisplayDescription = request.AppointmentChange.Vehicle.DisplayDescription;
                                proxyvehicle.DMSVehicleNo = request.AppointmentChange.Vehicle.DMSVehicleNo;
                                proxyvehicle.EngineType = request.AppointmentChange.Vehicle.EngineType;
                                proxyvehicle.ExtendedWarranty = request.AppointmentChange.Vehicle.ExtendedWarranty;
                                proxyvehicle.FuelType = request.AppointmentChange.Vehicle.FuelType;
                                proxyvehicle.FullModelName = request.AppointmentChange.Vehicle.FullModelName;
                                proxyvehicle.InsuranceDate = request.AppointmentChange.Vehicle.InsuranceDate;
                                proxyvehicle.LastMileage = request.AppointmentChange.Vehicle.LastMileage;
                                proxyvehicle.LastServiceDate = request.AppointmentChange.Vehicle.LastServiceDate;
                                proxyvehicle.LastSixVIN = request.AppointmentChange.Vehicle.LastSixVIN;
                                proxyvehicle.LicenseNumber = request.AppointmentChange.Vehicle.LicenseNumber;
                                proxyvehicle.LicensePlateNo = request.AppointmentChange.Vehicle.LicensePlateNo;
                                proxyvehicle.Make = request.AppointmentChange.Vehicle.Make;
                                proxyvehicle.ModelCode = request.AppointmentChange.Vehicle.ModelCode;
                                proxyvehicle.ModelName = request.AppointmentChange.Vehicle.ModelName;
                                proxyvehicle.ModelYear = request.AppointmentChange.Vehicle.ModelYear;
                                proxyvehicle.PendingJob = request.AppointmentChange.Vehicle.PendingJob;
                                proxyvehicle.StockNumber = request.AppointmentChange.Vehicle.StockNumber;
                                proxyvehicle.Trim = request.AppointmentChange.Vehicle.Trim;
                                proxyvehicle.VehicleType = request.AppointmentChange.Vehicle.VehicleType;
                                proxyvehicle.VIN = request.AppointmentChange.Vehicle.VIN;
                                proxyvehicle.WarrantyMiles = request.AppointmentChange.Vehicle.WarrantyMiles;
                                proxyvehicle.WarrantyMonths = request.AppointmentChange.Vehicle.WarrantyMonths;
                                proxyvehicle.WarrantyStartDate = request.AppointmentChange.Vehicle.WarrantyStartDate;
                                #endregion

                                #region//Appointment Vehicle Campaigns
                                if (request.AppointmentChange.Vehicle.Campaigns != null && request.AppointmentChange.Vehicle.Campaigns.Count > 0)
                                {
                                    int campaignscnt = 0;
                                    _1C.v4.Appointment.Campaign1[] proxycampaigns = new _1C.v4.Appointment.Campaign1[request.AppointmentChange.Vehicle.Campaigns.Count];
                                    foreach (WA.Standard.IF.Data.v2.Common.Vehicle.Campaign campaign in request.AppointmentChange.Vehicle.Campaigns)
                                    {
                                        _1C.v4.Appointment.Campaign1 proxycampaign = new _1C.v4.Appointment.Campaign1();
                                        proxycampaign.CampaignDescription = campaign.CampaignDescription;
                                        proxycampaign.CampaignID = campaign.CampaignID;
                                        proxycampaign.CampaignPerformed = campaign.CampaignPerformed;
                                        proxycampaigns[campaignscnt] = proxycampaign;
                                        campaignscnt++;
                                    }
                                    proxyvehicle.Campaigns = proxycampaigns;
                                }
                                #endregion

                                proxyappointmentchange.Vehicle = proxyvehicle;
                            }
                            #endregion

                            #region//Appointment RequestItems
                            if (request.AppointmentChange.RequestItems != null && request.AppointmentChange.RequestItems.Count > 0)
                            {
                                int requestitemscnt = 0;
                                _1C.v4.Appointment.RequestItem1[] proxyrequestitems = new _1C.v4.Appointment.RequestItem1[request.AppointmentChange.RequestItems.Count];
                                foreach (RequestItem requestitem in request.AppointmentChange.RequestItems)
                                {
                                    #region//Appointment RequestItem Header
                                    _1C.v4.Appointment.RequestItem1 proxyrequestitem = new _1C.v4.Appointment.RequestItem1();
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

                                    #region//Appointment RequestItem Comments
                                    if (requestitem.Comments != null && requestitem.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _1C.v4.Appointment.Comment1[] proxycomments = new _1C.v4.Appointment.Comment1[requestitem.Comments.Count];
                                        foreach (Comment Comment in requestitem.Comments)
                                        {
                                            _1C.v4.Appointment.Comment1 proxycomment = new _1C.v4.Appointment.Comment1();
                                            proxycomment.DescriptionComment = Comment.DescriptionComment;
                                            proxycomment.SequenceNumber = Comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyrequestitem.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//Appointment RequestItem Descriptions
                                    if (requestitem.Descriptions != null && requestitem.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _1C.v4.Appointment.Description1[] proxydescriptions = new _1C.v4.Appointment.Description1[requestitem.Descriptions.Count];
                                        foreach (Description description in requestitem.Descriptions)
                                        {
                                            _1C.v4.Appointment.Description1 proxydescription = new _1C.v4.Appointment.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyrequestitem.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//Appointment RequestItem OPCodes
                                    if (requestitem.OPCodes != null && requestitem.OPCodes.Count > 0)
                                    {
                                        int opcodescnt = 0;
                                        _1C.v4.Appointment.OPCode1[] proxyopcodes = new _1C.v4.Appointment.OPCode1[requestitem.OPCodes.Count];
                                        foreach (OPCode opcode in requestitem.OPCodes)
                                        {
                                            #region//Appointment RequestItem OPCode Header
                                            _1C.v4.Appointment.OPCode1 proxyopcode = new _1C.v4.Appointment.OPCode1();
                                            proxyopcode.ActualHours = opcode.ActualHours;
                                            proxyopcode.Code = opcode.Code;
                                            proxyopcode.Description = opcode.Description;
                                            proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                            proxyopcode.SequenceNumber = opcode.SequenceNumber;
                                            proxyopcode.ServiceType = opcode.ServiceType;
                                            proxyopcode.SkillLevel = opcode.SkillLevel;
                                            #endregion

                                            #region//Appointment RequestItem OPCode Descriptions
                                            if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                            {
                                                int descriptionscnt = 0;
                                                _1C.v4.Appointment.Description1[] proxydescriptions = new _1C.v4.Appointment.Description1[opcode.Descriptions.Count];
                                                foreach (Description description in opcode.Descriptions)
                                                {
                                                    _1C.v4.Appointment.Description1 proxydescription = new _1C.v4.Appointment.Description1();
                                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                                    proxydescriptions[descriptionscnt] = proxydescription;
                                                    descriptionscnt++;
                                                }
                                                proxyopcode.Descriptions = proxydescriptions;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Causes
                                            if (opcode.Causes != null && opcode.Causes.Count > 0)
                                            {
                                                int causescnt = 0;
                                                _1C.v4.Appointment.Cause1[] proxycauses = new _1C.v4.Appointment.Cause1[opcode.Causes.Count];
                                                foreach (Cause cause in opcode.Causes)
                                                {
                                                    _1C.v4.Appointment.Cause1 proxycause = new _1C.v4.Appointment.Cause1();
                                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                                    proxycause.Comment = cause.Comment;
                                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                                    proxycauses[causescnt] = proxycause;
                                                    causescnt++;
                                                }
                                                proxyopcode.Causes = proxycauses;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Corrections
                                            if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                            {
                                                int correctionscnt = 0;
                                                _1C.v4.Appointment.Correction1[] proxycorrections = new _1C.v4.Appointment.Correction1[opcode.Corrections.Count];
                                                foreach (Correction Correction in opcode.Corrections)
                                                {
                                                    _1C.v4.Appointment.Correction1 proxycorrection = new _1C.v4.Appointment.Correction1();
                                                    proxycorrection.CorrectionLaborOpCode = Correction.CorrectionLaborOpCode;
                                                    proxycorrection.Comment = Correction.Comment;
                                                    proxycorrection.SequenceNumber = Correction.SequenceNumber;
                                                    proxycorrections[correctionscnt] = proxycorrection;
                                                    correctionscnt++;
                                                }
                                                proxyopcode.Corrections = proxycorrections;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode PriceType
                                            if (opcode.PriceType != null)
                                            {
                                                _1C.v4.Appointment.PriceType1 proxypricetype = new _1C.v4.Appointment.PriceType1();
                                                proxypricetype.DiscountPrice = opcode.PriceType.DiscountPrice;
                                                proxypricetype.DiscountRate = opcode.PriceType.DiscountRate;
                                                proxypricetype.TotalPrice = opcode.PriceType.TotalPrice;
                                                proxypricetype.TotalPriceIncludeTax = opcode.PriceType.TotalPriceIncludeTax;
                                                proxypricetype.UnitPrice = opcode.PriceType.UnitPrice;
                                                proxyopcode.PriceType = proxypricetype;
                                            }
                                            #endregion

                                            #region//Appointment RequestItem OPCode Parts
                                            if (opcode.Parts != null && opcode.Parts.Count > 0)
                                            {
                                                int partscnt = 0;
                                                _1C.v4.Appointment.Part1[] proxyparts = new _1C.v4.Appointment.Part1[opcode.Parts.Count];
                                                foreach (Part part in opcode.Parts)
                                                {
                                                    #region//Appointment RequestItem OPCode Parts Header
                                                    _1C.v4.Appointment.Part1 proxypart = new _1C.v4.Appointment.Part1();
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

                                                    #region//Appointment RequestItem OPCode Parts Descriptions
                                                    if (part.Descriptions != null && part.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _1C.v4.Appointment.Description1[] proxydescriptions = new _1C.v4.Appointment.Description1[part.Descriptions.Count];
                                                        foreach (Description description in part.Descriptions)
                                                        {
                                                            _1C.v4.Appointment.Description1 proxydescription = new _1C.v4.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxypart.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Parts PriceType
                                                    if (part.PriceType != null)
                                                    {
                                                        _1C.v4.Appointment.PriceType1 proxypricetype = new _1C.v4.Appointment.PriceType1();
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

                                            #region//Appointment RequestItem OPCode Sublets
                                            if (opcode.Sublets != null && opcode.Sublets.Count > 0)
                                            {
                                                int subletscnt = 0;
                                                _1C.v4.Appointment.Sublet1[] proxysublets = new _1C.v4.Appointment.Sublet1[opcode.Sublets.Count];
                                                foreach (Sublet sublet in opcode.Sublets)
                                                {
                                                    #region//Appointment RequestItem OPCode Sublets Header
                                                    _1C.v4.Appointment.Sublet1 proxysublet = new _1C.v4.Appointment.Sublet1();
                                                    proxysublet.SequenceNumber = sublet.SequenceNumber;
                                                    proxysublet.ServiceType = sublet.ServiceType;
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Sublets Descriptions
                                                    if (sublet.Descriptions != null && sublet.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _1C.v4.Appointment.Description1[] proxydescriptions = new _1C.v4.Appointment.Description1[sublet.Descriptions.Count];
                                                        foreach (Description description in sublet.Descriptions)
                                                        {
                                                            _1C.v4.Appointment.Description1 proxydescription = new _1C.v4.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxysublet.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode Sublets PriceType
                                                    if (sublet.PriceType != null)
                                                    {
                                                        _1C.v4.Appointment.PriceType1 proxypricetype = new _1C.v4.Appointment.PriceType1();
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

                                            #region//Appointment RequestItem OPCode MISCs
                                            if (opcode.MISCs != null && opcode.MISCs.Count > 0)
                                            {
                                                int miscscnt = 0;
                                                _1C.v4.Appointment.MISC1[] proxymiscs = new _1C.v4.Appointment.MISC1[opcode.MISCs.Count];
                                                foreach (MISC misc in opcode.MISCs)
                                                {
                                                    #region//Appointment RequestItem OPCode MISCs Header
                                                    _1C.v4.Appointment.MISC1 proxymisc = new _1C.v4.Appointment.MISC1();
                                                    proxymisc.SequenceNumber = misc.SequenceNumber;
                                                    proxymisc.ServiceType = misc.ServiceType;
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode MISCs Descriptions
                                                    if (misc.Descriptions != null && misc.Descriptions.Count > 0)
                                                    {
                                                        int descriptionscnt = 0;
                                                        _1C.v4.Appointment.Description1[] proxydescriptions = new _1C.v4.Appointment.Description1[misc.Descriptions.Count];
                                                        foreach (Description description in misc.Descriptions)
                                                        {
                                                            _1C.v4.Appointment.Description1 proxydescription = new _1C.v4.Appointment.Description1();
                                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                                            proxydescriptions[descriptionscnt] = proxydescription;
                                                            descriptionscnt++;
                                                        }
                                                        proxymisc.Descriptions = proxydescriptions;
                                                    }
                                                    #endregion

                                                    #region//Appointment RequestItem OPCode MISCs PriceType
                                                    if (misc.PriceType != null)
                                                    {
                                                        _1C.v4.Appointment.PriceType1 proxypricetype = new _1C.v4.Appointment.PriceType1();
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
                                proxyappointmentchange.RequestItems = proxyrequestitems;
                            }
                            #endregion

                            proxyrequest.AppointmentChange = proxyappointmentchange;
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Appointment.AppointmentChangeResponse proxyresponse = proxyws.AppointmentChange(proxyrequest);

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
                                foreach (_1C.v4.Appointment.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//AppointmentChangeResponse Set

                                //if (proxyresponse.Appointment != null)
                                //{
                                //#region //Appointment Header
                                //_1C.v4.Appointment.Appointment2 proxyappointment = proxyresponse.Appointment;

                                //Appointment appointment = new Appointment();
                                //appointment.AppointmentDateTimeLocal = proxyappointment.AppointmentDateTimeLocal;
                                //appointment.CloseDateTimeLocal = proxyappointment.CloseDateTimeLocal;
                                //appointment.CustomerComment = proxyappointment.CustomerComment;
                                //appointment.DeliveryDateTimeLocal = proxyappointment.DeliveryDateTimeLocal;
                                //appointment.DMSAppointmentID = proxyappointment.DMSAppointmentID;
                                //appointment.DMSAppointmentNo = proxyappointment.DMSAppointmentNo;
                                //appointment.DMSAppointmentStatus = proxyappointment.DMSAppointmentStatus;
                                //appointment.InMileage = proxyappointment.InMileage;
                                //appointment.OpenDateTimeLocal = proxyappointment.OpenDateTimeLocal;
                                //appointment.PaymentMethod = proxyappointment.PaymentMethod;
                                //appointment.SAEmployeeID = proxyappointment.SAEmployeeID;
                                //appointment.SAEmployeeName = proxyappointment.SAEmployeeName;
                                //appointment.ServiceType = proxyappointment.ServiceType;
                                //appointment.TCEmployeeID = proxyappointment.TCEmployeeID;
                                //appointment.TCEmployeeName = proxyappointment.TCEmployeeName;
                                //appointment.WorkType = proxyappointment.WorkType;
                                //#endregion

                                //#region //Appointment AdditionalFields
                                //if (proxyappointment.AdditionalFields != null && proxyappointment.AdditionalFields.Length > 0)
                                //{
                                //    appointment.AdditionalFields = new List<AdditionalField>();
                                //    foreach (_1C.v4.Appointment.AdditionalField2 proxyadditionalfield in proxyappointment.AdditionalFields)
                                //    {
                                //        AdditionalField additionalfield = new AdditionalField();
                                //        additionalfield.Name = proxyadditionalfield.Name;
                                //        additionalfield.Value = proxyadditionalfield.Value;
                                //        appointment.AdditionalFields.Add(additionalfield);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment JobRefs
                                //if (proxyappointment.JobRefs != null && proxyappointment.JobRefs.Length > 0)
                                //{
                                //    appointment.JobRefs = new List<JobRef>();
                                //    foreach (_1C.v4.Appointment.JobRef1 proxyjobref in proxyappointment.JobRefs)
                                //    {
                                //        JobRef jobref = new JobRef();
                                //        jobref.DMSJobNo = proxyjobref.DMSJobNo;
                                //        jobref.DMSJobStatus = proxyjobref.DMSJobStatus;
                                //        appointment.JobRefs.Add(jobref);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment ManagementFields
                                //if (proxyappointment.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyappointment.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyappointment.ManagementFields.LastModifiedDateTimeUTC;
                                //    appointment.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//Appointment Options
                                //if (proxyappointment.Options != null && proxyappointment.Options.Length > 0)
                                //{
                                //    appointment.Options = new List<Option>();
                                //    foreach (_1C.v4.Appointment.Option2 proxyoption in proxyappointment.Options)
                                //    {
                                //        Option option = new Option();
                                //        option.Name = proxyoption.Name;
                                //        option.Value = proxyoption.Value;
                                //        appointment.Options.Add(option);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment PriceType
                                //if (proxyappointment.PriceType != null)
                                //{
                                //    PriceType pricetype = new PriceType();
                                //    pricetype.DiscountPrice = proxyappointment.PriceType.DiscountPrice;
                                //    pricetype.DiscountRate = proxyappointment.PriceType.DiscountRate;
                                //    pricetype.TotalPrice = proxyappointment.PriceType.TotalPrice;
                                //    pricetype.TotalPriceIncludeTax = proxyappointment.PriceType.TotalPriceIncludeTax;
                                //    pricetype.UnitPrice = proxyappointment.PriceType.UnitPrice;
                                //    appointment.PriceType = pricetype;
                                //}
                                //#endregion

                                //#region//Appointment RORefs
                                //if (proxyappointment.RORefs != null && proxyappointment.RORefs.Length > 0)
                                //{
                                //    appointment.RORefs = new List<RORef>();
                                //    foreach (_1C.v4.Appointment.RORef1 proxyroref in proxyappointment.RORefs)
                                //    {
                                //        RORef roref = new RORef();
                                //        roref.DMSRONo = proxyroref.DMSRONo;
                                //        roref.DMSROStatus = proxyroref.DMSROStatus;
                                //        appointment.RORefs.Add(roref);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment Customers
                                //if (proxyappointment.Customers != null && proxyappointment.Customers.Length > 0)
                                //{
                                //    appointment.Customers = new List<Data.v2.Common.Customer.Customer>();
                                //    foreach (_1C.v4.Appointment.Customer3 proxycustomer in proxyappointment.Customers)
                                //    {
                                //        #region//Appointment Customer Header
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

                                //        #region//Appointment Customer Addresses
                                //        if (proxycustomer.Addresses != null && proxycustomer.Addresses.Length > 0)
                                //        {
                                //            customer.Addresses = new List<Data.v2.Common.Customer.Address>();
                                //            foreach (_1C.v4.Appointment.Address2 proxyaddress in proxycustomer.Addresses)
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

                                //        #region//Appointment Customer Contacts
                                //        if (proxycustomer.Contacts != null && proxycustomer.Contacts.Length > 0)
                                //        {
                                //            customer.Contacts = new List<Data.v2.Common.Customer.Contact>();
                                //            foreach (_1C.v4.Appointment.Contact3 proxycontact in proxycustomer.Contacts)
                                //            {
                                //                Data.v2.Common.Customer.Contact contact = new Data.v2.Common.Customer.Contact();
                                //                contact.ContactMethodYN = proxycontact.ContactMethodYN;
                                //                contact.ContactType = proxycontact.ContactType;
                                //                contact.ContactValue = proxycontact.ContactValue;
                                //                customer.Contacts.Add(contact);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment Customer SpecialMessage
                                //        if (proxycustomer.SpecialMessage != null)
                                //        {
                                //            Data.v2.Common.Customer.SpecialMessage specialmessage = new Data.v2.Common.Customer.SpecialMessage();
                                //            specialmessage.Message = proxycustomer.SpecialMessage.Message;
                                //            customer.SpecialMessage = specialmessage;
                                //        }
                                //        #endregion

                                //        appointment.Customers.Add(customer);
                                //    }
                                //}
                                //#endregion

                                //#region//Appointment Vehicle
                                //if (proxyappointment.Vehicle != null)
                                //{
                                //    #region//Appointment Vehicle Header
                                //    Data.v2.Common.Vehicle.Vehicle vehicle = new Data.v2.Common.Vehicle.Vehicle();
                                //    vehicle.Color = proxyappointment.Vehicle.Color;
                                //    vehicle.Cylinders = proxyappointment.Vehicle.Cylinders;
                                //    vehicle.DateDelivered = proxyappointment.Vehicle.DateDelivered;
                                //    vehicle.DateInService = proxyappointment.Vehicle.DateInService;
                                //    vehicle.DeclinedJob = proxyappointment.Vehicle.DeclinedJob;
                                //    vehicle.DisplayDescription = proxyappointment.Vehicle.DisplayDescription;
                                //    vehicle.DMSVehicleNo = proxyappointment.Vehicle.DMSVehicleNo;
                                //    vehicle.EngineType = proxyappointment.Vehicle.EngineType;
                                //    vehicle.ExtendedWarranty = proxyappointment.Vehicle.ExtendedWarranty;
                                //    vehicle.FuelType = proxyappointment.Vehicle.FuelType;
                                //    vehicle.FullModelName = proxyappointment.Vehicle.FullModelName;
                                //    vehicle.InsuranceDate = proxyappointment.Vehicle.InsuranceDate;
                                //    vehicle.LastMileage = proxyappointment.Vehicle.LastMileage;
                                //    vehicle.LastServiceDate = proxyappointment.Vehicle.LastServiceDate;
                                //    vehicle.LastSixVIN = proxyappointment.Vehicle.LastSixVIN;
                                //    vehicle.LicenseNumber = proxyappointment.Vehicle.LicenseNumber;
                                //    vehicle.LicensePlateNo = proxyappointment.Vehicle.LicensePlateNo;
                                //    vehicle.Make = proxyappointment.Vehicle.Make;
                                //    vehicle.ModelCode = proxyappointment.Vehicle.ModelCode;
                                //    vehicle.ModelName = proxyappointment.Vehicle.ModelName;
                                //    vehicle.ModelYear = proxyappointment.Vehicle.ModelYear;
                                //    vehicle.PendingJob = proxyappointment.Vehicle.PendingJob;
                                //    vehicle.StockNumber = proxyappointment.Vehicle.StockNumber;
                                //    vehicle.Trim = proxyappointment.Vehicle.Trim;
                                //    vehicle.VehicleType = proxyappointment.Vehicle.VehicleType;
                                //    vehicle.VIN = proxyappointment.Vehicle.VIN;
                                //    vehicle.WarrantyMiles = proxyappointment.Vehicle.WarrantyMiles;
                                //    vehicle.WarrantyMonths = proxyappointment.Vehicle.WarrantyMonths;
                                //    vehicle.WarrantyStartDate = proxyappointment.Vehicle.WarrantyStartDate;
                                //    #endregion

                                //    #region//Appointment Vehicle Campaigns
                                //    if (proxyappointment.Vehicle.Campaigns != null && proxyappointment.Vehicle.Campaigns.Length > 0)
                                //    {
                                //        vehicle.Campaigns = new List<Data.v2.Common.Vehicle.Campaign>();
                                //        foreach (_1C.v4.Appointment.Campaign2 proxycampaign in proxyappointment.Vehicle.Campaigns)
                                //        {
                                //            Data.v2.Common.Vehicle.Campaign campaign = new Data.v2.Common.Vehicle.Campaign();
                                //            campaign.CampaignDescription = proxycampaign.CampaignDescription;
                                //            campaign.CampaignID = proxycampaign.CampaignID;
                                //            campaign.CampaignPerformed = proxycampaign.CampaignPerformed;
                                //            vehicle.Campaigns.Add(campaign);
                                //        }
                                //    }
                                //    #endregion

                                //    appointment.Vehicle = vehicle;
                                //}
                                //#endregion

                                //#region//Appointment RequestItems
                                //if (proxyappointment.RequestItems != null && proxyappointment.RequestItems.Length > 0)
                                //{
                                //    appointment.RequestItems = new List<RequestItem>();
                                //    foreach (_1C.v4.Appointment.RequestItem2 proxyrequestitem in proxyappointment.RequestItems)
                                //    {
                                //        #region//Appointment RequestItem Header
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

                                //        #region//Appointment RequestItem Comments
                                //        if (proxyrequestitem.Comments != null && proxyrequestitem.Comments.Length > 0)
                                //        {
                                //            requestitem.Comments = new List<Comment>();
                                //            foreach (_1C.v4.Appointment.Comment2 proxycomment in proxyrequestitem.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                requestitem.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment RequestItem Descriptions
                                //        if (proxyrequestitem.Descriptions != null && proxyrequestitem.Descriptions.Length > 0)
                                //        {
                                //            requestitem.Descriptions = new List<Description>();
                                //            foreach (_1C.v4.Appointment.Description2 proxydescription in proxyrequestitem.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                requestitem.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Appointment RequestItem OPCodes
                                //        if (proxyrequestitem.OPCodes != null && proxyrequestitem.OPCodes.Length > 0)
                                //        {
                                //            requestitem.OPCodes = new List<OPCode>();
                                //            foreach (_1C.v4.Appointment.OPCode2 proxyopcode in proxyrequestitem.OPCodes)
                                //            {
                                //                #region//Appointment RequestItem OPCode Header
                                //                OPCode opcode = new OPCode();
                                //                opcode.ActualHours = proxyopcode.ActualHours;
                                //                opcode.Code = proxyopcode.Code;
                                //                opcode.Description = proxyopcode.Description;
                                //                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //                opcode.SequenceNumber = proxyopcode.SequenceNumber;
                                //                opcode.ServiceType = proxyopcode.ServiceType;
                                //                opcode.SkillLevel = proxyopcode.SkillLevel;
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Descriptions
                                //                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //                {
                                //                    opcode.Descriptions = new List<Description>();
                                //                    foreach (_1C.v4.Appointment.Description2 proxydescription in proxyopcode.Descriptions)
                                //                    {
                                //                        Description description = new Description();
                                //                        description.DescriptionComment = proxydescription.DescriptionComment;
                                //                        description.SequenceNumber = proxydescription.SequenceNumber;
                                //                        opcode.Descriptions.Add(description);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Causes
                                //                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //                {
                                //                    opcode.Causes = new List<Cause>();
                                //                    foreach (_1C.v4.Appointment.Cause2 proxycause in proxyopcode.Causes)
                                //                    {
                                //                        Cause cause = new Cause();
                                //                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                        cause.Comment = proxycause.Comment;
                                //                        cause.SequenceNumber = proxycause.SequenceNumber;
                                //                        opcode.Causes.Add(cause);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode Corrections
                                //                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //                {
                                //                    opcode.Corrections = new List<Correction>();
                                //                    foreach (_1C.v4.Appointment.Correction2 proxycorrection in proxyopcode.Corrections)
                                //                    {
                                //                        Correction correction = new Correction();
                                //                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                        correction.Comment = proxycorrection.Comment;
                                //                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                        opcode.Corrections.Add(correction);
                                //                    }
                                //                }
                                //                #endregion

                                //                #region//Appointment RequestItem OPCode PriceType
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

                                //                #region//Appointment RequestItem OPCode Parts
                                //                if (proxyopcode.Parts != null && proxyopcode.Parts.Length > 0)
                                //                {
                                //                    opcode.Parts = new List<Part>();
                                //                    foreach (_1C.v4.Appointment.Part2 proxypart in proxyopcode.Parts)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode Parts Header
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

                                //                        #region//Appointment RequestItem OPCode Parts Descriptions
                                //                        if (proxypart.Descriptions != null && proxypart.Descriptions.Length > 0)
                                //                        {
                                //                            part.Descriptions = new List<Description>();
                                //                            foreach (_1C.v4.Appointment.Description2 proxydescription in proxypart.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                part.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Parts PriceType
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

                                //                #region//Appointment RequestItem OPCode Sublets
                                //                if (proxyopcode.Sublets != null && proxyopcode.Sublets.Length > 0)
                                //                {
                                //                    opcode.Sublets = new List<Sublet>();
                                //                    foreach (_1C.v4.Appointment.Sublet2 proxysublet in proxyopcode.Sublets)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode Sublet Header
                                //                        Sublet sublet = new Sublet();
                                //                        sublet.SequenceNumber = proxysublet.SequenceNumber;
                                //                        sublet.ServiceType = proxysublet.ServiceType;
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Sublets Descriptions
                                //                        if (proxysublet.Descriptions != null && proxysublet.Descriptions.Length > 0)
                                //                        {
                                //                            sublet.Descriptions = new List<Description>();
                                //                            foreach (_1C.v4.Appointment.Description2 proxydescription in proxysublet.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                sublet.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode Sublets PriceType
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

                                //                #region//Appointment RequestItem OPCode MISCs
                                //                if (proxyopcode.MISCs != null && proxyopcode.MISCs.Length > 0)
                                //                {
                                //                    opcode.MISCs = new List<MISC>();
                                //                    foreach (_1C.v4.Appointment.MISC2 proxymisc in proxyopcode.MISCs)
                                //                    {
                                //                        #region//Appointment RequestItem OPCode MISC Header
                                //                        MISC misc = new MISC();
                                //                        misc.SequenceNumber = proxymisc.SequenceNumber;
                                //                        misc.ServiceType = proxymisc.ServiceType;
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode MISCs Descriptions
                                //                        if (proxymisc.Descriptions != null && proxymisc.Descriptions.Length > 0)
                                //                        {
                                //                            misc.Descriptions = new List<Description>();
                                //                            foreach (_1C.v4.Appointment.Description2 proxydescription in proxymisc.Descriptions)
                                //                            {
                                //                                Description description = new Description();
                                //                                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                                misc.Descriptions.Add(description);
                                //                            }
                                //                        }
                                //                        #endregion

                                //                        #region//Appointment RequestItem OPCode MISCs PriceType
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

                                //        appointment.RequestItems.Add(requestitem);
                                //    }
                                //}
                                //#endregion

                                //response.Appointment = appointment;
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
