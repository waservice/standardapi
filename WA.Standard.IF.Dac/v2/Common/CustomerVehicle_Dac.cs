using System.Data;
using System.Data.Common;
using WA.Standard.IF.Data.v2.Common.CustomerVehicle;

namespace WA.Standard.IF.Dac.v2.Common
{
    public class CustomerVehicle_Dac : WA.Standard.IF.Dac.v2.Base.BaseDac
    {
        public CustomerVehicle_Dac() : base("DBCONN_DMS") { }

        //Get CustomerVehicle
        public DataSet SelectCustomerVehicle(string CountryID
                                        , string DistributorID
                                        , string GroupID
                                        , string DealerID
                                        , string Language
                                        , string ContactType
                                        , string ContactValue
                                        , CustomerVehicleGet request
            )
        {
            DataSet ds = null;

            DbCommand command = _agent.GetStoredProcCommand("DMS_CustomerVehicle_Q");

            _agent.AddInParameter(command, "@CountryID", DbType.String, CountryID);
            _agent.AddInParameter(command, "@DistributorID", DbType.String, DistributorID);
            _agent.AddInParameter(command, "@GroupID", DbType.String, GroupID);
            _agent.AddInParameter(command, "@DealerID", DbType.String, DealerID);
            _agent.AddInParameter(command, "@Language", DbType.String, Language);
            _agent.AddInParameter(command, "@DMSCustomerNo", DbType.String, request.Customer.DMSCustomerNo);
            _agent.AddInParameter(command, "@LastName", DbType.String, request.Customer.LastName);
            _agent.AddInParameter(command, "@Email", DbType.String, request.Customer.Email);
            _agent.AddInParameter(command, "@CardNo", DbType.String, request.Customer.CardNo);
            _agent.AddInParameter(command, "@ContactType", DbType.String, ContactType);
            _agent.AddInParameter(command, "@ContactValue", DbType.String, ContactValue);
            _agent.AddInParameter(command, "@DMSVehicleNo", DbType.String, request.Vehicle.DMSVehicleNo);
            _agent.AddInParameter(command, "@VIN", DbType.String, request.Vehicle.VIN);
            _agent.AddInParameter(command, "@LastSixVIN", DbType.String, request.Vehicle.LastSixVIN);
            _agent.AddInParameter(command, "@LicensePlateNo", DbType.String, request.Vehicle.LicensePlateNo);

            ds = _agent.ExecuteDataSet(command);

            return ds;
        }
    }
}
