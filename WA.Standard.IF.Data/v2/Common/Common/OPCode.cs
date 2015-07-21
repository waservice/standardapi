using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class OPCode
    {
        private string _sequencenumber = string.Empty; public string SequenceNumber { get { return this._sequencenumber; } set { this._sequencenumber = value; } }
        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _description = string.Empty; public string Description { get { return this._description; } set { this._description = value; } }
        private string _opcodetype = string.Empty; public string OPCodeType { get { return this._opcodetype; } set { this._opcodetype = value; } }
        private string _estimatedhours; public string EstimatedHours { get { return this._estimatedhours; } set { this._estimatedhours = value; } }
        private string _actualhours; public string ActualHours { get { return this._actualhours; } set { this._actualhours = value; } }
        private string _skilllevel = string.Empty; public string SkillLevel { get { return this._skilllevel; } set { this._skilllevel = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private string _quantity = string.Empty; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<Description> _descriptions; public List<Description> Descriptions { get { return this._descriptions; } set { this._descriptions = value; } }
        private List<Cause> _causes; public List<Cause> Causes { get { return this._causes; } set { this._causes = value; } }
        private List<Correction> _corrections; public List<Correction> Corrections { get { return this._corrections; } set { this._corrections = value; } }
        private List<Part> _parts; public List<Part> Parts { get { return this._parts; } set { this._parts = value; } }
        private List<Sublet> _sublets; public List<Sublet> Sublets { get { return this._sublets; } set { this._sublets = value; } }
        private List<MISC> _miscs; public List<MISC> MISCs { get { return this._miscs; } set { this._miscs = value; } }
    }
}