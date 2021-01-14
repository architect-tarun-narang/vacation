using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models.WFH
{
    public class EmployeeWFHIDRequestDTO
    {
        [Required(ErrorMessage = "WFHDaysId is required.")]
        public int WFHDaysId { get; set; }
        [Required(ErrorMessage = "VacationTypeID is required.")]
        public int VacationTypeId { get; set; }

    }
}
