using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.IO;

namespace Vacations.API.Contexts
{
    public class DapperVacationContext : IDapperVacationContext
    {
        private IConfiguration _config;

        public DapperVacationContext(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            /*try
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

                _config = builder.Build();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
*/


        }

        public IDbConnection Connection
        {
            get 
            {
                Debug.WriteLine(_config.GetConnectionString("VacationConnectionString"));
                return new SqlConnection(_config.GetConnectionString("VacationConnectionString"));
            }
        
        }

        public SqlConnection SQLConnection
        {
            get
            {                
                Debug.WriteLine(_config.GetConnectionString("VacationConnectionString"));
                return new SqlConnection(_config.GetConnectionString("VacationConnectionString"));
            }

        }


        int _timeoutperiod;
        public int TimeOutPeriod {
            get
            {
                return _timeoutperiod;
            }
            set
            {
                _timeoutperiod = Int32.Parse(_config["CommandTimeOutInSeconds"]);
            }
        }
       // public int TimeOutPeriod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<T> WithConnection<T>(Func<IDbConnection,Task<T>> executeQuery)
        {
            
            try
            {

                using (IDbConnection conn = Connection)
                {
                    
                    conn.Open();
                    return await executeQuery(conn);
                    
                }

            }
            catch (TimeoutException ex)
            {
                //TODO: Uncomment while setting up Elmah
                //ErrorSignal.FromCurrentContext().Raise(ex);
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                //TODO: Uncomment while setting up Elmah
                //ErrorSignal.FromCurrentContext().Raise(ex);
                throw new Exception(
                    $"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
            catch (Exception ex)
            {
                //TODO: Uncomment while setting up Elmah
                //ErrorSignal.FromCurrentContext().Raise(ex);
                Debug.WriteLine(ex);
                throw new Exception(
                    $"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }


        public void Dispose()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }

            if (SQLConnection != null && SQLConnection.State == ConnectionState.Open)
            {
                SQLConnection.Close();
            }

        }
    }
}
