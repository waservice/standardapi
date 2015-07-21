using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class Vehicle
    {
        private string _DMSVehicleNo = string.Empty; public string DMSVehicleNo { get { return this._DMSVehicleNo; } set { this._DMSVehicleNo = value; } }
        private string _vin = string.Empty; public string VIN { get { return this._vin; } set { this._vin = value; } }
        private string _lastsixvin = string.Empty; public string LastSixVIN { get { return this._lastsixvin; } set { this._lastsixvin = value; } }
    }
}
