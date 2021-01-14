using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.Trainings;

namespace Vacations.API.Contracts.Repositories.Trainings
{
    public interface IEmployeeTrainingsRepository
    {
        Task<IEnumerable<EmployeeTrainingsEntity>> GetEmployeeTrainingsAsync(EmployeeTrainingsEntity employeeTrainingsEntity);
        Task<IEnumerable<EmployeeTrainingsEntity>> GetEmployeeTrainingsAllAsync(EmployeeTrainingsEntity employeeTrainingsEntity);
        Task<EmployeeTrainingsEntity> GetEmployeeTrainingsByPrimaryKeyId(int Id);
        Task<IEnumerable<EmployeeTrainingsEntity>> GetAllEmployeesByTrainingsIdAsync(EmployeeTrainingsEntity employeeTrainingsEntity);
    }
}
