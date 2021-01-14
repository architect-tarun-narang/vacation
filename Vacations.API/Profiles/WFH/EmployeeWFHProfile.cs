using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.WFH;
using Vacations.API.Models.WFH;

namespace Vacations.API.Profiles.WFH
{
    public class EmployeeWFHProfile: Profile
    {
        public EmployeeWFHProfile()
        {
            CreateMap<EmployeeWFHEntity, EmployeeWFHResponseDTO>().ReverseMap();
            CreateMap<EmployeeWFHEntity, EmployeeWFHRequestDTO>().ReverseMap();
            CreateMap<EmployeeWFHEntity, EmployeeWFHAllRequestDTO>().ReverseMap();
            CreateMap<EmployeeWFHEntity, EmployeeWFHIDRequestDTO>().ReverseMap();
            CreateMap<EmployeeWFHEntity, EmployeeWFHCreationDTO>().ReverseMap();
            CreateMap<EmployeeWFHDaysEntity, EmployeeWFHDaysResponseDTO>().ReverseMap();            
        }
    }
}
