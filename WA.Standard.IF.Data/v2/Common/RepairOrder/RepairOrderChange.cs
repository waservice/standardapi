using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class RepairOrderChange
    {
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _dmsroid = string.Empty; public string DMSROID { get { return this._dmsroid; } set { this._dmsroid = value; } }
        private DateTime _deliverydatetimelocal; public DateTime DeliveryDateTimeLocal { get { return this._deliverydatetimelocal; } set { this._deliverydatetimelocal = value; } }
        private DateTime _opendatetimelocal; public DateTime OpenDateTimeLocal { get { return this._opendatetimelocal; } set { this._opendatetimelocal = value; } }
        private DateTime _closedatetimelocal; public DateTime CloseDateTimeLocal { get { return this._closedatetimelocal; } set { this._closedatetimelocal = value; } }
        private string _dmsrostatus = string.Empty; public string DMSROStatus { get { return this._dmsrostatus; } set { this._dmsrostatus = value; } }
        private string _worktype = string.Empty; public string WorkType { get { return this._worktype; } set { this._worktype = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private string _paymentmethod = string.Empty; public string PaymentMethod { get { return this._paymentmethod; } set { this._paymentmethod = value; } }
        private string _inmileage; public string InMileage { get { return this._inmileage; } set { this._inmileage = value; } }
        private string _outmileage; public string OutMileage { get { return this._outmileage; } set { this._outmileage = value; } }
        private string _hangtagno = string.Empty; public string HangTagNo { get { return this._hangtagno; } set { this._hangtagno = value; } }
        private string _hangtagcolor = string.Empty; public string HangTagColor { get { return this._hangtagcolor; } set { this._hangtagcolor = value; } }
        private string _rochannel = string.Empty; public string ROChannel { get { return this._rochannel; } set { this._rochannel = value; } }
        private string _saemployeeid = string.Empty; public string SAEmployeeID { get { return this._saemployeeid; } set { this._saemployeeid = value; } }
        private string _saemployeename = string.Empty; public string SAEmployeeName { get { return this._saemployeename; } set { this._saemployeename = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private List<JobRef> _jobrefs; public List<JobRef> JobRefs { get { return this._jobrefs; } set { this._jobrefs = value; } }
        private AppointmentRef _appointmentref; public AppointmentRef AppointmentRef { get { return this._appointmentref; } set { this._appointmentref = value; } }
        private List<AdditionalField> _additionalfields; public List<AdditionalField> AdditionalFields { get { return this._additionalfields; } set { this._additionalfields = value; } }
        private List<Option> _options; public List<Option> Options { get { return this._options; } set { this._options = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<CustomerPart> _customerparts; public List<CustomerPart> CustomerParts { get { return this._customerparts; } set { this._customerparts = value; } }
        private List<v2.Common.Customer.Customer> _customers; public List<v2.Common.Customer.Customer> Customers { get { return this._customers; } set { this._customers = value; } }
        private v2.Common.Vehicle.Vehicle _vehicle; public v2.Common.Vehicle.Vehicle Vehicle { get { return this._vehicle; } set { this._vehicle = value; } }
        private List<RequestItem> _requestitems; public List<RequestItem> RequestItems { get { return this._requestitems; } set { this._requestitems = value; } }
    }
}
