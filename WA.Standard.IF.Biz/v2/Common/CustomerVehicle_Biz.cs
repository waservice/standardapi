using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.CustomerVehicle;
using WA.Standard.IF.Data.v2.Common.Vehicle;
using WA.Standard.IF.Data.v2.Common.Customer;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class CustomerVehicle_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public CustomerVehicleGetResponse CustomerVehicleGet(CustomerVehicleGetRequest request)
        {
            CustomerVehicleGetResponse response = new CustomerVehicleGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.CustomerVehicle_Proxy proxy = new Proxy.v2.Common.CustomerVehicle_Proxy();
                response = proxy.CustomerVehicleGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
                
                #region For XML Process
                List<CustomerVehicle> CustomerVehicles = Util.DataHelper.GetListByElementName<CustomerVehicle>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/CustomerVehicles.xml"), "CustomerVehicle");

                if (CustomerVehicles != null && CustomerVehicles.Count > 0)
                {
                    List<CustomerVehicle> resultlist = CustomerVehicles
                        .Where(item =>
                            (request.CustomerVehicleGet.Customer == null
                                || (request.CustomerVehicleGet.Customer != null
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Customer.CardNo) || request.CustomerVehicleGet.Customer.CardNo == item.Customer.CardNo)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Customer.DMSCustomerNo) || request.CustomerVehicleGet.Customer.DMSCustomerNo == item.Customer.DMSCustomerNo)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Customer.Email) || request.CustomerVehicleGet.Customer.Email == item.Customer.Email)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Customer.LastName) || request.CustomerVehicleGet.Customer.LastName == item.Customer.LastName)
                                //Need to add condition, Contacts
                                )
                            ) &&
                            (request.CustomerVehicleGet.Vehicle == null
                                || (request.CustomerVehicleGet.Vehicle != null
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Vehicle.DMSVehicleNo) || request.CustomerVehicleGet.Vehicle.DMSVehicleNo == item.Vehicle.DMSVehicleNo)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Vehicle.LastSixVIN) || request.CustomerVehicleGet.Vehicle.LastSixVIN == item.Vehicle.LastSixVIN)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Vehicle.LicensePlateNo) || request.CustomerVehicleGet.Vehicle.LicensePlateNo == item.Vehicle.LicensePlateNo)
                                    && (string.IsNullOrEmpty(request.CustomerVehicleGet.Vehicle.VIN) || request.CustomerVehicleGet.Vehicle.VIN == item.Vehicle.VIN)
                                )
                            )).ToList<CustomerVehicle>();

                    response.CustomerVehicles = resultlist;

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
                using (CustomerVehicle_Dac dac = new CustomerVehicle_Dac())
                {
                    if (request.CustomerVehicleGet.Customer != null && request.CustomerVehicleGet.Customer.Contacts != null)
                    {
                        foreach (WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact contact in request.CustomerVehicleGet.Customer.Contacts)
                        {
                            DataSet ds = dac.SelectCustomerVehicle(request.TransactionHeader.CountryID
                                                                , request.TransactionHeader.DistributorID
                                                                , request.TransactionHeader.GroupID
                                                                , request.TransactionHeader.DealerID
                                                                , request.TransactionHeader.Language // Need to check
                                                                , contact.ContactType
                                                                , contact.ContactValue
                                                                , request.CustomerVehicleGet
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
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCustomerNo");
                                else if (i == 1)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSAddressNo");
                                else if (i == 2)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSContactNo");
                                else if (i == 3)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCorporateInfoNo");
                                else if (i == 4)
                                    Util.DataHelper.RemoveDuplicateRows(resultDS.Tables[i], "DMSCampaignNo");
                            }
                        }
                    }
                    else
                    {
                        resultDS = dac.SelectCustomerVehicle(request.TransactionHeader.CountryID
                                                                , request.TransactionHeader.DistributorID
                                                                , request.TransactionHeader.GroupID
                                                                , request.TransactionHeader.DealerID
                                                                , request.TransactionHeader.Language //language
                                                                , null //contact.ContactType
                                                                , null //contact.ContactValue
                                                                , request.CustomerVehicleGet
                                                                );
                    }
                }

                //0. Customer
                //1. Address
                //2. Contact
                //3. CorporateInfo
                //4. Customer
                //5. Vehicle
                //6. Campaigns

                if (resultDS.Tables != null && resultDS.Tables.Count > 0)
                {
                    List<CustomerVehicle> CustomerVehicles = null;

                    if (resultDS.Tables[0].Rows.Count > 0)
                    {
                        #region CustomerVehicles
                        CustomerVehicles = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new CustomerVehicle
                        {
                            Customer = new Data.v2.Common.Customer.Customer()
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
                                SpecialMessage = new SpecialMessage() { Message = Util.DataHelper.ConvertObjectToString(row["SpecialMessage"], null) },
                                Addresses = new List<Address>(),
                                Contacts = new List<Data.v2.Common.Customer.Contact>(),
                                CorporateInfos = new List<CorporateInfo>(),
                            },
                            Vehicle = new Data.v2.Common.Vehicle.Vehicle()
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
                            }
                        }).ToList();
                        #endregion

                        if (CustomerVehicles != null && CustomerVehicles.Count > 0)
                        {
                            foreach (CustomerVehicle customervehicle in CustomerVehicles)
                            {
                                if (resultDS.Tables.Count > 1 && resultDS.Tables[1].Rows.Count > 0)
                                {
                                    #region Addresses
                                    List<Address> Addresses = null;
                                    Addresses = resultDS.Tables[1].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customervehicle.Customer.DMSCustomerNo)
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
                                        customervehicle.Customer.Addresses = Addresses;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 2 && resultDS.Tables[2].Rows.Count > 0)
                                {
                                    #region Contacts
                                    List<WA.Standard.IF.Data.v2.Common.Customer.Contact> Contacts = null;
                                    Contacts = resultDS.Tables[2].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customervehicle.Customer.DMSCustomerNo)
                                        .Select(row =>
                                    new WA.Standard.IF.Data.v2.Common.Customer.Contact
                                    {
                                        ContactMethodYN = Util.DataHelper.ConvertObjectToString(row["ContactMethodYN"]),
                                        ContactType = Util.DataHelper.ConvertObjectToString(row["ContactType"]),
                                        ContactValue = Util.DataHelper.ConvertObjectToString(row["ContactValue"]),
                                    }).ToList();
                                    if (Contacts != null && Contacts.Count > 0)
                                        customervehicle.Customer.Contacts = Contacts;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 3 && resultDS.Tables[3].Rows.Count > 0)
                                {
                                    #region CorporateInfos
                                    List<WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo> CorporateInfos = null;
                                    CorporateInfos = resultDS.Tables[3].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSCustomerNo"], null) == customervehicle.Customer.DMSCustomerNo)
                                        .Select(row =>
                                    new WA.Standard.IF.Data.v2.Common.Customer.CorporateInfo
                                    {
                                        Name = Util.DataHelper.ConvertObjectToString(row["Name"]),
                                        Value = Util.DataHelper.ConvertObjectToString(row["Value"]),
                                    }).ToList();
                                    if (CorporateInfos != null && CorporateInfos.Count > 0)
                                        customervehicle.Customer.CorporateInfos = CorporateInfos;
                                    #endregion
                                }

                                if (resultDS.Tables.Count > 4 && resultDS.Tables[4].Rows.Count > 0)
                                {
                                    #region Campaigns
                                    List<WA.Standard.IF.Data.v2.Common.Vehicle.Campaign> Campaigns = null;
                                    Campaigns = resultDS.Tables[4].AsEnumerable()
                                        .Where(row => Util.DataHelper.ConvertObjectToString(row["VIN"], null) == customervehicle.Vehicle.VIN)
                                        .Select(row =>
                                    new WA.Standard.IF.Data.v2.Common.Vehicle.Campaign
                                    {
                                        CampaignDescription = Util.DataHelper.ConvertObjectToString(row["CampaignDescription"]),
                                        CampaignID = Util.DataHelper.ConvertObjectToString(row["CampaignID"]),
                                        CampaignPerformed = Util.DataHelper.ConvertObjectToString(row["CampaignPerformed"]),
                                    }).ToList();
                                    if (Campaigns != null && Campaigns.Count > 0)
                                        customervehicle.Vehicle.Campaigns = Campaigns;
                                    #endregion
                                }
                            }
                            response.CustomerVehicles = CustomerVehicles;
                            response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        }
                    }
                    else
                    {
                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                    }
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

        public CustomerVehicleChangeResponse CustomerVehicleChange(CustomerVehicleChangeRequest request)
        {
            CustomerVehicleChangeResponse response = new CustomerVehicleChangeResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.CustomerVehicle_Proxy proxy = new Proxy.v2.Common.CustomerVehicle_Proxy();
                response = proxy.CustomerVehiclChange(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
                
                #region For XML Process
                List<CustomerVehicle> CustomerVehicles = Util.DataHelper.GetListByElementName<CustomerVehicle>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/CustomerVehicles.xml"), "CustomerVehicle");

                if (CustomerVehicles != null && CustomerVehicles.Count > 0)
                {
                    if (request.CustomerVehicleChange.Customer != null && request.CustomerVehicleChange.Vehicle == null)
                    {
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, "14430"//PredefinedMessage._SuccessDone
                            );

                    }
                    else if (request.CustomerVehicleChange.Customer == null && request.CustomerVehicleChange.Vehicle != null)
                    {
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, "1488"//PredefinedMessage._SuccessDone
                            );

                    }
                    else
                    {
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);

                    }

                    //response.CustomerVehicle = CustomerVehicles[0];
                    //response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
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
