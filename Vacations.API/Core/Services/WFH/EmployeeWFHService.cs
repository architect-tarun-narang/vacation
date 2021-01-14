using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Entities.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Core.Services.WFH
{
    public class EmployeeWFHService : IEmployeeWFHService
    {
        private readonly IEmployeeWFHRepository _employeeWFHRepository;
        private readonly IEmployeeWFHDaysRepository _employeeWFHDaysRepository;
        private readonly ILogger<EmployeeWFHService> _logger;
        private readonly IMapper _mapper;

        public EmployeeWFHService(IEmployeeWFHRepository employeeWFHRepository,
            IEmployeeWFHDaysRepository employeeWFHDaysRepository,
            ILogger<EmployeeWFHService> logger,
             IMapper mapper
             )
        {
            _employeeWFHRepository = employeeWFHRepository ?? throw new ArgumentNullException(nameof(employeeWFHRepository));
            _employeeWFHDaysRepository = employeeWFHDaysRepository ?? throw new ArgumentNullException(nameof(employeeWFHDaysRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EmployeeWFHResponseDTO>> GetEmployeeWFH(EmployeeWFHRequestDTO employeeWFHRequestDTO)
        {
            try
            {
                _logger.LogInformation("Performing Service operation GetEmployeeWFH");
                var employeeWFHEntity = _mapper.Map<EmployeeWFHEntity>(employeeWFHRequestDTO);
                _logger.LogInformation("Calling Repository operation GetEmployeeWFHAsync ");
                var listEmployeeWFHEntities = await _employeeWFHRepository.GetEmployeeWFHAsync(employeeWFHEntity);
                _logger.LogDebug("Payload returned List of all employees WFH in a given date range for a specific vacationTypeId" + listEmployeeWFHEntities);
                var employeeWFHResponseDTO = _mapper.Map<IEnumerable<EmployeeWFHResponseDTO>>(listEmployeeWFHEntities);
                return employeeWFHResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee WFH data " + ex);
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeWFHResponseDTO>> GetEmployeeWFHAll(EmployeeWFHAllRequestDTO employeeWFHAllRequestDTO)
        {
            try
            {
                _logger.LogInformation("Performing Service operation GetEmployeeWFHAll");
                var employeeWFHEntity = _mapper.Map<EmployeeWFHEntity>(employeeWFHAllRequestDTO);
                _logger.LogInformation("Calling Repository operation GetEmployeeWFHAllAsync ");
                var listEmployeeWFHEntities = await _employeeWFHRepository.GetEmployeeWFHAllAsync(employeeWFHEntity);
                _logger.LogDebug("Payload returned List of all employees WFH in a given date range for a specific vacationTypeId" + listEmployeeWFHEntities);
                var employeeWFHResponseDTO = _mapper.Map<IEnumerable<EmployeeWFHResponseDTO>>(listEmployeeWFHEntities);
                return employeeWFHResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee All WFH data " + ex);
                throw;
            }
        }
        public async Task<IEnumerable<EmployeeWFHResponseDTO>> GetAllEmployeeByWFHId(EmployeeWFHIDRequestDTO employeeWFHIDRequestDTO)
        {
            try
            {
                _logger.LogInformation("Performing Service operation GetAllEmployeeByWFHId");
                var employeeWFHEntity = _mapper.Map<EmployeeWFHEntity>(employeeWFHIDRequestDTO);
                _logger.LogInformation("Calling Repository operation GetEmployeeWFHAllAsync ");
                var listAllEmployeeByWFHIDEntities = await _employeeWFHRepository.GetAllEmployeesByWFHIdAsync(employeeWFHEntity);
                _logger.LogDebug("Payload returned List of all employees by WFH ID in a given date range for a specific WFH ID = " + listAllEmployeeByWFHIDEntities);
                var employeeWFHResponseDTO = _mapper.Map<IEnumerable<EmployeeWFHResponseDTO>>(listAllEmployeeByWFHIDEntities);
                return employeeWFHResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee All WFH data " + ex);
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeWFHDaysResponseDTO>> GetWFHDays()
        {
            try
            {
                var employeeWFHDaysResponseEntity = await _employeeWFHDaysRepository.GetWFHDaysAsync();
                var employeeWFHDaysResponseDTO = _mapper.Map<IEnumerable<EmployeeWFHDaysResponseDTO>>(employeeWFHDaysResponseEntity);
                return employeeWFHDaysResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee WFH Days data " + ex);
                throw;
            }
        }
    }
 }