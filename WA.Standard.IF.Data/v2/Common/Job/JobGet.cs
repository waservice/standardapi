using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class JobGet
    {
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _dmsjobno = string.Empty; public string DMSJobNo { get { return this._dmsjobno; } set { this._dmsjobno = value; } }
        private string _dmsjobstatus = string.Empty; public string DMSJobStatus { get { return this._dmsjobstatus; } set { this._dmsjobstatus = value; } }
        private DateTime? _scheduleddatetimefromlocal; public DateTime? ScheduledDateTimeFromLocal { get { return this._scheduleddatetimefromlocal; } set { this._scheduleddatetimefromlocal = value; } }
        private DateTime? _scheduleddatetimetolocal; public DateTime? ScheduledDateTimeToLocal { get { return this._scheduleddatetimetolocal; } set { this._scheduleddatetimetolocal = value; } }
        private DateTime? _lastmodifieddatetimefromutc; public DateTime? LastModifiedDateTimeFromUTC { get { return this._lastmodifieddatetimefromutc; } set { this._lastmodifieddatetimefromutc = value; } }
        private DateTime? _lastmodifieddatetimetoutc; public DateTime? LastModifiedDateTimeToUTC { get { return this._lastmodifieddatetimetoutc; } set { this._lastmodifieddatetimetoutc = value; } }
    }
}
