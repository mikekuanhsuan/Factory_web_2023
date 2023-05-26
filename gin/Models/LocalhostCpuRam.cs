using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class LocalhostCpuRam
    {
        public DateTime Dtime { get; set; }
        public double? Cpu { get; set; }
        public double? Ram { get; set; }
    }
}
