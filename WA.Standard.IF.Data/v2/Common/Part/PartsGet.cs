using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Part
{
    [Serializable]
    public class PartsGet
    {
        private string _manufacturer = string.Empty; public string Manufacturer { get { return this._manufacturer; } set { this._manufacturer = value; } }
        private string _partnumber = string.Empty; public string PartNumber { get { return this._partnumber; } set { this._partnumber = value; } }
        private string _partdescription = string.Empty; public string PartDescription { get { return this._partdescription; } set { this._partdescription = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _model = string.Empty; public string Model { get { return this._model; } set { this._model = value; } }
        private string _year = string.Empty; public string Year { get { return this._year; } set { this._year = value; } }
        private string _engine = string.Empty; public string Engine { get { return this._engine; } set { this._engine = value; } }
        private string _mileage; public string Mileage { get { return this._mileage; } set { this._mileage = value; } }
        private string _category = string.Empty; public string Category { get { return this._category; } set { this._category = value; } }
    }
}
