using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.CustomerVehicle
{
    [Serializable]
    public class CustomerVehicle
    {
        private v2.Common.Customer.Customer _customer; public v2.Common.Customer.Customer Customer { get { return this._customer; } set { this._customer = value; } }
        private v2.Common.Vehicle.Vehicle _vehicle; public v2.Common.Vehicle.Vehicle Vehicle { get { return this._vehicle; } set { this._vehicle = value; } }
    }
}
