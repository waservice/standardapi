using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.PackageCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("PackageCodeGetResponse", Namespace = "http://wa.dms.webservice/PackageCodeGetResponse")]
    public class PackageCodeGetResponse
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private ResultMessage _resultmessage; public ResultMessage ResultMessage { get { return this._resultmessage; } set { this._resultmessage = value; } }
        private List<Error> _errors; public List<Error> Errors { get { return this._errors; } set { this._errors = value; } }
        private List<PackageCode> _packagecodes; public List<PackageCode> PackageCodes { get { return this._packagecodes; } set { this._packagecodes = value; } }

    }
}
