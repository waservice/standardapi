using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("RepairOrderGetRequest", Namespace = "http://wa.dms.webservice/RepairOrderGetRequest")]
    public class RepairOrderGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private RepairOrderGet _repairorderget; public RepairOrderGet RepairOrderGet { get { return this._repairorderget; } set { this._repairorderget = value; } }
    }
}
