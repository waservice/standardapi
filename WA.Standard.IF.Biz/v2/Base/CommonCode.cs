using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WA.Standard.IF.Biz.v2.Base
{
    public class RunningMode 
    {
        public const string XMLDMS = "XMLDMS";
        public const string DBDMS = "DBDMS";
        public const string Mapper = "Mapper";
    }

    public class LoggingMode
    {
        public const string File = "File";
        public const string DB = "DB";
        public const string None = "None";
    }

    public class LineType
    {
        public const string Request = "Request";
        public const string OPCode = "OPCode";
        public const string Part = "Part";
        public const string Sublet = "Sublet";
        public const string MISC = "MISC";
    }

    public class TransCode
    {
        public const string Request = "Request";

        public const string Cause = "Cause";
        public const string Correction = "Correction";
        public const string Description = "Description";
        public const string Comment = "Comment";
    }


}
