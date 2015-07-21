using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.OPCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("OPCodeGetRequest", Namespace = "http://wa.dms.webservice/OPCodeGetRequest")]
    public class OPCodeGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private OPCodeGet _opcodeget; public OPCodeGet OPCodeGet { get { return this._opcodeget; } set { this._opcodeget = value; } }
    }
}
