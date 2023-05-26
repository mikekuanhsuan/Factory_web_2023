using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachingWorkValue30m
    {
        public string FactoryId { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public string? Mname { get; set; }
        public DateTime Mdate { get; set; }
        public decimal? Mvalue { get; set; }
        public decimal? TotalMvalue { get; set; }
    }
}
