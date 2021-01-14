using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models
{
    public class EmployeeLeavesMonthDTO
    {
        [Required(ErrorMessage = "EmployeeID is required.")]
        string EmployeeId { get; set; }
        [Required(ErrorMessage = "VacationTypeID is required.")]
        int VacationTypeId { get; set; }
        [Required(ErrorMessage = "Month is required.")]
        string Month { get; set; }
        bool Approved
        {
            get { return Approved; }

            set { Approved = false; }
        }
    }
}
