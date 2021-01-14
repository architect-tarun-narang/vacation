using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Models.WFH;

namespace Vacations.API.Contracts.Services.WFH
{
    public interface IEmployeeWFHService
    {
        Task<IEnumerable<EmployeeWFHResponseDTO>> GetEmployeeWFH(EmployeeWFHRequestDTO employeeWFHRequestDTO);
        Task<IEnumerable<EmployeeWFHResponseDTO>> GetEmployeeWFHAll(EmployeeWFHAllRequestDTO employeeWFHAllRequestDTO);
        Task<IEnumerable<EmployeeWFHResponseDTO>> GetAllEmployeeByWFHId(EmployeeWFHIDRequestDTO employeeWFHIDRequestDTO);
        Task<IEnumerable<EmployeeWFHDaysResponseDTO>> GetWFHDays();

    }
}
