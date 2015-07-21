using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Vehicle
{
    [Serializable]
    public class Vehicle
    {
        private string _dmscustomerno;
        [System.Xml.Serialization.XmlIgnore]
        public string DMSCustomerNo { get { return this._dmscustomerno; } set { this._dmscustomerno = value; } }

        private string _DMSVehicleNo = string.Empty; public string DMSVehicleNo { get { return this._DMSVehicleNo; } set { this._DMSVehicleNo = value; } }
        private string _vin = string.Empty; public string VIN { get { return this._vin; } set { this._vin = value; } }
        private string _lastsixvin = string.Empty; public string LastSixVIN { get { return this._lastsixvin; } set { this._lastsixvin = value; } }
        private string _stocknumber = string.Empty; public string StockNumber { get { return this._stocknumber; } set { this._stocknumber = value; } }
        private string _licenseplateno = string.Empty; public string LicensePlateNo { get { return this._licenseplateno; } set { this._licenseplateno = value; } }
        private string _make = string.Empty; public string Make { get { return this._make; } set { this._make = value; } }
        private string _modelcode = string.Empty; public string ModelCode { get { return this._modelcode; } set { this._modelcode = value; } }
        private string _modelname = string.Empty; public string ModelName { get { return this._modelname; } set { this._modelname = value; } }
        private string _modelyear = string.Empty; public string ModelYear { get { return this._modelyear; } set { this._modelyear = value; } }
        private string _lastmileage; public string LastMileage { get { return this._lastmileage; } set { this._lastmileage = value; } }
        private string _color = string.Empty; public string Color { get { return this._color; } set { this._color = value; } }
        private string _vehicletype = string.Empty; public string VehicleType { get { return this._vehicletype; } set { this._vehicletype = value; } }
        private string _enginetype = string.Empty; public string EngineType { get { return this._enginetype; } set { this._enginetype = value; } }
        private string _fueltype = string.Empty; public string FuelType { get { return this._fueltype; } set { this._fueltype = value; } }
        private string _cylinders = string.Empty; public string Cylinders { get { return this._cylinders; } set { this._cylinders = value; } }
        private string _trim = string.Empty; public string Trim { get { return this._trim; } set { this._trim = value; } }
        private string _fullmodelname = string.Empty; public string FullModelName { get { return this._fullmodelname; } set { this._fullmodelname = value; } }
        private DateTime _insurancedate; public DateTime InsuranceDate { get { return this._insurancedate; } set { this._insurancedate = value; } }
        private DateTime _dateinservice; public DateTime DateInService { get { return this._dateinservice; } set { this._dateinservice = value; } }
        private DateTime _datedelivered; public DateTime DateDelivered { get { return this._datedelivered; } set { this._datedelivered = value; } }
        private DateTime _warrantystartdate; public DateTime WarrantyStartDate { get { return this._warrantystartdate; } set { this._warrantystartdate = value; } }
        private string _warrantymonths = string.Empty; public string WarrantyMonths { get { return this._warrantymonths; } set { this._warrantymonths = value; } }
        private string _warrantymiles; public string WarrantyMiles { get { return this._warrantymiles; } set { this._warrantymiles = value; } }
        private string _licensenumber = string.Empty; public string LicenseNumber { get { return this._licensenumber; } set { this._licensenumber = value; } }
        private DateTime _lastservicedate; public DateTime LastServiceDate { get { return this._lastservicedate; } set { this._lastservicedate = value; } }
        private DateTime _extendedwarranty; public DateTime ExtendedWarranty { get { return this._extendedwarranty; } set { this._extendedwarranty = value; } }
        private string _declinedjob = string.Empty; public string DeclinedJob { get { return this._declinedjob; } set { this._declinedjob = value; } }
        private string _pendingjob = string.Empty; public string PendingJob { get { return this._pendingjob; } set { this._pendingjob = value; } }
        private string _displaydescription = string.Empty; public string DisplayDescription { get { return this._displaydescription; } set { this._displaydescription = value; } }
        private DateTime _extendedwarrantyexpiredate; public DateTime ExtendedWarrantyExpireDate { get { return this._extendedwarrantyexpiredate; } set { this._extendedwarrantyexpiredate = value; } }
        private string _engineno = string.Empty; public string EngineNo { get { return this._engineno; } set { this._engineno = value; } }
        private List<Campaign> _campaigns; public List<Campaign> Campaigns { get { return this._campaigns; } set { this._campaigns = value; } }

    }
}