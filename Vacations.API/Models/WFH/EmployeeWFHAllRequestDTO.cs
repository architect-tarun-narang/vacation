using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models.WFH
{
    public class EmployeeWFHAllRequestDTO
    {
        [Required(ErrorMessage = "VacationTypeID is required.")]
        public int VacationTypeId { get; set; }
    }
}
