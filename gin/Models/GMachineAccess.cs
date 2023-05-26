using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachineAccess
    {
        public string? FactoryId { get; set; }
        public string? ObjectId { get; set; }
        public string Cid { get; set; } = null!;
        public string? DeviceNum { get; set; }
        public string? ClassName { get; set; }
        public string? AccessName { get; set; }
        public string? AccessSpec { get; set; }
        public string? AccessCount { get; set; }
        public string? MaterialsNum { get; set; }
        public string? AssetsNum { get; set; }
        public string? Note { get; set; }
        public int? NextDatePm { get; set; }
        public string? LinkTag { get; set; }
        public string? Stop { get; set; }
        public string? FilePath { get; set; }
    }
}
