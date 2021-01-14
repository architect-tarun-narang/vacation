using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Contracts.Services.Trainings
{
    public interface IEmployeeTrainingsService
    {
        Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetEmployeeTrainings(EmployeeTrainingsRequestDTO employeeTrainingsRequestDTO);
        Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetEmployeeTrainingsAll(EmployeeTrainingsAllRequestDTO employeeTrainingsAllRequestDTO);
        Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetAllEmployeeByTrainingsId(EmployeeTrainingsIDRequestDTO employeeTrainingsIDRequestDTO);
        Task<IEnumerable<TrainingTypeResponseDTO>> GetTrainingTypes();
    }
}
