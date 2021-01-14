using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contexts;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Entities.WFH;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Vacations.API.Core.Repositories.WFH
{
    public class EmployeeWFHDaysRepository: IEmployeeWFHDaysRepository
    {
        private readonly IDapperVacationContext _dbcontext;

        public EmployeeWFHDaysRepository(IDapperVacationContext dbcontext) {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<IEnumerable<EmployeeWFHDaysEntity>> GetWFHDaysAsync()
        {
            using (var connection = _dbcontext.SQLConnection)
            {
                string sQuery = "select * from WFHDays";
                return await connection.QueryAsync<EmployeeWFHDaysEntity>(sQuery);
            }
        }
    }
}
