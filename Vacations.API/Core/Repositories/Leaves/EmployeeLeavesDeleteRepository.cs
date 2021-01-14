using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Entities;
using Vacations.API.Models;

namespace Vacations.API.Core.Repositories.Leaves
{
    public class EmployeeLeavesDeleteRepository : IEmployeeLeavesDeleteRepository
    {
        private readonly IBaseRepository<EmployeeLeavesEntity> _baseRepository;
        private readonly ILogger<EmployeeLeavesDeleteRepository> _logger;

        public EmployeeLeavesDeleteRepository(IBaseRepository<EmployeeLeavesEntity> baseRepository,
            ILogger<EmployeeLeavesDeleteRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> DeleteEmployeeLeavesAsync(EmployeeLeavesEntity employeeLeavesEntity)
        {
            _logger.LogInformation("Performing Delete operation for Employee Leaves");
            _logger.LogDebug("Delete operation - Payload EmployeeLeavesDateDTO = " + employeeLeavesEntity);
            try
            {
                return await _baseRepository.DeleteEntityContribAsync(employeeLeavesEntity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception Occured while performing delete operation."+ex);
                throw;
            }
        }
    }
}
