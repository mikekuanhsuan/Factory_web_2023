using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class AProductShipDatum
    {
        public string FactoryId { get; set; } = null!;
        public DateTime DataDate { get; set; }
        public int Dhour { get; set; }
        public int LibraryClass { get; set; }
        public decimal? Value { get; set; }
    }
}
