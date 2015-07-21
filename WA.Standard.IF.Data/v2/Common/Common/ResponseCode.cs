using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    public class ResponseCode
    {
        //Result Code
        public const string Success = "1";
        public const string NoResult = "0";
        public const string Fail = "-1";

        //Error Code

        //ETC
        public const string NoMatchedProxy = "F100NMP";

        //Common
        public const string Timeout = "WA01";
        public const string RequestEmpty = "WA02";
        public const string UnHandledError = "WA03";
        public const string TransactionHeaderNull = "WA04";
        public const string RequestNull = "WA05";

        //AppointmentGet
        public const string AG_Short_LastName = "AG01";
        public const string AG_Short_ContactValue = "AG02";
        public const string AG_Invalid_VIN = "AG03";
        public const string AG_Invalid_LastSixVIN = "AG04";

        //AppointmentChange
        public const string AC_NoLonger = "AC01";
        public const string AC_Invalid_WorkType = "AC02";
        public const string AC_Invalid_ServiceType = "AC03";
        public const string AC_Invalid_VIN = "AC04";
        public const string AC_Invalid_InMileage = "AC05";
        public const string AC_Invalid_DMSCustomerNo = "AC06";
        public const string AC_Invalid_CustomerName = "AC07";
        public const string AC_Invalid_ContactValue = "AC08";
        public const string AC_Invalid_SAEmployeeID = "AC09";
        public const string AC_RequestItem_Invalid_ServiceLineNumber = "AC10";
        public const string AC_RequestItem_Invalid_ServiceLineStatus = "AC11";
        public const string AC_RequestItem_Invalid_Code = "AC12";
        public const string AC_RequestItem_Invalid_WorkType = "AC13";
        public const string AC_RequestItem_Invalid_ServiceType = "AC14";
        public const string AC_OPCode_Invalid_SequenceNumber = "AC15";
        public const string AC_OPCode_Invalid_Code = "AC16";
        public const string AC_OPCode_Invalid_ServiceType = "AC17";
        public const string AC_Part_Invalid_SequenceNumber = "AC18";
        public const string AC_Part_Invalid_PartNumber = "AC19";
        public const string AC_Part_Invalid_ServiceType = "AC20";
        public const string AC_Sulbet_Invalid_SequenceNumber = "AC21";
        public const string AC_Sulbet_Invalid_ServiceType = "AC22";
        public const string AC_MISC_Invalid_SequenceNumber = "AC23";
        public const string AC_MISC_Invalid_ServiceType = "AC24";
        public const string AC_Description_Invalid_SequenceNumber = "AC25";
        public const string AC_Comment_Invalid_SequenceNumber = "AC26";
        public const string AC_Cause_Invalid_SequenceNumber = "AC27";
        public const string AC_Correction_Invalid_SequenceNumber = "AC28";

        //AppointmentDelete
        public const string AD_NoLonger = "AD01";
        public const string AD_NotExist_DMSAppointmentNo = "AD02";
        public const string AD_NotExist_ServiceLineNumber = "AD03";
        public const string AD_NotExist_SequenceNumber = "AD04";

        //CustomerVehicleGet
        public const string CVG_Short_LastName = "CVG01";
        public const string CVG_Short_Email = "CVG02";
        public const string CVG_Short_CardNo = "CVG03";
        public const string CVG_Short_ContactValue = "CVG04";
        public const string CVG_Invalid_VIN = "CVG05";
        public const string CVG_Invalid_LastSixVIN = "CVG06";
        public const string CVG_Short_LicensePlateNo = "CVG07";

        //CustomerVehicleChange
        public const string CVC_Invalid_DMSCustomerNo = "CVC01";
        public const string CVC_Validation_Name = "CVC02";
        public const string CVC_Invalid_AddressType = "CVC03";
        public const string CVC_Validation_Address = "CVC04";
        public const string CVC_Invalid_ContactType = "CVC05";
        public const string CVC_Invalid_DMSVehicleNo = "CVC06";
        public const string CVC_Invalid_VIN = "CVC07";
        public const string CVC_LessThan_LastMileage = "CVC08";

        //RepairOrderGet
        public const string ROG_Short_LastName = "ROG01";
        public const string ROG_Short_ContactValue = "ROG02";
        public const string ROG_Invalid_VIN = "ROG03";
        public const string ROG_Invalid_LastSixVIN = "ROG04";

        //RepairOrderChange
        public const string ROC_NoLonger = "ROC01";
        public const string ROC_Invalid_WorkType = "ROC02";
        public const string ROC_Invalid_ServiceType = "ROC03";
        public const string ROC_Invalid_VIN = "ROC04";
        public const string ROC_Invalid_InMileage = "ROC05";
        public const string ROC_Invalid_DMSCustomerNo = "ROC06";
        public const string ROC_Invalid_CustomerName = "ROC07";
        public const string ROC_Invalid_ContactValue = "ROC08";
        public const string ROC_Invalid_SAEmployeeID = "ROC09";
        public const string ROC_RequestItem_Invalid_ServiceLineNumber = "ROC10";
        public const string ROC_RequestItem_Invalid_ServiceLineStatus = "ROC11";
        public const string ROC_RequestItem_Invalid_Code = "ROC12";
        public const string ROC_RequestItem_Invalid_WorkType = "ROC13";
        public const string ROC_RequestItem_Invalid_ServiceType = "ROC14";
        public const string ROC_OPCode_Invalid_SequenceNumber = "ROC15";
        public const string ROC_OPCode_Invalid_Code = "ROC16";
        public const string ROC_OPCode_Invalid_ServiceType = "ROC17";
        public const string ROC_Part_Invalid_SequenceNumber = "ROC18";
        public const string ROC_Part_Invalid_PartNumber = "ROC19";
        public const string ROC_Part_Invalid_ServiceType = "ROC20";
        public const string ROC_Sulbet_Invalid_SequenceNumber = "ROC21";
        public const string ROC_Sulbet_Invalid_ServiceType = "ROC22";
        public const string ROC_MISC_Invalid_SequenceNumber = "ROC23";
        public const string ROC_MISC_Invalid_ServiceType = "ROC24";
        public const string ROC_Description_Invalid_SequenceNumber = "ROC25";
        public const string ROC_Comment_Invalid_SequenceNumber = "ROC26";
        public const string ROC_Cause_Invalid_SequenceNumber = "ROC27";
        public const string ROC_Correction_Invalid_SequenceNumber = "ROC28";

        //RepairOrderDelete
        public const string ROD_NoLonger = "ROD01";
        public const string ROD_NotExist_DMSAppointmentNo = "ROD02";
        public const string ROD_NotExist_ServiceLineNumber = "ROD03";
        public const string ROD_NotExist_SequenceNumber = "ROD04";

        //JobChange
        public const string JC_NoLonger = "JC01";
        public const string JC_Invalid_DMSRONo = "JC02";
        public const string JC_Invalid_DMSAppintmentNo = "JC03";
        public const string JC_Invalid_ServiceLineNumber = "JC04";
        public const string JC_Description_Invalid_SequenceNumber = "JC05";
        public const string JC_Comment_Invalid_SequenceNumber = "JC06";
        public const string JC_Cause_Invalid_SequenceNumber = "JC07";
        public const string JC_Correction_Invalid_SequenceNumber = "JC08";
        public const string JC_OPCode_Invalid_Code = "JC09";
        public const string JC_JobLog_Invalid_LogType = "JC10";
        public const string JC_JobLog_Invalid_Stall = "JC11";
        public const string JC_Technician_Invalid_TCEmployeeID = "JC12";
        public const string JC_ActualTimeLog_Invalid_TCEmployeeID = "JC13";

        //JobDelete
        public const string JD_NoLonger = "JD01";
        public const string JD_NotExist_DMSAppointmentNo = "JD02";
        public const string JD_NotExist_DMSRONo = "JD03";
        public const string JD_NotExist_ServiceLineNumber = "JD04";

        //PackageCodeGet
        public const string PCG_Short_Code = "PCG01";
        public const string PCG_Short_Description = "PCG02";

        //OPCodeGet
        public const string OCG_Short_Code = "OCG01";
        public const string OCG_Short_Description = "OCG02";

        //PartGet
        public const string PG_Short_Code = "PG01";
        public const string PG_Short_Description = "PG02";

        //PrintRequest
        public const string PR_Invalid_DMSRONo = "PR01";
        public const string PR_Invalid_PrintType = "PR02";
        public const string PR_Invalid_PrintAddress = "PR03";

        //PriceCheck
        public const string PC_Invalid_DMSRONo = "PC01";
        public const string PC_Invalid_Code = "PC02";
        public const string PC_Invalid_PartNumber = "PC03";

        //MessageReceive
        public const string MR_Invalid_MessageID = "MR01";
        public const string MR_Invalid_MessageType = "MR02";
        public const string MR_Invalid_ActionType = "MR03";

        //MessageSend
        public const string MS_Invalid_MessageID = "MS01";
        public const string MS_Invalid_MessageType = "MS02";
        public const string MS_Invalid_ActionType = "MS03";

    }
}
