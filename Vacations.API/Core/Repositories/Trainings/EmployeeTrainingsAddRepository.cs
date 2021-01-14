using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Entities.Trainings;

namespace Vacations.API.Core.Repositories.Trainings
{
    public class EmployeeTrainingsAddRepository : IEmployeeTrainingsAddRepository
    {
        private readonly IBaseRepository<EmployeeTrainingsEntity> _baseRepository;
        private readonly ILogger _logger;

        public EmployeeTrainingsAddRepository(IBaseRepository<EmployeeTrainingsEntity> baseRepository, 
            ILogger<EmployeeTrainingsAddRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> AddEmployeeTrainings(EmployeeTrainingsEntity employeeTrainingsEntity)
        {
            _logger.LogInformation("Performing Add operation for Employee Trainings");
            _logger.LogDebug("Add operation - Payload employeeTrainingsEntity = " + employeeTrainingsEntity);
            try
            {
                int id = await _baseRepository.AddEntityContribAsync(employeeTrainingsEntity);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption occured while performing Add employees Trainings operation."+ex);
                throw;
            }
        }
    }
}
