using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.OPCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("OPCodeGetResponse", Namespace = "http://wa.dms.webservice/OPCodeGetResponse")]
    public class OPCodeGetResponse
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private ResultMessage _resultmessage; public ResultMessage ResultMessage { get { return this._resultmessage; } set { this._resultmessage = value; } }
        private List<Error> _errors; public List<Error> Errors { get { return this._errors; } set { this._errors = value; } }
        private List<OPCode> _opcodes; public List<OPCode> OPCodes { get { return this._opcodes; } set { this._opcodes = value; } }
    }
}
