using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Service
{
    public interface IStatisticsService
    {
        public Task<IEnumerable<Statistics>> Get();
        public Task Post();
    }
}
