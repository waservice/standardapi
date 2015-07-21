using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.PackageCode
{
    [Serializable]
    public class PackageCodeGet
    {
        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _description = string.Empty; public string Description { get { return this._description; } set { this._description = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _model = string.Empty; public string Model { get { return this._model; } set { this._model = value; } }
        private string _year = string.Empty; public string Year { get { return this._year; } set { this._year = value; } }
        private string _engine = string.Empty; public string Engine { get { return this._engine; } set { this._engine = value; } }
        private string _mileage; public string Mileage { get { return this._mileage; } set { this._mileage = value; } }
        private string _category = string.Empty; public string Category { get { return this._category; } set { this._category = value; } }
        private DateTime? _lastmodifieddatetimefromutc; public DateTime? LastModifiedDateTimeFromUTC { get { return this._lastmodifieddatetimefromutc; } set { this._lastmodifieddatetimefromutc = value; } }
        private DateTime? _lastmodifieddatetimetoutc; public DateTime? LastModifiedDateTimeToUTC { get { return this._lastmodifieddatetimetoutc; } set { this._lastmodifieddatetimetoutc = value; } }

    }
}
