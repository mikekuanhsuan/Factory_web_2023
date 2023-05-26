using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GSeM
    {
        public string SeId { get; set; } = null!;
        public DateTime Ddate { get; set; }
        public decimal? PowerGeneration { get; set; }
        public int? LostPower { get; set; }
        public decimal? KwhAvg { get; set; }
    }
}
