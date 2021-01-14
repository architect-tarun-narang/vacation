using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models.Trainings
{
    public class EmployeeTrainingsResponseDTO
    {
        public int Id { get; set; }
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
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int TrainingId { get; set; }
        public int TrainingHours { get; set; }
        public string Remarks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
