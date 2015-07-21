using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Customer
{
    [Serializable]
    public class SpecialMessage
    {
        private string _message = string.Empty; public string Message { get { return this._message; } set { this._message = value; } }
    }
}