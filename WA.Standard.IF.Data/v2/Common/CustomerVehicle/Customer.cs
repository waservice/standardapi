using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.CustomerVehicle
{
    [Serializable]
    public class Customer
    {
        private string _dmscustomerno = string.Empty; public string DMSCustomerNo { get { return this._dmscustomerno; } set { this._dmscustomerno = value; } }
        private string _lastname = string.Empty; public string LastName { get { return this._lastname; } set { this._lastname = value; } }
        private string _email = string.Empty; public string Email { get { return this._email; } set { this._email = value; } }
        private string _cardno = string.Empty; public string CardNo { get { return this._cardno; } set { this._cardno = value; } }
        private List<WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact> _contacts; public List<WA.Standard.IF.Data.v2.Common.CustomerVehicle.Contact> Contacts { get { return this._contacts; } set { this._contacts = value; } }

    }
}
