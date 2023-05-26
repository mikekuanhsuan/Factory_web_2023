using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class ValueMin
    {
        public DateTime DataDateTime { get; set; }
        public string SourceServer { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public decimal? Value { get; set; }
    }
}
