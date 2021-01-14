using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Contracts.Services.Leaves;
using Vacations.API.Entities.All;
using Vacations.API.Entities.Leaves;
using Vacations.API.Models;


namespace Vacations.API.Core.Services.Leaves
{
    public class EmployeeLeavesService : IEmployeeLeavesService
    {
        private readonly IEmployeeLeavesRepository _employeeLeavesRepository;
        private readonly ILogger<EmployeeLeavesService> _logger;
        private readonly IMapper _mapper;

        public EmployeeLeavesService(IEmployeeLeavesRepository employeeLeavesRepository,
            ILogger<EmployeeLeavesService> logger,
            IMapper mapper
            )
        {
            _employeeLeavesRepository = employeeLeavesRepository ?? throw new ArgumentNullException(nameof(employeeLeavesRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<EmployeeLeavesDateDTO>> GetEmployeeLeavesByDate(EmployeeLeavesDateDTO employeeLeavesDateDTO)
        {
            var employeeLeavesEntity = _mapper.Map<Entities.EmployeeLeavesEntity>(employeeLeavesDateDTO);

            var listEmployeeEntities = await _employeeLeavesRepository.GetEmployeeLeavesByDateAsync(employeeLeavesEntity);

            var employeeLeavesDTO = _mapper.Map<IEnumerable<Models.EmployeeLeavesDateDTO>>(listEmployeeEntities);

            return employeeLeavesDTO;
        }

        public async Task<IEnumerable<EmployeeLeavesDateDTO>> GetEmployeeLeavesAllByDate(EmployeeLeavesAllDateDTO employeeLeavesAllDateDTO)
        {
            try
            {
                 _logger.LogInformation("Performing Service operation GetEmployeeLeavesAllByDate");
                var employeeLeavesEntity = _mapper.Map<Entities.EmployeeLeavesEntity>(employeeLeavesAllDateDTO);
                _logger.LogInformation("Calling Repository operation GetEmployeeLeavesAllByDateAsync ");
                var listEmployeeEntities = await _employeeLeavesRepository.GetEmployeeLeavesAllByDateAsync(employeeLeavesEntity);
                _logger.LogDebug("Payload returned List of all employees in a given date range for a specific vacationTypeId");
                var employeeLeavesDateDTO = _mapper.Map<IEnumerable<Models.EmployeeLeavesDateDTO>>(listEmployeeEntities);
                return employeeLeavesDateDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee leaves data "+ ex);
                throw;
            }            
        }

        public async Task<EmployeeAll> GetEmployeeLeavesAllDetails(EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO)
        {
            try
            {
                _logger.LogInformation("Calling Repository operation GetEmployeeLeavesAllDetailsAsync ");
                var employeeAllDetailsEntities = await _employeeLeavesRepository.GetEmployeeLeavesAllDetailsAsync(employeeLeavesAllDetailsRequestDTO);
                _logger.LogDebug("Payload returned List of all employees in a given date range for a specific vacationTypeId");
                return employeeAllDetailsEntities;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee leaves data " + ex);
                throw;
            }
        }
        public async Task<EmployeeInformationEntity> GetEmployeeByEmployeeCode(string employeeCode)
        {
            var employeeInformationEntity = await _employeeLeavesRepository.GetEmployeeByEmployeeCodeAsync(employeeCode);
            return employeeInformationEntity;
        }
    }
}
