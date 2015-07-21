using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class RequestItem
    {
        private string _servicelinenumber = string.Empty; public string ServiceLineNumber { get { return this._servicelinenumber; } set { this._servicelinenumber = value; } }
        private string _servicelinestatus = string.Empty; public string ServiceLineStatus { get { return this._servicelinestatus; } set { this._servicelinestatus = value; } }
        private string _requestcode = string.Empty; public string RequestCode { get { return this._requestcode; } set { this._requestcode = value; } }
        private string _requestdescription = string.Empty; public string RequestDescription { get { return this._requestdescription; } set { this._requestdescription = value; } }
        private string _cpsind = string.Empty; public string CPSIND { get { return this._cpsind; } set { this._cpsind = value; } }
        private string _worktype = string.Empty; public string WorkType { get { return this._worktype; } set { this._worktype = value; } }
        private string _servicetype = string.Empty; public string ServiceType { get { return this._servicetype; } set { this._servicetype = value; } }
        private string _tcemployeeid = string.Empty; public string TCEmployeeID { get { return this._tcemployeeid; } set { this._tcemployeeid = value; } }
        private string _tcemployeename = string.Empty; public string TCEmployeeName { get { return this._tcemployeename; } set { this._tcemployeename = value; } }
        private List<Comment> _comments; public List<Comment> Comments { get { return this._comments; } set { this._comments = value; } }
        private List<Description> _descriptions; public List<Description> Descriptions { get { return this._descriptions; } set { this._descriptions = value; } }
        private List<OPCode> _opcodes; public List<OPCode> OPCodes { get { return this._opcodes; } set { this._opcodes = value; } }
    }
}