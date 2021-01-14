using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Contexts
{
    public interface IDapperVacationContext: IDisposable
    {
        IDbConnection Connection { get; }

        SqlConnection SQLConnection { get; }

        Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> executeQuery);

        int TimeOutPeriod { get;  set; }
      
    }
}
