using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GSe
    {
        public string SeId { get; set; } = null!;
        public string? FactoryId { get; set; }
        public decimal? BuildVolumeKwh { get; set; }
    }
}
