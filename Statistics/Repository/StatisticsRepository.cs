using Microsoft.EntityFrameworkCore;
using Statistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly StatisticContext _context;

        public StatisticsRepository(StatisticContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Statistics>> Get()
        {
            await _context.Database.EnsureCreatedAsync();
            var response = GetAllStatistics();

            if (response.Any())
                return await response.Take(200).ToListAsync();
            else
                return Enumerable.Empty<Statistics>();

        }
        public async Task Post()
        {
            var machineIdentifiers = new List<MachineIdentifier>();

            const int machineFamilyCount = 30;
            const int minStatisticTypeCount = 5;
            const int maxStatisticTypeCount = 30;
            const int maxDimensionalValueCount = 10;

            Random random = new Random();

            foreach (var i in Enumerable.Range(0, machineFamilyCount))
            {
                var statisticTypeCount = random.Next(minStatisticTypeCount, maxStatisticTypeCount);
                var statistics = new List<Statistics>();

                foreach (var j in Enumerable.Range(0, statisticTypeCount))
                {
                    var statistic = new Statistics
                    {
                        TimeStamp = DateTime.UtcNow,
                        Value = (decimal)random.NextDouble(),
                        StatisticType = $"statistic-type-{j}",
                        Dimensions = Enumerable.Range(0, random.Next(maxDimensionalValueCount))
                            .Select(k => new Dimensions { Value = $"dimensional-value-{k}" })
                            .ToList()
                    };

                    statistics.Add(statistic);
                }

                machineIdentifiers.Add(new MachineIdentifier
                {
                    MachineName = $"machine-{i}",
                    Statistics = statistics
                });
            }

            await _context.Database.EnsureCreatedAsync();
            await _context.MachineIdentifiers.AddRangeAsync(machineIdentifiers);
            await _context.SaveChangesAsync();
        }

        private IQueryable<Statistics> GetAllStatistics()
        {
            return _context.Statistics.Include(x => x.Dimensions).AsQueryable();
        }
    }
}
