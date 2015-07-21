using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class Correction
    {
        private string _sequencenumber = string.Empty; public string SequenceNumber { get { return this._sequencenumber; } set { this._sequencenumber = value; } }
        private string _comment = string.Empty; public string Comment { get { return this._comment; } set { this._comment = value; } }
        private string _correctionlaboropcode = string.Empty; public string CorrectionLaborOpCode { get { return this._correctionlaboropcode; } set { this._correctionlaboropcode = value; } }
    }
}