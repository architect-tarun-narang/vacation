using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities.WFH
{
    [Dapper.Contrib.Extensions.Table("EmployeeWFH")]
    public class EmployeeWFHEntity
    {
        //[ExplicitKey]
        //public int Id { get; set; }
        [ExplicitKey]
        public string EmployeeId { get; set; }
        [ExplicitKey]
        public int VacationTypeId { get; set; }
        public int WFHDaysId { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public string Days { get; set; }
    }
}
