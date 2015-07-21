using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    public class ResponseMessage
    {
        //Result Message
        public const string Success = "Success";
        public const string NoResult = "No data found";
        public const string Fail = "Fail";

        //Error Message

        //ETC
        public const string NoMatchedProxy = "No matched proxy.dll. Please check your dealer inforamtion in TransactionHeader";

        //Common
        public const string Timeout = "Timeout Exceeded.";
        public const string RequestEmpty = "At least 1 field must be specified.";
        //public const string Unhandled = "Unhandled error message. (Please fill this by detail error description)";
        public const string TransactionHeaderNull = "TransactionHeader can not be null.";
        public const string RequestNull = "Request object can not be null.";


        //AppointmentGet
        public const string AG_Short_LastName="LastName at least 3 characters.";
        public const string AG_Short_ContactValue = "ContactValue at least 4 characters.";
        public const string AG_Invalid_VIN = "VIN should be 17 characters.";
        public const string AG_Invalid_LastSixVIN = "LastSixVIN should be 6 characters.";

        //AppointmentChange
        public const string AC_NoLonger = "No longer open and cannot be changed.";
        public const string AC_Invalid_WorkType = "Invalid or missing WorkType.";
        public const string AC_Invalid_ServiceType = "Invalid or missing ServiceType.";
        public const string AC_Invalid_VIN = "Invalid or missing VIN.";
        public const string AC_Invalid_InMileage = "Invalid or missing InMileage.";
        public const string AC_Invalid_DMSCustomerNo = "Invalid or missing DMSCustomerNo.";
        public const string AC_Invalid_CustomerName = "Invalid or missing CustomerName.";
        public const string AC_Invalid_ContactValue = "Invalid or missing ContactValue.";
        public const string AC_Invalid_SAEmployeeID = "Invalid or missing SAEmployeeID.";
        public const string AC_RequestItem_Invalid_ServiceLineNumber = "RequestItem - invalid or missing ServiceLineNumber.";
        public const string AC_RequestItem_Invalid_ServiceLineStatus = "RequestItem - invalid or missing ServiceLineStatus.";
        public const string AC_RequestItem_Invalid_Code = "RequestItem - invalid or missing RequestCode.";
        public const string AC_RequestItem_Invalid_WorkType = "RequestItem - invalid or missing WorkType.";
        public const string AC_RequestItem_Invalid_ServiceType = "RequestItem - invalid or missing ServiceType.";
        public const string AC_OPCode_Invalid_SequenceNumber = "OPCode - invalid or missing SequenceNumber.";
        public const string AC_OPCode_Invalid_Code = "OPCode - invalid or missing Code.";
        public const string AC_OPCode_Invalid_ServiceType = "OPCode - invalid or missing ServiceType.";
        public const string AC_Part_Invalid_SequenceNumber = "Part - invalid or missing SequenceNumber.";
        public const string AC_Part_Invalid_PartNumber = "Part - invalid or missing PartNumber.";
        public const string AC_Part_Invalid_ServiceType = "Part - invalid or missing ServiceType.";
        public const string AC_Sulbet_Invalid_SequenceNumber = "Sulbet - invalid or missing SequenceNumber.";
        public const string AC_Sulbet_Invalid_ServiceType = "Sulbet - invalid or missing ServiceType.";
        public const string AC_MISC_Invalid_SequenceNumber = "MISC - invalid or missing SequenceNumber.";
        public const string AC_MISC_Invalid_ServiceType = "MISC - invalid or missing ServiceType.";
        public const string AC_Description_Invalid_SequenceNumber = "Description - invalid or missing SequenceNumber.";
        public const string AC_Comment_Invalid_SequenceNumber = "Comment - invalid or missing SequenceNumber.";
        public const string AC_Cause_Invalid_SequenceNumber = "Cause - invalid or missing SequenceNumber.";
        public const string AC_Correction_Invalid_SequenceNumber = "Correction - invalid or missing SequenceNumber.";

        //AppointmentDelete
        public const string AD_NoLonger = "No longer open and cannot be changed.";
        public const string AD_NotExist_DMSAppointmentNo = "The DMSAppointmentNo does not exist";
        public const string AD_NotExist_ServiceLineNumber = "The ServiceLineNumber does not exist";
        public const string AD_NotExist_SequenceNumber = "The SequenceNumber does not exist";

        //CustomerVehicleGet
        public const string CVG_Short_LastName = "LastName at least 3 characters.";
        public const string CVG_Short_Email = "Email at least 3 characters.";
        public const string CVG_Short_CardNo = "CardNo at least 3 characters.";
        public const string CVG_Short_ContactValue = "ContactValue at least 4 characters.";
        public const string CVG_Invalid_VIN = "VIN should be 17 characters.";
        public const string CVG_Invalid_LastSixVIN = "LastSixVIN should be 6 characters.";
        public const string CVG_Short_LicensePlateNo = "LicensePlateNo at least 4 characters.";

        //CustomerVehicleChange
        public const string CVC_Invalid_DMSCustomerNo = "Invalid or missing DMSCustomerNo.";
        public const string CVC_Validation_Name = "Validation failed on [First or Last] Name.";
        public const string CVC_Invalid_AddressType = "Invalid or missing AddressType.";
        public const string CVC_Validation_Address = "Validation failed on [Address1 or Address2] Address.";
        public const string CVC_Invalid_ContactType = "Invalid or missing ContactType.";
        public const string CVC_Invalid_DMSVehicleNo = "Invalid or missing DMSVehicleNo.";
        public const string CVC_Invalid_VIN = "Invalid or missing VIN.";
        public const string CVC_LessThan_LastMileage = "LastMileage must be greater than last recorded vehicle mileage.";

        //RepairOrderGet
        public const string ROG_Short_LastName = "LastName at least 3 characters.";
        public const string ROG_Short_ContactValue = "ContactValue at least 4 characters.";
        public const string ROG_Invalid_VIN = "VIN should be 17 characters.";
        public const string ROG_Invalid_LastSixVIN = "LastSixVIN should be 6 characters.";

        //RepairOrderChange
        public const string ROC_NoLonger = "No longer open and cannot be changed.";
        public const string ROC_Invalid_WorkType = "Invalid or missing WorkType.";
        public const string ROC_Invalid_ServiceType = "Invalid or missing ServiceType.";
        public const string ROC_Invalid_VIN = "Invalid or missing VIN.";
        public const string ROC_Invalid_InMileage = "Invalid or missing InMileage.";
        public const string ROC_Invalid_DMSCustomerNo = "Invalid or missing DMSCustomerNo.";
        public const string ROC_Invalid_CustomerName = "Invalid or missing CustomerName.";
        public const string ROC_Invalid_ContactValue = "Invalid or missing ContactValue.";
        public const string ROC_Invalid_SAEmployeeID = "Invalid or missing SAEmployeeID.";
        public const string ROC_RequestItem_Invalid_ServiceLineNumber = "RequestItem - invalid or missing ServiceLineNumber.";
        public const string ROC_RequestItem_Invalid_ServiceLineStatus = "RequestItem - invalid or missing ServiceLineStatus.";
        public const string ROC_RequestItem_Invalid_Code = "RequestItem - invalid or missing RequestCode.";
        public const string ROC_RequestItem_Invalid_WorkType = "RequestItem - invalid or missing WorkType.";
        public const string ROC_RequestItem_Invalid_ServiceType = "RequestItem - invalid or missing ServiceType.";
        public const string ROC_OPCode_Invalid_SequenceNumber = "OPCode - invalid or missing SequenceNumber.";
        public const string ROC_OPCode_Invalid_Code = "OPCode - invalid or missing Code.";
        public const string ROC_OPCode_Invalid_ServiceType = "OPCode - invalid or missing ServiceType.";
        public const string ROC_Part_Invalid_SequenceNumber = "Part - invalid or missing SequenceNumber.";
        public const string ROC_Part_Invalid_PartNumber = "Part - invalid or missing PartNumber.";
        public const string ROC_Part_Invalid_ServiceType = "Part - invalid or missing ServiceType.";
        public const string ROC_Sulbet_Invalid_SequenceNumber = "Sulbet - invalid or missing SequenceNumber.";
        public const string ROC_Sulbet_Invalid_ServiceType = "Sulbet - invalid or missing ServiceType.";
        public const string ROC_MISC_Invalid_SequenceNumber = "MISC - invalid or missing SequenceNumber.";
        public const string ROC_MISC_Invalid_ServiceType = "MISC - invalid or missing ServiceType.";
        public const string ROC_Description_Invalid_SequenceNumber = "Description - invalid or missing SequenceNumber.";
        public const string ROC_Comment_Invalid_SequenceNumber = "Comment - invalid or missing SequenceNumber.";
        public const string ROC_Cause_Invalid_SequenceNumber = "Cause - invalid or missing SequenceNumber.";
        public const string ROC_Correction_Invalid_SequenceNumber = "Correction - invalid or missing SequenceNumber.";

        //RepairOrderDelete
        public const string ROD_NoLonger = "No longer open and cannot be changed.";
        public const string ROD_NotExist_DMSAppointmentNo = "The DMSAppointmentNo does not exist";
        public const string ROD_NotExist_ServiceLineNumber = "The ServiceLineNumber does not exist";
        public const string ROD_NotExist_SequenceNumber = "The SequenceNumber does not exist";

        //JobChange
        public const string JC_NoLonger = "No longer open and cannot be changed.";
        public const string JC_Invalid_DMSRONo = "Invalid or missing DMSRONo.";
        public const string JC_Invalid_DMSAppintmentNo = "Invalid or missing DMSAppintmentNo";
        public const string JC_Invalid_ServiceLineNumber = "Invalid or missing ServiceLineNumber";
        public const string JC_Description_Invalid_SequenceNumber = "Description - invalid or missing SequenceNumber.";
        public const string JC_Comment_Invalid_SequenceNumber = "Comment - invalid or missing SequenceNumber.";
        public const string JC_Cause_Invalid_SequenceNumber = "Cause - invalid or missing SequenceNumber.";
        public const string JC_Correction_Invalid_SequenceNumber = "Correction - invalid or missing SequenceNumber.";
        public const string JC_OPCode_Invalid_Code = "OPCode - invalid or missing Code.";
        public const string JC_JobLog_Invalid_LogType = "JobLog - invalid or missing LogType.";
        public const string JC_JobLog_Invalid_Stall = "JobLog - invalid or missing Stall.";
        public const string JC_Technician_Invalid_TCEmployeeID = "Technician - invalid or missing TCEmployeeID.";
        public const string JC_ActualTimeLog_Invalid_TCEmployeeID = "ActualTimeLog - invalid or missing TCEmployeeID.";

        //JobDelete
        public const string JD_NoLonger = "No longer open and cannot be changed.";
        public const string JD_NotExist_DMSAppointmentNo = "The DMSAppointmentNo does not exist";
        public const string JD_NotExist_DMSRONo = "The DMSRONo does not exist";
        public const string JD_NotExist_ServiceLineNumber = "The ServiceLineNumber does not exist";

        //PackageCodeGet
        public const string PCG_Short_Code="Code at least 3 characters.";
        public const string PCG_Short_Description="Description at least 3 characters.";

        //OPCodeGet
        public const string OCG_Short_Code = "Code at least 3 characters.";
        public const string OCG_Short_Description = "Description at least 3 characters.";

        //PartGet
        public const string PG_Short_Code = "PartNumber at least 3 characters.";
        public const string PG_Short_Description = "PartDescription at least 3 characters.";

        //PrintRequest
        public const string PR_Invalid_DMSRONo = "Invalid or missing DMSRONo.";
        public const string PR_Invalid_PrintType = "Invalid or missing PrintType.";
        public const string PR_Invalid_PrintAddress = "Invalid or missing PrintAddress.";

        //PriceCheck
        public const string PC_Invalid_DMSRONo = "Invalid or missing DMSRONo.";
        public const string PC_Invalid_Code = "Invalid or missing Code.";
        public const string PC_Invalid_PartNumber = "Invalid or missing PartNumber.";
       
        //MessageReceive
        public const string MR_Invalid_MessageID = "Invalid or missing MessageID.";
        public const string MR_Invalid_MessageType = "Invalid or missing MessageType.";
        public const string MR_Invalid_ActionType = "Invalid or missing ActionType.";

        //MessageSend
        public const string MS_Invalid_MessageID = "Invalid or missing MessageID.";
        public const string MS_Invalid_MessageType = "Invalid or missing MessageType.";
        public const string MS_Invalid_ActionType = "Invalid or missing ActionType.";

    }
}
