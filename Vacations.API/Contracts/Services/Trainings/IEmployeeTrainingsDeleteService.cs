using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Contracts.Services.Trainings
{
    public interface IEmployeeTrainingsDeleteService
    {
        Task<bool> DeleteEmployeeTrainings(int id);
    }
}
