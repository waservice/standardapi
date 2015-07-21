using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.PackageCode
{
    [Serializable]
    public class OPCode
    {
        private string _dmsopcodeno = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSOPCodeNo { get { return this._dmsopcodeno; } set { this._dmsopcodeno = value; } }

        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _description = string.Empty; public string Description { get { return this._description; } set { this._description = value; } }
        private string _opcodetype = string.Empty; public string OPCodeType { get { return this._opcodetype; } set { this._opcodetype = value; } }
        private string _displayopcode = string.Empty; public string DisplayOPCode { get { return this._displayopcode; } set { this._displayopcode = value; } }
        private string _displayopdescription = string.Empty; public string DisplayOPDescription { get { return this._displayopdescription; } set { this._displayopdescription = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _model = string.Empty; public string Model { get { return this._model; } set { this._model = value; } }
        private string _engine = string.Empty; public string Engine { get { return this._engine; } set { this._engine = value; } }
        private string _year = string.Empty; public string Year { get { return this._year; } set { this._year = value; } }
        private string _mileage; public string Mileage { get { return this._mileage; } set { this._mileage = value; } }
        private string _period = string.Empty; public string Period { get { return this._period; } set { this._period = value; } }
        private string _deflinepaymentmethod = string.Empty; public string DefLinePaymentMethod { get { return this._deflinepaymentmethod; } set { this._deflinepaymentmethod = value; } }
        private string _correctionlop = string.Empty; public string CorrectionLOP { get { return this._correctionlop; } set { this._correctionlop = value; } }
        private string _skilllevel = string.Empty; public string SkillLevel { get { return this._skilllevel; } set { this._skilllevel = value; } }
        private string _hazardmaterialcharge; public string HazardMaterialCharge { get { return this._hazardmaterialcharge; } set { this._hazardmaterialcharge = value; } }
        private string _estimatedhours; public string EstimatedHours { get { return this._estimatedhours; } set { this._estimatedhours = value; } }
        private string _predefinedcausedescription = string.Empty; public string PredefinedCauseDescription { get { return this._predefinedcausedescription; } set { this._predefinedcausedescription = value; } }
        private string _cpsind = string.Empty; public string CPSIND { get { return this._cpsind; } set { this._cpsind = value; } }
        private string _mandatoryyn = string.Empty; public string MandatoryYN { get { return this._mandatoryyn; } set { this._mandatoryyn = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<Part> _parts; public List<Part> Parts { get { return this._parts; } set { this._parts = value; } }
    }
}
