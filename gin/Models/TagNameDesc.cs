using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class TagNameDesc
    {
        public string TagGroup { get; set; } = null!;
        public string? TagMid { get; set; }
        public int TagSort { get; set; }
        public string ServerName { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public string SourceTag { get; set; } = null!;
        public string? TagDesc { get; set; }
    }
}
