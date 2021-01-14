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
    public class EmployeeLeavesAddService: IEmployeeLeavesAddService
    {
        private readonly IEmployeeLeavesAddRepository _employeeLeavesAddRepository;
        private readonly IEmployeeLeavesRepository _employeeLeavesRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EmployeeLeavesAddService(IEmployeeLeavesAddRepository employeeLeavesAddRepository,
            IEmployeeLeavesRepository employeeLeavesRepository,
            ILogger<EmployeeLeavesAddService> logger,
            IMapper mapper)
        {
            _employeeLeavesAddRepository = employeeLeavesAddRepository ?? throw new ArgumentNullException(nameof(employeeLeavesAddRepository));
            _employeeLeavesRepository = employeeLeavesRepository ?? throw new ArgumentNullException(nameof(employeeLeavesRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<EmployeeLeavesDateDTO> AddEmployeeLeaves(EmployeeLeavesCreationDTO employeeLeavesCreationDTO) 
        {

            var employeeLeavesEntity = _mapper.Map<EmployeeLeavesEntity>(employeeLeavesCreationDTO);
            var newRecordCreatedID = await _employeeLeavesAddRepository.AddEmployeeLeaves(employeeLeavesEntity);
            var employeeLeavesEntityAdded = await _employeeLeavesRepository.GetEmployeeLeavesByPrimaryKeyId(newRecordCreatedID);
            var employeeLeavesDateDTOTransformed = _mapper.Map<EmployeeLeavesDateDTO>(employeeLeavesEntityAdded);
            return employeeLeavesDateDTOTransformed;
        }
    }
}
