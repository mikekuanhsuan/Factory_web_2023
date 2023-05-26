using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachine
    {
        public string FactoryId { get; set; } = null!;
        public string DeviceNum { get; set; } = null!;
        public string? ClassName { get; set; }
        public int? Bach { get; set; }
        public string? CountTag { get; set; }
        public string? CountTotalTag { get; set; }
        public int? Par { get; set; }
        public int? MachineNum { get; set; }
    }
}
