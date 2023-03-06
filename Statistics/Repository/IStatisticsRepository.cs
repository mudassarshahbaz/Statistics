using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Repository
{
    public interface IStatisticsRepository
    {
        public Task<IEnumerable<Statistics>> Get();
        public Task Post();
    }
}
