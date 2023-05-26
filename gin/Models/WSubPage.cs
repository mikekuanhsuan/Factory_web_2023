using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WSubPage
    {
        public int Num { get; set; }
        public string SubId { get; set; } = null!;
        public string SubName { get; set; } = null!;
        public string? SubUrl { get; set; }
        public int State { get; set; }
        public string? WebId { get; set; }

        public virtual WWebPage? Web { get; set; }
    }
}
