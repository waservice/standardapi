using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.RepairOrder
{
    [Serializable]
    public class Customer
    {
        private string _dmscustomerno = string.Empty; public string DMSCustomerNo { get { return this._dmscustomerno; } set { this._dmscustomerno = value; } }
        private string _lastname = string.Empty; public string LastName { get { return this._lastname; } set { this._lastname = value; } }
        private List<Contact> _contacts; public List<Contact> Contacts { get { return this._contacts; } set { this._contacts = value; } }
    }
}
