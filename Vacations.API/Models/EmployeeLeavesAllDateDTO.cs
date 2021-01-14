using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models
{
    public class EmployeeLeavesAllDateDTO
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "VacationTypeID is required.")]
        public int VacationTypeId { get; set; }

        public string strDateFrom
        {
            get => DateFrom.ToString("dd-MMM-yyyy");

        }

        public string strDateTo
        {
            get => DateTo.ToString("dd-MMM-yyyy");
            
        }

        [Required(ErrorMessage = "DateFrom is required.")]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "DateTo is required.")]
        public DateTime DateTo { get; set; }         
    }
}
