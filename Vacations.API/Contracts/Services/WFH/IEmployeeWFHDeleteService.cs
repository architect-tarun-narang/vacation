using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.WFH;

namespace Vacations.API.Contracts.Services.WFH
{
    public interface IEmployeeWFHDeleteService
    {
        Task<bool> DeleteEmployeeWFH(int id);
        Task<bool> DeleteEmployeeWFH(EmployeeWFHEntity employeeWFHEntity);
    }
}
