using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Appointment;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Customer;
using WA.Standard.IF.Data.v2.Common.Vehicle;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class Appointment_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public AppointmentGetResponse AppointmentGet(AppointmentGetRequest request)
        {
            AppointmentGetResponse response = new AppointmentGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Appointment_Proxy proxy = new Proxy.v2.Common.Appointment_Proxy();
                response = proxy.AppointmentGet(request);               
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                List<Appointment> Appointments = Util.DataHelper.GetListByElementName<Appointment>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Appointments.xml"), "Appointment");

                if (Appointments != null && Appointments.Count > 0)
                {
                    List<Appointment> resultlist = Appointments
                        .Where(item =>
                            ((request.AppointmentGet.AppointmentDateTimeFromLocal == null || item.AppointmentDateTimeLocal >= request.AppointmentGet.AppointmentDateTimeFromLocal)
                                && (request.AppointmentGet.AppointmentDateTimeToLocal == null || item.AppointmentDateTimeLocal <= request.AppointmentGet.AppointmentDateTimeToLocal) && (string.IsNullOrEmpty(request.AppointmentGet.DMSAppointmentID) || item.DMSAppointmentID == request.AppointmentGet.DMSAppointmentID)
                                && (string.IsNullOrEmpty(request.AppointmentGet.DMSAppointmentNo) || item.DMSAppointmentNo == request.AppointmentGet.DMSAppointmentNo)
                                && (string.IsNullOrEmpty(request.AppointmentGet.DMSAppointmentStatus) || item.DMSAppointmentStatus == request.AppointmentGet.DMSAppointmentStatus)
                                && (request.AppointmentGet.LastModifiedDateTimeFromUTC == null || item.ManagementFields.LastModifiedDateTimeUTC >= request.AppointmentGet.LastModifiedDateTimeFromUTC)
                                && (request.AppointmentGet.LastModifiedDateTimeToUTC == null || item.ManagementFields.LastModifiedDateTimeUTC <= request.AppointmentGet.LastModifiedDateTimeToUTC)
                                && (string.IsNullOrEmpty(request.AppointmentGet.SAEmployeeID) || item.SAEmployeeID == request.AppointmentGet.SAEmployeeID)
                                && (string.IsNullOrEmpty(request.AppointmentGet.SAEmployeeName) || item.SAEmployeeName == request.AppointmentGet.SAEmployeeName)
                                && (string.IsNullOrEmpty(request.AppointmentGet.TCEmployeeID) || item.TCEmployeeID == request.AppointmentGet.TCEmployeeID)
                                && (string.IsNullOrEmpty(request.AppointmentGet.TCEmployeeName) || item.TCEmployeeName == request.AppointmentGet.TCEmployeeName)
                                //Need to add condition, Contacts
                            )
                            &&
                            (request.AppointmentGet.Vehicle == null || (request.AppointmentGet.Vehicle != null
                                && (string.IsNullOrEmpty(request.AppointmentGet.Vehicle.DMSVehicleNo) || request.AppointmentGet.Vehicle.DMSVehicleNo == item.Vehicle.DMSVehicleNo)
                                && (string.IsNullOrEmpty(request.AppointmentGet.Vehicle.LastSixVIN) || request.AppointmentGet.Vehicle.LastSixVIN == item.Vehicle.LastSixVIN)
                                && (string.IsNullOrEmpty(request.AppointmentGet.Vehicle.VIN) || request.AppointmentGet.Vehicle.VIN == item.Vehicle.VIN))
                            )
                            ).ToList<Appointment>();

                    response.Appointments = resultlist;

                    if(resultlist.Count >0)
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
                /* For DB Process

                    DataSet resultDS = new DataSet();
                    using (Appointment_Dac dac = new Appointment_Dac())
                    {
                        if (request.AppointmentGet.Customer != null && request.AppointmentGet.Customer.Contacts != null)
                        {
                            foreach (WA.Standard.IF.Data.v2.Common.Appointment.Contact contact in request.AppointmentGet.Customer.Contacts)
                            {
                                DataSet ds = dac.SelectAppointment(request.TransactionHeader.CountryID
                                                                    , request.TransactionHeader.DistributorID
                                                                    , request.TransactionHeader.GroupID
                                                                    , request.TransactionHeader.DealerID
                                                                    , request.TransactionHeader.Language // Need to check
                                                                    , contact.ContactType
                                                                    , contact.ContactValue
                                                                    , request.AppointmentGet
                                                                    );
                                //Merging all data. Because same appointment could be return from sql server.
                                resultDS.Merge(ds);
                            }

                            //Remove duplicate rows by key field
                            if (resultDS.Tables != null)
                            {
                                for (int i = 0; i < resultDS.Tables.Count; i++)
                                {
                                    if (i == 0)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSAppointmentNo");
                                    else if (i == 1)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSJobNo");
                                    else if (i == 2)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSRONo");
                                    else if (i == 3)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCustomerNo");
                                    else if (i == 4)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSAddressNo");
                                    else if (i == 5)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSContactNo");
                                    else if (i == 6)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCorporateNo");
                                    else if (i == 7)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSVehicleNo");
                                    else if (i == 8)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCampaignNo");
                                    else if (i == 9)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSAdditionalFieldNo");
                                    else if (i == 10)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSOptionNo");
                                    else if (i == 11)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "ServiceLineNumber");
                                    else if (i == 12)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "SequenceNumber");
                                    else if (i == 13)
                                        Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSPriceTypeNo");
                                }
                            }
                        }
                        else
                        {
                            resultDS = dac.SelectAppointment(request.TransactionHeader.CountryID
                                                                    , request.TransactionHeader.DistributorID
                                                                    , request.TransactionHeader.GroupID
                                                                    , request.TransactionHeader.DealerID
                                                                    , request.TransactionHeader.Language // Need to check
                                                                    , null //contact.ContactType
                                                                    , null //contact.ContactValue
                                                                    , request.AppointmentGet
                                                                    );
                        }
                    }

                    //0.Appointment & ManagementField
                    //1.JobRefs
                    //2.RORefs
                    //3.Customers
                    //4.Addresses
                    //5.Contacts
                    //6.CorporateInfos
                    //7.Vehicle
                    //8.Campaigns
                    //9.AdditionalFields
                    //10.Options
                    //11.RequestItems
                    //12.RequestItem Comments & Descriptions
                    //12.OPCodes & Descriptions & Causes & Corrections 
                    //12.Parts & Descriptions
                    //12.MISCs & Descriptions
                    //12.Sublets & Descriptions
                    //13.AppointmentPrice & RequestItemPrice & OPPrice & PartPrice & MISCPrice & SubletPrice

                    //List<RODocument> RODocuments = null;
                    //List<RepairOrder> Appointments = null;
                    //List<AppointmentRef> AppointmentRefs = null;
                    //List<CustomerPart> CustomerParts = null;

                    List<Appointment> Appointments = null;
                    if (resultDS.Tables.Count > 0 && resultDS.Tables[0].Rows.Count > 0)
                    {
                        #region AppointmentGet

                        #region Appointments
                        Appointments = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new Appointment
                        {
                            AppointmentChannel = Util.DataHelper.ConvertObjectToString(row["AppointmentChannel"]),
                            AppointmentDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["AppointmentDateTimeLocal"]),
                            CloseDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["CloseDateTimeLocal"]),
                            CustomerComment = Util.DataHelper.ConvertObjectToString(row["CustomerComment"]),
                            DeliveryDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["DeliveryDateTimeLocal"]),
                            DMSAppointmentID = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentID"]),
                            DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"]),
                            DMSAppointmentStatus = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentStatus"]),
                            InMileage = Util.DataHelper.ConvertObjectToString(row["InMileage"]),
                            OpenDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["OpenDateTimeLocal"]),
                            PaymentMethod = Util.DataHelper.ConvertObjectToString(row["PaymentMethod"]),
                            SAEmployeeID = Util.DataHelper.ConvertObjectToString(row["SAEmployeeID"]),
                            SAEmployeeName = Util.DataHelper.ConvertObjectToString(row["SAEmployeeName"]),
                            ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                            TCEmployeeID = Util.DataHelper.ConvertObjectToString(row["TCEmployeeID"]),
                            TCEmployeeName = Util.DataHelper.ConvertObjectToString(row["TCEmployeeName"]),
                            WorkType = Util.DataHelper.ConvertObjectToString(row["WorkType"]),
                            ManagementFields = new ManagementFields()
                            {
                                CreateDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["CreateDateTimeUTC"]),
                                LastModifiedDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["LastModifiedDateTimeUTC"])
                            },
                            JobRefs = new List<JobRef>(),
                            RORefs = new List<RORef>(),
                            AdditionalFields = new List<AdditionalField>(),
                            Options = new List<Option>(),
                            PriceType = new PriceType(),
                            Customers = new List<Data.v2.Common.Customer.Customer>(),
                            Vehicle = new Data.v2.Common.Vehicle.Vehicle(),
                            RequestItems = new List<RequestItem>(),
                        }).ToList();
                        #endregion

                        if (Appointments != null && Appointments.Count > 0)
                        {
                            foreach (Appointment appointment in Appointments)
                            {
                                if (resultDS.Tables.Count > 1 && resultDS.Tables[1].Rows.Count > 0)
                                {
                                    #region JobRefs
                                    List<JobRef> JobRefs = null;
                                    JobRefs = resultDS.Tables[1].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new JobRef
                                    {
                                        DMSJobNo = Util.DataHelper.ConvertObjectToString(row["DMSJobNo"]),
                                        DMSJobStatus = Util.DataHelper.ConvertObjectToString(row["DMSJobStatus"]),
                                    }).ToList();
                                    if (JobRefs != null && JobRefs.Count > 0)
                                        appointment.JobRefs = JobRefs;
                                    #endregion

                                }

                                if (resultDS.Tables.Count > 2 && resultDS.Tables[2].Rows.Count > 0)
                                {
                                    #region RORefs
                                    List<RORef> RORefs = null;
                                    RORefs = resultDS.Tables[2].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new RORef
                                    {
                                        DMSRONo = Util.DataHelper.ConvertObjectToString(row["DMSRONo"]),
                                        DMSROStatus = Util.DataHelper.ConvertObjectToString(row["DMSROStatus"]),
                                    }).ToList();
                                    if (RORefs != null && RORefs.Count > 0)
                                        appointment.RORefs = RORefs;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 3 && resultDS.Tables[3].Rows.Count > 0)
                                {
                                    #region Customers & SpecialMessage
                                    List<WA.Standard.IF.Data.v2.Common.Customer.Customer> Customers = null;
                                    Customers = resultDS.Tables[3].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new WA.Standard.IF.Data.v2.Common.Customer.Customer
                                    {
                                        CardNo = Util.DataHelper.ConvertObjectToString(row["CardNo"]),
                                        CustomerInfoType = Util.DataHelper.ConvertObjectToString(row["CustomerInfoType"]),
                                        DMSCustomerNo = Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"]),
                                        Email = Util.DataHelper.ConvertObjectToString(row["Email"]),
                                        FirstName = Util.DataHelper.ConvertObjectToString(row["FirstName"]),
                                        FullName = Util.DataHelper.ConvertObjectToString(row["FullName"]),
                                        Gender = Util.DataHelper.ConvertObjectToString(row["Gender"]),
                                        LastName = Util.DataHelper.ConvertObjectToString(row["LastName"]),
                                        MiddleName = Util.DataHelper.ConvertObjectToString(row["MiddleName"]),
                                        Salutation = Util.DataHelper.ConvertObjectToString(row["Salutation"]),
                                        SpecialMessage = new SpecialMessage() { Message = Util.DataHelper.ConvertObjectToString(row["SpecialMessage"]) },
                                        Addresses = new List<Address>(),
                                        Contacts = new List<Data.v2.Common.Customer.Contact>(),
                                        CorporateInfos = new List<CorporateInfo>(),
                                    }).ToList();
                                    #endregion

                                    if (Customers != null && Customers.Count > 0)
                                    {
                                        foreach (WA.Standard.IF.Data.v2.Common.Customer.Customer customer in Customers)
                                        {
                                            if (resultDS.Tables.Count > 4 && resultDS.Tables[4].Rows.Count > 0)
                                            {
                                                #region Addresses
                                                List<Address> Addresses = null;
                                                Addresses = resultDS.Tables[4].AsEnumerable()
                                                    .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customer.DMSCustomerNo)
                                                    .Select(row =>
                                                new Address
                                                {
                                                    Address1 = Util.DataHelper.ConvertObjectToString(row["Address1"]),
                                                    Address2 = Util.DataHelper.ConvertObjectToString(row["Address2"]),
                                                    AddressType = Util.DataHelper.ConvertObjectToString(row["AddressType"]),
                                                    City = Util.DataHelper.ConvertObjectToString(row["City"]),
                                                    Country = Util.DataHelper.ConvertObjectToString(row["Country"]),
                                                    State = Util.DataHelper.ConvertObjectToString(row["State"]),
                                                    ZipCode = Util.DataHelper.ConvertObjectToString(row["ZipCode"]),
                                                }).ToList();
                                                if (Addresses != null && Addresses.Count > 0)
                                                    customer.Addresses = Addresses;
                                                #endregion
                                            }

                                            if (resultDS.Tables.Count > 5 && resultDS.Tables[5].Rows.Count > 0)
                                            {
                                                #region Contacts
                                                List<WA.Standard.IF.Data.v2.Common.Customer.Contact> Contacts = null;
                                                Contacts = resultDS.Tables[5].AsEnumerable()
                                                    .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customer.DMSCustomerNo)
                                                    .Select(row =>
                                                new WA.Standard.IF.Data.v2.Common.Customer.Contact
                                                {
                                                    ContactMethodYN = Util.DataHelper.ConvertObjectToString(row["ContactMethodYN"]),
                                                    ContactType = Util.DataHelper.ConvertObjectToString(row["ContactType"]),
                                                    ContactValue = Util.DataHelper.ConvertObjectToString(row["ContactValue"]),
                                                }).ToList();
                                                if (Contacts != null && Contacts.Count > 0)
                                                    customer.Contacts = Contacts;
                                                #endregion
                                            }

                                            if (resultDS.Tables.Count > 6 && resultDS.Tables[6].Rows.Count > 0)
                                            {
                                                #region CorporateInfos
                                                List<WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo> CorporateInfos = null;
                                                CorporateInfos = resultDS.Tables[6].AsEnumerable()
                                                    .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customer.DMSCustomerNo)
                                                    .Select(row =>
                                                new WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo
                                                {
                                                    Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                                    Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                                }).ToList();
                                                if (CorporateInfos != null && CorporateInfos.Count > 0)
                                                    customer.CorporateInfos = CorporateInfos;
                                                #endregion
                                            }
                                        }
                                        appointment.Customers = Customers;
                                    }
                                }

                                if (resultDS.Tables.Count > 7 && resultDS.Tables[7].Rows.Count > 0)
                                {
                                    #region Vehicles
                                    List<WA.Standard.IF.Data.v2.Common.Vehicle.Vehicle> Vehicles = null;
                                    Vehicles = resultDS.Tables[7].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new WA.Standard.IF.Data.v2.Common.Vehicle.Vehicle
                                    {
                                        Color = Util.DataHelper.ConvertObjectToString(row["Color"]),
                                        Cylinders = Util.DataHelper.ConvertObjectToString(row["Cylinders"]),
                                        DateDelivered = Util.DataHelper.ConvertObjectToDateTime(row["DateDelivered"]),
                                        DateInService = Util.DataHelper.ConvertObjectToDateTime(row["DateInService"]),
                                        DeclinedJob = Util.DataHelper.ConvertObjectToString(row["DeclinedJob"]),
                                        DisplayDescription = Util.DataHelper.ConvertObjectToString(row["DisplayDescription"]),
                                        DMSCustomerNo = Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"]),
                                        DMSVehicleNo = Util.DataHelper.ConvertObjectToString(row["DMSVehicleNo"]),
                                        EngineType = Util.DataHelper.ConvertObjectToString(row["EngineType"]),
                                        ExtendedWarranty = Util.DataHelper.ConvertObjectToDateTime(row["ExtendedWarranty"]),
                                        FuelType = Util.DataHelper.ConvertObjectToString(row["FuelType"]),
                                        FullModelName = Util.DataHelper.ConvertObjectToString(row["FullModelName"]),
                                        InsuranceDate = Util.DataHelper.ConvertObjectToDateTime(row["InsuranceDate"]),
                                        LastMileage = Util.DataHelper.ConvertObjectToString(row["LastMileage"]),
                                        LastServiceDate = Util.DataHelper.ConvertObjectToDateTime(row["LastServiceDate"]),
                                        LastSixVIN = Util.DataHelper.ConvertObjectToString(row["LastSixVIN"]),
                                        LicenseNumber = Util.DataHelper.ConvertObjectToString(row["LicenseNumber"]),
                                        LicensePlateNo = Util.DataHelper.ConvertObjectToString(row["LicensePlateNo"]),
                                        Make = Util.DataHelper.ConvertObjectToString(row["Make"]),
                                        ModelCode = Util.DataHelper.ConvertObjectToString(row["ModelCode"]),
                                        ModelName = Util.DataHelper.ConvertObjectToString(row["ModelName"]),
                                        ModelYear = Util.DataHelper.ConvertObjectToString(row["ModelYear"]),
                                        PendingJob = Util.DataHelper.ConvertObjectToString(row["PendingJob"]),
                                        StockNumber = Util.DataHelper.ConvertObjectToString(row["StockNumber"]),
                                        Trim = Util.DataHelper.ConvertObjectToString(row["Trim"]),
                                        VehicleType = Util.DataHelper.ConvertObjectToString(row["VehicleType"]),
                                        VIN = Util.DataHelper.ConvertObjectToString(row["VIN"]),
                                        WarrantyMiles = Util.DataHelper.ConvertObjectToString(row["WarrantyMiles"]),
                                        WarrantyMonths = Util.DataHelper.ConvertObjectToString(row["WarrantyMonths"]),
                                        WarrantyStartDate = Util.DataHelper.ConvertObjectToDateTime(row["WarrantyStartDate"]),
                                        Campaigns = new List<Campaign>(),
                                    }).ToList();
                                    #endregion

                                    if (Vehicles != null && Vehicles.Count > 0 && resultDS.Tables.Count > 8 && resultDS.Tables[8].Rows.Count > 0)
                                    {
                                        foreach (WA.Standard.IF.Data.v2.Common.Vehicle.Vehicle vehicle in Vehicles)
                                        {
                                            #region Campaigns
                                            List<WA.Standard.IF.Data.v2.Common.Vehicle.Campaign> Campaigns = null;
                                            Campaigns = resultDS.Tables[8].AsEnumerable()
                                                .Where(row => Util.DataHelper.ConvertObjectToString(row["VIN"], null) == vehicle.VIN)
                                                .Select(row =>
                                            new WA.Standard.IF.Data.v2.Common.Vehicle.Campaign
                                            {
                                                CampaignDescription = Util.DataHelper.ConvertObjectToString(row["CampaignDescription"]),
                                                CampaignID = Util.DataHelper.ConvertObjectToString(row["CampaignID"]),
                                                CampaignPerformed = Util.DataHelper.ConvertObjectToString(row["CampaignPerformed"]),
                                            }).ToList();
                                            if (Campaigns != null && Campaigns.Count > 0)
                                                vehicle.Campaigns = Campaigns;
                                            #endregion
                                        }
                                        appointment.Vehicle = Vehicles[0];
                                    }
                                }

                                if (resultDS.Tables.Count > 9 && resultDS.Tables[9].Rows.Count > 0)
                                {
                                    #region AdditionalFields
                                    List<AdditionalField> AdditionalFields = null;
                                    AdditionalFields = resultDS.Tables[9].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new AdditionalField
                                    {
                                        Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                        Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                    }).ToList();
                                    if (AdditionalFields != null && AdditionalFields.Count > 0)
                                        appointment.AdditionalFields = AdditionalFields;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 10 && resultDS.Tables[10].Rows.Count > 0)
                                {
                                    #region Options
                                    List<Option> Options = null;
                                    Options = resultDS.Tables[10].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new Option
                                    {
                                        Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                        Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                    }).ToList();
                                    if (Options != null && Options.Count > 0)
                                        appointment.Options = Options;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 11 && resultDS.Tables[11].Rows.Count > 0)
                                {
                                    #region RequestItems
                                    List<RequestItem> RequestItems = null;
                                    RequestItems = resultDS.Tables[11].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo)
                                        .Select(row =>
                                    new RequestItem
                                    {
                                        CPSIND = Util.DataHelper.ConvertObjectToString(row["CPSIND"]),
                                        RequestCode = Util.DataHelper.ConvertObjectToString(row["RequestCode"]),
                                        RequestDescription = Util.DataHelper.ConvertObjectToString(row["RequestDescription"]),
                                        ServiceLineNumber = Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"]),
                                        ServiceLineStatus = Util.DataHelper.ConvertObjectToString(row["ServiceLineStatus"]),
                                        ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                                        TCEmployeeID = Util.DataHelper.ConvertObjectToString(row["TCEmployeeID"]),
                                        TCEmployeeName = Util.DataHelper.ConvertObjectToString(row["TCEmployeeName"]),
                                        WorkType = Util.DataHelper.ConvertObjectToString(row["WorkType"]),
                                        OPCodes = new List<OPCode>(),
                                        Comments = new List<Comment>(),
                                        Descriptions = new List<Description>(),
                                    }).ToList();
                                    #endregion

                                    if (RequestItems != null && RequestItems.Count > 0 && resultDS.Tables.Count > 12 && resultDS.Tables[12].Rows.Count > 0)
                                    {
                                        //12.RequestItem Comments & Descriptions
                                        //12.OPCodes & Descriptions & Causes & Corrections 
                                        //12.Parts & Descriptions
                                        //12.MISCs & Descriptions
                                        //12.Sublets & Descriptions
                                        //13.AppointmentPrice & RequestItemPrice & OPPrice & PartPrice & MISCPrice & SubletPrice
                                        foreach (RequestItem requestitem in RequestItems)
                                        {
                                            #region RequestItemComments
                                            List<Comment> RequestItemComments = null;
                                            RequestItemComments = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Request
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Comment
                                                        )
                                                .Select(row =>
                                            new Comment
                                            {
                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                            }).ToList();
                                            if (RequestItemComments != null && RequestItemComments.Count > 0)
                                                requestitem.Comments = RequestItemComments;
                                            #endregion

                                            #region RequestItemDescriptions
                                            List<Description> RequestItemDescriptions = null;
                                            RequestItemDescriptions = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Request
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Description
                                                        )
                                                .Select(row =>
                                            new Description
                                            {
                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                            }).ToList();
                                            if (RequestItemDescriptions != null && RequestItemDescriptions.Count > 0)
                                                requestitem.Descriptions = RequestItemDescriptions;
                                            #endregion

                                            #region OPCodes
                                            List<OPCode> OPCodes = null;
                                            OPCodes = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._OPCode
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Request
                                                        )
                                                .Select(row =>
                                            new OPCode
                                            {
                                                ActualHours = Util.DataHelper.ConvertObjectToDouble(row["ActualHours"]),
                                                Code = Util.DataHelper.ConvertObjectToString(row["OPCode"]),
                                                Description = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                EstimatedHours = Util.DataHelper.ConvertObjectToDouble(row["EstimatedHours"]),
                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                                                SkillLevel = Util.DataHelper.ConvertObjectToString(row["SkillLevel"]),
                                                Causes = new List<Cause>(),
                                                Corrections = new List<Correction>(),
                                                Descriptions = new List<Description>(),
                                                PriceType = new PriceType(),
                                                Parts = new List<Part>(),
                                                Sublets = new List<Sublet>(),
                                                MISCs = new List<MISC>(),
                                            }).ToList();
                                            #endregion

                                            if (OPCodes != null && OPCodes.Count > 0)
                                            {
                                                foreach (OPCode opcode in OPCodes)
                                                {
                                                    #region OPCodeDescriptions
                                                    List<Description> OPCodeDescriptions = null;
                                                    OPCodeDescriptions = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._OPCode
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Description
                                                        )
                                                        .Select(row =>
                                                    new Description
                                                    {
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                        DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                    }).ToList();
                                                    if (OPCodeDescriptions != null && OPCodeDescriptions.Count > 0)
                                                        opcode.Descriptions = OPCodeDescriptions;
                                                    #endregion

                                                    #region OPCodeCauses
                                                    List<Cause> OPCodeCauses = null;
                                                    OPCodeCauses = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._OPCode
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Cause
                                                        )
                                                        .Select(row =>
                                                    new Cause
                                                    {
                                                        CauseLaborOpCode = Util.DataHelper.ConvertObjectToString(row["CauseLaborOpCode"]),
                                                        Comment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                    }).ToList();
                                                    if (OPCodeCauses != null && OPCodeCauses.Count > 0)
                                                        opcode.Causes = OPCodeCauses;
                                                    #endregion

                                                    #region OPCodeCorrections
                                                    List<Correction> OPCodeCorrections = null;
                                                    OPCodeCorrections = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._OPCode
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Correction
                                                        )
                                                        .Select(row =>
                                                    new Correction
                                                    {
                                                        CorrectionLaborOpCode = Util.DataHelper.ConvertObjectToString(row["CauseLaborOpCode"]),
                                                        Comment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                    }).ToList();
                                                    if (OPCodeCorrections != null && OPCodeCorrections.Count > 0)
                                                        opcode.Corrections = OPCodeCorrections;
                                                    #endregion

                                                    #region Parts
                                                    List<Part> Parts = null;
                                                    Parts = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Part
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Request
                                                        )
                                                        .Select(row =>
                                                    new Part
                                                    {
                                                        DisplayPartNumber = Util.DataHelper.ConvertObjectToString(row["PartNumber"]),
                                                        PartDescription = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                        PartNumber = Util.DataHelper.ConvertObjectToString(row["PartNumber"]),
                                                        PartType = Util.DataHelper.ConvertObjectToString(row["PartType"]),
                                                        Quantity = Util.DataHelper.ConvertObjectToDouble(row["Quantity"]),
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                        ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                                                        StockQuantity = Util.DataHelper.ConvertObjectToDouble(row["StockQuantity"]),
                                                        StockStatus = Util.DataHelper.ConvertObjectToString(row["StockStatus"]),
                                                        UnitOfMeasure = Util.DataHelper.ConvertObjectToString(row["UnitOfMeasure"]),
                                                        Descriptions = new List<Description>(),
                                                        PriceType = new PriceType(),
                                                    }).ToList();
                                                    #endregion

                                                    if (Parts != null && Parts.Count > 0)
                                                    {
                                                        foreach (Part part in Parts)
                                                        {
                                                            #region PartDescriptions
                                                            List<Description> PartDescriptions = null;
                                                            PartDescriptions = resultDS.Tables[12].AsEnumerable()
                                                               .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                                && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                                && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                                && Util.DataHelper.ConvertObjectToString(row["PartNumber"], null) == part.PartNumber
                                                                && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Part
                                                                && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Description
                                                                )
                                                                .Select(row =>
                                                            new Description
                                                            {
                                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                                DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                            }).ToList();
                                                            if (PartDescriptions != null && PartDescriptions.Count > 0)
                                                                part.Descriptions = PartDescriptions;
                                                            #endregion
                                                        }
                                                        opcode.Parts = Parts;
                                                    }

                                                    #region Sublets
                                                    List<Sublet> Sublets = null;
                                                    Sublets = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Sublet
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Request
                                                        )
                                                        .Select(row =>
                                                    new Sublet
                                                    {
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                        ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                                                        Descriptions = new List<Description>(),
                                                        PriceType = new PriceType(),
                                                    }).ToList();
                                                    #endregion

                                                    if (Sublets != null && Sublets.Count > 0)
                                                    {
                                                        foreach (Sublet sublet in Sublets)
                                                        {
                                                            #region SubletDescriptions
                                                            List<Description> SubletDescriptions = null;
                                                            SubletDescriptions = resultDS.Tables[12].AsEnumerable()
                                                               .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                                && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                                && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                                && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._Sublet
                                                                && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Description
                                                                )
                                                                .Select(row =>
                                                            new Description
                                                            {
                                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                                DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                            }).ToList();
                                                            if (SubletDescriptions != null && SubletDescriptions.Count > 0)
                                                                sublet.Descriptions = SubletDescriptions;
                                                            #endregion
                                                        }
                                                        opcode.Sublets = Sublets;
                                                    }

                                                    #region MISCs
                                                    List<MISC> MISCs = null;
                                                    MISCs = resultDS.Tables[12].AsEnumerable()
                                                       .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                        && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                        && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                        && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._MISC
                                                        && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Request
                                                        )
                                                        .Select(row =>
                                                    new MISC
                                                    {
                                                        SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                        ServiceType = Util.DataHelper.ConvertObjectToString(row["ServiceType"]),
                                                        Descriptions = new List<Description>(),
                                                        PriceType = new PriceType(),
                                                    }).ToList();
                                                    #endregion

                                                    if (MISCs != null && MISCs.Count > 0)
                                                    {
                                                        foreach (MISC misc in MISCs)
                                                        {
                                                            #region MISCDescriptions
                                                            List<Description> MISCDescriptions = null;
                                                            MISCDescriptions = resultDS.Tables[12].AsEnumerable()
                                                               .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"], null) == appointment.DMSAppointmentNo
                                                                && Util.DataHelper.ConvertObjectToString(row["ServiceLineNumber"], null) == requestitem.ServiceLineNumber
                                                                && Util.DataHelper.ConvertObjectToString(row["OPCode"], null) == opcode.Code
                                                                && Util.DataHelper.ConvertObjectToString(row["LineType"], null) == WA.Standard.IF.Biz.v2.Base.LineType._MISC
                                                                && Util.DataHelper.ConvertObjectToString(row["TransCode"], null) == WA.Standard.IF.Biz.v2.Base.TransCode._Description
                                                                )
                                                                .Select(row =>
                                                            new Description
                                                            {
                                                                SequenceNumber = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                                                DescriptionComment = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                                            }).ToList();
                                                            if (MISCDescriptions != null && MISCDescriptions.Count > 0)
                                                                misc.Descriptions = MISCDescriptions;
                                                            #endregion
                                                        }
                                                        opcode.MISCs = MISCs;
                                                    }
                                                }
                                                requestitem.OPCodes = OPCodes;
                                            }

                                        }
                                        appointment.RequestItems = RequestItems;
                                    }
                                }

                                if (resultDS.Tables.Count > 13 && resultDS.Tables[13].Rows.Count > 0)
                                {
                                    #region PriceTypes - Not Yet

                                    #endregion
                                }

                            }
                            response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                            response.Appointments = Appointments;
                        }
                        #endregion
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

        public AppointmentChangeResponse AppointmentChange(AppointmentChangeRequest request)
        {
            AppointmentChangeResponse response = new AppointmentChangeResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Appointment_Proxy proxy = new Proxy.v2.Common.Appointment_Proxy();
                response = proxy.AppointmentChange(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                List<Appointment> Appointments = Util.DataHelper.GetListByElementName<Appointment>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Appointments.xml"), "Appointment");

                if (Appointments != null && Appointments.Count > 0)
                {
                    //response.Appointment = Appointments.Where([0];
                    response.ResultMessage = GetResultMessageData(ResponseCode.Success, "445"//PredefinedMessage._SuccessDone
                        );
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet

                #endregion
            }

            request.TransactionHeader.TransactionDateTimeUTC = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            request.TransactionHeader.TransactionDateTimeLocal = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            request.TransactionHeader.RequestPollingToken = Guid.NewGuid().ToString();
            response.TransactionHeader = request.TransactionHeader;
            return response;
        }
    }
}
