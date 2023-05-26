using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WLoginGroupRight
    {
        public int GroupId { get; set; }
        public string Account { get; set; } = null!;
        public string? FactoryId { get; set; }
        public string? SubId { get; set; }
        public int? RightId { get; set; }
    }
}
