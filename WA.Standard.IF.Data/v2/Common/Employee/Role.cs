using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WA.Standard.IF.Data.v2.Common.Employee
{
    [Serializable]
    public class Role
    {
        private string _rolename = string.Empty; public string RoleName { get { return this._rolename; } set { this._rolename = value; } }
        private string _roleuserid = string.Empty; public string RoleUserID { get { return this._roleuserid; } set { this._roleuserid = value; } }
    }
}
