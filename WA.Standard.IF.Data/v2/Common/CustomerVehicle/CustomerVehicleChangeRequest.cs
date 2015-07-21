using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.CustomerVehicle
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("CustomerVehicleChangeRequest", Namespace = "http://wa.dms.webservice/CustomerVehicleChangeRequest")]
    public class CustomerVehicleChangeRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private CustomerVehicleChange _customervehiclechange; public CustomerVehicleChange CustomerVehicleChange { get { return this._customervehiclechange; } set { this._customervehiclechange = value; } }
    }
}
