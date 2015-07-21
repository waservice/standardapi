using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Customer
{
    [Serializable]
    public class Address
    {
        private string _addresstype = string.Empty; public string AddressType { get { return this._addresstype; } set { this._addresstype = value; } }
        private string _address1 = string.Empty; public string Address1 { get { return this._address1; } set { this._address1 = value; } }
        private string _address2 = string.Empty; public string Address2 { get { return this._address2; } set { this._address2 = value; } }
        private string _city = string.Empty; public string City { get { return this._city; } set { this._city = value; } }
        private string _state = string.Empty; public string State { get { return this._state; } set { this._state = value; } }
        private string _country = string.Empty; public string Country { get { return this._country; } set { this._country = value; } }
        private string _zipcode = string.Empty; public string ZipCode { get { return this._zipcode; } set { this._zipcode = value; } }
        private string _fulladdress = string.Empty; public string FullAddress { get { return this._fulladdress; } set { this._fulladdress = value; } }
        private string _addressspectype = string.Empty; public string AddressSpecType { get { return this._addressspectype; } set { this._addressspectype = value; } }

    }
}