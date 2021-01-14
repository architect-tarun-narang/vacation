using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities.Leaves
{
    public class EmployeeWFH
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public int WFHDaysId { get; set; }
        public List<WFHDays> WFHDays = new List<WFHDays>();
    }
}
