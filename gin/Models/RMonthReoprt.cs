using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class RMonthReoprt
    {
        public string FactoryId { get; set; } = null!;
        public DateTime Month { get; set; }
        public string MillId { get; set; } = null!;
        public string Product { get; set; } = null!;
        public decimal? ProductionTotalA { get; set; }
        public decimal? ProductionHourA { get; set; }
        public decimal? RunHourA { get; set; }
        public decimal? ProductionTotalB { get; set; }
        public decimal? ProductionHourB { get; set; }
        public decimal? RunHourB { get; set; }
    }
}
