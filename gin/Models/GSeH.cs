using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GSeH
    {
        public string SeId { get; set; } = null!;
        public DateTime Dtime { get; set; }
        public decimal? PowerGeneration { get; set; }
        public decimal? KwhAvg { get; set; }
    }
}
