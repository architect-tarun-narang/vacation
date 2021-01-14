using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities;
using Vacations.API.Models;

namespace Vacations.API.Contracts.Services.Leaves
{
    public interface IEmployeeLeavesAddService
    {
        Task<EmployeeLeavesDateDTO> AddEmployeeLeaves(EmployeeLeavesCreationDTO employeeLeavesCreationDTO);

    }
}
