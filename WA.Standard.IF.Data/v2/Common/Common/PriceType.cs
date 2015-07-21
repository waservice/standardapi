using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class PriceType
    {
        private string _unitprice; public string UnitPrice { get { return this._unitprice; } set { this._unitprice = value; } }
        private string _totalprice; public string TotalPrice { get { return this._totalprice; } set { this._totalprice = value; } }
        private string _totalpriceincludetax; public string TotalPriceIncludeTax { get { return this._totalpriceincludetax; } set { this._totalpriceincludetax = value; } }
        private string _discountrate; public string DiscountRate { get { return this._discountrate; } set { this._discountrate = value; } }
        private string _discountprice; public string DiscountPrice { get { return this._discountprice; } set { this._discountprice = value; } }
    }
}