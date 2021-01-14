using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities;


namespace Vacations.API.Contracts.Repositories.Leaves
{
    public interface IEmployeeLeavesDeleteRepository
    {
        Task<bool> DeleteEmployeeLeavesAsync(EmployeeLeavesEntity employeeLeavesEntity);
    }
}
