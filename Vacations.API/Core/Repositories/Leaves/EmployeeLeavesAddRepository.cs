using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Entities;

namespace Vacations.API.Core.Repositories.Leaves
{
    public class EmployeeLeavesAddRepository : IEmployeeLeavesAddRepository
    {
        private readonly IBaseRepository<EmployeeLeavesEntity> _baseRepository;
        private readonly ILogger _logger;

        public EmployeeLeavesAddRepository(IBaseRepository<EmployeeLeavesEntity> baseRepository, 
            ILogger<EmployeeLeavesAddRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> AddEmployeeLeaves(EmployeeLeavesEntity employeeLeavesEntity)
        {
            _logger.LogInformation("Performing Add operation for Employee Leaves");
            _logger.LogDebug("Add operation - Payload employeeLeavesEntity = " + employeeLeavesEntity);
            try
            {
                int id = await _baseRepository.AddEntityContribAsync(employeeLeavesEntity);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption occured while performing Add employees operation."+ex);
                throw;
            }
        }
    }
}
