using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WLoginUserGroup
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public virtual WLoginGroup Group { get; set; } = null!;
    }
}
