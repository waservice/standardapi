using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class ResultMessage
    {
        private string _resultcode = string.Empty; public string Code { get { return this._resultcode; } set { this._resultcode = value; } }
        private string _resultmessage = string.Empty; public string Message { get { return this._resultmessage; } set { this._resultmessage = value; } }
    }
}