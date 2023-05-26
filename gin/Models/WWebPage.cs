using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WWebPage
    {
        public WWebPage()
        {
            WSubPages = new HashSet<WSubPage>();
        }

        public int Num { get; set; }
        public string WebId { get; set; } = null!;
        public string WebName { get; set; } = null!;
        public string? WebUrl { get; set; }
        public int? State { get; set; }
        public int? OrderById { get; set; }

        public virtual ICollection<WSubPage> WSubPages { get; set; }
    }
}
