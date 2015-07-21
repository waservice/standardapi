using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.Job;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class Job_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public Job_Dac() : base("DBCONN_DMS") { }

        //Get Job
        public DataSet SelectJob(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , JobGet request
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);
            _agent.AddInParameter(command, "@DMSAppointmentNo", DbType.String, request.DMSAppointmentNo);
            _agent.AddInParameter(command, "@DMSJobNo", DbType.String, request.DMSJobNo);
            _agent.AddInParameter(command, "@DMSJobStatus", DbType.String, request.DMSJobStatus);
            _agent.AddInParameter(command, "@DMSRONo", DbType.String, request.DMSRONo);
            _agent.AddInParameter(command, "@LastModifiedDateTimeFromUTC", DbType.DateTime, request.LastModifiedDateTimeFromUTC);
            _agent.AddInParameter(command, "@LastModifiedDateTimeToUTC", DbType.DateTime, request.LastModifiedDateTimeToUTC);
            _agent.AddInParameter(command, "@ScheduledDateTimeFromLocal", DbType.DateTime, request.ScheduledDateTimeFromLocal);
            _agent.AddInParameter(command, "@ScheduledDateTimeToLocal", DbType.DateTime, request.ScheduledDateTimeToLocal);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}
