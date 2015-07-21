using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.HMCIS.Price;

namespace WA.Standard.IF.Dac.v2.HMCIS
{
    public class Price_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public Price_Dac() : base("DBCONN_DMS") { }

        //Get Price
        public DataSet SelectPrice(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , PriceCheck request
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