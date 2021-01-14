using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacations.API.Models
{
  
    public class EmployeeDTO
    {
        //[FromQuery(Name = "Id")]
        //[Required(ErrorMessage = "Email is required.")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MgrId { get; set; }
    }
}
