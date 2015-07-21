using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.OPCode;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class OPCode_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public OPCode_Dac() : base("DBCONN_DMS") { }

        //Get OPCode
        public DataSet SelectOPCode(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , OPCodeGet request
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("DMS_OPCode_Q");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Code", DbType.String, request.Code);
            _agent.AddInParameter(command, "@Description", DbType.String, request.Description);
            _agent.AddInParameter(command, "@Make", DbType.String, request.Make);
            _agent.AddInParameter(command, "@Model", DbType.String, request.Model);
            _agent.AddInParameter(command, "@Year", DbType.String, request.Year);
            _agent.AddInParameter(command, "@Engine", DbType.String, request.Engine);
            _agent.AddInParameter(command, "@Mileage", DbType.String, request.Mileage);
            _agent.AddInParameter(command, "@Category", DbType.String, request.Category);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}