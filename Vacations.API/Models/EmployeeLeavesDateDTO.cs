using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models
{
    public class EmployeeLeavesDateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EmployeeID is required.")]
        public string EmployeeId { get; set; }
       
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

        public string Remarks { get; set; }

        private bool _approved = false;
        public bool Approved 
        {
            get
            {
                return _approved;
            }
            set
            {
                _approved = value;
            }
        }
         
    }
}
