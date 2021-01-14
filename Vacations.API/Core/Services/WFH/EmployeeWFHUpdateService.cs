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
    public class EmployeeWFHUpdateService: IEmployeeWFHUpdateService
    {
        private readonly IEmployeeWFHUpdateRepository _employeeWFHUpdateRepository;
        private readonly IEmployeeWFHRepository _employeeWFHRepository; 
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EmployeeWFHUpdateService(IEmployeeWFHUpdateRepository employeeWFHUpdateRepository,
            IEmployeeWFHRepository employeeWFHRepository,
            ILogger<EmployeeWFHUpdateService> logger,
            IMapper mapper)
        {
            _employeeWFHUpdateRepository = employeeWFHUpdateRepository ?? throw new ArgumentNullException(nameof(employeeWFHUpdateRepository));
            _employeeWFHRepository = employeeWFHRepository ?? throw new ArgumentNullException(nameof(employeeWFHRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> UpdateEmployeeWFH(EmployeeWFHCreationDTO employeeWFHCreationDTO) 
        {
            try
            {
                _logger.LogDebug("Payload employeeWFHCreationDTO = " + employeeWFHCreationDTO);
                var employeeWFHEntity = _mapper.Map<EmployeeWFHEntity>(employeeWFHCreationDTO);
                var EmployeeWFHEntityRecords = await _employeeWFHRepository.GetEmployeeWFHAsync(employeeWFHEntity);
                bool isRecordCreated = false;
                if (EmployeeWFHEntityRecords.Count() > 0)
                {
                    //Update
                    isRecordCreated = await _employeeWFHUpdateRepository.UpdateEmployeeWFH(employeeWFHEntity);
                }
                else 
                {
                    //Add/Insert
                    var newWFHRecordCreatedID = await _employeeWFHUpdateRepository.AddEmployeeWFH(employeeWFHEntity);
                }
                //var employeeWFHEntityAdded = await _employeeWFHRepository.GetEmployeeWFHByPrimaryKeyId(newWFHRecordCreatedID);
                //var employeeWFHResponseDTO = _mapper.Map<EmployeeWFHResponseDTO>(employeeWFHEntityAdded);
                return isRecordCreated;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while calling AddEmployeeWFH method" + ex);
                throw;
            }

        }
    }
}
