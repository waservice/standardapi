using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.OperationCode
{
    [Serializable]
    public class OperationCode
    {
        private string _dmsoperationcodeno = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSOperationCodeNo { get { return this._dmsoperationcodeno; } set { this._dmsoperationcodeno = value; } }

        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _description = string.Empty; public string Description { get { return this._description; } set { this._description = value; } }
        private string _displayoperationcode = string.Empty; public string DisplayOperationCode { get { return this._displayoperationcode; } set { this._displayoperationcode = value; } }
        private string _displayoperationdescription = string.Empty; public string DisplayOperationDescription { get { return this._displayoperationdescription; } set { this._displayoperationdescription = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _model = string.Empty; public string Model { get { return this._model; } set { this._model = value; } }
        private string _engine = string.Empty; public string Engine { get { return this._engine; } set { this._engine = value; } }
        private string _year = string.Empty; public string Year { get { return this._year; } set { this._year = value; } }
        private string _mileage; public string Mileage { get { return this._mileage; } set { this._mileage = value; } }
        private string _period = string.Empty; public string Period { get { return this._period; } set { this._period = value; } }
        private string _deflinepaymentmethod = string.Empty; public string DefLinePaymentMethod { get { return this._deflinepaymentmethod; } set { this._deflinepaymentmethod = value; } }
        private string _estimatedhours; public string EstimatedHours { get { return this._estimatedhours; } set { this._estimatedhours = value; } }
        private ManagementFields _managementfields; public ManagementFields ManagementFields { get { return this._managementfields; } set { this._managementfields = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<Common.OPCode.OPCode> _opcodes; public List<Common.OPCode.OPCode> OPCodes { get { return this._opcodes; } set { this._opcodes = value; } }

    }
}
