using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.Employee;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class Employee_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public Employee_Dac() : base("DBCONN_DMS") { }

        //Get Employee
        public DataSet SelectEmployee(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , EmployeeGet request
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("DMS_Employee_Q");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);
            _agent.AddInParameter(command, "@DMSEmployeeNo", DbType.String, request.DMSEmployeeNo);
            _agent.AddInParameter(command, "@LoginID", DbType.String, request.LoginID);
            _agent.AddInParameter(command, "@LastModifiedDateTimeFromUTC", DbType.DateTime, request.LastModifiedDateTimeFromUTC);
            _agent.AddInParameter(command, "@LastModifiedDateTimeToUTC", DbType.DateTime, request.LastModifiedDateTimeToUTC);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}
