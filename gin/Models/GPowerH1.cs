using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GPowerH1
    {
        public string FactoryId { get; set; } = null!;
        public DateTime Ddate { get; set; }
        public string TimeKey { get; set; } = null!;
        public DateTime Stime { get; set; }
        public DateTime Etime { get; set; }
        public decimal? PowerKwh { get; set; }
        public decimal? Kwh { get; set; }
        public decimal? Peak { get; set; }
        public decimal? PartialPeak { get; set; }
        public decimal? PartialPeakSat { get; set; }
        public decimal? OffPeak { get; set; }
    }
}
