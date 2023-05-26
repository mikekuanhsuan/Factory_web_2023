using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class TagList
    {
        /// <summary>
        /// FactoryID
        /// </summary>
        public string ServerName { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public string? SourceTag { get; set; }
        public string? TagDesc { get; set; }
        public bool? RepLive { get; set; }
        public bool? RepHour { get; set; }
        public bool? RepMin { get; set; }
        public decimal? TagOrder { get; set; }
    }
}
