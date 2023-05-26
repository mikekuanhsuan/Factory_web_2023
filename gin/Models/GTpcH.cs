using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GTpcH
    {
        public string FactoryId { get; set; } = null!;
        public DateTime Dtime { get; set; }
        public string ElectricityPeriod { get; set; } = null!;
        public int? PowerKw { get; set; }
    }
}
