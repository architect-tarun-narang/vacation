using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Entities.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Core.Services.Trainings
{
    public class EmployeeTrainingsAddService: IEmployeeTrainingsAddService
    {
        private readonly IEmployeeTrainingsAddRepository _employeeTrainingsAddRepository;
        private readonly IEmployeeTrainingsRepository _employeeTrainingsRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EmployeeTrainingsAddService(IEmployeeTrainingsAddRepository employeeTrainingsAddRepository,
            IEmployeeTrainingsRepository employeeTrainingsRepository,
            ILogger<EmployeeTrainingsAddService> logger,
            IMapper mapper)
        {
            _employeeTrainingsAddRepository = employeeTrainingsAddRepository ?? throw new ArgumentNullException(nameof(employeeTrainingsAddRepository));
            _employeeTrainingsRepository = employeeTrainingsRepository ?? throw new ArgumentNullException(nameof(employeeTrainingsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<EmployeeTrainingsResponseDTO> AddEmployeeTrainings(EmployeeTrainingsCreationDTO employeeTrainingsCreationDTO) 
        {
            try
            {
                _logger.LogDebug("Payload employeeTrainingsCreationDTO = "+ employeeTrainingsCreationDTO);
                var employeeTrainingsEntity = _mapper.Map<EmployeeTrainingsEntity>(employeeTrainingsCreationDTO);
                var newTrainingRecordCreatedID = await _employeeTrainingsAddRepository.AddEmployeeTrainings(employeeTrainingsEntity);
                var employeeTrainingsEntityAdded = await _employeeTrainingsRepository.GetEmployeeTrainingsByPrimaryKeyId(newTrainingRecordCreatedID);
                var employeeTrainingsResponseDTO = _mapper.Map<EmployeeTrainingsResponseDTO>(employeeTrainingsEntityAdded);
                return employeeTrainingsResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while calling AddEmployeeTrainings method" + ex);
                throw;

            }

        }
    }
}
