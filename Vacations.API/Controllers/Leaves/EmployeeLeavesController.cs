using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.Leaves;
using Vacations.API.Models;

namespace Vacations.API.Controllers.Leaves
{
    [Authorize]
    [ApiController]
    [Route("api/vacation/[controller]")]
    public class EmployeeLeavesController : ControllerBase
    {
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        private readonly IEmployeeLeavesService _employeeLeavesService;
        private readonly ILogger<EmployeeLeavesController> _logger;

        public EmployeeLeavesController(IEmployeeLeavesService employeeLeavesService,
            ILogger<EmployeeLeavesController> logger)
        {
            _employeeLeavesService = employeeLeavesService ?? throw new ArgumentNullException(nameof(employeeLeavesService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("loggedInUser")]
        [Route("getLoggedInUser")]
        [Authorize]
        public async Task<IActionResult> GetLoggedInUser(string userCode)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            // TODO: Remove parameter [userCode] before deploying it to production. This is kept for testing purpose so that test by impersonating user
            var employeeCode = userCode ?? HttpContext.User.Identity.Name.Replace("BAIN\\", "");
            var employee = await _employeeLeavesService.GetEmployeeByEmployeeCode(employeeCode);
            return Ok(employee);
        }

        [HttpGet(Name = "GetEmployeeLeavesByDate")]
        [Route("getEmployeeLeavesByDate/{employeeId}/{vacationTypeId}/{dateFrom}/{dateTo}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeeLeavesByDate(string employeeId, int vacationTypeId,
            DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeeLeavesByDate operation having values employeeId={employeeId} + " +
                $"vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");
            EmployeeLeavesDateDTO employeeLeavesDateDTO = new EmployeeLeavesDateDTO();            
            employeeLeavesDateDTO.EmployeeId = employeeId;
            employeeLeavesDateDTO.VacationTypeId = vacationTypeId;
            employeeLeavesDateDTO.DateFrom = dateFrom;
            employeeLeavesDateDTO.DateTo = dateTo;
            _logger.LogDebug("payload EmployeeLeavesDateDTO=" + employeeLeavesDateDTO);
            var employeeLeavesDTO = await _employeeLeavesService.GetEmployeeLeavesByDate(employeeLeavesDateDTO);
            return Ok(employeeLeavesDTO);
        }

        [HttpGet(Name = "GetEmployeeLeavesAllByDate")]
        [Route("getEmployeeLeavesAllByDate/{vacationTypeId}/{dateFrom}/{dateTo}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeeLeavesAllByDate(int vacationTypeId,
             DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeeLeavesByDate operation having values" +
                                    $"vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");

            EmployeeLeavesAllDateDTO employeeLeavesAllDateDTO = new EmployeeLeavesAllDateDTO();
            employeeLeavesAllDateDTO.VacationTypeId = vacationTypeId;
            employeeLeavesAllDateDTO.DateFrom = dateFrom;
            employeeLeavesAllDateDTO.DateTo = dateTo;
            _logger.LogDebug("Payload employeeLeavesAllDateDTO =" + employeeLeavesAllDateDTO);
            var employeeLeavesDateDTO = await _employeeLeavesService.GetEmployeeLeavesAllByDate(employeeLeavesAllDateDTO);
            return Ok(employeeLeavesDateDTO);
        }

        [HttpGet(Name = "GetEmployeeLeavesAllDetailsById")]
        [Route("getEmployeeLeavesAllDetailsById/{employeeId}/{dateFrom}/{dateTo}")]        
        //[Route("getEmployeeLeavesAllDetails")]
        //int employeeId,        DateTime dateFrom, DateTime dateTo
        public async Task<IActionResult> GetEmployeeLeavesAllDetailsById(string employeeId, DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeeLeavesAllDetailsById operation having values employeeId={employeeId} + " +
                $"+ dateFrom={dateFrom} + dateTo={dateTo}");
            EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO = new EmployeeLeavesAllDetailsRequestDTO();
            employeeLeavesAllDetailsRequestDTO.EmployeeId = employeeId;
            employeeLeavesAllDetailsRequestDTO.DateFrom = dateFrom;
            employeeLeavesAllDetailsRequestDTO.DateTo = dateTo;
            _logger.LogDebug("payload employeeLeavesAllDetailsRequestDTO =" + employeeLeavesAllDetailsRequestDTO);
            var employeeLeavesDTO = await _employeeLeavesService.GetEmployeeLeavesAllDetails(employeeLeavesAllDetailsRequestDTO);
            return Ok(employeeLeavesDTO);
        }

        [HttpGet(Name = "GetEmployeeLeavesAllDetails")]
        [Route("getEmployeeLeavesAllDetails/{dateFrom}/{dateTo}")]
        //[Route("getEmployeeLeavesAllDetails")]
        //int employeeId,        DateTime dateFrom, DateTime dateTo
        public async Task<IActionResult> GetEmployeeLeavesAllDetails(DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeeLeavesAllDetails operation having values " +
                $"+ dateFrom={dateFrom} + dateTo={dateTo}");
            EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO = new EmployeeLeavesAllDetailsRequestDTO();
            employeeLeavesAllDetailsRequestDTO.DateFrom = dateFrom;
            employeeLeavesAllDetailsRequestDTO.DateTo = dateTo;
            _logger.LogDebug("payload employeeLeavesAllDetailsRequestDTO =" + employeeLeavesAllDetailsRequestDTO);
            var employeeLeavesDTO = await _employeeLeavesService.GetEmployeeLeavesAllDetails(employeeLeavesAllDetailsRequestDTO);
            return Ok(employeeLeavesDTO);
        }


    }
}
