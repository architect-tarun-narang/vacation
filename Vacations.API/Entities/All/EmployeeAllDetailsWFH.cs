using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
namespace Vacations.API.Entities.All
{    
    public class EmployeeAllDetailsWFH
    {
        public int WFHPrimaryId { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MgrId { get; set; }
        public int VacationTypeId { get; set; }
        public int WFHDaysId { get; set; }
        public string Days { get; set; }

    }
}
