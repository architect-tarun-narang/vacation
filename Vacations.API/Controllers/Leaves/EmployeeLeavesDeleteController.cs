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
    [Route("/api/vacation/[controller]/{id}")]
    public class EmployeeLeavesDeleteController: ControllerBase
    {
        private readonly IEmployeeLeavesDeleteService _employeeLeavesDeleteService;
        private readonly ILogger<EmployeeLeavesDeleteController> _logger;

        public EmployeeLeavesDeleteController(IEmployeeLeavesDeleteService employeeLeavesDeleteService,
            ILogger<EmployeeLeavesDeleteController> logger)
        {
            _employeeLeavesDeleteService = employeeLeavesDeleteService ?? throw new ArgumentNullException(nameof(employeeLeavesDeleteService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeLeaves(int id)
        {
            _logger.LogInformation($"In a delete employee leaves control to delete employee details having id = {id}");
            try
            {
                var statusInBoolean = await _employeeLeavesDeleteService.DeleteEmployeeLeaves(id);
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
