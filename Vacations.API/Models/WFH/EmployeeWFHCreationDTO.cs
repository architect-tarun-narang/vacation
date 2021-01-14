using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models.WFH
{
    public class EmployeeWFHCreationDTO
    {
        [Required(ErrorMessage = "EmployeeID is required.")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "VacationTypeID is required.")]
        public int VacationTypeId { get; set; }
        [Required(ErrorMessage = "WFHDaysId is required.")]
        public int WFHDaysId { get; set; }
    }
}
