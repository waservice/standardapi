using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Customer
{
    [Serializable]
    public class CorporateInfo
    {
        private string _corporateinfoname = string.Empty; public string CorporateInfoName { get { return this._corporateinfoname; } set { this._corporateinfoname = value; } }
        private string _corporateinfovalue = string.Empty; public string CorporateInfoValue { get { return this._corporateinfovalue; } set { this._corporateinfovalue = value; } }
    }
}