using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class Error
    {
        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _message = string.Empty; public string Message { get { return this._message; } set { this._message = value; } }
    }
}