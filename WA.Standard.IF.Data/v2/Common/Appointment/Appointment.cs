using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Appointment
{
    [Serializable]
    public class Appointment
    {
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _dmsappointmentid = string.Empty; public string DMSAppointmentID { get { return this._dmsappointmentid; } set { this._dmsappointmentid = value; } }
        private DateTime _appointmentdatetimelocal; public DateTime AppointmentDateTimeLocal { get { return this._appointmentdatetimelocal; } set { this._appointmentdatetimelocal = value; } }
        private DateTime _deliverydatetimelocal; public DateTime DeliveryDateTimeLocal { get { return this._deliverydatetimelocal; } set { this._deliverydatetimelocal = value; } }
        private DateTime _opendatetimelocal; public DateTime OpenDateTimeLocal { get { return this._opendatetimelocal; } set { this._opendatetimelocal = value; } }
        private DateTime _closedatetimelocal; public DateTime CloseDateTimeLocal { get { return this._closedatetimelocal; } set { this._closedatetimelocal = value; } }
        private string _dmsappointmentstatus = string.Empty; public string DMSAppointmentStatus { get { return this._dmsappointmentstatus; } set { this._dmsappointmentstatus = value; } }
        private string _worktype = string.Empty; public string WorkType { get { return this._worktype; } set { this._worktype = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private string _paymentmethod = string.Empty; public string PaymentMethod { get { return this._paymentmethod; } set { this._paymentmethod = value; } }
        private string _inmileage; public string InMileage { get { return this._inmileage; } set { this._inmileage = value; } }
        private string _saemployeeid = string.Empty; public string SAEmployeeID { get { return this._saemployeeid; } set { this._saemployeeid = value; } }
        private string _saemployeename = string.Empty; public string SAEmployeeName { get { return this._saemployeename; } set { this._saemployeename = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private string _customercomment = string.Empty; public string CustomerComment { get { return this._customercomment; } set { this._customercomment = value; } }
        private string _appointmentchannel = string.Empty; public string AppointmentChannel { get { return this._appointmentchannel; } set { this._appointmentchannel = value; } }
        private ManagementFields _managementfields; public ManagementFields ManagementFields { get { return this._managementfields; } set { this._managementfields = value; } }
        private List<JobRef> _jobrefs; public List<JobRef> JobRefs { get { return this._jobrefs; } set { this._jobrefs = value; } }
        private List<RORef> _rorefs; public List<RORef> RORefs { get { return this._rorefs; } set { this._rorefs = value; } }
        private List<AdditionalField> _additionalfields; public List<AdditionalField> AdditionalFields { get { return this._additionalfields; } set { this._additionalfields = value; } }
        private List<Option> _options; public List<Option> Options { get { return this._options; } set { this._options = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<v2.Common.Customer.Customer> _customers; public List<v2.Common.Customer.Customer> Customers { get { return this._customers; } set { this._customers = value; } }
        private v2.Common.Vehicle.Vehicle _vehicle; public v2.Common.Vehicle.Vehicle Vehicle { get { return this._vehicle; } set { this._vehicle = value; } }
        private List<RequestItem> _requestitems; public List<RequestItem> RequestItems { get { return this._requestitems; } set { this._requestitems = value; } }
    }
}