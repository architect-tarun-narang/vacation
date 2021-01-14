using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities;
using Vacations.API.Entities.Leaves;
using Vacations.API.Models;

namespace Vacations.API.Profiles.Leaves
{
    public class EmployeeLeavesProfile: Profile
    {
        public EmployeeLeavesProfile()
        {
            CreateMap<EmployeeLeavesEntity, EmployeeLeavesDateDTO>().ReverseMap();
            CreateMap<EmployeeLeavesEntity, EmployeeLeavesAllDateDTO>().ReverseMap();
            CreateMap<EmployeeLeavesEntity, EmployeeLeavesCreationDTO>().ReverseMap();
            CreateMap<EmployeeLeavesAllDetailsEntity, EmployeeLeavesAllDetailsResponseDTO>().ReverseMap();
            //.ForMember(dest => dest.GivenName, opt => opt.MapFrom(
            //   (src => $"({src.FirstName}-{src.LastName})")));
            //CreateMap<Models.EmployeeDTO, Entities.Employee>();

        }
    }
}
