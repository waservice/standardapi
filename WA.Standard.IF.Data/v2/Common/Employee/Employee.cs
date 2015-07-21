using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Employee
{
    [Serializable]
    public class Employee
    {
        private string _dmsemployeeno = string.Empty; public string DMSEmployeeNo { get { return this._dmsemployeeno; } set { this._dmsemployeeno = value; } }
        private string _lastname = string.Empty; public string LastName { get { return this._lastname; } set { this._lastname = value; } }
        private string _middlename = string.Empty; public string MiddleName { get { return this._middlename; } set { this._middlename = value; } }
        private string _firstname = string.Empty; public string FirstName { get { return this._firstname; } set { this._firstname = value; } }
        private string _fullname = string.Empty; public string FullName { get { return this._fullname; } set { this._fullname = value; } }
        private string _salution = string.Empty; public string Salution { get { return this._salution; } set { this._salution = value; } }
        private string _gender = string.Empty; public string Gender { get { return this._gender; } set { this._gender = value; } }
        private string _language = string.Empty; public string Language { get { return this._language; } set { this._language = value; } }
        private string _skillsetstring = string.Empty; public string SkillsetString { get { return this._skillsetstring; } set { this._skillsetstring = value; } }
        private string _title = string.Empty; public string Title { get { return this._title; } set { this._title = value; } }
        private string _mobilenumber = string.Empty; public string MobileNumber { get { return this._mobilenumber; } set { this._mobilenumber = value; } }
        private string _phonenumber = string.Empty; public string PhoneNumber { get { return this._phonenumber; } set { this._phonenumber = value; } }
        private string _email = string.Empty; public string Email { get { return this._email; } set { this._email = value; } }
        private string _loginid = string.Empty; public string LoginID { get { return this._loginid; } set { this._loginid = value; } }
        private string _loginpassword = string.Empty; public string LoginPassword { get { return this._loginpassword; } set { this._loginpassword = value; } }
        private string _employeestatus = string.Empty; public string EmployeeStatus { get { return this._employeestatus; } set { this._employeestatus = value; } }
        private string _group = string.Empty; public string Group { get { return this._group; } set { this._group = value; } }
        //private DateTime _validfromdatetimelocal; public DateTime ValidFromDateTimeLocal { get { return this._validfromdatetimelocal; } set { this._validfromdatetimelocal = value; } }
        //private DateTime _validtodatetimelocal; public DateTime ValidToDateTimeLocal { get { return this._validtodatetimelocal; } set { this._validtodatetimelocal = value; } }
        //private DateTime _upcomingvacationfromdatetimelocal; public DateTime UpcomingVacationFromDateTimeLocal { get { return this._upcomingvacationfromdatetimelocal; } set { this._upcomingvacationfromdatetimelocal = value; } }
        //private DateTime _upcomingvacationtodatetimelocal; public DateTime UpcomingVacationToDateTimeLocal { get { return this._upcomingvacationtodatetimelocal; } set { this._upcomingvacationtodatetimelocal = value; } }
        //private DateTime _clockindatetimelocal; public DateTime ClockInDateTimeLocal { get { return this._clockindatetimelocal; } set { this._clockindatetimelocal = value; } }
        //private DateTime _clockoutdatetimelocal; public DateTime ClockOutDateTimeLocal { get { return this._clockoutdatetimelocal; } set { this._clockoutdatetimelocal = value; } }
        private ManagementFields _managementfields; public ManagementFields ManagementFields { get { return this._managementfields; } set { this._managementfields = value; } }
        private List<Role> _roles; public List<Role> Roles { get { return this._roles; } set { this._roles = value; } }

    }
}
