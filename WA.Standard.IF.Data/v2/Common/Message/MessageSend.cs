using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Message
{
    [Serializable]
    public class MessageSend
    {
        private string _messageid; public string MessageID { get { return this._messageid; } set { this._messageid = value; } }
        private string _messageType; public string MessageType { get { return this._messageType; } set { this._messageType = value; } }
        private string _actionType; public string ActionType { get { return this._actionType; } set { this._actionType = value; } }
    }
}
