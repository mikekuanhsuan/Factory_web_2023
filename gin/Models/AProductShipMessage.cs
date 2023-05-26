using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class AProductShipMessage
    {
        public DateTime Dtime { get; set; }
        public int Dhour { get; set; }
        public string FactoryId { get; set; } = null!;
        public string? Message { get; set; }
    }
}
