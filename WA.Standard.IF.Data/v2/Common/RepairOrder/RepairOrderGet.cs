using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class RepairOrderGet
    {
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsappointmentid = string.Empty; public string DMSAppointmentID { get { return this._dmsappointmentid; } set { this._dmsappointmentid = value; } }
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _dmsroid = string.Empty; public string DMSROID { get { return this._dmsroid; } set { this._dmsroid = value; } }
        private DateTime _opendatetimefromlocal; public DateTime OpenDateTimeFromLocal { get { return this._opendatetimefromlocal; } set { this._opendatetimefromlocal = value; } }
        private DateTime _opendatetimetolocal; public DateTime OpenDateTimeToLocal { get { return this._opendatetimetolocal; } set { this._opendatetimetolocal = value; } }
        private DateTime _lastmodifieddatetimefromutc; public DateTime LastModifiedDateTimeFromUTC { get { return this._lastmodifieddatetimefromutc; } set { this._lastmodifieddatetimefromutc = value; } }
        private DateTime _lastmodifieddatetimetoutc; public DateTime LastModifiedDateTimeToUTC { get { return this._lastmodifieddatetimetoutc; } set { this._lastmodifieddatetimetoutc = value; } }
        private string _dmsrostatus = string.Empty; public string DMSROStatus { get { return this._dmsrostatus; } set { this._dmsrostatus = value; } }
        private string _saemployeeid = string.Empty; public string SAEmployeeID { get { return this._saemployeeid; } set { this._saemployeeid = value; } }
        private string _saemployeename = string.Empty; public string SAEmployeeName { get { return this._saemployeename; } set { this._saemployeename = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private v2.Common.RepairOrder.Customer _customer; public v2.Common.RepairOrder.Customer Customer { get { return this._customer; } set { this._customer = value; } }
        private v2.Common.RepairOrder.Vehicle _vehicle; public v2.Common.RepairOrder.Vehicle Vehicle { get { return this._vehicle; } set { this._vehicle = value; } }
    }
}
