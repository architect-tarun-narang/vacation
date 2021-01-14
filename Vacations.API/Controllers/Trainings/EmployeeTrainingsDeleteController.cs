using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Models;

namespace Vacations.API.Controllers.Trainings
{
    [ApiController]
    [Route("/api/vacation/[controller]/{id}")]
    public class EmployeeTrainingsDeleteController : ControllerBase
    {
        private readonly IEmployeeTrainingsDeleteService _employeeTrainingsDeleteService;
        private readonly ILogger<EmployeeTrainingsDeleteController> _logger;

        public EmployeeTrainingsDeleteController(IEmployeeTrainingsDeleteService employeeTrainingsDeleteService,
            ILogger<EmployeeTrainingsDeleteController> logger)
        {
            _employeeTrainingsDeleteService = employeeTrainingsDeleteService ?? throw new ArgumentNullException(nameof(employeeTrainingsDeleteService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeTrainings(int id)
        {
            _logger.LogInformation($"In a delete employee leaves control to delete employee details having id = {id}");
            try
            {
                var statusInBoolean = await _employeeTrainingsDeleteService.DeleteEmployeeTrainings(id);
                return Ok(statusInBoolean);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured in a controller while calling delete employee leaves with id {id}" + ex);
                throw;
            }
        }
    }
}
