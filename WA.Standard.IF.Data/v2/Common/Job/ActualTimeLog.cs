using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class ActualTimeLog
    {
        private DateTime _startdatetimelocal; public DateTime StartDateTimeLocal { get { return this._startdatetimelocal; } set { this._startdatetimelocal = value; } }
        private DateTime _enddatetimelocal; public DateTime EndDateTimeLocal { get { return this._enddatetimelocal; } set { this._enddatetimelocal = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private string _status = string.Empty; public string Status { get { return this._status; } set { this._status = value; } }
        private string _pausereasoncode = string.Empty; public string PauseReasonCode { get { return this._pausereasoncode; } set { this._pausereasoncode = value; } }
        private string _pausereasoncomment = string.Empty; public string PauseReasonComment { get { return this._pausereasoncomment; } set { this._pausereasoncomment = value; } }
    }
}
