using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class TagGroup
    {
        public string GroupId { get; set; } = null!;
        public string? GroupDesc { get; set; }
        public int GroupSort { get; set; }
    }
}
