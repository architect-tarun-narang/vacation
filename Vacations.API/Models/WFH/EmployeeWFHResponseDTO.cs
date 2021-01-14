using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models.WFH
{
    public class EmployeeWFHResponseDTO
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public int WFHDaysId { get; set; }
        public string Days { get; set; }
    }
}
