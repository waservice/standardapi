using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Employee;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class Employee_Proxy : Base.BaseProxy
    {
        public EmployeeGetResponse EmployeeGet(EmployeeGetRequest request)
        {
            EmployeeGetResponse response = new EmployeeGetResponse();

            //DMS information set by dealer information
            string proxypath = string.Format("{0}.{1}.{2}.{3}",
                request.TransactionHeader.DocumentVersion,
                request.TransactionHeader.DistributorID,
                request.TransactionHeader.DMSCode,
                request.TransactionHeader.DMSVersion);

            switch (proxypath)
            {
                case "v2.Common.WA.v2":
                    {
                        #region v2.Common.WA.v2 - Standard (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region EmployeeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Employee.Employee proxyws = new _WA.Mapper.v2.Employee.Employee(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with employeeget and transaction
                        _WA.Mapper.v2.Employee.EmployeeGetRequest proxyrequest = new _WA.Mapper.v2.Employee.EmployeeGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Employee.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.Employee.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy employeeget
                        _WA.Mapper.v2.Employee.EmployeeGet proxyemployeeget = new _WA.Mapper.v2.Employee.EmployeeGet();
                        if (request.EmployeeGet != null)
                        {
                            #region//EmployeeGet Set
                            proxyemployeeget.DMSEmployeeNo = request.EmployeeGet.DMSEmployeeNo;
                            proxyemployeeget.LastModifiedDateTimeFromUTC = request.EmployeeGet.LastModifiedDateTimeFromUTC;
                            proxyemployeeget.LastModifiedDateTimeToUTC = request.EmployeeGet.LastModifiedDateTimeToUTC;
                            proxyemployeeget.LoginID = request.EmployeeGet.LoginID;
                            proxyrequest.EmployeeGet = proxyemployeeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Employee.EmployeeGetResponse proxyresponse = proxyws.EmployeeGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_WA.Mapper.v2.Employee.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //EmployeeGetResponse Set

                                if (proxyresponse.Employees != null && proxyresponse.Employees.Length > 0)
                                {
                                    response.Employees = new List<Employee>();
                                    foreach (_WA.Mapper.v2.Employee.Employee1 proxyemployee in proxyresponse.Employees)
                                    {
                                        #region //Employee Header
                                        Employee employee = new Employee();
                                        employee.DMSEmployeeNo = proxyemployee.DMSEmployeeNo;
                                        employee.Email = proxyemployee.Email;
                                        employee.EmployeeStatus = proxyemployee.EmployeeStatus;
                                        employee.FirstName = proxyemployee.FirstName;
                                        employee.FullName = proxyemployee.FullName;
                                        employee.Gender = proxyemployee.Gender;
                                        employee.Group = proxyemployee.Group;
                                        employee.Language = proxyemployee.Language;
                                        employee.LastName = proxyemployee.LastName;
                                        employee.LoginID = proxyemployee.LoginID;
                                        employee.LoginPassword = proxyemployee.LoginPassword;
                                        employee.MiddleName = proxyemployee.MiddleName;
                                        employee.MobileNumber = proxyemployee.MobileNumber;
                                        employee.PhoneNumber = proxyemployee.PhoneNumber;
                                        employee.Salution = proxyemployee.Salution;
                                        employee.SkillsetString = proxyemployee.SkillsetString;
                                        employee.Title = proxyemployee.Title;
                                        #endregion

                                        #region //Employee Roles
                                        if (proxyemployee.Roles != null && proxyemployee.Roles.Length > 0)
                                        {
                                            employee.Roles = new List<Role>();
                                            foreach (_WA.Mapper.v2.Employee.Role proxyrole in proxyemployee.Roles)
                                            {
                                                Role role = new Role();
                                                role.RoleName = proxyrole.RoleName;
                                                role.RoleUserID = proxyrole.RoleUserID;
                                                employee.Roles.Add(role);
                                            }
                                        }
                                        #endregion

                                        #region //Employee ManagementFields
                                        if (proxyemployee.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxyemployee.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyemployee.ManagementFields.LastModifiedDateTimeUTC;
                                            employee.ManagementFields = managementfields;
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                case "v2.HMCIS.1C.v4":
                    {
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region EmployeeGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Employee.Employee proxyws = new _1C.v4.Employee.Employee(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with employeeget and transaction
                        _1C.v4.Employee.EmployeeGetRequest proxyrequest = new _1C.v4.Employee.EmployeeGetRequest();

                        //Create proxy transaction
                        _1C.v4.Employee.TransactionHeader proxytransactionheader = new _1C.v4.Employee.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy employeeget
                        _1C.v4.Employee.EmployeeGet proxyemployeeget = new _1C.v4.Employee.EmployeeGet();
                        if (request.EmployeeGet != null)
                        {
                            #region//EmployeeGet Set
                            proxyemployeeget.DMSEmployeeNo = request.EmployeeGet.DMSEmployeeNo;
                            proxyemployeeget.LastModifiedDateTimeFromUTC = request.EmployeeGet.LastModifiedDateTimeFromUTC;
                            proxyemployeeget.LastModifiedDateTimeToUTC = request.EmployeeGet.LastModifiedDateTimeToUTC;
                            proxyemployeeget.LoginID = request.EmployeeGet.LoginID;
                            proxyrequest.EmployeeGet = proxyemployeeget;
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Employee.EmployeeGetResponse proxyresponse = proxyws.EmployeeGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_1C.v4.Employee.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region //EmployeeGetResponse Set

                                if (proxyresponse.Employees != null && proxyresponse.Employees.Length > 0)
                                {
                                    response.Employees = new List<Employee>();
                                    foreach (_1C.v4.Employee.Employee1 proxyemployee in proxyresponse.Employees)
                                    {
                                        #region //Employee Header
                                        Employee employee = new Employee();
                                        employee.DMSEmployeeNo = proxyemployee.DMSEmployeeNo;
                                        employee.Email = proxyemployee.Email;
                                        employee.EmployeeStatus = proxyemployee.EmployeeStatus;
                                        employee.FirstName = proxyemployee.FirstName;
                                        employee.FullName = proxyemployee.FullName;
                                        employee.Gender = proxyemployee.Gender;
                                        employee.Group = proxyemployee.Group;
                                        employee.Language = proxyemployee.Language;
                                        employee.LastName = proxyemployee.LastName;
                                        employee.LoginID = proxyemployee.LoginID;
                                        employee.LoginPassword = proxyemployee.LoginPassword;
                                        employee.MiddleName = proxyemployee.MiddleName;
                                        employee.MobileNumber = proxyemployee.MobileNumber;
                                        employee.PhoneNumber = proxyemployee.PhoneNumber;
                                        employee.Salution = proxyemployee.Salution;
                                        employee.SkillsetString = proxyemployee.SkillsetString;
                                        employee.Title = proxyemployee.Title;
                                        #endregion

                                        #region //Employee Roles
                                        if (proxyemployee.Roles != null && proxyemployee.Roles.Length > 0)
                                        {
                                            employee.Roles = new List<Role>();
                                            foreach (_1C.v4.Employee.Role proxyrole in proxyemployee.Roles)
                                            {
                                                Role role = new Role();
                                                role.RoleName = proxyrole.RoleName;
                                                role.RoleUserID = proxyrole.RoleUserID;
                                                employee.Roles.Add(role);
                                            }
                                        }
                                        #endregion

                                        #region //Employee ManagementFields
                                        if (proxyemployee.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.LastModifiedDateTimeUTC = proxyemployee.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyemployee.ManagementFields.LastModifiedDateTimeUTC;
                                            employee.ManagementFields = managementfields;
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = ResponseCode.NoMatchedProxy, Message = ResponseMessage.NoMatchedProxy } };
                    break;
            }

            return response;
        }
    }
}
