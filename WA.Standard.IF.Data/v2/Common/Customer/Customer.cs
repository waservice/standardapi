using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Customer
{
    [Serializable]
    public class Customer
    {
        private string _message = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        public string Message { get { return this._message; } set { this._message = value; } }

        private string _customerinfotype = string.Empty; public string CustomerInfoType { get { return this._customerinfotype; } set { this._customerinfotype = value; } }
        private string _dmscustomerno = string.Empty; public string DMSCustomerNo { get { return this._dmscustomerno; } set { this._dmscustomerno = value; } }
        private string _lastname = string.Empty; public string LastName { get { return this._lastname; } set { this._lastname = value; } }
        private string _middlename = string.Empty; public string MiddleName { get { return this._middlename; } set { this._middlename = value; } }
        private string _firstname = string.Empty; public string FirstName { get { return this._firstname; } set { this._firstname = value; } }
        private string _fullname = string.Empty; public string FullName { get { return this._fullname; } set { this._fullname = value; } }
        private string _salutation = string.Empty; public string Salutation { get { return this._salutation; } set { this._salutation = value; } }
        private string _gender = string.Empty; public string Gender { get { return this._gender; } set { this._gender = value; } }
        private string _cardno = string.Empty; public string CardNo { get { return this._cardno; } set { this._cardno = value; } }
        private string _email = string.Empty; public string Email { get { return this._email; } set { this._email = value; } }
        private List<Address> _addresses; public List<Address> Addresses { get { return this._addresses; } set { this._addresses = value; } }
        private List<Contact> _contacts; public List<Contact> Contacts { get { return this._contacts; } set { this._contacts = value; } }
        private SpecialMessage _specialmessage; public SpecialMessage SpecialMessage { get { return this._specialmessage; } set { this._specialmessage = value; } }
        private List<CorporateInfo> _corporateinfos; public List<CorporateInfo> CorporateInfos { get { return this._corporateinfos; } set { this._corporateinfos = value; } }
    }
}