using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models
{
    public class EmployeeLeavesAllDetailsRequestDTO
    {
        public string EmployeeId { get; set; }        
        public int VacationTypeId { get; set; }

        [Required(ErrorMessage = "DateFrom is required.")]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "DateTo is required.")]
        public DateTime DateTo { get; set; }         
    }
}
