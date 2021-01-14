using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.Leaves;
using Vacations.API.Models;

namespace Vacations.API.Controllers.Leaves
{
    [ApiController]
    [Route("/api/vacation/[controller]")]
    public class EmployeeLeavesAddController : ControllerBase
    {
        private readonly IEmployeeLeavesAddService _employeeLeavesAddService;
        private readonly ILogger _logger;

        public EmployeeLeavesAddController(IEmployeeLeavesAddService employeeLeavesAddService, ILogger<EmployeeLeavesAddController> logger)
        {
            _employeeLeavesAddService = employeeLeavesAddService ?? throw new ArgumentNullException(nameof(employeeLeavesAddService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        //[Route("addEmployeeLeaves")]
        public async Task<IActionResult> AddEmployeeLeaves([FromBody] EmployeeLeavesCreationDTO employeeLeavesCreationDTO)
        {
            _logger.LogDebug("Employee Leaves DTO = " + employeeLeavesCreationDTO);

            if (employeeLeavesCreationDTO.VacationTypeId < 1)
            {
                ModelState.AddModelError(
                    "Vacation Type", "It can not be less than or equal to zero.");
            }

            if (employeeLeavesCreationDTO == null)
            {
                return NotFound();
            }
            var employeeLeavesDateDTOAdded = await _employeeLeavesAddService.AddEmployeeLeaves(employeeLeavesCreationDTO);
             return Ok(employeeLeavesDateDTOAdded);
        }
    }
}
