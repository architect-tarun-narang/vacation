using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contexts;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Entities;
using Vacations.API.Entities.Leaves;
using Dapper;
using Vacations.API.Models;
using System.Text;
using Vacations.API.Constants;
using Vacations.API.Entities.All;
namespace Vacations.API.Core.Repositories.Leaves
{
    public class EmployeeLeavesRepository : IEmployeeLeavesRepository
    {
        private readonly IBaseRepository<EmployeeLeavesEntity> _baseRepository;
        private readonly IBaseRepository<EmployeeInformationEntity> _baseRepositoryInformation;
        private readonly IBaseRepository<EmployeeLeavesAllDetailsEntity> _baseRepositoryAllDetails;
        private readonly ILogger<EmployeeLeavesRepository> _logger;
        private readonly IDapperVacationContext _context;
        public EmployeeLeavesRepository(IDapperVacationContext context, 
            IBaseRepository<EmployeeLeavesEntity> baseRepository, 
            IBaseRepository<EmployeeLeavesAllDetailsEntity> baseRepositoryAllDetails,
            IBaseRepository<EmployeeInformationEntity> baseRepositoryInformation,
            ILogger<EmployeeLeavesRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _baseRepositoryAllDetails = baseRepositoryAllDetails ?? throw new ArgumentNullException(nameof(baseRepositoryAllDetails));
            _baseRepositoryInformation = baseRepositoryInformation ?? throw new ArgumentNullException(nameof(baseRepositoryInformation));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<EmployeeLeavesEntity>> GetEmployeeLeavesByDateAsync(EmployeeLeavesEntity employeeLeavesEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select * from Vacation.dbo.EmployeeVacation WHERE EmployeeId=@EmployeeId and VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeLeavesEntity);
        }

