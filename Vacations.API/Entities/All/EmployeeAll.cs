using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities.All
{
    public class EmployeeAll
    {
        public EmployeeAllDetails EmployeeAllDetails { get; set; }        
        public IEnumerable<EmployeeAllDetailsTraining> EmployeeAllDetailsTraining { get; set; } 
        public IEnumerable<EmployeeAllDetailsVacation> EmployeeAllDetailsVacation { get; set; }
        public IEnumerable<EmployeeAllDetailsWFH> EmployeeAllDetailsWFH { get; set; }

    }
}
