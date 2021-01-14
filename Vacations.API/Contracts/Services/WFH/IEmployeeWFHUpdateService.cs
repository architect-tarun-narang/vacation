using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Models.WFH;

namespace Vacations.API.Contracts.Services.WFH
{
    public interface IEmployeeWFHUpdateService
    {
        Task<bool> UpdateEmployeeWFH(EmployeeWFHCreationDTO employeeWFHCreationDTO );

    }
}
