using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("JobGetRequest", Namespace = "http://wa.dms.webservice/JobGetRequest")]
    public class JobGetRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private JobGet _jobget; public JobGet JobGet { get { return this._jobget; } set { this._jobget = value; } }
    }
}
