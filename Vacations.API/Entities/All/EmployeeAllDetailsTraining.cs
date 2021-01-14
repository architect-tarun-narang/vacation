using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
namespace Vacations.API.Entities.All
{    
    public class EmployeeAllDetailsTraining
    {
        public int TrainingPrimaryId { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MgrId { get; set; }

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
        public string Remarks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
