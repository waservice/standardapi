using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.HMCIS.Price
{
    [Serializable]
    public class Part
    {
        private string _manufacturer = string.Empty; public string Manufacturer { get { return this._manufacturer; } set { this._manufacturer = value; } }
        private string _partnumber = string.Empty; public string PartNumber { get { return this._partnumber; } set { this._partnumber = value; } }
        private string _quantity; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
    }
}
