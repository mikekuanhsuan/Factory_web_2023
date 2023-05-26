using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GPowerCalender
    {
        public string? PYear { get; set; }
        public DateTime PDate { get; set; }
        public string? PWeekDay { get; set; }
        public bool? OffPeak { get; set; }
        public bool? HalfPeak { get; set; }
    }
}