        public async Task<IEnumerable<EmployeeLeavesEntity>> GetEmployeeLeavesAllByDateAsync(EmployeeLeavesEntity employeeLeavesEntity)
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select * from Vacation.dbo.EmployeeVacation WHERE VacationTypeId=@VacationTypeId and DateFrom>=@DateFrom and DateTo<=@DateTo";
            return await _baseRepository.GetAllEntitiesAsync(sQuery, employeeLeavesEntity);
        }
        public async Task<EmployeeAll> GetEmployeeLeavesAllDetailsAsync(EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO)
        {
            //String queryEmployee = @QueryConstants.EMPLOYEE_TRAINING + QueryConstants.EMPLOYEE_VACATION + QueryConstants.EMPLOYEE_WFH;
            //String queryEmployee = @QueryConstants.EMPLOYEE_TRAINING + QueryConstants.EMPLOYEE_VACATION + QueryConstants.EMPLOYEE_WFH;

            StringBuilder queryEmpDetails = new StringBuilder();
            if (employeeLeavesAllDetailsRequestDTO.EmployeeId != null)
            {
                queryEmpDetails.Append(@QueryConstants.EMPLOYEE_DETAILS);
                queryEmpDetails.Append($" where emp.id=" + employeeLeavesAllDetailsRequestDTO.EmployeeId + ";");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_TRAINING);
                queryEmpDetails.Append($" where emp.id=" + employeeLeavesAllDetailsRequestDTO.EmployeeId + " and ");
                queryEmpDetails.Append(" et.DateFrom >= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateFrom + "',3) and et.DateTo <= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateTo + "',3);");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_VACATION);
                queryEmpDetails.Append($" where emp.id=" + employeeLeavesAllDetailsRequestDTO.EmployeeId + " and ");
                queryEmpDetails.Append("ev.DateFrom >= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateFrom + "',3) and ev.DateTo <= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateTo + "',3);");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_WFH).Append($" where emp.id=" + employeeLeavesAllDetailsRequestDTO.EmployeeId + ";"); ;
            }
            else {
                queryEmpDetails.Append(@QueryConstants.EMPLOYEE_DETAILS + ";");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_TRAINING + " and ");
                queryEmpDetails.Append(" et.DateFrom >= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateFrom + "',3) and et.DateTo <= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateTo + "',3);");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_VACATION + " and ");
                queryEmpDetails.Append("ev.DateFrom >= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateFrom + "',3) and ev.DateTo <= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateTo + "',3);");
                queryEmpDetails.Append(QueryConstants.EMPLOYEE_WFH);
            }

            EmployeeAll employeeAll = new EmployeeAll();
            using (var conn = _context.Connection)
            {
                conn.Open();
                var multi = await conn.QueryMultipleAsync(queryEmpDetails.ToString(), null);
                var employeeAllDetails = await multi.ReadAsync<EmployeeAllDetails>(); 
                var employeesTrainingDetails = await multi.ReadAsync<EmployeeAllDetailsTraining>();
                var employeeAllDetailsVacation = await multi.ReadAsync<EmployeeAllDetailsVacation>();
                var employeeAllDetailsWFH = await multi.ReadAsync<EmployeeAllDetailsWFH>();

                employeeAll.EmployeeAllDetails = employeeAllDetails.First();
                employeeAll.EmployeeAllDetailsTraining = employeesTrainingDetails;
                employeeAll.EmployeeAllDetailsVacation = employeeAllDetailsVacation;
                employeeAll.EmployeeAllDetailsWFH = employeeAllDetailsWFH;
                conn.Close();
            }
            return employeeAll;

        }

        /*        public async Task<Dictionary<string, Employee>> GetEmployeeLeavesAllDetailsAsync(EmployeeLeavesAllDetailsRequestDTO employeeLeavesAllDetailsRequestDTO)
                {
                    StringBuilder sQuery = new StringBuilder();
                    sQuery.Append($"SELECT * FROM Vacation.dbo.Employee AS emp " +
                        $"LEFT OUTER JOIN Vacation.dbo.EmployeeTraining AS et ON emp.Id = et.EmployeeId " +
                        $"LEFT OUTER JOIN Vacation.dbo.Training As training ON et.TrainingId = training.Id " +
                        $"LEFT OUTER JOIN Vacation.dbo.EmployeeVacation AS ev ON ev.EmployeeId = emp.id " +
                        $"LEFT OUTER JOIN Vacation.dbo.VacationType AS vt ON vt.Id = ev.VacationTypeId " +
                        $"LEFT OUTER JOIN Vacation.dbo.EmployeeWFH AS wfh ON wfh.EmployeeId = emp.Id " +
                        $"LEFT OUTER JOIN Vacation.dbo.WFHDays AS wfhDays ON wfhDays.Id = wfh.WFHDaysId Where ");            
                        if (employeeLeavesAllDetailsRequestDTO.EmployeeId != null){ 
                            sQuery.Append($"emp.id=" + employeeLeavesAllDetailsRequestDTO.EmployeeId + " and ");
                        }
                     sQuery.Append("(et.DateFrom >= CONVERT(varchar, '"+ employeeLeavesAllDetailsRequestDTO.DateFrom+ "',3) and et.DateTo <= CONVERT(varchar, '"+ employeeLeavesAllDetailsRequestDTO.DateTo + "',3) " +
                        " OR ev.DateFrom >= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateFrom + "',3) and ev.DateTo <= CONVERT(varchar, '" + employeeLeavesAllDetailsRequestDTO.DateTo + "',3))");
                    using (var conn = _context.Connection)
                    {
                        conn.Open();
                        var employeeDict = new Dictionary<string, Employee>();
                        var employees = await conn.QueryAsync<Employee, EmployeeTraining, Training, EmployeeVacation, VacationType, EmployeeWFH, WFHDays, Employee>(sQuery.ToString(), (employee, employeeTraining, training, employeeVacation, vacationType, employeeWFH, wfhDays) =>
                        {
                            if (!employeeDict.TryGetValue(employee.Id, out var currentEmployee))
                            {
                                currentEmployee = employee;
                                employeeDict.Add(currentEmployee.Id, currentEmployee);
                            }
                            if (employeeTraining != null)
                            {
                                currentEmployee.EmployeeTraining.Add(employeeTraining);
                                employeeTraining.Training.Add(training);
                            }
                            if (employeeVacation != null)
                            {
                                currentEmployee.EmployeeVacation.Add(employeeVacation);
                                employeeVacation.VacationType.Add(vacationType);
                            }
                            if (employeeWFH != null)
                            {
                                currentEmployee.EmployeeWFH.Add(employeeWFH);
                                employeeWFH.WFHDays.Add(wfhDays);
                            }

                            return currentEmployee;
                        });
                        conn.Close();
                        return employeeDict;
                    }
                }
        */

        public async Task<EmployeeLeavesEntity> GetEmployeeLeavesByPrimaryKeyId(int Id)
        {
            _logger.LogInformation("### Called GetEmployeeLeavesByPrimaryKeyId ### ");
            var employeeLeavesEntity  = await _baseRepository.FindEntityContrib(Id);
            return employeeLeavesEntity;
        }

        public async Task<EmployeeInformationEntity> GetEmployeeByEmployeeCodeAsync(string employeeCode)
        {
            var employeeInformationEntity = await _baseRepositoryInformation.FindEntityContrib(employeeCode);
            return employeeInformationEntity;
        }
    }
}
