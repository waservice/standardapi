using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Employee
{
    [Serializable]
    public class EmployeeGet
    {
        private string _dmsemployeeno = string.Empty; public string DMSEmployeeNo { get { return this._dmsemployeeno; } set { this._dmsemployeeno = value; } }
        private string _loginid = string.Empty; public string LoginID { get { return this._loginid; } set { this._loginid = value; } }
        private DateTime? _lastmodifieddatetimefromutc; public DateTime? LastModifiedDateTimeFromUTC { get { return this._lastmodifieddatetimefromutc; } set { this._lastmodifieddatetimefromutc = value; } }
        private DateTime? _lastmodifieddatetimetoutc; public DateTime? LastModifiedDateTimeToUTC { get { return this._lastmodifieddatetimetoutc; } set { this._lastmodifieddatetimetoutc = value; } }
    }
}
