using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.Print
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("PrintRequest", Namespace = "http://wa.dms.webservice/PrintRequest")]
    public class PrintRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private Print _print; public Print Print { get { return this._print; } set { this._print = value; } } 
    }
}
