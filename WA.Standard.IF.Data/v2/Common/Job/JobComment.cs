using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Job
{
    [Serializable]
    public class JobComment
    {
        private string _actualworkhour; public string ActualWorkHour { get { return this._actualworkhour; } set { this._actualworkhour = value; } }
        private string _substatus = string.Empty; public string SubStatus { get { return this._substatus; } set { this._substatus = value; } }
    }
}
