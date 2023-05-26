using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class FtyPhoto
    {
        public string Id { get; set; } = null!;
        public string FactoryId { get; set; } = null!;
        public string? Lane { get; set; }
        public string? LicenseId { get; set; }
        public string? UnsafetyPerson { get; set; }
        public string? UnsafetyHat { get; set; }
        public string? Dust { get; set; }
        public DateTime? Time1 { get; set; }
        public DateTime? Time2 { get; set; }
        public string? OrderId1 { get; set; }
        public string? WorkId { get; set; }
        public string? Remark { get; set; }
    }
}
