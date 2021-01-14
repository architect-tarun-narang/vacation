using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.WFH;

namespace Vacations.API.Contracts.Repositories.WFH
{
    public interface IEmployeeWFHRepository
    {
        Task<IEnumerable<EmployeeWFHEntity>> GetEmployeeWFHAsync(EmployeeWFHEntity employeeWFHEntity);
        Task<IEnumerable<EmployeeWFHEntity>> GetEmployeeWFHAllAsync(EmployeeWFHEntity employeeWFHEntity);
        Task<EmployeeWFHEntity> GetEmployeeWFHByPrimaryKeyId(int Id);
        Task<IEnumerable<EmployeeWFHEntity>> GetAllEmployeesByWFHIdAsync(EmployeeWFHEntity employeeWFHEntity);

    }
}
