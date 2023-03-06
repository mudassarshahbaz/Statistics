using Statistics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Service
{
    public class StatisticsService: IStatisticsService
    {
        private readonly IStatisticsRepository _repository;

        public StatisticsService(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Statistics>> Get()
        {
            return await _repository.Get();
        }

        public async Task Post()
        {
            await _repository.Post();
        }
    }
}
