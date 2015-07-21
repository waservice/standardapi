using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class RepairOrderDocument
    {
        private string _dmsrodocumentno;
        //[System.Xml.Serialization.XmlIgnore]
        public string DMSRODocumentNo { get { return this._dmsrodocumentno; } set { this._dmsrodocumentno = value; } }
        private string _dmsrodocumentstatus;
        //[System.Xml.Serialization.XmlIgnore]
        public string DMSRODocumentStatus { get { return this._dmsrodocumentstatus; } set { this._dmsrodocumentstatus = value; } }

        private string _dmsappointmentno;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsappointmentstatus;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSAppointmentStatus { get { return this._dmsappointmentstatus; } set { this._dmsappointmentstatus = value; } }

        private AppointmentRef _appointmentref;
        [System.Xml.Serialization.XmlIgnore]
        public AppointmentRef AppointmentRef { get { return this._appointmentref; } set { this._appointmentref = value; } }

        private List<RepairOrder> _repairorders; public List<RepairOrder> RepairOrders { get { return this._repairorders; } set { this._repairorders = value; } }
    }
}
