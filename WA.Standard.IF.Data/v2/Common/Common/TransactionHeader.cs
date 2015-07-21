using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class TransactionHeader
    {
        private string _language = string.Empty;
        [System.Xml.Serialization.XmlIgnore]
        public string Language { get { return this._language; } set { this._language = value; } }

        private string _countryid = string.Empty; public string CountryID { get { return this._countryid; } set { this._countryid = value; } }
        private string _distributorid = string.Empty; public string DistributorID { get { return this._distributorid; } set { this._distributorid = value; } }
        private string _groupid = string.Empty; public string GroupID { get { return this._groupid; } set { this._groupid = value; } }
        private string _dealerid = string.Empty; public string DealerID { get { return this._dealerid; } set { this._dealerid = value; } }
        private string _dmscode = string.Empty; public string DMSCode { get { return this._dmscode; } set { this._dmscode = value; } }
        private string _dmsversion = string.Empty; public string DMSVersion { get { return this._dmsversion; } set { this._dmsversion = value; } }
        private string _dmsserverurl = string.Empty; public string DMSServerUrl { get { return this._dmsserverurl; } set { this._dmsserverurl = value; } }
        private string _documentversion = string.Empty; public string DocumentVersion { get { return this._documentversion; } set { this._documentversion = value; } }
        private string _username = string.Empty; public string Username { get { return this._username; } set { this._username = value; } }
        private string _password = string.Empty; public string Password { get { return this._password; } set { this._password = value; } }
        private string _transactionid = string.Empty; public string TransactionId { get { return this._transactionid; } set { this._transactionid = value; } }
        private DateTime _transactiondatetimeutc; public DateTime TransactionDateTimeUTC { get { return this._transactiondatetimeutc; } set { this._transactiondatetimeutc = value; } }
        private DateTime _transactiondatetimelocal; public DateTime TransactionDateTimeLocal { get { return this._transactiondatetimelocal; } set { this._transactiondatetimelocal = value; } }
        private string _transactiontype = string.Empty; public string TransactionType { get { return this._transactiontype; } set { this._transactiontype = value; } }
        private string _requesttype = string.Empty; public string RequestType { get { return this._requesttype; } set { this._requesttype = value; } }
        private string _requestpollingtoken = string.Empty; public string RequestPollingToken { get { return this._requestpollingtoken; } set { this._requestpollingtoken = value; } }
        private string _vendertrackingcode = string.Empty; public string VenderTrackingCode { get { return this._vendertrackingcode; } set { this._vendertrackingcode = value; } }
        private string _ineterfaceid = string.Empty; public string IneterfaceID { get { return this._ineterfaceid; } set { this._ineterfaceid = value; } }
        private string _pollingtoken = string.Empty; public string PollingToken { get { return this._pollingtoken; } set { this._pollingtoken = value; } }

    }
}