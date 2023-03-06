using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Statistics
{
    public class Dimensions
    {
        [Key]
        public int DimensionId { get; set; }
        public string Value { get; set; }
        public long StatisticId { get; set; }
        public virtual Statistics Statistics { get; set; }
    }
}
