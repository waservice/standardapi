using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1C_v8_2.Employee
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class EmployeeGetResponse
    {
        private TransactionHeader transactionHeaderField;

        private ResultMessage resultMessageField;

        private Error[] errorsField;

        private Employee[] employeesField;

        /// <remarks/>
        public TransactionHeader TransactionHeader
        {
            get
            {
                return this.transactionHeaderField;
            }
            set
            {
                this.transactionHeaderField = value;
            }
        }

        /// <remarks/>
        public ResultMessage ResultMessage
        {
            get
            {
                return this.resultMessageField;
            }
            set
            {
                this.resultMessageField = value;
            }
        }

        /// <remarks/>
        public Error[] Errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public Employee[] Employees
        {
            get
            {
                return this.employeesField;
            }
            set
            {
                this.employeesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class EmployeeGetRequest
    {

        private TransactionHeader transactionHeaderField;

        private EmployeeGet employeeGetField;

        /// <remarks/>
        public TransactionHeader TransactionHeader
        {
            get
            {
                return this.transactionHeaderField;
            }
            set
            {
                this.transactionHeaderField = value;
            }
        }

        /// <remarks/>
        public EmployeeGet EmployeeGet
        {
            get
            {
                return this.employeeGetField;
            }
            set
            {
                this.employeeGetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class EmployeeGet
    {

        private string dMSEmployeeNoField;

        private string loginIDField;

        private System.Nullable<System.DateTime> lastModifiedDateTimeFromUTCField;

        private System.Nullable<System.DateTime> lastModifiedDateTimeToUTCField;

        /// <remarks/>
        public string DMSEmployeeNo
        {
            get
            {
                return this.dMSEmployeeNoField;
            }
            set
            {
                this.dMSEmployeeNoField = value;
            }
        }

        /// <remarks/>
        public string LoginID
        {
            get
            {
                return this.loginIDField;
            }
            set
            {
                this.loginIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> LastModifiedDateTimeFromUTC
        {
            get
            {
                return this.lastModifiedDateTimeFromUTCField;
            }
            set
            {
                this.lastModifiedDateTimeFromUTCField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> LastModifiedDateTimeToUTC
        {
            get
            {
                return this.lastModifiedDateTimeToUTCField;
            }
            set
            {
                this.lastModifiedDateTimeToUTCField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class Error
    {

        private string codeField;

        private string messageField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class TransactionHeader
    {

        private string countryIDField;

        private string distributorIDField;

        private string groupIDField;

        private string dealerIDField;

        private string dMSCodeField;

        private string dMSVersionField;

        private string dMSServerUrlField;

        private string documentVersionField;

        private string usernameField;

        private string passwordField;

        private string transactionIdField;

        private System.DateTime transactionDateTimeUTCField;

        private System.DateTime transactionDateTimeLocalField;

        private string transactionTypeField;

        private string requestTypeField;

        private string requestPollingTokenField;

        private string venderTrackingCodeField;

        private string ineterfaceIDField;

        private string pollingTokenField;

        /// <remarks/>
        public string CountryID
        {
            get
            {
                return this.countryIDField;
            }
            set
            {
                this.countryIDField = value;
            }
        }

        /// <remarks/>
        public string DistributorID
        {
            get
            {
                return this.distributorIDField;
            }
            set
            {
                this.distributorIDField = value;
            }
        }

        /// <remarks/>
        public string GroupID
        {
            get
            {
                return this.groupIDField;
            }
            set
            {
                this.groupIDField = value;
            }
        }

        /// <remarks/>
        public string DealerID
        {
            get
            {
                return this.dealerIDField;
            }
            set
            {
                this.dealerIDField = value;
            }
        }

        /// <remarks/>
        public string DMSCode
        {
            get
            {
                return this.dMSCodeField;
            }
            set
            {
                this.dMSCodeField = value;
            }
        }

        /// <remarks/>
        public string DMSVersion
        {
            get
            {
                return this.dMSVersionField;
            }
            set
            {
                this.dMSVersionField = value;
            }
        }

        /// <remarks/>
        public string DMSServerUrl
        {
            get
            {
                return this.dMSServerUrlField;
            }
            set
            {
                this.dMSServerUrlField = value;
            }
        }

        /// <remarks/>
        public string DocumentVersion
        {
            get
            {
                return this.documentVersionField;
            }
            set
            {
                this.documentVersionField = value;
            }
        }

        /// <remarks/>
        public string Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string TransactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }

        /// <remarks/>
        public System.DateTime TransactionDateTimeUTC
        {
            get
            {
                return this.transactionDateTimeUTCField;
            }
            set
            {
                this.transactionDateTimeUTCField = value;
            }
        }

        /// <remarks/>
        public System.DateTime TransactionDateTimeLocal
        {
            get
            {
                return this.transactionDateTimeLocalField;
            }
            set
            {
                this.transactionDateTimeLocalField = value;
            }
        }

        /// <remarks/>
        public string TransactionType
        {
            get
            {
                return this.transactionTypeField;
            }
            set
            {
                this.transactionTypeField = value;
            }
        }

        /// <remarks/>
        public string RequestType
        {
            get
            {
                return this.requestTypeField;
            }
            set
            {
                this.requestTypeField = value;
            }
        }

        /// <remarks/>
        public string RequestPollingToken
        {
            get
            {
                return this.requestPollingTokenField;
            }
            set
            {
                this.requestPollingTokenField = value;
            }
        }

        /// <remarks/>
        public string VenderTrackingCode
        {
            get
            {
                return this.venderTrackingCodeField;
            }
            set
            {
                this.venderTrackingCodeField = value;
            }
        }

        /// <remarks/>
        public string IneterfaceID
        {
            get
            {
                return this.ineterfaceIDField;
            }
            set
            {
                this.ineterfaceIDField = value;
            }
        }

        /// <remarks/>
        public string PollingToken
        {
            get
            {
                return this.pollingTokenField;
            }
            set
            {
                this.pollingTokenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class ResultMessage
    {

        private string codeField;

        private string messageField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class Employee
    {
        private string dMSEmployeeNoField;

        private string lastNameField;

        private string middleNameField;

        private string firstNameField;

        private string fullNameField;

        private string salutionField;

        private string genderField;

        private string languageField;

        private string skillsetStringField;

        private string titleField;

        private string mobileNumberField;

        private string phoneNumberField;

        private string emailField;

        private string loginIDField;

        private string loginPasswordField;

        private string employeeStatusField;

        private string groupField;

        private ManagementFields managementFieldsField;

        private Role[] rolesField;

        /// <remarks/>
        public string DMSEmployeeNo
        {
            get
            {
                return this.dMSEmployeeNoField;
            }
            set
            {
                this.dMSEmployeeNoField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public string MiddleName
        {
            get
            {
                return this.middleNameField;
            }
            set
            {
                this.middleNameField = value;
            }
        }

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        public string Salution
        {
            get
            {
                return this.salutionField;
            }
            set
            {
                this.salutionField = value;
            }
        }

        /// <remarks/>
        public string Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string SkillsetString
        {
            get
            {
                return this.skillsetStringField;
            }
            set
            {
                this.skillsetStringField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string MobileNumber
        {
            get
            {
                return this.mobileNumberField;
            }
            set
            {
                this.mobileNumberField = value;
            }
        }

        /// <remarks/>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public string LoginID
        {
            get
            {
                return this.loginIDField;
            }
            set
            {
                this.loginIDField = value;
            }
        }

        /// <remarks/>
        public string LoginPassword
        {
            get
            {
                return this.loginPasswordField;
            }
            set
            {
                this.loginPasswordField = value;
            }
        }

        /// <remarks/>
        public string EmployeeStatus
        {
            get
            {
                return this.employeeStatusField;
            }
            set
            {
                this.employeeStatusField = value;
            }
        }

        /// <remarks/>
        public string Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }

        /// <remarks/>
        public ManagementFields ManagementFields
        {
            get
            {
                return this.managementFieldsField;
            }
            set
            {
                this.managementFieldsField = value;
            }
        }

        /// <remarks/>
        public Role[] Roles
        {
            get
            {
                return this.rolesField;
            }
            set
            {
                this.rolesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class ManagementFields
    {

        private System.DateTime createDateTimeUTCField;

        private System.DateTime lastModifiedDateTimeUTCField;

        /// <remarks/>
        public System.DateTime CreateDateTimeUTC
        {
            get
            {
                return this.createDateTimeUTCField;
            }
            set
            {
                this.createDateTimeUTCField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LastModifiedDateTimeUTC
        {
            get
            {
                return this.lastModifiedDateTimeUTCField;
            }
            set
            {
                this.lastModifiedDateTimeUTCField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://wa.dms.webservice/EmployeeGetRequest")]
    public class Role
    {

        private string roleNameField;

        private string roleUserIDField;

        /// <remarks/>
        public string RoleName
        {
            get
            {
                return this.roleNameField;
            }
            set
            {
                this.roleNameField = value;
            }
        }

        /// <remarks/>
        public string RoleUserID
        {
            get
            {
                return this.roleUserIDField;
            }
            set
            {
                this.roleUserIDField = value;
            }
        }
    }
}
