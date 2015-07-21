using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.Price
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("PriceCheckRequest", Namespace = "http://wa.dms.webservice/PriceCheckRequest")]
    public class PriceCheckRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private PriceCheck _pricecheck; public PriceCheck PriceCheck { get { return this._pricecheck; } set { this._pricecheck = value; } }
    }
}
