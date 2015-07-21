using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.OperationCode
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("OperationCodeGetRequest", Namespace = "http://wa.dms.webservice/OperationCodeGetRequest")]
    public class OperationCodeGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private OperationCodeGet _operationcodeget; public OperationCodeGet OperationCodeGet { get { return this._operationcodeget; } set { this._operationcodeget = value; } }
    }
}
