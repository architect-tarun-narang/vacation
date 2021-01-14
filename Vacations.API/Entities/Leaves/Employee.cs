using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
namespace Vacations.API.Entities.Leaves
{    
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MgrId { get; set; }

        [Write(false)]
        public List<EmployeeTraining> EmployeeTraining { get; } = new List<EmployeeTraining>();
        public List<EmployeeVacation> EmployeeVacation { get; } = new List<EmployeeVacation>();        
        public List<EmployeeWFH> EmployeeWFH { get; } = new List<EmployeeWFH>();        

    }
}
