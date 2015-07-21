using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Employee
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("EmployeeGetRequest", Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class EmployeeGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private EmployeeGet _employeeget; public EmployeeGet EmployeeGet { get { return this._employeeget; } set { this._employeeget = value; } }
    }
}
