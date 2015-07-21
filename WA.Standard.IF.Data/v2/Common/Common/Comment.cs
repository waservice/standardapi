using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Data.v2.Common.Common
{
    [Serializable]
    public class Comment
    {
        private string _sequencenumber = string.Empty; public string SequenceNumber { get { return this._sequencenumber; } set { this._sequencenumber = value; } }
        private string _descriptioncomment = string.Empty; public string DescriptionComment { get { return this._descriptioncomment; } set { this._descriptioncomment = value; } }
    }
}