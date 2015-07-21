using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.Price
{
    [Serializable]
    public class OPCode
    {
        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _model = string.Empty; public string Model { get { return this._model; } set { this._model = value; } }
        private string _engine = string.Empty; public string Engine { get { return this._engine; } set { this._engine = value; } }
        private string _year = string.Empty; public string Year { get { return this._year; } set { this._year = value; } }
        private string _mileage; public string Mileage { get { return this._mileage; } set { this._mileage = value; } }
        private string _period = string.Empty; public string Period { get { return this._period; } set { this._period = value; } }
        private string _quantity = string.Empty; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<Part> _parts; public List<Part> Parts { get { return this._parts; } set { this._parts = value; } }

    }
}
