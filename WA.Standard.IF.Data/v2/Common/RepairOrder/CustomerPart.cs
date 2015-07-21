using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class CustomerPart
    {
        private string _partnumber = string.Empty; public string PartNumber { get { return this._partnumber; } set { this._partnumber = value; } }
        private string _partdescription = string.Empty; public string PartDescription { get { return this._partdescription; } set { this._partdescription = value; } }
        private string _quantity; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private string _unitofmeasure = string.Empty; public string UnitOfMeasure { get { return this._unitofmeasure; } set { this._unitofmeasure = value; } }
        private string _comment = string.Empty; public string Comment { get { return this._comment; } set { this._comment = value; } }
    }
}
