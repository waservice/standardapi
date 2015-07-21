using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Part
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("PartsGetRequest", Namespace = "http://wa.dms.webservice/PartsGetRequest")]
    public class PartsGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private PartsGet _partsget; public PartsGet PartsGet { get { return this._partsget; } set { this._partsget = value; } }
    }
}
