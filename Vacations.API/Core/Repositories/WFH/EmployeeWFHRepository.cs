using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Entities.WFH;

namespace Vacations.API.Core.Repositories.WFH
{
    public class EmployeeWFHRepository : IEmployeeWFHRepository
    {
        private readonly IBaseRepository<EmployeeWFHEntity> _baseRepository;
        private readonly ILogger<EmployeeWFHRepository> _logger;

        public EmployeeWFHRepository(IBaseRepository<EmployeeWFHEntity> baseRepository, ILogger<EmployeeWFHRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<IEnumerable<EmployeeWFHEntity>> GetEmployeeWFHAsync(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select * from EmployeeWFH wfh, WFHDays wfhDays where wfhDays.Id=wfh.WFHDaysId and wfh.EmployeeId=@EmployeeId and wfh.VacationTypeId=@VacationTypeId";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeWFHEntity);
        }

        public async Task<IEnumerable<EmployeeWFHEntity>> GetEmployeeWFHAllAsync(EmployeeWFHEntity employeeWFHEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select wfh.id, wfh.EmployeeId,wfh.VacationTypeId,wfh.WFHDaysId, wfhDays.Days from EmployeeWFH wfh, WFHDays wfhDays where wfhDays.Id=wfh.WFHDaysId and wfh.VacationTypeId=@VacationTypeId";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeWFHEntity);
        }

        public async Task<EmployeeWFHEntity> GetEmployeeWFHByPrimaryKeyId(int Id)
        {
            _logger.LogInformation("### Called GetEmployeeWFHByPrimaryKeyId ### ");
            var employeeWFHEntity = await _baseRepository.FindEntityContrib(Id);
            return employeeWFHEntity;
        }

        public async Task<IEnumerable<EmployeeWFHEntity>> GetAllEmployeesByWFHIdAsync(EmployeeWFHEntity employeeWFHEntity)
        {
            string sQuery = "Select * from EmployeeWFH wfh, WFHDays wfhDays where wfhDays.Id=wfh.WFHDaysId and wfh.VacationTypeId=@VacationTypeId and wfh.WFHDaysId=@WFHDaysId";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeWFHEntity);
        }
    }
}
