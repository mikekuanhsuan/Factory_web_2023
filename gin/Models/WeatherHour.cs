using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WeatherHour
    {
        public DateTime Dtime { get; set; }
        public string Area { get; set; } = null!;
        public int? Uv { get; set; }
    }
}
