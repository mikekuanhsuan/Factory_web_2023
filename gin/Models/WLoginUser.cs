using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class WLoginUser
    {
        public int UserId { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? FactoryId { get; set; }
        public int? State { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? StopTime { get; set; }
    }
}
