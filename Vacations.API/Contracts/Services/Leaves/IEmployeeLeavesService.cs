using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.All;
using Vacations.API.Entities.Leaves;
using Vacations.API.Models;

namespace Vacations.API.Contracts.Services.Leaves
{
    public interface IEmployeeLeavesService
    {
        Task<IEnumerable<EmployeeLeavesDateDTO>> GetEmployeeLeavesByDate(EmployeeLeavesDateDTO employeeLeavesDateDTO);
        Task<IEnumerable<EmployeeLeavesDateDTO>> GetEmployeeLeavesAllByDate(EmployeeLeavesAllDateDTO employeeLeavesAllDateDTO);

        Task<EmployeeAll> GetEmployeeLeavesAllDetails(EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDateDTO);
        Task<EmployeeInformationEntity> GetEmployeeByEmployeeCode(string employeeCode);
    }
}
