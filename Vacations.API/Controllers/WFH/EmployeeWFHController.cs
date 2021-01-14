using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Controllers.WFH
{
    [ApiController]
    [Route("api/vacation/[controller]")]
    public class EmployeeWFHController : ControllerBase
    {
        private readonly IEmployeeWFHService _employeeWFHService;
        private readonly ILogger<EmployeeWFHController> _logger;

        public EmployeeWFHController(IEmployeeWFHService employeeWFHService,
            ILogger<EmployeeWFHController> logger)
        {
            _employeeWFHService = employeeWFHService ?? throw new ArgumentNullException(nameof(employeeWFHService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet(Name = "GetEmployeeWFH")]
        [Route("getEmployeeWFH/{employeeId}/{vacationTypeId}")]
        public async Task<IActionResult> GetEmployeeWFH(string employeeId, int vacationTypeId)
        {
            _logger.LogInformation($"Performing GetEmployeeWFH operation having values employeeId={employeeId} + " +
                $"vacationTypeId={vacationTypeId}");
            EmployeeWFHRequestDTO employeeWFHRequestDTO = new EmployeeWFHRequestDTO();
            employeeWFHRequestDTO.EmployeeId = employeeId;
            employeeWFHRequestDTO.VacationTypeId = vacationTypeId;
            _logger.LogDebug("payload employeeWFHRequestDTO=" + employeeWFHRequestDTO);
            var employeeWFHResponseDTO = await _employeeWFHService.GetEmployeeWFH(employeeWFHRequestDTO);
            return Ok(employeeWFHResponseDTO);
        }

        [HttpGet(Name = "GetEmployeeWFHAll")]
        [Route("getEmployeeWFHAll/{vacationTypeId}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeeWFHAll(int vacationTypeId,
             DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeeWFHAll operation having values" +
                                    $"vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");

            EmployeeWFHAllRequestDTO employeeWFHAllRequestDTO = new EmployeeWFHAllRequestDTO();
            employeeWFHAllRequestDTO.VacationTypeId = vacationTypeId;
            _logger.LogDebug("Payload employeeWFHAllRequestDTO =" + employeeWFHAllRequestDTO);
            var employeeWFHResponseDTO = await _employeeWFHService.GetEmployeeWFHAll(employeeWFHAllRequestDTO);
            return Ok(employeeWFHResponseDTO);
        }

        [HttpGet(Name = "GetAllEmployeesByWFHId")]
        [Route("getAllEmployeesByWFHId/{WFHId}/{vacationTypeId}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeesByWFHId(int WFHId, int vacationTypeId,
             DateTime dateFrom, DateTime dateTo)
        {
            _logger.LogInformation($"Performing GetEmployeesByWFHId operation having values" +
                                    $"WFHId = {WFHId} + vacationTypeId={vacationTypeId}");

            EmployeeWFHIDRequestDTO employeeWFHIdRequestDTO = new EmployeeWFHIDRequestDTO();
            employeeWFHIdRequestDTO.WFHDaysId = WFHId;
            employeeWFHIdRequestDTO.VacationTypeId = vacationTypeId;
            _logger.LogDebug("Payload GetEmployeesByWFHId =" + employeeWFHIdRequestDTO);
            var employeeWFHResponseDTO = await _employeeWFHService.GetAllEmployeeByWFHId(employeeWFHIdRequestDTO);
            return Ok(employeeWFHResponseDTO);
        }

        [HttpGet(Name = "GetWFHDays")]
        [Route("getWFHDays")]
        public async Task<IActionResult> GetWFHDays()
        {
            var employeeWFHDaysResponseDTO = await _employeeWFHService.GetWFHDays();
            return Ok(employeeWFHDaysResponseDTO);
        }
    }
}
