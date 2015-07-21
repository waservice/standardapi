using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class OPCode
    {
        private string _code = string.Empty; public string Code { get { return this._code; } set { this._code = value; } }
        private string _description = string.Empty; public string Description { get { return this._description; } set { this._description = value; } }
        private string _estimatedhours; public string EstimatedHours { get { return this._estimatedhours; } set { this._estimatedhours = value; } }
        private string _actualhours; public string ActualHours { get { return this._actualhours; } set { this._actualhours = value; } }
        private string _skilllevel = string.Empty; public string SkillLevel { get { return this._skilllevel; } set { this._skilllevel = value; } }
        private List<Description> _descriptions; public List<Description> Descriptions { get { return this._descriptions; } set { this._descriptions = value; } }
        private List<Cause> _causes; public List<Cause> Causes { get { return this._causes; } set { this._causes = value; } }
        private List<Correction> _corrections; public List<Correction> Corrections { get { return this._corrections; } set { this._corrections = value; } }
        private List<Comment> _comments; public List<Comment> Comments { get { return this._comments; } set { this._comments = value; } }

    }
}
