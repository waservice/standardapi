using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Appointment
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("AppointmentChangeRequest", Namespace = "http://wa.dms.webservice/AppointmentChangeRequest")]
    public class AppointmentChangeRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private AppointmentChange _appointmentchange; public AppointmentChange AppointmentChange { get { return this._appointmentchange; } set { this._appointmentchange = value; } }
    }
}
