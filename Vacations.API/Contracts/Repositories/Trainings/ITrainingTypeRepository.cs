using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Entities.Trainings;

namespace Vacations.API.Contracts.Repositories.Trainings
{
    public interface ITrainingTypeRepository
    {
         Task<IEnumerable<TrainingTypeEntity>> GetTrainingTypeAsync();

    }
}
