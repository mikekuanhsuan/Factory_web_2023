using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMaintainLog
    {
        public string FactoryId { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public DateTime MaintainDate { get; set; }
        public int Ver { get; set; }
        public string? MaintainDesc { get; set; }
        public string? MaintainDetil { get; set; }
        public DateTime CreatDate { get; set; }
    }
}
