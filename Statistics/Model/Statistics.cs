using Statistics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Statistics
{
    public class Statistics
    {
        [Key]
        public long StatisticId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Value { get; set; }
        public string StatisticType { get; set; }
        public int MachineId { get; set; }
        public virtual MachineIdentifier MachineIdentifier { get; set; }
        public List<Dimensions> Dimensions { get; set; }
    }
}
