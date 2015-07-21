﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.34209
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 이 소스 코드는 wsdl, 버전=4.0.30319.1에서 자동 생성되었습니다.
// 
namespace _1C.v4.Print {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PrintSoap", Namespace="http://wa.dms.webservice/")]
    public partial class Print : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PrintRequestOperationCompleted;
        
        /// <remarks/>
        public Print(string url)
        {
            this.Url = string.Format("{0}/v2/HMCIS/Print.asmx", url);
        }
        
        /// <remarks/>
        public event PrintRequestCompletedEventHandler PrintRequestCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://wa.dms.webservice/PrintRequest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("PrintResponse", Namespace="http://wa.dms.webservice/PrintResponse", IsNullable=true)]
        public PrintResponse PrintRequest([System.Xml.Serialization.XmlElementAttribute("PrintRequest", Namespace="http://wa.dms.webservice/PrintRequest", IsNullable=true)] PrintRequest PrintRequest1) {
            object[] results = this.Invoke("PrintRequest", new object[] {
                        PrintRequest1});
            return ((PrintResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPrintRequest(PrintRequest PrintRequest1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PrintRequest", new object[] {
                        PrintRequest1}, callback, asyncState);
        }
        
        /// <remarks/>
        public PrintResponse EndPrintRequest(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((PrintResponse)(results[0]));
        }
        
        /// <remarks/>
        public void PrintRequestAsync(PrintRequest PrintRequest1) {
            this.PrintRequestAsync(PrintRequest1, null);
        }
        
        /// <remarks/>
        public void PrintRequestAsync(PrintRequest PrintRequest1, object userState) {
            if ((this.PrintRequestOperationCompleted == null)) {
                this.PrintRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPrintRequestOperationCompleted);
            }
            this.InvokeAsync("PrintRequest", new object[] {
                        PrintRequest1}, this.PrintRequestOperationCompleted, userState);
        }
        
