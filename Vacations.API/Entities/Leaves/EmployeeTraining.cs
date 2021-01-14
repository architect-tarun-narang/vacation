using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
namespace Vacations.API.Entities.Leaves
{    
    public class EmployeeTraining
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public int TrainingId { get; set; }
        public int TrainingHours { get; set; }
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

        public List<Training> Training = new List<Training>();
    }
}
