using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities.Trainings
{
    [Table("EmployeeTraining")]
    public class EmployeeTrainingsEntity
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public int TrainingId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int TrainingHours { get; set; }        
        public string Remarks { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public string Name { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public string Description { get; set; }
    }
}
