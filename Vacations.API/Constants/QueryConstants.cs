using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Constants
{
    public static class QueryConstants
    {
        public static string EMPLOYEE_DETAILS = "SELECT * FROM Vacation.dbo.Employee AS emp ";
        public static string EMPLOYEE_TRAINING = "SELECT et.Id as TrainingPrimaryId, *  FROM Vacation.dbo.Employee AS emp " +
            "RIGHT OUTER JOIN Vacation.dbo.EmployeeTraining AS et ON emp.Id = et.EmployeeId " +
            "LEFT OUTER JOIN Vacation.dbo.Training As training ON et.TrainingId = training.Id ";
        public static string EMPLOYEE_VACATION = "SELECT ev.id as VacationPrimaryId, * FROM Vacation.dbo.Employee AS emp " +
            "RIGHT OUTER JOIN Vacation.dbo.EmployeeVacation AS ev ON ev.EmployeeId = emp.id " +
            "LEFT OUTER JOIN Vacation.dbo.VacationType AS vt ON vt.Id = ev.VacationTypeId ";
        public static string EMPLOYEE_WFH = "SELECT wfh.Id as WFHPrimaryId, * FROM Vacation.dbo.Employee AS emp " +
            "RIGHT OUTER JOIN Vacation.dbo.EmployeeWFH AS wfh ON wfh.EmployeeId = emp.Id " +
            "LEFT OUTER JOIN Vacation.dbo.WFHDays AS wfhDays ON wfhDays.Id = wfh.WFHDaysId ";

    }
}
