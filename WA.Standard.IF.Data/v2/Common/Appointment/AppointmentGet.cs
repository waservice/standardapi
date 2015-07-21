using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Appointment
{
    [Serializable]
    public class AppointmentGet
    {
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsappointmentid = string.Empty; public string DMSAppointmentID { get { return this._dmsappointmentid; } set { this._dmsappointmentid = value; } }
        private DateTime? _appointmentdatetimefromlocal; public DateTime? AppointmentDateTimeFromLocal { get { return this._appointmentdatetimefromlocal; } set { this._appointmentdatetimefromlocal = value; } }
        private DateTime? _appointmentdatetimetolocal; public DateTime? AppointmentDateTimeToLocal { get { return this._appointmentdatetimetolocal; } set { this._appointmentdatetimetolocal = value; } }
        private DateTime? _lastmodifieddatetimefromutc; public DateTime? LastModifiedDateTimeFromUTC { get { return this._lastmodifieddatetimefromutc; } set { this._lastmodifieddatetimefromutc = value; } }
        private DateTime? _lastmodifieddatetimetoutc; public DateTime? LastModifiedDateTimeToUTC { get { return this._lastmodifieddatetimetoutc; } set { this._lastmodifieddatetimetoutc = value; } }
        private string _dmsappointmentstatus = string.Empty; public string DMSAppointmentStatus { get { return this._dmsappointmentstatus; } set { this._dmsappointmentstatus = value; } }
        private string _saemployeeid = string.Empty; public string SAEmployeeID { get { return this._saemployeeid; } set { this._saemployeeid = value; } }
        private string _saemployeename = string.Empty; public string SAEmployeeName { get { return this._saemployeename; } set { this._saemployeename = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private v2.Common.Appointment.Customer _customer; public v2.Common.Appointment.Customer Customer { get { return this._customer; } set { this._customer = value; } }
        private v2.Common.Appointment.Vehicle _vehicle; public v2.Common.Appointment.Vehicle Vehicle { get { return this._vehicle; } set { this._vehicle = value; } }
    }
}
