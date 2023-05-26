using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class AProductShipMapping
    {
        public string FactoryId { get; set; } = null!;
        public int BarrelTank { get; set; }
        public string ProductId { get; set; } = null!;
        public int Depth { get; set; }
        public int Height { get; set; }
        public int Diameter { get; set; }
        public int Bottom { get; set; }
        public decimal Proportion { get; set; }
        public decimal TotalHeight { get; set; }
    }
}
