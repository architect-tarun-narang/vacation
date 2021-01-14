using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Contracts.Services.Leaves;
using Vacations.API.Entities;
using Vacations.API.Models;

namespace Vacations.API.Core.Services.Leaves
{
    public class EmployeeLeavesDeleteService: IEmployeeLeavesDeleteService
    {
        private readonly IEmployeeLeavesDeleteRepository _employeeLeavesDeleteRepository;
        private readonly IEmployeeLeavesRepository _employeeLeavesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeLeavesDeleteService(IEmployeeLeavesDeleteRepository employeeLeavesDeleteRepository,
            IEmployeeLeavesRepository employeeLeavesRepository,
            IMapper mapper,
            ILogger<EmployeeLeavesDeleteService> logger)
        {
            _employeeLeavesDeleteRepository = employeeLeavesDeleteRepository ?? throw new ArgumentNullException(nameof(employeeLeavesDeleteRepository));
            _employeeLeavesRepository = employeeLeavesRepository ?? throw new ArgumentNullException(nameof(employeeLeavesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<bool> DeleteEmployeeLeaves(int id)
        {
            _logger.LogInformation("Delete Employee Leaves operation requested for Id - " + id);
            var employeeLeavesEntity = await GetEmployeeLeavesEntity(id);
            try
            {
                return await _employeeLeavesDeleteRepository.DeleteEmployeeLeavesAsync(employeeLeavesEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while calling delete operation for record id = {id} --> "+ex);
                throw;
            }
        }

        private async Task<EmployeeLeavesEntity> GetEmployeeLeavesEntity(int id)
        {
            try
            {
                EmployeeLeavesEntity employeeLeavesEntity = await _employeeLeavesRepository.GetEmployeeLeavesByPrimaryKeyId(id);
                if (employeeLeavesEntity == null)
                {
                    _logger.LogError("Record Not found and Null is returned whilst calling GetEmployeeLeavesByPrimaryKeyId method from DeleteEmployeeLeaves having id - " + id);
                }
                return employeeLeavesEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured whilst calling a GetEmployeeLeavesByPrimaryKeyId operation from DeleteEmployeeLeaves for id = {id} -->" + ex);
                throw;
            }
        }
    }
}
