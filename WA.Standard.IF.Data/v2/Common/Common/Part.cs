using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class Part
    {
        private string _sequencenumber = string.Empty; public string SequenceNumber { get { return this._sequencenumber; } set { this._sequencenumber = value; } }
        private string _partnumber = string.Empty; public string PartNumber { get { return this._partnumber; } set { this._partnumber = value; } }
        private string _partdescription = string.Empty; public string PartDescription { get { return this._partdescription; } set { this._partdescription = value; } }
        private string _parttype = string.Empty; public string PartType { get { return this._parttype; } set { this._parttype = value; } }
        private string _stockquantity; public string StockQuantity { get { return this._stockquantity; } set { this._stockquantity = value; } }
        private string _stockstatus = string.Empty; public string StockStatus { get { return this._stockstatus; } set { this._stockstatus = value; } }
        private string _displaypartnumber = string.Empty; public string DisplayPartNumber { get { return this._displaypartnumber; } set { this._displaypartnumber = value; } }
        private string _unitofmeasure = string.Empty; public string UnitOfMeasure { get { return this._unitofmeasure; } set { this._unitofmeasure = value; } }
        private string _quantity; public string Quantity { get { return this._quantity; } set { this._quantity = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private PriceType _pricetype; public PriceType PriceType { get { return this._pricetype; } set { this._pricetype = value; } }
        private List<Description> _descriptions; public List<Description> Descriptions { get { return this._descriptions; } set { this._descriptions = value; } }
    }
}