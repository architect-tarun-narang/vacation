using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.API.Entities;
using Vacations.API.Entities.Leaves;
using Vacations.API.Models;
using Vacations.API.Entities.All;
namespace Vacations.API.Contracts.Repositories.Leaves
{
    public interface IEmployeeLeavesRepository
    {
        Task<IEnumerable<EmployeeLeavesEntity>> GetEmployeeLeavesByDateAsync(EmployeeLeavesEntity employeeLeavesEntity);
        Task<IEnumerable<EmployeeLeavesEntity>> GetEmployeeLeavesAllByDateAsync(EmployeeLeavesEntity employeeLeavesEntity);
        Task<EmployeeAll> GetEmployeeLeavesAllDetailsAsync(EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO);
        Task<EmployeeLeavesEntity> GetEmployeeLeavesByPrimaryKeyId(int Id);
        Task<EmployeeInformationEntity> GetEmployeeByEmployeeCodeAsync(string employeeCode);
    }
}
