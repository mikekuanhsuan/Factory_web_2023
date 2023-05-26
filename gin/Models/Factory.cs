using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class Factory
    {
        public string FactoryId { get; set; } = null!;
        public string? FactoryName { get; set; }
        public int? AOrder { get; set; }
        public string? ServerIp { get; set; }
        public string? TpcAct { get; set; }
        public string? TpcPwd { get; set; }
    }
}
