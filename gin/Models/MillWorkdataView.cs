using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class MillWorkdataView
    {
        public string? DeptEngSname { get; set; }
        public string? MillNum { get; set; }
        public DateTime Mdate { get; set; }
        public decimal? WorkSecond { get; set; }
        public decimal? FeedValue { get; set; }
        public decimal? FeedTotal { get; set; }
    }
}
