using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class ManagementFields
    {
        private DateTime _createdatetimeutc; public DateTime CreateDateTimeUTC { get { return this._createdatetimeutc; } set { this._createdatetimeutc = value; } }
        private DateTime _lastmodifieddatetimeutc; public DateTime LastModifiedDateTimeUTC { get { return this._lastmodifieddatetimeutc; } set { this._lastmodifieddatetimeutc = value; } }
    }
}