using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vacations.API.Entities.WFH
{
    [Table("WFHDays")]
    public class EmployeeWFHDaysEntity
    {
        [Key]
        public int Id { get; set; }
        public string Days { get; set; }
    }
}
