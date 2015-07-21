using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.HMCIS.Print
{
    [Serializable]
    public class Print
    {
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _printtype = string.Empty; public string PrintType { get { return this._printtype; } set { this._printtype = value; } }
        private string _printaddress = string.Empty; public string PrintAddress { get { return this._printaddress; } set { this._printaddress = value; } }
    }
}
