using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class FactoryState
    {
        public DateTime Dtime { get; set; }
        public string Host1 { get; set; } = null!;
        public string Host2 { get; set; } = null!;
        public bool? Light { get; set; }
        public string? Message { get; set; }
    }
}
