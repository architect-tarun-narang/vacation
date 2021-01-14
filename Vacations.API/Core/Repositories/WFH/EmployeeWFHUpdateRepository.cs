using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Entities.WFH;

namespace Vacations.API.Core.Repositories.WFH
{
    public class EmployeeWFHUpdateRepository : IEmployeeWFHUpdateRepository
    {
        private readonly IBaseRepository<EmployeeWFHEntity> _baseRepository;
        private readonly ILogger _logger;

        public EmployeeWFHUpdateRepository(IBaseRepository<EmployeeWFHEntity> baseRepository, 
            ILogger<EmployeeWFHUpdateRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> UpdateEmployeeWFH(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("Performing Update operation for Employee WFH");
            _logger.LogDebug("Update peration - Payload employeeWFHEntity = " + employeeWFHEntity);
            try
            {
                bool isChanged = await _baseRepository.UpdateEntityContribAsync(employeeWFHEntity);
                return isChanged;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption occured while performing Update employees WFH operation."+ex);
                throw;
            }
        }
        public async Task<int> AddEmployeeWFH(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("Performing Add operation for Employee WFH");
            _logger.LogDebug("Add operation - Payload employeeWFHEntity = " + employeeWFHEntity);
            try
            {
                int recordCreated = await _baseRepository.AddEntityContribAsync(employeeWFHEntity);
                return recordCreated;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption occured while performing Add employees WFH operation." + ex);
                throw;
            }
        }

    }
}
