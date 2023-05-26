using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class RMonthCondition
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public string Product { get; set; } = null!;
        public int? OsepaMin { get; set; }
        public int? OsepaMax { get; set; }
        public int? WeightMin { get; set; }
        public int? WeightMax { get; set; }
    }
}
