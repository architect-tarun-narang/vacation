using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Controllers.Trainings
{
    [Authorize]
    [ApiController]
    [Route("api/vacation/[controller]")]
    public class EmployeeTrainingsController : ControllerBase
    {
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        private readonly IEmployeeTrainingsService _employeeTrainingsService;
        private readonly ILogger<EmployeeTrainingsController> _logger;

        public EmployeeTrainingsController(IEmployeeTrainingsService employeeTrainingsService,
            ILogger<EmployeeTrainingsController> logger)
        {
            _employeeTrainingsService = employeeTrainingsService ?? throw new ArgumentNullException(nameof(employeeTrainingsService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet(Name = "GetEmployeeTrainings")]
        [Route("getEmployeeTrainings/{employeeId}/{vacationTypeId}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetEmployeeTrainings(string employeeId, int vacationTypeId,
            DateTime dateFrom, DateTime dateTo)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogInformation($"Performing GetEmployeeTrainings operation having values employeeId={employeeId} + " +
                $"vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");
            EmployeeTrainingsRequestDTO employeeTrainingsRequestDTO = new EmployeeTrainingsRequestDTO();
            employeeTrainingsRequestDTO.EmployeeId = employeeId;
            employeeTrainingsRequestDTO.VacationTypeId = vacationTypeId;
            employeeTrainingsRequestDTO.DateFrom = dateFrom;
            employeeTrainingsRequestDTO.DateTo = dateTo;            
            _logger.LogDebug("payload employeeTrainingsRequestDTO=" + employeeTrainingsRequestDTO);
            var employeeTrainingsResponseDTO = await _employeeTrainingsService.GetEmployeeTrainings(employeeTrainingsRequestDTO);
            return Ok(employeeTrainingsResponseDTO);
        }

        [HttpGet(Name = "GetEmployeeTrainingsAll")]
        [Route("getEmployeeTrainingsAll/{vacationTypeId}/{dateFrom}/{dateTo}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeeTrainingsAll(int vacationTypeId,
             DateTime dateFrom, DateTime dateTo)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogInformation($"Performing GetEmployeeTrainingsAll operation having values" +
                                    $"vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");

            EmployeeTrainingsAllRequestDTO employeeTrainingsAllRequestDTO = new EmployeeTrainingsAllRequestDTO();
            employeeTrainingsAllRequestDTO.VacationTypeId = vacationTypeId;
            employeeTrainingsAllRequestDTO.DateFrom = dateFrom;
            employeeTrainingsAllRequestDTO.DateTo = dateTo;
            _logger.LogDebug("Payload employeeTrainingsAllRequestDTO =" + employeeTrainingsAllRequestDTO);
            var employeeTrainingResponseDTO = await _employeeTrainingsService.GetEmployeeTrainingsAll(employeeTrainingsAllRequestDTO);
            return Ok(employeeTrainingResponseDTO);
        }

        [HttpGet(Name = "GetAllEmployeesByTrainingsId")]
        [Route("getAllEmployeesByTrainingsId/{trainingId}/{vacationTypeId}/{dateFrom}/{dateTo}")]
        //Append [FromQuery] in signature below in case the data is sent differently using Querystring method i.e ?employeeId=1&Vacation..
        public async Task<IActionResult> GetEmployeesByTrainingsId(int trainingId, int vacationTypeId,
             DateTime dateFrom, DateTime dateTo)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogInformation($"Performing GetEmployeesByTrainingsId operation having values" +
                                    $"TrainingId = {trainingId} + vacationTypeId={vacationTypeId} + dateFrom={dateFrom} + dateTo={dateTo}");

            EmployeeTrainingsIDRequestDTO employeeTrainingsIdRequestDTO = new EmployeeTrainingsIDRequestDTO();
            employeeTrainingsIdRequestDTO.TrainingId = trainingId;
            employeeTrainingsIdRequestDTO.VacationTypeId = vacationTypeId;
            employeeTrainingsIdRequestDTO.DateFrom = dateFrom;
            employeeTrainingsIdRequestDTO.DateTo = dateTo;
            _logger.LogDebug("Payload GetEmployeesByTrainingsId =" + employeeTrainingsIdRequestDTO);
            var employeeTrainingResponseDTO = await _employeeTrainingsService.GetAllEmployeeByTrainingsId(employeeTrainingsIdRequestDTO);
            return Ok(employeeTrainingResponseDTO);
        }

        [HttpGet(Name = "GetTrainingTypes")]
        [Route("GetTrainingTypes")]
        public async Task<IActionResult> GetTrainingTypes()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            _logger.LogInformation($"Performing operation GetTrainingTypes()");
            var trainingTypeResponseDTO = await _employeeTrainingsService.GetTrainingTypes();
            return Ok(trainingTypeResponseDTO);
        }



    }
}
