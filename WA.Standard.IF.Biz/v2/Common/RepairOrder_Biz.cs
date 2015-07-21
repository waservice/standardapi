using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Customer;
using WA.Standard.IF.Data.v2.Common.RepairOrder;
using WA.Standard.IF.Data.v2.Common.Vehicle;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class RepairOrder_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public RepairOrderGetResponse RepairOrderGet(RepairOrderGetRequest request)
        {
            RepairOrderGetResponse response = new RepairOrderGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.RepairOrder_Proxy proxy = new Proxy.v2.Common.RepairOrder_Proxy();
                response = proxy.RepairOrderGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;

                #region For XML Process
                List<RepairOrderDocument> RepairOrderDocuments = Util.DataHelper.GetListByElementName<RepairOrderDocument>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/RepairOrderDocuments.xml"), "RepairOrderDocument");

                List<RepairOrderDocument> resultlist = new List<RepairOrderDocument>();

                if (RepairOrderDocuments != null && RepairOrderDocuments.Count > 0)
                {
                    foreach (RepairOrderDocument repairorderdocument in RepairOrderDocuments)
                    {
                        if (repairorderdocument.RepairOrders != null && repairorderdocument.RepairOrders.Count > 0)
                        {
                            repairorderdocument.RepairOrders = repairorderdocument.RepairOrders
                                    .Where(item =>
                                    (string.IsNullOrEmpty(request.RepairOrderGet.DMSAppointmentID) || item.AppointmentRef.DMSAppointmentID == request.RepairOrderGet.DMSAppointmentID)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.DMSAppointmentNo) || item.AppointmentRef.DMSAppointmentNo == request.RepairOrderGet.DMSAppointmentNo)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.DMSROID) || item.DMSROID == request.RepairOrderGet.DMSROID)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.DMSRONo) || item.DMSRONo == request.RepairOrderGet.DMSRONo)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.DMSROStatus) || item.DMSROStatus == request.RepairOrderGet.DMSROStatus)
                                    && (request.RepairOrderGet.LastModifiedDateTimeFromUTC == null || item.ManagementFields.LastModifiedDateTimeUTC >= request.RepairOrderGet.LastModifiedDateTimeFromUTC)
                                    && (request.RepairOrderGet.LastModifiedDateTimeToUTC == null || item.ManagementFields.LastModifiedDateTimeUTC <= request.RepairOrderGet.LastModifiedDateTimeToUTC)
                                    && (request.RepairOrderGet.OpenDateTimeFromLocal == null || item.OpenDateTimeLocal >= request.RepairOrderGet.OpenDateTimeFromLocal)
                                    && (request.RepairOrderGet.OpenDateTimeToLocal == null || item.OpenDateTimeLocal <= request.RepairOrderGet.OpenDateTimeToLocal)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.SAEmployeeID) || item.DMSRONo == request.RepairOrderGet.SAEmployeeID)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.SAEmployeeName) || item.DMSRONo == request.RepairOrderGet.SAEmployeeName)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.TCEmployeeID) || item.DMSRONo == request.RepairOrderGet.TCEmployeeID)
                                    && (string.IsNullOrEmpty(request.RepairOrderGet.TCEmployeeName) || item.DMSRONo == request.RepairOrderGet.TCEmployeeName)

                                    && (request.RepairOrderGet.Vehicle == null
                                        || (request.RepairOrderGet.Vehicle != null
                                            && (string.IsNullOrEmpty(request.RepairOrderGet.Vehicle.DMSVehicleNo) || request.RepairOrderGet.Vehicle.DMSVehicleNo == item.Vehicle.DMSVehicleNo)
                                            && (string.IsNullOrEmpty(request.RepairOrderGet.Vehicle.LastSixVIN) || request.RepairOrderGet.Vehicle.LastSixVIN == item.Vehicle.LastSixVIN)
                                            && (string.IsNullOrEmpty(request.RepairOrderGet.Vehicle.VIN) || request.RepairOrderGet.Vehicle.VIN == item.Vehicle.VIN)
                                        )
                                    )

                                    && (request.RepairOrderGet.Customer == null || true)
                                //Need To Check Condition. Customer & Contact
                                    ).ToList<RepairOrder>();

                            resultlist.Add(repairorderdocument);
                        }
                    }

                    response.RepairOrderDocuments = resultlist;

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
                using (RepairOrder_Dac dac = new RepairOrder_Dac())
                {
                    if (request.RepairOrderGet.Customer != null && request.RepairOrderGet.Customer.Contacts != null)
                    {
                        foreach (WA.Standard.IF.Data.v2.Common.RepairOrder.Contact contact in request.RepairOrderGet.Customer.Contacts)
                        {
                            DataSet ds = dac.SelectRepairOrder(request.TransactionHeader.CountryID
                                                                , request.TransactionHeader.DistributorID
                                                                , request.TransactionHeader.GroupID
                                                                , request.TransactionHeader.DealerID
                                                                , request.TransactionHeader.Language // Need to check
                                                                , contact.ContactType
                                                                , contact.ContactValue
                                                                , request.RepairOrderGet
                                                                );
                            //Merging all data. Because same RO could be return from sql server.
                            resultDS.Merge(ds);
                        }

                        //Remove duplicate rows by key field
                        if (resultDS.Tables != null)
                        {
                            for (int i = 0; i < resultDS.Tables.Count; i++)
                            {
                                if (i == 0)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSRODocumentNo");
                                else if (i == 1)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSRONo");
                                else if (i == 2)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSJobNo");
                                //else if (i == 3)
                                //    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSRODocumentNo");
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
                                else if (i == 14)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCustomerPartNo");
                            }
                        }
                    }
                    else
                    {
                        resultDS = dac.SelectRepairOrder(request.TransactionHeader.CountryID
                                                                , request.TransactionHeader.DistributorID
                                                                , request.TransactionHeader.GroupID
                                                                , request.TransactionHeader.DealerID
                                                                , request.TransactionHeader.Language // Need to check
                                                                , null //contact.ContactType
                                                                , null //contact.ContactValue
                                                                , request.RepairOrderGet
                                                                );
                    }
                }

                //0.RODocument
                //1.RO & ManagementField
                //2.JobRefs
                //3.RORefs - AppointmentRef
                //4.Customers
                //5.Addresses
                //6.Contacts
                //7.CorporateInfos
                //8.Vehicle
                //9.Campaigns
                //10.AdditionalFields
                //11.Options
                //12.RequestItems
                //13.RequestItem Comments & Descriptions
                //13.OPCodes & Descriptions & Causes & Corrections 
                //13.Parts & Descriptions
                //13.MISCs & Descriptions
                //13.Sublets & Descriptions
                //14.ROPrice & RequestItemPrice & OPPrice & PartPrice & MISCPrice & SubletPrice

                List<RepairOrderDocument> RepairOrderDocuments = null;
                //List<CustomerPart> CustomerParts = null;

                if (resultDS.Tables.Count > 0 && resultDS.Tables[0].Rows.Count > 0)
                {
                    #region RepairOrderGet

                    #region RepairOrderDocuments
                    RepairOrderDocuments = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new RepairOrderDocument
                        {
                            DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"]),
                            DMSAppointmentStatus = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentStatus"]),
                            DMSRODocumentNo = Util.DataHelper.ConvertObjectToString(row["DMSRODocumentNo"]),
                            DMSRODocumentStatus = Util.DataHelper.ConvertObjectToString(row["DMSRODocumentStatus"]),
                            AppointmentRef = new AppointmentRef()
                            {
                                DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"]),
                                DMSAppointmentStatus = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentStatus"])
                            },
                            RepairOrders = new List<RepairOrder>(),
                        }).ToList();
                    #endregion

                    if (RepairOrderDocuments != null && RepairOrderDocuments.Count > 0)
                    {
                        foreach (RepairOrderDocument repairorderdocument in RepairOrderDocuments)
                        {
                            #region RepairOrders
                            List<RepairOrder> RepairOrders = null;
                            RepairOrders = resultDS.Tables[1].AsEnumerable()
                                .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRODocumentNo"], null) == repairorderdocument.DMSRODocumentNo)
                                .Select(row =>
                            new RepairOrder
                            {
                                CloseDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["CloseDateTimeLocal"]),
                                DeliveryDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["RODateTimeLocal"]),
                                DMSROID = Util.DataHelper.ConvertObjectToString(row["DMSROID"]),
                                DMSRONo = Util.DataHelper.ConvertObjectToString(row["DMSRONo"]),
                                DMSROStatus = Util.DataHelper.ConvertObjectToString(row["DMSROStatus"]),
                                HangTagColor = Util.DataHelper.ConvertObjectToString(row["HangTagColor"]),
                                HangTagNo = Util.DataHelper.ConvertObjectToString(row["HangTagNo"]),
                                InMileage = Util.DataHelper.ConvertObjectToString(row["InMileage"]),
                                OpenDateTimeLocal = Util.DataHelper.ConvertObjectToDateTime(row["RODateTimeLocal"]),
                                OutMileage = Util.DataHelper.ConvertObjectToString(row["OutMileage"]),
                                PaymentMethod = Util.DataHelper.ConvertObjectToString(row["PaymentMethod"]),
                                ROChannel = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                SAEmployeeID = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                ServiceType = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                TCEmployeeID = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                TCEmployeeName = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                WorkType = Util.DataHelper.ConvertObjectToString(row["RODateTimeLocal"]),
                                ManagementFields = new ManagementFields()
                                {
                                    CreateDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["CreateDateTimeUTC"]),
                                    LastModifiedDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["LastModifiedDateTimeUTC"])
                                },
                                AppointmentRef = new AppointmentRef(),
                                JobRefs = new List<JobRef>(),
                                CustomerParts = new List<CustomerPart>(),
                                AdditionalFields = new List<AdditionalField>(),
                                Options = new List<Option>(),
                                PriceType = new PriceType(),
                                Customers = new List<Data.v2.Common.Customer.Customer>(),
                                Vehicle = new Data.v2.Common.Vehicle.Vehicle(),
                                RequestItems = new List<RequestItem>(),
                            }).ToList();
                            #endregion

                            if (RepairOrders != null && RepairOrders.Count > 0)
                            {
                                foreach (RepairOrder repairorder in RepairOrders)
                                {
                                    if (resultDS.Tables.Count > 2 && resultDS.Tables[2].Rows.Count > 0)
                                    {
                                        #region JobRefs
                                        List<JobRef> JobRefs = null;
                                        JobRefs = resultDS.Tables[2].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
                                            .Select(row =>
                                        new JobRef
                                        {
                                            DMSJobNo = Util.DataHelper.ConvertObjectToString(row["DMSJobNo"]),
                                            DMSJobStatus = Util.DataHelper.ConvertObjectToString(row["DMSJobStatus"]),
                                        }).ToList();
                                        if (JobRefs != null && JobRefs.Count > 0)
                                            repairorder.JobRefs = JobRefs;
                                        #endregion

                                    }

                                    //if (resultDS.Tables.Count > 3 && resultDS.Tables[3].Rows.Count > 0)
                                    //{
                                    #region AppointmentRefs
                                    //List<AppointmentRef> AppointmentRefs = null;
                                    //AppointmentRefs = resultDS.Tables[3].AsEnumerable()
                                    //    .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRODocumentNo"], null) == repairorders.DMSRODocumentNo)
                                    //    .Select(row =>
                                    //new AppointmentRef
                                    //{
                                    //    DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentNo"]),
                                    //    DMSAppointmentStatus = Util.DataHelper.ConvertObjectToString(row["DMSAppointmentStatus"]),
                                    //}).ToList();
                                    //if (AppointmentRefs != null && AppointmentRefs.Count > 0)
                                    repairorder.AppointmentRef = repairorderdocument.AppointmentRef;
                                    #endregion
                                    //}

                                    if (resultDS.Tables.Count > 3 && resultDS.Tables[3].Rows.Count > 0)
                                    {
                                        #region Customers & SpecialMessage
                                        List<WA.Standard.IF.Data.v2.Common.Customer.Customer> Customers = null;
                                        Customers = resultDS.Tables[3].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
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
                                            repairorder.Customers = Customers;
                                        }
                                    }

                                    if (resultDS.Tables.Count > 7 && resultDS.Tables[7].Rows.Count > 0)
                                    {
                                        #region Vehicles
                                        List<WA.Standard.IF.Data.v2.Common.Vehicle.Vehicle> Vehicles = null;
                                        Vehicles = resultDS.Tables[7].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
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
                                            repairorder.Vehicle = Vehicles[0];
                                        }
                                    }

                                    if (resultDS.Tables.Count > 9 && resultDS.Tables[9].Rows.Count > 0)
                                    {
                                        #region AdditionalFields
                                        List<AdditionalField> AdditionalFields = null;
                                        AdditionalFields = resultDS.Tables[9].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
                                            .Select(row =>
                                        new AdditionalField
                                        {
                                            Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                            Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                        }).ToList();
                                        if (AdditionalFields != null && AdditionalFields.Count > 0)
                                            repairorder.AdditionalFields = AdditionalFields;
                                        #endregion
                                    }

                                    if (resultDS.Tables.Count > 10 && resultDS.Tables[10].Rows.Count > 0)
                                    {
                                        #region Options
                                        List<Option> Options = null;
                                        Options = resultDS.Tables[10].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
                                            .Select(row =>
                                        new Option
                                        {
                                            Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                            Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                        }).ToList();
                                        if (Options != null && Options.Count > 0)
                                            repairorder.Options = Options;
                                        #endregion
                                    }

                                    if (resultDS.Tables.Count > 11 && resultDS.Tables[11].Rows.Count > 0)
                                    {
                                        #region RequestItems
                                        List<RequestItem> RequestItems = null;
                                        RequestItems = resultDS.Tables[11].AsEnumerable()
                                            .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
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

                                        if (RequestItems != null && RequestItems.Count > 0 && resultDS.Tables.Count > 13 && resultDS.Tables[13].Rows.Count > 0)
                                        {
                                            //12.RequestItem Comments & Descriptions
                                            //12.OPCodes & Descriptions & Causes & Corrections 
                                            //12.Parts & Descriptions
                                            //12.MISCs & Descriptions
                                            //12.Sublets & Descriptions
                                            //13.ROPrice & RequestItemPrice & OPPrice & PartPrice & MISCPrice & SubletPrice
                                            foreach (RequestItem requestitem in RequestItems)
                                            {
                                                #region RequestItemComments
                                                List<Comment> RequestItemComments = null;
                                                RequestItemComments = resultDS.Tables[12].AsEnumerable()
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                    //Causes = new List<Cause>(),
                                                    //Corrections = new List<Correction>(),
                                                    //Descriptions = new List<Description>(),
                                                    //PriceType = new PriceType(),
                                                    //Parts = new List<Part>(),
                                                    //Sublets = new List<Sublet>(),
                                                    //MISCs = new List<MISC>(),
                                                }).ToList();
                                                #endregion

                                                if (OPCodes != null && OPCodes.Count > 0)
                                                {
                                                    foreach (OPCode opcode in OPCodes)
                                                    {
                                                        #region OPCodeDescriptions
                                                        List<Description> OPCodeDescriptions = null;
                                                        OPCodeDescriptions = resultDS.Tables[12].AsEnumerable()
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                            //Descriptions = new List<Description>(),
                                                            //PriceType = new PriceType(),
                                                        }).ToList();
                                                        #endregion

                                                        if (Parts != null && Parts.Count > 0)
                                                        {
                                                            foreach (Part part in Parts)
                                                            {
                                                                #region PartDescriptions
                                                                List<Description> PartDescriptions = null;
                                                                PartDescriptions = resultDS.Tables[12].AsEnumerable()
                                                                   .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                            //Descriptions = new List<Description>(),
                                                            //PriceType = new PriceType(),
                                                        }).ToList();
                                                        #endregion

                                                        if (Sublets != null && Sublets.Count > 0)
                                                        {
                                                            foreach (Sublet sublet in Sublets)
                                                            {
                                                                #region SubletDescriptions
                                                                List<Description> SubletDescriptions = null;
                                                                SubletDescriptions = resultDS.Tables[12].AsEnumerable()
                                                                   .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                                            //Descriptions = new List<Description>(),
                                                            //PriceType = new PriceType(),
                                                        }).ToList();
                                                        #endregion

                                                        if (MISCs != null && MISCs.Count > 0)
                                                        {
                                                            foreach (MISC misc in MISCs)
                                                            {
                                                                #region MISCDescriptions
                                                                List<Description> MISCDescriptions = null;
                                                                MISCDescriptions = resultDS.Tables[12].AsEnumerable()
                                                                   .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo
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
                                            repairorder.RequestItems = RequestItems;
                                        }
                                    }

                                    if (resultDS.Tables.Count > 13 && resultDS.Tables[13].Rows.Count > 0)
                                    {
                                        #region PriceTypes - Not Yet

                                        #endregion
                                    }

                                    if (resultDS.Tables.Count > 14 && resultDS.Tables[14].Rows.Count > 0)
                                    {
                                        #region CustomerParts
                                        List<CustomerPart> CustomerParts = null;
                                        CustomerParts = resultDS.Tables[14].AsEnumerable()
                                           .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSRONo"], null) == repairorder.DMSRONo)
                                            .Select(row =>
                                        new CustomerPart
                                        {
                                            Comment = Util.DataHelper.ConvertObjectToString(row["SequenceNumber"]),
                                            PartDescription = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                            PartNumber = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                            Quantity = Util.DataHelper.ConvertObjectToDouble(row["Description"]),
                                            UnitOfMeasure  = Util.DataHelper.ConvertObjectToString(row["Description"]),
                                        }).ToList();
                                        if (CustomerParts != null && CustomerParts.Count > 0)
                                            repairorder.CustomerParts = CustomerParts;
                                        #endregion
                                    }
                                }
                                repairorderdocument.RepairOrders = RepairOrders;
                            }
                        }
                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        response.RepairOrderDocuments = RepairOrderDocuments;
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

        public RepairOrderChangeResponse RepairOrderChange(RepairOrderChangeRequest request)
        {
            RepairOrderChangeResponse response = new RepairOrderChangeResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.RepairOrder_Proxy proxy = new Proxy.v2.Common.RepairOrder_Proxy();
                response = proxy.RepairOrderChange(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;

                #region For XML Process
                List<RepairOrder> RepairOrders = Util.DataHelper.GetListByElementName<RepairOrder>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/RepairOrderDocuments.xml"), "RepairOrder");
                if (RepairOrders != null && RepairOrders.Count > 0)
                {
                    //response.RepairOrder = RepairOrders[0];
                    response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
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

            return response;
        }
    }
}
