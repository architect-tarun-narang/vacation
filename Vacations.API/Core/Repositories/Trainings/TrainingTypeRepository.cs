using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Entities.Trainings;

namespace Vacations.API.Core.Repositories.Trainings
{
    public class TrainingTypeRepository: ITrainingTypeRepository
    {
        private readonly IBaseRepository<TrainingTypeEntity> _baseRepository;
        private readonly ILogger<TrainingTypeRepository> _logger;

        public TrainingTypeRepository(IBaseRepository<TrainingTypeEntity> baseRepository, ILogger<TrainingTypeRepository> logger)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<TrainingTypeEntity>> GetTrainingTypeAsync()
        {
            _logger.LogInformation("### Calling base repository method ### ");
            string sQuery = "Select * from Training";
            return await _baseRepository.GetEntityAsync(sQuery);
        }

    }
}
