using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("JobChangeRequest", Namespace = "http://wa.dms.webservice/JobChangeRequest")]
    public class JobChangeRequest
    {
        private TransactionHeader _transactionheader; public TransactionHeader TransactionHeader { get { return this._transactionheader; } set { this._transactionheader = value; } }
        private JobChange _jobchange; public JobChange JobChange { get { return this._jobchange; } set { this._jobchange = value; } }
    }
}
