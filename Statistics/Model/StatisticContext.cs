using Microsoft.EntityFrameworkCore;
using Statistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics
{
    public class StatisticContext : DbContext
    {
        public StatisticContext(DbContextOptions options) : base (options)
        {
            //constructor, Inject DbContextOptions class
        }

        public DbSet<MachineIdentifier> MachineIdentifiers { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistics>()
                .HasOne(c => c.MachineIdentifier)
                .WithMany(s => s.Statistics)
                .HasForeignKey(c => c.MachineId);

            modelBuilder.Entity<Dimensions>()
               .HasOne(c => c.Statistics)
               .WithMany(s => s.Dimensions)
               .HasForeignKey(c => c.StatisticId);
        }
    }
}
