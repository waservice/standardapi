using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class JobLog
    {
        private string _logtype = string.Empty; public string LogType { get { return this._logtype; } set { this._logtype = value; } }
        private string _stall = string.Empty; public string Stall { get { return this._stall; } set { this._stall = value; } }
        private string _dmsjobstatus = string.Empty; public string DMSJobStatus { get { return this._dmsjobstatus; } set { this._dmsjobstatus = value; } }
        private string _estimatedlaborhour; public string EstimatedLaborHour { get { return this._estimatedlaborhour; } set { this._estimatedlaborhour = value; } }
        private DateTime _scheduleddatetimefromlocal; public DateTime ScheduledDateTimeFromLocal { get { return this._scheduleddatetimefromlocal; } set { this._scheduleddatetimefromlocal = value; } }
        private DateTime _scheduleddatetimetolocal; public DateTime ScheduledDateTimeToLocal { get { return this._scheduleddatetimetolocal; } set { this._scheduleddatetimetolocal = value; } }
        private List<Technician> _technicians; public List<Technician> Technicians { get { return this._technicians; } set { this._technicians = value; } }
        private List<ActualTimeLog> _actualtimelogs; public List<ActualTimeLog> ActualTimeLogs { get { return this._actualtimelogs; } set { this._actualtimelogs = value; } }
        private List<JobComment> _jobcomments; public List<JobComment> JobComments { get { return this._jobcomments; } set { this._jobcomments = value; } }
    }
}
