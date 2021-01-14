using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Entities.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Core.Services.WFH
{
    public class EmployeeWFHDeleteService : IEmployeeWFHDeleteService
    {
        private readonly IEmployeeWFHDeleteRepository _employeeWFHDeleteRepository;
        private readonly IEmployeeWFHRepository _employeeWFHRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeWFHDeleteService(IEmployeeWFHDeleteRepository employeeWFHDeleteRepository,
            IEmployeeWFHRepository employeeWFHRepository,
            IMapper mapper,
            ILogger<EmployeeWFHDeleteService> logger)
        {
            _employeeWFHDeleteRepository = employeeWFHDeleteRepository ?? throw new ArgumentNullException(nameof(employeeWFHDeleteRepository));
            _employeeWFHRepository = employeeWFHRepository ?? throw new ArgumentNullException(nameof(employeeWFHRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> DeleteEmployeeWFH(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("Delete Employee WFH operation requested");
            try
            {
                return await _employeeWFHDeleteRepository.DeleteEmployeeWFHAsync(employeeWFHEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while calling delete WFH operation  " + ex);
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeWFH(int id)
        {
            _logger.LogInformation("Delete Employee WFH operation requested for Id - " + id);
            var employeeWFHEntity = await GetEmployeeWFHEntity(id);
            try
            {
                return await _employeeWFHDeleteRepository.DeleteEmployeeWFHAsync(employeeWFHEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while calling delete WFH operation for record id = {id} --> " + ex);
                throw;
            }
        }

        private async Task<EmployeeWFHEntity> GetEmployeeWFHEntity(int id)
        {
            try
            {
                EmployeeWFHEntity employeeWFHEntity = await _employeeWFHRepository.GetEmployeeWFHByPrimaryKeyId(id);
                if (employeeWFHEntity == null)
                {
                    _logger.LogError("Record Not found and Null is returned whilst calling GetEmployeeWFHByPrimaryKeyId method from DeleteEmployeeTrainings having id - " + id);
                }
                return employeeWFHEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured whilst calling a GetEmployeeWFHByPrimaryKeyId operation from DeleteEmployeeWFH for id = {id} -->" + ex);
                throw;
            }
        }
    }
}
