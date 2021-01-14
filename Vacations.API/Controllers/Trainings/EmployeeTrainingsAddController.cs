using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Controllers.Trainings
{
    [ApiController]
    [Route("/api/vacation/[controller]")]
    public class EmployeeTrainingsAddController : ControllerBase
    {
        private readonly IEmployeeTrainingsAddService _employeeTrainingsAddService;
        private readonly ILogger _logger;

        public EmployeeTrainingsAddController(IEmployeeTrainingsAddService employeeTrainingsAddService, 
            ILogger<EmployeeTrainingsAddController> logger)
        {
            _employeeTrainingsAddService = employeeTrainingsAddService ?? throw new ArgumentNullException(nameof(employeeTrainingsAddService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        //[Route("addEmployeeLeaves")]
        public async Task<IActionResult> AddEmployeeTraining([FromBody] EmployeeTrainingsCreationDTO employeeTrainingCreationDTO)
        {
            _logger.LogDebug("Employee Training DTO = " + employeeTrainingCreationDTO);

            if (employeeTrainingCreationDTO.VacationTypeId < 1)
            {
                ModelState.AddModelError(
                    "Vacation Type", "It can not be less than or equal to zero.");
            }

            if (employeeTrainingCreationDTO == null)
            {
                return NotFound();
            }
            var employeeTrainingDTOAdded = await _employeeTrainingsAddService.AddEmployeeTrainings(employeeTrainingCreationDTO);
             return Ok(employeeTrainingDTOAdded);
        }
    }
}
