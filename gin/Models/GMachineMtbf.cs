using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachineMtbf
    {
        public string FactoryId { get; set; } = null!;
        public string ObjectId { get; set; } = null!;
        public string? ClassName { get; set; }
        public string? LinkTag { get; set; }
        public string? StopFlag { get; set; }
        public DateTime? StopTime { get; set; }
    }
}
