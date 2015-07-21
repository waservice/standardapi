using System;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using STIS.Framework.V4.Cryptography;
using WA.Standard.IF.Logger.Log;

namespace WA.Standard.IF.Dac.v2.Base
{
    public class BaseDac : IDisposable
    {
        public SqlDatabase _agent;
        
        bool disposed = false;
        bool _isEncrypted = true;
        string _connectionString;

        public BaseDac(string connectionStringName)
        {
            try
            {
                if (this._isEncrypted)
                    this._connectionString = Cryptor.Decrypt(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
                else
                    this._connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

                _agent = new SqlDatabase(this._connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                //do something
                _agent = null;
            }

            disposed = true;
        }
    }
}
