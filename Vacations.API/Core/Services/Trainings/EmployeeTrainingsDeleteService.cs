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
    public class EmployeeTrainingsDeleteService : IEmployeeTrainingsDeleteService
    {
        private readonly IEmployeeTrainingsDeleteRepository _employeeTrainingsDeleteRepository;
        private readonly IEmployeeTrainingsRepository _employeeTrainingsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeTrainingsDeleteService(IEmployeeTrainingsDeleteRepository employeeTrainingsDeleteRepository,
            IEmployeeTrainingsRepository employeeTrainingsRepository,
            IMapper mapper,
            ILogger<EmployeeTrainingsDeleteService> logger)
        {
            _employeeTrainingsDeleteRepository = employeeTrainingsDeleteRepository ?? throw new ArgumentNullException(nameof(employeeTrainingsDeleteRepository));
            _employeeTrainingsRepository = employeeTrainingsRepository ?? throw new ArgumentNullException(nameof(employeeTrainingsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<bool> DeleteEmployeeTrainings(int id)
        {
            _logger.LogInformation("Delete Employee Trainings operation requested for Id - " + id);
            var employeeTrainingEntity = await GetEmployeeTrainingsEntity(id);
            try
            {
                return await _employeeTrainingsDeleteRepository.DeleteEmployeeTrainingsAsync(employeeTrainingEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while calling delete training operation for record id = {id} --> " + ex);
                throw;
            }
        }

        private async Task<EmployeeTrainingsEntity> GetEmployeeTrainingsEntity(int id)
        {
            try
            {
                EmployeeTrainingsEntity employeeTrainingsEntity = await _employeeTrainingsRepository.GetEmployeeTrainingsByPrimaryKeyId(id);
                if (employeeTrainingsEntity == null)
                {
                    _logger.LogError("Record Not found and Null is returned whilst calling GetEmployeeTrainingsByPrimaryKeyId method from DeleteEmployeeTrainings having id - " + id);
                }
                return employeeTrainingsEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured whilst calling a GetEmployeeTrainingsByPrimaryKeyId operation from DeleteEmployeeTrainings for id = {id} -->" + ex);
                throw;
            }
        }
    }
}
