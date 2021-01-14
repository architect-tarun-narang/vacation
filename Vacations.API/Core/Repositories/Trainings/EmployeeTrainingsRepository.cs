using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Entities.Trainings;

namespace Vacations.API.Core.Repositories.Trainings
{
    public class EmployeeTrainingsRepository : IEmployeeTrainingsRepository
    {
        private readonly IBaseRepository<EmployeeTrainingsEntity> _baseRepository;
        private readonly ILogger<EmployeeTrainingsRepository> _logger;

        public EmployeeTrainingsRepository(IBaseRepository<EmployeeTrainingsEntity> baseRepository, ILogger<EmployeeTrainingsRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<IEnumerable<EmployeeTrainingsEntity>> GetEmployeeTrainingsAsync(EmployeeTrainingsEntity employeeTrainingsEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            //string sQuery = "Select * from EmployeeTraining WHERE EmployeeId=@EmployeeId and VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            string sQuery = "Select * from EmployeeTraining et, Training t where t.id=et.TrainingId and et.EmployeeId=@EmployeeId and VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeTrainingsEntity);
        }

        public async Task<IEnumerable<EmployeeTrainingsEntity>> GetEmployeeTrainingsAllAsync(EmployeeTrainingsEntity employeeTrainingsEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            //string sQuery = "Select * from EmployeeTraining WHERE VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            string sQuery = "Select * from EmployeeTraining et, Training t where t.id=et.TrainingId and VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeTrainingsEntity);
        }

        public async Task<EmployeeTrainingsEntity> GetEmployeeTrainingsByPrimaryKeyId(int Id)
        {
            _logger.LogInformation("### Called GetEmployeeTrainingsByPrimaryKeyId ### ");
            var employeeTrainingsEntity  = await _baseRepository.FindEntityContrib(Id);
            return employeeTrainingsEntity;
        }

        public async Task<IEnumerable<EmployeeTrainingsEntity>> GetAllEmployeesByTrainingsIdAsync(EmployeeTrainingsEntity employeeTrainingsEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select * from EmployeeTraining et, Training t where t.id=et.TrainingId and VacationTypeId=@VacationTypeId and TrainingId=@TrainingId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeTrainingsEntity);
        }

    }
}
