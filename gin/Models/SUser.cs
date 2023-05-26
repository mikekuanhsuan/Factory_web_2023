using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class SUser
    {
        public string UserId { get; set; } = null!;
        public string UserPwd { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FactoryId { get; set; } = null!;
        public string? DepartmentId { get; set; }
    }
}
