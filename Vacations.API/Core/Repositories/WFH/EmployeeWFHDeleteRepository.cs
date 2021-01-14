using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Entities.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Core.Repositories.WFH
{
    public class EmployeeWFHDeleteRepository : IEmployeeWFHDeleteRepository
    {
        private readonly IBaseRepository<EmployeeWFHEntity> _baseRepository;
        private readonly ILogger<EmployeeWFHDeleteRepository> _logger;

        public EmployeeWFHDeleteRepository(IBaseRepository<EmployeeWFHEntity> baseRepository,
            ILogger<EmployeeWFHDeleteRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> DeleteEmployeeWFHAsync(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("Performing Delete operation for Employee WFH.");
            _logger.LogDebug("Delete operation - Payload employeeWFHEntity = " + employeeWFHEntity);
            try
            {
                return await _baseRepository.DeleteEntityContribAsync(employeeWFHEntity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception Occured while performing delete trainings operation."+ex);
                throw;
            }
        }
    }
}
