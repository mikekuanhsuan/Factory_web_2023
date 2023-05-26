using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachineWorkHour
    {
        public string FactoryId { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public DateTime Ddate { get; set; }
        public decimal? WorkHour { get; set; }
    }
}
