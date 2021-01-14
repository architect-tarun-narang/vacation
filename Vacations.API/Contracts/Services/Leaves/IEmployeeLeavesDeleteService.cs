using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Contracts.Services.Leaves
{
    public interface IEmployeeLeavesDeleteService
    {
        Task<bool> DeleteEmployeeLeaves(int id);
    }
}
