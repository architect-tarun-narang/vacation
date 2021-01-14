using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Controllers.WFH
{
    [ApiController]
    [Route("/api/vacation/[controller]")]
    public class EmployeeWFHUpdateController : ControllerBase
    {
        private readonly IEmployeeWFHUpdateService _employeeWFHUpdateService;
        private readonly ILogger _logger;

        public EmployeeWFHUpdateController(IEmployeeWFHUpdateService employeeWFHUpdateService, 
            ILogger<EmployeeWFHUpdateController> logger)
        {
            _employeeWFHUpdateService = employeeWFHUpdateService ?? throw new ArgumentNullException(nameof(employeeWFHUpdateService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        //[Route("addEmployeeWFH")]
        public async Task<IActionResult> UpdateEmployeeWFH([FromBody] EmployeeWFHCreationDTO employeeWFHCreationDTO)
        {
            _logger.LogDebug("Employee WFH DTO = " + employeeWFHCreationDTO);

            if (employeeWFHCreationDTO.VacationTypeId < 1)
            {
                ModelState.AddModelError(
                    "Vacation Type", "It can not be less than or equal to zero.");
            }

            if (employeeWFHCreationDTO == null)
            {
                return NotFound();
            }
            var employeeWFHDTOUpdated = await _employeeWFHUpdateService.UpdateEmployeeWFH(employeeWFHCreationDTO);
             return Ok(employeeWFHDTOUpdated);
        }
    }
}
