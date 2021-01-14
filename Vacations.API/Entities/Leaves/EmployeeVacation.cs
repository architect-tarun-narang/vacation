using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Entities.Leaves
{
    public class EmployeeVacation
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Remarks { get; set; }
        public string strDateFrom
        {
            get => DateFrom.ToString("dd-MMM-yyyy");
        }

        public string strDateTo
        {
            get => DateTo.ToString("dd-MMM-yyyy");

        }
        public List<VacationType> VacationType = new List<VacationType>();
    }
}
