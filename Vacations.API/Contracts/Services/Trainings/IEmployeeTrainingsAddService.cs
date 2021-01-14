using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Contracts.Services.Trainings
{
    public interface IEmployeeTrainingsAddService
    {
        Task<EmployeeTrainingsResponseDTO> AddEmployeeTrainings(EmployeeTrainingsCreationDTO employeeTrainingsCreationDTO );

    }
}
