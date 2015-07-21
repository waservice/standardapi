using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class AppointmentRef
    {      
        //private string _dmsrodocumentno = string.Empty; public string DMSRODocumentNo { get { return this._dmsrodocumentno; } set { this._dmsrodocumentno = value; } }
        //private string _dmsrodocumentstatus = string.Empty; public string DMSRODocumentStatus { get { return this._dmsrodocumentstatus; } set { this._dmsrodocumentstatus = value; } }
        //private string _dmsrodocumentversion = string.Empty; public string DMSRODocumentVersion { get { return this._dmsrodocumentversion; } set { this._dmsrodocumentversion = value; } }
        private string _dmsappointmentid = string.Empty; public string DMSAppointmentID { get { return this._dmsappointmentid; } set { this._dmsappointmentid = value; } }
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        //private string _dmsappointmentid = string.Empty; public string DMSAppointmentID { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsappointmentstatus = string.Empty; public string DMSAppointmentStatus { get { return this._dmsappointmentstatus; } set { this._dmsappointmentstatus = value; } }
    }
}