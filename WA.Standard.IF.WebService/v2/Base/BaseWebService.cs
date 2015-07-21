using System;
using System.Collections.Generic;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.WebService.v2.Base
{
    public class BaseWebService
    {
        public List<Error> GetErrorDataListFromRequest(object request)
        {
            int validcount = 0;

            List<Error> errorDataList = new List<Error>();

            if (request == null)
            {
                errorDataList.Add(GetErrorData(ResponseCode.RequestNull, ResponseMessage.RequestNull));
            }
            else
            {
                if (typeof(WA.Standard.IF.Data.v2.Common.Appointment.AppointmentGet) == (request.GetType()))
                {
                    #region//AppointmentGet Validation
                    WA.Standard.IF.Data.v2.Common.Appointment.AppointmentGet req = request as WA.Standard.IF.Data.v2.Common.Appointment.AppointmentGet;

                    if (req.AppointmentDateTimeFromLocal != null)
                        validcount++;
                    if (req.AppointmentDateTimeToLocal != null)
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSAppointmentID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSAppointmentNo))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSAppointmentStatus))
                        validcount++;
                    if (req.LastModifiedDateTimeFromUTC != null)
                        validcount++;
                    if (req.LastModifiedDateTimeToUTC != null)
                        validcount++;
                    if (!string.IsNullOrEmpty(req.SAEmployeeID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.SAEmployeeName))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.TCEmployeeID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.TCEmployeeName))
                        validcount++;

                    if (req.Customer != null)
                    {
                        if (req.Customer.DMSCustomerNo != null)
                            validcount++;
                        if (req.Customer.LastName != null)
                        {
                            if (req.Customer.LastName.Length >= 3)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.AG_Short_LastName, ResponseMessage.AG_Short_LastName));
                        }
                        if (req.Customer.Contacts != null && req.Customer.Contacts.Count > 0)
                        {
                            foreach (WA.Standard.IF.Data.v2.Common.Appointment.Contact contact in req.Customer.Contacts)
                            {
                                if (!string.IsNullOrEmpty(contact.ContactType))
                                    validcount++;
                                if (!string.IsNullOrEmpty(contact.ContactValue))
                                {
                                    if (contact.ContactValue.Length >= 3)
                                        validcount++;
                                    else
                                        errorDataList.Add(GetErrorData(ResponseCode.AG_Short_ContactValue, ResponseMessage.AG_Short_ContactValue));
                                }
                            }
                        }
                    }

                    if (req.Vehicle != null)
                    {
                        if (!string.IsNullOrEmpty(req.Vehicle.DMSVehicleNo))
                            validcount++;
                        if (!string.IsNullOrEmpty(req.Vehicle.LastSixVIN))
                        {
                            if (req.Vehicle.LastSixVIN.Length != 6)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.AG_Invalid_LastSixVIN, ResponseMessage.AG_Invalid_LastSixVIN));
                        }
                        if (!string.IsNullOrEmpty(req.Vehicle.VIN))
                        {
                            if (req.Vehicle.VIN.Length != 17)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.AG_Invalid_VIN, ResponseMessage.AG_Invalid_VIN));
                        }
                    }

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.CustomerVehicle.CustomerVehicleGet) == (request.GetType()))
                {
                    #region//CustomerVehicleGet Validation
                    WA.Standard.IF.Data.v2.Common.CustomerVehicle.CustomerVehicleGet req = request as WA.Standard.IF.Data.v2.Common.CustomerVehicle.CustomerVehicleGet;
                    if (req.Customer != null)
                    {
                        if (!string.IsNullOrEmpty(req.Customer.CardNo))
                        {
                            if(req.Customer.CardNo.Length >= 3)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Short_CardNo, ResponseMessage.CVG_Short_CardNo));
                        }
                        if (!string.IsNullOrEmpty(req.Customer.DMSCustomerNo))
                                validcount++;
                        if (!string.IsNullOrEmpty(req.Customer.Email))
                        {
                            if (req.Customer.Email.Length >= 3)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Short_Email, ResponseMessage.CVG_Short_Email));
                        }
                        if (!string.IsNullOrEmpty(req.Customer.LastName))
                        {
                            if (req.Customer.LastName.Length >= 3)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Short_LastName, ResponseMessage.CVG_Short_LastName));
                        }

                        if (req.Customer.Contacts != null && req.Customer.Contacts.Count > 0)
                        {
                            foreach (WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact contact in req.Customer.Contacts)
                            {
                                if (!string.IsNullOrEmpty(contact.ContactType))
                                    validcount++;
                                if (!string.IsNullOrEmpty(contact.ContactValue))
                                {
                                    if (contact.ContactValue.Length >= 4)
                                        validcount++;
                                    else
                                        errorDataList.Add(GetErrorData(ResponseCode.CVG_Short_ContactValue, ResponseMessage.CVG_Short_ContactValue));
                                }
                            }
                        }

                    }

                    if (req.Vehicle != null)
                    {
                        if (!string.IsNullOrEmpty(req.Vehicle.DMSVehicleNo))
                            validcount++;
                        if (!string.IsNullOrEmpty(req.Vehicle.LastSixVIN))
                        {
                            if (req.Vehicle.LastSixVIN.Length != 6)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Invalid_LastSixVIN, ResponseMessage.CVG_Invalid_LastSixVIN));
                        }
                        if (!string.IsNullOrEmpty(req.Vehicle.LicensePlateNo))
                        {
                            if (req.Vehicle.LicensePlateNo.Length >= 4)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Short_LicensePlateNo, ResponseMessage.CVG_Short_LicensePlateNo));
                        }
                        if (!string.IsNullOrEmpty(req.Vehicle.VIN))
                        {
                            if (req.Vehicle.VIN.Length != 17)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.CVG_Invalid_VIN, ResponseMessage.CVG_Invalid_VIN));
                        }
                    }

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.Employee.EmployeeGet) == (request.GetType()))
                {
                    #region//EmployeeGet Validation
                    WA.Standard.IF.Data.v2.Common.Employee.EmployeeGet req = request as WA.Standard.IF.Data.v2.Common.Employee.EmployeeGet;

                    if (!string.IsNullOrEmpty(req.DMSEmployeeNo))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.LoginID))
                        validcount++;
                    if (req.LastModifiedDateTimeFromUTC != null)
                        validcount++;
                    if (req.LastModifiedDateTimeToUTC != null)
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.Message.MessageReceive) == (request.GetType()))
                {
                    #region//MessageReceive Validation
                    WA.Standard.IF.Data.v2.Common.Message.MessageReceive req = request as WA.Standard.IF.Data.v2.Common.Message.MessageReceive;

                    if (!string.IsNullOrEmpty(req.ActionType) && !string.IsNullOrEmpty(req.MessageID) && !string.IsNullOrEmpty(req.MessageType))
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.OPCode.OPCodeGet) == (request.GetType()))
                {
                    #region//OPCodeGet Validation
                    WA.Standard.IF.Data.v2.Common.OPCode.OPCodeGet req = request as WA.Standard.IF.Data.v2.Common.OPCode.OPCodeGet;

                    if (!string.IsNullOrEmpty(req.Category))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Code))
                    {
                        if (req.Code.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.OCG_Short_Code, ResponseMessage.OCG_Short_Code));
                    }
                    if (!string.IsNullOrEmpty(req.Description))
                    {
                        if (req.Code.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.OCG_Short_Description, ResponseMessage.OCG_Short_Description));
                    }
                    if (!string.IsNullOrEmpty(req.Engine))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Make))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Mileage))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Model))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Year))
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.PackageCode.PackageCodeGet) == (request.GetType()))
                {
                    #region//PackageCodeGet Validation
                    WA.Standard.IF.Data.v2.Common.PackageCode.PackageCodeGet req = request as WA.Standard.IF.Data.v2.Common.PackageCode.PackageCodeGet;

                    if (!string.IsNullOrEmpty(req.Category))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Code))
                    {
                        if (req.Code.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.PCG_Short_Code, ResponseMessage.PCG_Short_Code));
                    }
                    if (!string.IsNullOrEmpty(req.Description))
                    {
                        if (req.Description.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.PCG_Short_Description, ResponseMessage.PCG_Short_Description));
                    }
                    if (!string.IsNullOrEmpty(req.Engine))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Make))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Mileage))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Model))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Year))
                        validcount++;
                    if (req.LastModifiedDateTimeFromUTC != null)
                        validcount++;
                    if (req.LastModifiedDateTimeToUTC != null)
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.Part.PartsGet) == (request.GetType()))
                {
                    #region//PartsGet Validation
                    WA.Standard.IF.Data.v2.Common.Part.PartsGet req = request as WA.Standard.IF.Data.v2.Common.Part.PartsGet;

                    if (!string.IsNullOrEmpty(req.Category))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Engine))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Make))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Manufacturer))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Mileage))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.Model))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.PartDescription))
                    {
                        if (req.PartDescription.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.PG_Short_Description, ResponseMessage.PG_Short_Description));
                    }
                    if (!string.IsNullOrEmpty(req.PartNumber))
                    {
                        if (req.PartNumber.Length >= 3)
                            validcount++;
                        else
                            errorDataList.Add(GetErrorData(ResponseCode.PG_Short_Code, ResponseMessage.PG_Short_Code));
                    }
                    if (!string.IsNullOrEmpty(req.Year))
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }

                else if (typeof(WA.Standard.IF.Data.v2.Common.RepairOrder.RepairOrderGet) == (request.GetType()))
                {
                    #region//RepairOrderGet Validation
                    WA.Standard.IF.Data.v2.Common.RepairOrder.RepairOrderGet req = request as WA.Standard.IF.Data.v2.Common.RepairOrder.RepairOrderGet;

                    if (!string.IsNullOrEmpty(req.DMSAppointmentID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSAppointmentNo))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSROID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSRONo))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.DMSROStatus))
                        validcount++;
                    if (req.LastModifiedDateTimeFromUTC != null)
                        validcount++;
                    if (req.LastModifiedDateTimeToUTC != null)
                        validcount++;
                    if (req.OpenDateTimeFromLocal != null)
                        validcount++;
                    if (req.OpenDateTimeToLocal != null)
                        validcount++;
                    if (!string.IsNullOrEmpty(req.SAEmployeeID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.SAEmployeeName))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.TCEmployeeID))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.TCEmployeeName))
                        validcount++;

                    if (req.Customer != null)
                    {
                        if (req.Customer.DMSCustomerNo != null)
                            validcount++;
                        if (req.Customer.LastName != null)
                        {
                            if (req.Customer.LastName.Length >= 3)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.ROG_Short_LastName, ResponseMessage.ROG_Short_LastName));
                        }

                        if (req.Customer.Contacts != null && req.Customer.Contacts.Count > 0)
                        {
                            foreach (WA.Standard.IF.Data.v2.Common.RepairOrder.Contact contact in req.Customer.Contacts)
                            {
                                if (!string.IsNullOrEmpty(contact.ContactType))
                                    validcount++;
                                if (!string.IsNullOrEmpty(contact.ContactValue))
                                {
                                    if (contact.ContactValue.Length >= 3)
                                        validcount++;
                                    else
                                        errorDataList.Add(GetErrorData(ResponseCode.ROG_Short_ContactValue, ResponseMessage.ROG_Short_ContactValue));
                                }
                            }
                        }
                    }

                    if (req.Vehicle != null)
                    {
                        if (!string.IsNullOrEmpty(req.Vehicle.DMSVehicleNo))
                            validcount++;
                        if (!string.IsNullOrEmpty(req.Vehicle.LastSixVIN))
                        {
                            if (req.Vehicle.LastSixVIN.Length != 6)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.ROG_Invalid_LastSixVIN, ResponseMessage.ROG_Invalid_LastSixVIN));
                        }
                        if (!string.IsNullOrEmpty(req.Vehicle.VIN))
                        {
                            if (req.Vehicle.VIN.Length != 17)
                                validcount++;
                            else
                                errorDataList.Add(GetErrorData(ResponseCode.ROG_Invalid_VIN, ResponseMessage.ROG_Invalid_VIN));
                        }
                    }

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }              

                else if (typeof(WA.Standard.IF.Data.v2.HMCIS.Print.Print) == (request.GetType()))
                {
                    #region//PrintRequest Validation
                    WA.Standard.IF.Data.v2.HMCIS.Print.Print req = request as WA.Standard.IF.Data.v2.HMCIS.Print.Print;

                    if (!string.IsNullOrEmpty(req.DMSRONo))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.PrintAddress))
                        validcount++;
                    if (!string.IsNullOrEmpty(req.PrintType))
                        validcount++;

                    if (validcount == 0)
                    {
                        errorDataList.Add(GetErrorData(ResponseCode.RequestEmpty, ResponseMessage.RequestEmpty));
                    }

                    #endregion
                }
            }

            return errorDataList.Count > 0 ? errorDataList : null;
        }

        public List<Error> GetErrorDataListFromRequestTransactionHeader(TransactionHeader header)
        {
            List<Error> errorDataList = new List<Error>();

            if (header == null)
            {
                errorDataList.Add(GetErrorData(ResponseCode.TransactionHeaderNull, ResponseMessage.TransactionHeaderNull));
            }
            else
            {
                //if (STIS.Framework.V4.Cryptography.Cryptor.Decrypt(request.TransactionHeader.Username) != "AdminWS" || STIS.Framework.V4.Cryptography.Cryptor.Decrypt(request.TransactionHeader.Password) != "111")
                //if (header.Username != "AdminWS" || header.Password != "111")
                //{
                //    errorDataList.Add(GetErrorData(PredefinedCode._AuthenticationFailed, PredefinedMessage._AuthenticationFailed));
                //}

                //if (string.IsNullOrEmpty(header.DealerID) || header.DealerID.ToUpper() != "PTP")
                //{
                //    errorDataList.Add(GetErrorData(PredefinedCode._EmptyDealerRequest, PredefinedMessage._EmptyDealerRequest));
                //}
            }

            return errorDataList.Count > 0 ? errorDataList : null;
        }

        public ResultMessage GetResultMessageData(string resultCode, string resultMessage)
        {
            ResultMessage resultMessageData = new ResultMessage();
            resultMessageData.Code = resultCode;
            resultMessageData.Message = resultMessage;

            //DB or File Logging ???

            return resultMessageData;
        }

        public Error GetErrorData(string resultCode, string resultMessage)
        {
            Error errorData = new Error();
            errorData.Code = resultCode;
            errorData.Message = resultMessage;

            //DB or File Logging ???

            return errorData;
        }

        public List<Error> GetErrorDataList(string resultCode, string resultMessage)
        {
            List<Error> errorDataList = new List<Error>();
            Error errorData = new Error();
            errorData.Code = resultCode;
            errorData.Message = resultMessage;
            errorDataList.Add(errorData);

            //DB or File Logging ???

            return errorDataList;
        }

        public Error GetErrorDataFromException(Exception ex)
        {
            Error errorData = new Error();
            errorData.Code = ResponseCode.UnHandledError;
            errorData.Message = string.Format("{0}:\r\n{1}", ex.Message, ex.StackTrace);

            //DB or File Logging ???

            return errorData;
        }

        public List<Error> GetErrorDataListFromException(Exception ex)
        {
            List<Error> errorDataList = new List<Error>();
            Error errorData = new Error();
            errorData.Code = ResponseCode.UnHandledError;
            errorData.Message = string.Format("{0}:\r\n{1}", ex.Message, ex.StackTrace);
            errorDataList.Add(errorData);

            //DB or File Logging ???

            return errorDataList;
        }
    }
}