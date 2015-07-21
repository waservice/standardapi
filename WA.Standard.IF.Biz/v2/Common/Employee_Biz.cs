using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Employee;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class Employee_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public EmployeeGetResponse EmployeeGet(EmployeeGetRequest request)
        {
            EmployeeGetResponse response = new EmployeeGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Employee_Proxy proxy = new Proxy.v2.Common.Employee_Proxy();
                response = proxy.EmployeeGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                List<Employee> Employees = Util.DataHelper.GetListByElementName<Employee>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Employees.xml"), "Employee");

                if (Employees != null && Employees.Count > 0)
                {
                    List<Employee> resultlist = Employees.Where(item =>
                        (string.IsNullOrEmpty(request.EmployeeGet.DMSEmployeeNo) || request.EmployeeGet.DMSEmployeeNo == item.DMSEmployeeNo)
                        && (string.IsNullOrEmpty(request.EmployeeGet.LoginID) || request.EmployeeGet.LoginID == item.LoginID)
                        && (request.EmployeeGet.LastModifiedDateTimeFromUTC == null || request.EmployeeGet.LastModifiedDateTimeFromUTC <= item.ManagementFields.LastModifiedDateTimeUTC)
                        && (request.EmployeeGet.LastModifiedDateTimeToUTC == null || request.EmployeeGet.LastModifiedDateTimeToUTC >= item.ManagementFields.LastModifiedDateTimeUTC)
                        ).ToList<Employee>();

                    response.Employees = resultlist;

                    if (resultlist.Count > 0)
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                    else
                        response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process

                /*
                DataSet resultDS = new DataSet();
                using (Employee_Dac dac = new Employee_Dac())
                {
                    resultDS = dac.SelectEmployee(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language // Need to check
                                                        , request.EmployeeGet
                                                        );
                }

                //0. Employee Data
                //1. Role Data

                if (resultDS.Tables != null && resultDS.Tables.Count > 0)
                {
                    List<Employee> Employees = null;
                    if (resultDS.Tables[0].Rows.Count > 0)
                    {
                        #region Employees
                        Employees = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new Employee
                        {
                            DMSEmployeeNo = Util.DataHelper.ConvertObjectToString(row["DMSEmployeeNo"]),
                            Email = Util.DataHelper.ConvertObjectToString(row["Email"]),
                            EmployeeStatus = Util.DataHelper.ConvertObjectToString(row["EmployeeStatus"]),
                            FirstName = Util.DataHelper.ConvertObjectToString(row["FirstName"]),
                            FullName = Util.DataHelper.ConvertObjectToString(row["FullName"]),
                            Gender = Util.DataHelper.ConvertObjectToString(row["Gender"]),
                            Group = Util.DataHelper.ConvertObjectToString(row["Group"]),
                            Language = Util.DataHelper.ConvertObjectToString(row["Language"]),
                            LastName = Util.DataHelper.ConvertObjectToString(row["LastName"]),
                            LoginID = Util.DataHelper.ConvertObjectToString(row["LoginID"]),
                            LoginPassword = Util.DataHelper.ConvertObjectToString(row["LoginPassword"]),
                            MiddleName = Util.DataHelper.ConvertObjectToString(row["MiddleName"]),
                            MobileNumber = Util.DataHelper.ConvertObjectToString(row["MobileNumber"]),
                            PhoneNumber = Util.DataHelper.ConvertObjectToString(row["PhoneNumber"]),
                            Salution = Util.DataHelper.ConvertObjectToString(row["Salution"]),
                            SkillsetString = Util.DataHelper.ConvertObjectToString(row["SkillsetString"]),
                            Title = Util.DataHelper.ConvertObjectToString(row["Title"]),
                            ManagementFields = new ManagementFields() {
                                CreateDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["CreateDateTimeUTC"]), 
                                LastModifiedDateTimeUTC = Util.DataHelper.ConvertObjectToDateTime(row["LastModifiedDateTimeUTC"]) },
                            Roles = new List<Role>(),
                        }).ToList();
                        #endregion

                        if (Employees != null && Employees.Count > 0)
                        {
                            foreach (Employee employee in Employees)
                            {
                                #region Roles
                                List<Role> Roles = resultDS.Tables[1].AsEnumerable()
                                    .Where(row => Util.DataHelper.ConvertObjectToString(row["DMSEmployeeNo"]) == employee.DMSEmployeeNo)
                                    .Select(row =>
                                new Role
                                {
                                    RoleName = Util.DataHelper.ConvertObjectToString(row["RoleName"]),
                                    RoleUserID = Util.DataHelper.ConvertObjectToString(row["RoleUserID"]),
                                }).ToList();
                                if (Roles.Count > 0)
                                    employee.Roles = Roles;
                                #endregion
                            }

                            response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                            response.Employees = Employees;
                        }
                    }
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                }
                 */
                #endregion
            }

            return response;
        }
    }
}
