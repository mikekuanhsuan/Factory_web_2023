using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WLoginLogfile
    {
        public int LogId { get; set; }
        public string? UserName { get; set; }
        public DateTime? Time { get; set; }
        public string? Detail { get; set; }
    }
}
