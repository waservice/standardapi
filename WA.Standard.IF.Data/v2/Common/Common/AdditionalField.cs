using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class AdditionalField
    {
        private string _additionalfieldname = string.Empty; public string AdditionalFieldName { get { return this._additionalfieldname; } set { this._additionalfieldname = value; } }
        private string _additionalfielvalue = string.Empty; public string AdditionalFieldValue { get { return this._additionalfielvalue; } set { this._additionalfielvalue = value; } }
    }
}