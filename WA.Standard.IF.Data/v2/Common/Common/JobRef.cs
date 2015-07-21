using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class JobRef
    {
        private string _dmsjobno = string.Empty; public string DMSJobNo { get { return this._dmsjobno; } set { this._dmsjobno = value; } }
        private string _dmsjobstatus = string.Empty; public string DMSJobStatus { get { return this._dmsjobstatus; } set { this._dmsjobstatus = value; } }
    }
}