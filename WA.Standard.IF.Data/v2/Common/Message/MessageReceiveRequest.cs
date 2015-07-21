using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Message
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("MessageReceiveRequest", Namespace = "http://wa.dms.webservice/MessageReceiveRequest")]
    public class MessageReceiveRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private MessageReceive _messagereceive; public MessageReceive MessageReceive { get { return this._messagereceive; } set { this._messagereceive = value; } }
    }
}
