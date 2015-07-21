using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class Job
    {
        private string _dmsjobno = string.Empty; public string DMSJobNo { get { return this._dmsjobno; } set { this._dmsjobno = value; } }
        private string _dmsrono = string.Empty; public string DMSRONo { get { return this._dmsrono; } set { this._dmsrono = value; } }
        private string _dmsappointmentno = string.Empty; public string DMSAppointmentNo { get { return this._dmsappointmentno; } set { this._dmsappointmentno = value; } }
        private string _servicelinenumber = string.Empty; public string ServiceLineNumber { get { return this._servicelinenumber; } set { this._servicelinenumber = value; } }
        private string _estimatedhours; public string EstimatedHours { get { return this._estimatedhours; } set { this._estimatedhours = value; } }
        private string _actualhours; public string ActualHours { get { return this._actualhours; } set { this._actualhours = value; } }
        private string _skilllevel = string.Empty; public string SkillLevel { get { return this._skilllevel; } set { this._skilllevel = value; } }
        private ManagementFields _managementfields; public ManagementFields ManagementFields { get { return this._managementfields; } set { this._managementfields = value; } }
        private List<Description> _descriptions; public List<Description> Descriptions { get { return this._descriptions; } set { this._descriptions = value; } }
        private List<Cause> _causes; public List<Cause> Causes { get { return this._causes; } set { this._causes = value; } }
        private List<Correction> _corrections; public List<Correction> Corrections { get { return this._corrections; } set { this._corrections = value; } }
        private List<Comment> _comments; public List<Comment> Comments { get { return this._comments; } set { this._comments = value; } }
        private List<OPCode> _opcodes; public List<OPCode> OPCodes { get { return this._opcodes; } set { this._opcodes = value; } }
        private List<JobLog> _joblogs; public List<JobLog> JobLogs { get { return this._joblogs; } set { this._joblogs = value; } }

    }
}
