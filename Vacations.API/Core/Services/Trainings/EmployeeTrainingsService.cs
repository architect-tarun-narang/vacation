using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Entities.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Core.Services.Trainings
{
    public class EmployeeTrainingsService : IEmployeeTrainingsService
    {
        private readonly IEmployeeTrainingsRepository _employeeTrainingsRepository;
        private readonly ITrainingTypeRepository _trainingTypeRepository;
        private readonly ILogger<EmployeeTrainingsService> _logger;
        private readonly IMapper _mapper;

       public EmployeeTrainingsService(IEmployeeTrainingsRepository employeeTrainingsRepository,
           ITrainingTypeRepository trainingTypeRepository,
           ILogger<EmployeeTrainingsService> logger,
            IMapper mapper
            )
        {
            _employeeTrainingsRepository = employeeTrainingsRepository ?? throw new ArgumentNullException(nameof(employeeTrainingsRepository));
            _trainingTypeRepository = trainingTypeRepository ?? throw new ArgumentNullException(nameof(trainingTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetEmployeeTrainings(EmployeeTrainingsRequestDTO employeeTrainingsRequestDTO)
        {
           try
           {
               var employeeTrainingsEntity = _mapper.Map<EmployeeTrainingsEntity>(employeeTrainingsRequestDTO);
               var listEmployeeTrainingsEntities = await _employeeTrainingsRepository.GetEmployeeTrainingsAsync(employeeTrainingsEntity);
               var employeeTrainingsResponseDTO = _mapper.Map<IEnumerable<EmployeeTrainingsResponseDTO>>(listEmployeeTrainingsEntities);
               return employeeTrainingsResponseDTO;
           }
           catch(Exception ex) 
           {
                _logger.LogError("Payload returned List of all employees trainings in a given date range for a specific vacationTypeId" + employeeTrainingsRequestDTO);
                _logger.LogError("Exception occured while retrieving employee Trainings data " + ex);
               throw;
           }
        }

        public async Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetEmployeeTrainingsAll(EmployeeTrainingsAllRequestDTO employeeTrainingsAllRequestDTO)
        {
           try
           {
                _logger.LogInformation("Performing Service operation GetEmployeeTrainingsAll");
               var employeeTrainingsEntity = _mapper.Map<EmployeeTrainingsEntity>(employeeTrainingsAllRequestDTO);
               _logger.LogInformation("Calling Repository operation GetEmployeeTrainingsAllAsync ");
               var listEmployeeTrainingsEntities = await _employeeTrainingsRepository.GetEmployeeTrainingsAllAsync(employeeTrainingsEntity);
               _logger.LogDebug("Payload returned List of all employees trainings in a given date range for a specific vacationTypeId"+ listEmployeeTrainingsEntities);
               var employeeTrainingsResponseDTO = _mapper.Map<IEnumerable<EmployeeTrainingsResponseDTO>>(listEmployeeTrainingsEntities);
               return employeeTrainingsResponseDTO;
           }
           catch (Exception ex)
           {
               _logger.LogError("Exception occured while retrieving employee All Trainings data "+ ex);
               throw;
           }            
        }
        public async Task<IEnumerable<EmployeeTrainingsResponseDTO>> GetAllEmployeeByTrainingsId(EmployeeTrainingsIDRequestDTO employeeTrainingsIDRequestDTO)
        {
            try
            {
                _logger.LogInformation("Performing Service operation GetAllEmployeeByTrainingsId");
                var employeeTrainingsEntity = _mapper.Map<EmployeeTrainingsEntity>(employeeTrainingsIDRequestDTO);
                _logger.LogInformation("Calling Repository operation GetEmployeeTrainingsAllAsync ");
                var listAllEmployeeByTrainingsIDEntities = await _employeeTrainingsRepository.GetAllEmployeesByTrainingsIdAsync(employeeTrainingsEntity);
                _logger.LogDebug("Payload returned List of all employees by training ID in a given date range for a specific Training ID = " + listAllEmployeeByTrainingsIDEntities);
                var employeeTrainingsResponseDTO = _mapper.Map<IEnumerable<EmployeeTrainingsResponseDTO>>(listAllEmployeeByTrainingsIDEntities);
                return employeeTrainingsResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee All Trainings data " + ex);
                throw;
            }
        }

        public async Task<IEnumerable<TrainingTypeResponseDTO>> GetTrainingTypes()
        {
            try
            {
                var trainingTypeEntity = await _trainingTypeRepository.GetTrainingTypeAsync();
                var trainingTypeResponseDTO = _mapper.Map<IEnumerable<TrainingTypeResponseDTO>>(trainingTypeEntity);
                return trainingTypeResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while retrieving employee WFH Days data " + ex);
                throw;
            }
        }


    }
}
