using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GAirCompMapping
    {
        public string FactoryId { get; set; } = null!;
        public string Mid { get; set; } = null!;
        public string? AirAcc01 { get; set; }
        public string? AirAcc02 { get; set; }
        public string? Power01 { get; set; }
        public string? Power02 { get; set; }
        public string? Power03 { get; set; }
        public string? Power04 { get; set; }
        public string? Power05 { get; set; }
        public string? WorkTime01 { get; set; }
        public string? WorkTime02 { get; set; }
        public string? WorkTime03 { get; set; }
        public string? WorkTime04 { get; set; }
        public string? WorkTime05 { get; set; }
    }
}
