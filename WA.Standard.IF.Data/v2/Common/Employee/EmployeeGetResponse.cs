using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Employee
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("EmployeeGetResponse", Namespace = "http://wa.dms.webservice/EmployeeGetResponse")]
    public class EmployeeGetResponse
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private ResultMessage _resultmessage; public ResultMessage ResultMessage { get { return this._resultmessage; } set { this._resultmessage = value; } }
        private List<Error> _errors; public List<Error> Errors { get { return this._errors; } set { this._errors = value; } }
        private List<Employee> _employees; public List<Employee> Employees { get { return this._employees; } set { this._employees = value; } }
    }
}
