using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.CustomerVehicle
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("CustomerVehicleGetRequest", Namespace = "http://wa.dms.webservice/CustomerVehicleGetRequest")]
    public class CustomerVehicleGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private CustomerVehicleGet _customervehicleget; public CustomerVehicleGet CustomerVehicleGet { get { return this._customervehicleget; } set { this._customervehicleget = value; } }
    }
}
