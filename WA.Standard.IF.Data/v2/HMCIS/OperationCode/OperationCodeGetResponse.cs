using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.OperationCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("OperationCodeGetResponse", Namespace = "http://wa.dms.webservice/OperationCodeGetResponse")]
    public class OperationCodeGetResponse
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private ResultMessage _resultmessage; public ResultMessage ResultMessage { get { return this._resultmessage; } set { this._resultmessage = value; } }
        private List<Error> _errors; public List<Error> Errors { get { return this._errors; } set { this._errors = value; } }
        private List<OperationCode> _operationcodes; public List<OperationCode> OperationCodes { get { return this._operationcodes; } set { this._operationcodes = value; } }

    }
}
