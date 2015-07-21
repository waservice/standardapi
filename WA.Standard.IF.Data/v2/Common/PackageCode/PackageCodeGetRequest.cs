using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.PackageCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("PackageCodeGetRequest", Namespace = "http://wa.dms.webservice/PackageCodeGetRequest")]
    public class PackageCodeGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private PackageCodeGet _packagecodeget; public PackageCodeGet PackageCodeGet { get { return this._packagecodeget; } set { this._packagecodeget = value; } }
    }
}
