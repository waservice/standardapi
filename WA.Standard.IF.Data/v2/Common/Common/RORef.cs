using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class RORef
    {
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _dmsroid = string.Empty; public string DMSROID { get { return this._dmsroid; } set { this._dmsroid = value; } }
        private string _dmsrostatus = string.Empty; public string DMSROStatus { get { return this._dmsrostatus; } set { this._dmsrostatus = value; } }
    }
}