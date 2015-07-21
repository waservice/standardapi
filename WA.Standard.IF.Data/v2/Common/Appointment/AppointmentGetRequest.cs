using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Appointment
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("AppointmentGetRequest", Namespace = "http://wa.dms.webservice/AppointmentGetRequest")]
    public class AppointmentGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private AppointmentGet _appointmentget; public AppointmentGet AppointmentGet { get { return this._appointmentget; } set { this._appointmentget = value; } }
    }
}
