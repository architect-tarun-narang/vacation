using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Entities.WFH;
using Vacations.API.Models;

namespace Vacations.API.Controllers.WFH
{
    [ApiController]
    [Route("/api/vacation/[controller]/{employeeID}/{vacationTypeID}/{wfhDaysID}")]
    public class EmployeeWFHDeleteController : ControllerBase
    {
        private readonly IEmployeeWFHDeleteService _employeeWFHDeleteService;
        private readonly ILogger<EmployeeWFHDeleteController> _logger;

        public EmployeeWFHDeleteController(IEmployeeWFHDeleteService employeeWFHDeleteService,
            ILogger<EmployeeWFHDeleteController> logger)
        {
            _employeeWFHDeleteService = employeeWFHDeleteService ?? throw new ArgumentNullException(nameof(employeeWFHDeleteService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeWFH(string employeeId, int vacationTypeId,int wfhDaysID)
        {
            _logger.LogInformation($"In a delete employee WFH control to delete WFH details");
            try
            {
                EmployeeWFHEntity employeeWFHEntity = new EmployeeWFHEntity();
                employeeWFHEntity.EmployeeId = employeeId;
                employeeWFHEntity.VacationTypeId = vacationTypeId;
                employeeWFHEntity.WFHDaysId = wfhDaysID;
                var statusInBoolean = await _employeeWFHDeleteService.DeleteEmployeeWFH(employeeWFHEntity);
                return Ok(statusInBoolean);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in a controller while calling delete WFH leaves" + ex);
                throw;
            }
        }
    }
}
