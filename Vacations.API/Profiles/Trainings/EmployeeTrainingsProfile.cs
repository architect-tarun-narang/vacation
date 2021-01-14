using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.Trainings;
using Vacations.API.Models.Trainings;

namespace Vacations.API.Profiles.Trainings
{
    public class EmployeeTrainingsProfile: Profile
    {
        public EmployeeTrainingsProfile()
        {
            CreateMap<EmployeeTrainingsEntity, EmployeeTrainingsResponseDTO>().ReverseMap();
            CreateMap<EmployeeTrainingsEntity, EmployeeTrainingsRequestDTO>().ReverseMap();
            CreateMap<EmployeeTrainingsEntity, EmployeeTrainingsAllRequestDTO>().ReverseMap();
            CreateMap<EmployeeTrainingsEntity, EmployeeTrainingsIDRequestDTO>().ReverseMap();            
            CreateMap<EmployeeTrainingsEntity, EmployeeTrainingsCreationDTO>().ReverseMap();
            CreateMap<TrainingTypeEntity, TrainingTypeResponseDTO>().ReverseMap();

        }
    }
}
