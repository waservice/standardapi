using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Customer
{
    [Serializable]
    public class Contact
    {
        private string _contacttype = string.Empty; public string ContactType { get { return this._contacttype; } set { this._contacttype = value; } }
        private string _contactvalue = string.Empty; public string ContactValue { get { return this._contactvalue; } set { this._contactvalue = value; } }
        private string _contactmethodyn = string.Empty; public string ContactMethodYN { get { return this._contactmethodyn; } set { this._contactmethodyn = value; } }
    }
}