using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Message
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("MessageSendRequest", Namespace = "http://wa.dms.webservice/MessageSendRequest")]
    public class MessageSendRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private MessageSend _messagesend; public MessageSend MessageSend { get { return this._messagesend; } set { this._messagesend = value; } }
     
    }
}
