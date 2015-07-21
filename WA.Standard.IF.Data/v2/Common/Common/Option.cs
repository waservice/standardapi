using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class Option
    {
        private string _optionname = string.Empty; public string OptionName { get { return this._optionname; } set { this._optionname = value; } }
        private string _optionvalue = string.Empty; public string OptionValue { get { return this._optionvalue; } set { this._optionvalue = value; } }
    }
}