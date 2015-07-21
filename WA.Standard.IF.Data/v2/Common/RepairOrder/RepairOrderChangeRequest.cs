using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("RepairOrderChangeRequest", Namespace = "http://wa.dms.webservice/RepairOrderChangeRequest")]
    public class RepairOrderChangeRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private RepairOrderChange _repairorderchange; public RepairOrderChange RepairOrderChange { get { return this._repairorderchange; } set { this._repairorderchange = value; } }
    }
}
