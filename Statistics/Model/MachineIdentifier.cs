using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Model
{
    public class MachineIdentifier
    {
        [Key]
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public List<Statistics> Statistics { get; set; }
    }
}
