using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class AProductMachine
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public DateTime Dtime { get; set; }
        public string? ProductId { get; set; }
        public decimal? Moisture { get; set; }
        public decimal? SpecificSurface { get; set; }
        public decimal? ResidualOnSieve { get; set; }
        public decimal? DeviceValue1Mill { get; set; }
        public decimal? DeviceValue1Pressure { get; set; }
        public decimal? DeviceValue2Mill { get; set; }
        public decimal? DeviceValue2Pressure { get; set; }
        public decimal? DeviceValueCarrier { get; set; }
        public decimal? DeviceValueBlower { get; set; }
    }
}
