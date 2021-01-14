using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Entities.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Core.Repositories.Trainings
{
    public class EmployeeTrainingsDeleteRepository : IEmployeeTrainingsDeleteRepository
    {
        private readonly IBaseRepository<EmployeeTrainingsEntity> _baseRepository;
        private readonly ILogger<EmployeeTrainingsDeleteRepository> _logger;

        public EmployeeTrainingsDeleteRepository(IBaseRepository<EmployeeTrainingsEntity> baseRepository,
            ILogger<EmployeeTrainingsDeleteRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> DeleteEmployeeTrainingsAsync(EmployeeTrainingsEntity employeeTrainingsEntity)
        {
            _logger.LogInformation("Performing Delete operation for Employee Trainings.");
            _logger.LogDebug("Delete operation - Payload employeeTrainingsEntity = " + employeeTrainingsEntity);
            try
            {
                return await _baseRepository.DeleteEntityContribAsync(employeeTrainingsEntity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception Occured while performing delete trainings operation."+ex);
                throw;
            }
        }
    }
}
