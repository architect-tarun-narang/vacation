using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities
{
    [Table("EmployeeVacation")]
    public class EmployeeLeavesEntity
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Approved { get; set; }
        public string Remarks { get; set; }
    }
}
