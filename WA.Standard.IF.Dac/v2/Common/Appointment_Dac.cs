using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.Appointment;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class Appointment_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public Appointment_Dac() : base("DBCONN_DMS") { }

        //Get Appointment
        public DataSet SelectAppointment(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , string ContactType
                                        , string ContactValue
                                        , AppointmentGet request
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("DMS_Appointment_Q");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);
            _agent.AddInParameter(command, "@DMSAppointmentNo", DbType.String, request.DMSAppointmentNo);
            _agent.AddInParameter(command, "@DMSAppointmentID", DbType.String, request.DMSAppointmentID);
            _agent.AddInParameter(command, "@AppointmentDateTimeFromLocal", DbType.DateTime, request.AppointmentDateTimeFromLocal);
            _agent.AddInParameter(command, "@AppointmentDateTimeToLocal", DbType.DateTime, request.AppointmentDateTimeToLocal);
            _agent.AddInParameter(command, "@LastModifiedDateTimeFromUTC", DbType.DateTime, request.LastModifiedDateTimeFromUTC);
            _agent.AddInParameter(command, "@LastModifiedDateTimeToUTC", DbType.DateTime, request.LastModifiedDateTimeToUTC);
            _agent.AddInParameter(command, "@DMSAppointmentStatus", DbType.String, request.DMSAppointmentStatus);
            _agent.AddInParameter(command, "@SAEmployeeID", DbType.String, request.SAEmployeeID);
            _agent.AddInParameter(command, "@SAEmployeeName", DbType.String, request.SAEmployeeName);
            _agent.AddInParameter(command, "@TCEmployeeID", DbType.String, request.TCEmployeeID);
            _agent.AddInParameter(command, "@TCEmployeeName", DbType.String, request.TCEmployeeName);
            _agent.AddInParameter(command, "@DMSCustomerNo", DbType.String, request.Customer.DMSCustomerNo);
            _agent.AddInParameter(command, "@LastName", DbType.String, request.Customer.LastName);
            _agent.AddInParameter(command, "@ContactType", DbType.String, ContactType);
            _agent.AddInParameter(command, "@ContactValue", DbType.String, ContactValue);
            _agent.AddInParameter(command, "@DMSVehicleNo", DbType.String, request.Vehicle.DMSVehicleNo);
            _agent.AddInParameter(command, "@VIN", DbType.String, request.Vehicle.VIN);
            _agent.AddInParameter(command, "@LastSixVIN", DbType.String, request.Vehicle.LastSixVIN);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}
