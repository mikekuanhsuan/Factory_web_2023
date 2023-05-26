using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WeatherDay
    {
        public DateTime DataDate { get; set; }
        public string Area { get; set; } = null!;
        public int? Uv { get; set; }
    }
}