        private void OnPrintRequestOperationCompleted(object arg) {
            if ((this.PrintRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PrintRequestCompleted(this, new PrintRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.dms.webservice/PrintRequest")]
    public partial class PrintRequest {
        
        private TransactionHeader transactionHeaderField;
        
        private Print1 printField;
        
        /// <remarks/>
        public TransactionHeader TransactionHeader {
            get {
                return this.transactionHeaderField;
            }
            set {
                this.transactionHeaderField = value;
            }
        }
        
        /// <remarks/>
        public Print1 Print {
            get {
                return this.printField;
            }
            set {
                this.printField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.dms.webservice/PrintRequest")]
    public partial class TransactionHeader {
        
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
        public string CountryID {
            get {
                return this.countryIDField;
            }
            set {
                this.countryIDField = value;
            }
        }
        
        /// <remarks/>
        public string DistributorID {
            get {
                return this.distributorIDField;
            }
            set {
                this.distributorIDField = value;
            }
        }
        
        /// <remarks/>
        public string GroupID {
            get {
                return this.groupIDField;
            }
            set {
                this.groupIDField = value;
            }
        }
        
        /// <remarks/>
        public string DealerID {
            get {
                return this.dealerIDField;
            }
            set {
                this.dealerIDField = value;
            }
        }
        
        /// <remarks/>
        public string DMSCode {
            get {
                return this.dMSCodeField;
            }
            set {
                this.dMSCodeField = value;
            }
        }
        
        /// <remarks/>
        public string DMSVersion {
            get {
                return this.dMSVersionField;
            }
            set {
                this.dMSVersionField = value;
            }
        }
        
        /// <remarks/>
        public string DMSServerUrl {
            get {
                return this.dMSServerUrlField;
            }
            set {
                this.dMSServerUrlField = value;
            }
        }
        
        /// <remarks/>
        public string DocumentVersion {
            get {
                return this.documentVersionField;
            }
            set {
                this.documentVersionField = value;
            }
        }
        
        /// <remarks/>
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string TransactionId {
            get {
                return this.transactionIdField;
            }
            set {
                this.transactionIdField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TransactionDateTimeUTC {
            get {
                return this.transactionDateTimeUTCField;
            }
            set {
                this.transactionDateTimeUTCField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TransactionDateTimeLocal {
            get {
                return this.transactionDateTimeLocalField;
            }
            set {
                this.transactionDateTimeLocalField = value;
            }
        }
        
        /// <remarks/>
        public string TransactionType {
            get {
                return this.transactionTypeField;
            }
            set {
                this.transactionTypeField = value;
            }
        }
        
        /// <remarks/>
        public string RequestType {
            get {
                return this.requestTypeField;
            }
            set {
                this.requestTypeField = value;
            }
        }
        
        /// <remarks/>
        public string RequestPollingToken {
            get {
                return this.requestPollingTokenField;
            }
            set {
                this.requestPollingTokenField = value;
            }
        }
        
        /// <remarks/>
        public string VenderTrackingCode {
            get {
                return this.venderTrackingCodeField;
            }
            set {
                this.venderTrackingCodeField = value;
            }
        }
        
        /// <remarks/>
        public string IneterfaceID {
            get {
                return this.ineterfaceIDField;
            }
            set {
                this.ineterfaceIDField = value;
            }
        }
        
        /// <remarks/>
        public string PollingToken {
            get {
                return this.pollingTokenField;
            }
            set {
                this.pollingTokenField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.dms.webservice/PrintResponse")]
    public partial class Error {
        
        private string codeField;
        
        private string messageField;
        
        /// <remarks/>
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.dms.webservice/PrintResponse")]
    public partial class ResultMessage {
        
        private string codeField;
        
        private string messageField;
        
        /// <remarks/>
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="TransactionHeader", Namespace="http://wa.dms.webservice/PrintResponse")]
    public partial class TransactionHeader1 {
        
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
        public string CountryID {
            get {
                return this.countryIDField;
            }
            set {
                this.countryIDField = value;
            }
        }
        
        /// <remarks/>
        public string DistributorID {
            get {
                return this.distributorIDField;
            }
            set {
                this.distributorIDField = value;
            }
        }
        
        /// <remarks/>
        public string GroupID {
            get {
                return this.groupIDField;
            }
            set {
                this.groupIDField = value;
            }
        }
        
        /// <remarks/>
        public string DealerID {
            get {
                return this.dealerIDField;
            }
            set {
                this.dealerIDField = value;
            }
        }
        
        /// <remarks/>
        public string DMSCode {
            get {
                return this.dMSCodeField;
            }
            set {
                this.dMSCodeField = value;
            }
        }
        
        /// <remarks/>
        public string DMSVersion {
            get {
                return this.dMSVersionField;
            }
            set {
                this.dMSVersionField = value;
            }
        }
        
        /// <remarks/>
        public string DMSServerUrl {
            get {
                return this.dMSServerUrlField;
            }
            set {
                this.dMSServerUrlField = value;
            }
        }
        
        /// <remarks/>
        public string DocumentVersion {
            get {
                return this.documentVersionField;
            }
            set {
                this.documentVersionField = value;
            }
        }
        
        /// <remarks/>
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string TransactionId {
            get {
                return this.transactionIdField;
            }
            set {
                this.transactionIdField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TransactionDateTimeUTC {
            get {
                return this.transactionDateTimeUTCField;
            }
            set {
                this.transactionDateTimeUTCField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TransactionDateTimeLocal {
            get {
                return this.transactionDateTimeLocalField;
            }
            set {
                this.transactionDateTimeLocalField = value;
            }
        }
        
        /// <remarks/>
        public string TransactionType {
            get {
                return this.transactionTypeField;
            }
            set {
                this.transactionTypeField = value;
            }
        }
        
        /// <remarks/>
        public string RequestType {
            get {
                return this.requestTypeField;
            }
            set {
                this.requestTypeField = value;
            }
        }
        
        /// <remarks/>
        public string RequestPollingToken {
            get {
                return this.requestPollingTokenField;
            }
            set {
                this.requestPollingTokenField = value;
            }
        }
        
        /// <remarks/>
        public string VenderTrackingCode {
            get {
                return this.venderTrackingCodeField;
            }
            set {
                this.venderTrackingCodeField = value;
            }
        }
        
        /// <remarks/>
        public string IneterfaceID {
            get {
                return this.ineterfaceIDField;
            }
            set {
                this.ineterfaceIDField = value;
            }
        }
        
        /// <remarks/>
        public string PollingToken {
            get {
                return this.pollingTokenField;
            }
            set {
                this.pollingTokenField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.dms.webservice/PrintResponse")]
    public partial class PrintResponse {
        
        private TransactionHeader1 transactionHeaderField;
        
        private ResultMessage resultMessageField;
        
        private Error[] errorsField;
        
        /// <remarks/>
        public TransactionHeader1 TransactionHeader {
            get {
                return this.transactionHeaderField;
            }
            set {
                this.transactionHeaderField = value;
            }
        }
        
        /// <remarks/>
        public ResultMessage ResultMessage {
            get {
                return this.resultMessageField;
            }
            set {
                this.resultMessageField = value;
            }
        }
        
        /// <remarks/>
        public Error[] Errors {
            get {
                return this.errorsField;
            }
            set {
                this.errorsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="Print", Namespace="http://wa.dms.webservice/PrintRequest")]
    public partial class Print1 {
        
        private string dMSRONoField;
        
        private string printTypeField;
        
        private string printAddressField;
        
        /// <remarks/>
        public string DMSRONo {
            get {
                return this.dMSRONoField;
            }
            set {
                this.dMSRONoField = value;
            }
        }
        
        /// <remarks/>
        public string PrintType {
            get {
                return this.printTypeField;
            }
            set {
                this.printTypeField = value;
            }
        }
        
        /// <remarks/>
        public string PrintAddress {
            get {
                return this.printAddressField;
            }
            set {
                this.printAddressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void PrintRequestCompletedEventHandler(object sender, PrintRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PrintRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PrintRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PrintResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PrintResponse)(this.results[0]));
            }
        }
    }
}
