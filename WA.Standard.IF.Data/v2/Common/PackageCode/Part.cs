using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.PackageCode
{
    [Serializable]
    public class Part
    {
        private string _dmspartno = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSPartNo { get { return this._dmspartno; } set { this._dmspartno = value; } }

        private string _manufacturer = string.Empty; public string Manufacturer { get { return this._manufacturer; } set { this._manufacturer = value; } }
        private string _partnumber = string.Empty; public string PartNumber { get { return this._partnumber; } set { this._partnumber = value; } }
        private string _partdescription = string.Empty; public string PartDescription { get { return this._partdescription; } set { this._partdescription = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _partstatus = string.Empty; public string PartStatus { get { return this._partstatus; } set { this._partstatus = value; } }
        private string _parttype = string.Empty; public string PartType { get { return this._parttype; } set { this._parttype = value; } }
        private string _quantityonhand; public string QuantityOnHand { get { return this._quantityonhand; } set { this._quantityonhand = value; } }
        private string _stockstatus = string.Empty; public string StockStatus { get { return this._stockstatus; } set { this._stockstatus = value; } }
        private string _displaypartnumber = string.Empty; public string DisplayPartNumber { get { return this._displaypartnumber; } set { this._displaypartnumber = value; } }
        private string _remarks = string.Empty; public string Remarks { get { return this._remarks; } set { this._remarks = value; } }
        private string _unitofmeasure = string.Empty; public string UnitOfMeasure { get { return this._unitofmeasure; } set { this._unitofmeasure = value; } }
        private string _stockquantity; public string StockQuantity { get { return this._stockquantity; } set { this._stockquantity = value; } }
        private string _quantity; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private string _displayremarks = string.Empty; public string DisplayRemarks { get { return this._displayremarks; } set { this._displayremarks = value; } }
        private string _mandatoryyn = string.Empty; public string MandatoryYN { get { return this._mandatoryyn; } set { this._mandatoryyn = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
    }
}
