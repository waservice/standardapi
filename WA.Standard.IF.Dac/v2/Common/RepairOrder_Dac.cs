using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.RepairOrder;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class RepairOrder_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public RepairOrder_Dac() : base("DBCONN_DMS") { }

        //Get RepairOrder
        public DataSet SelectRepairOrder(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , string ContactType
                                        , string ContactValue
                                        , RepairOrderGet request
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
