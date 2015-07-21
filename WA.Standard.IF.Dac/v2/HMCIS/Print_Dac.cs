using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.HMCIS.Print;

namespace WA.Standard.IF.Dac.v2.HMCIS
{
    public class Print_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public Print_Dac() : base("DBCONN_DMS") { }

        //Get Print
        public DataSet SelectPrint(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , PrintRequest request
                                        , string Language
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}