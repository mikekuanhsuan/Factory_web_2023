using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class AProductQuality2
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public DateTime Dtime { get; set; }
        public DateTime DateTime { get; set; }
        public string ProductId { get; set; } = null!;
        public decimal? Moisture { get; set; }
        public decimal? SpecificSurface { get; set; }
        public decimal? ResidualOnSieve { get; set; }
        public string? Visible { get; set; }
        public string ClientInfo { get; set; } = null!;
        public string Laboratory { get; set; } = null!;
    }
}
