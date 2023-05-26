using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class OccDespatch
    {
        public string WorkId { get; set; } = null!;
        public string? DeptId { get; set; }
        public DateTime? ODate { get; set; }
        public string? CarId { get; set; }
        public string? OrderId1 { get; set; }
        public string? CustId { get; set; }
        public string? CustName { get; set; }
        public string? ProdId { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Delivery { get; set; }
        public decimal? Tare { get; set; }
        public decimal? DeliWt { get; set; }
        public string? ITime { get; set; }
        public string? OTime { get; set; }
        public string? ScaleNo { get; set; }
        public string? Package { get; set; }
        public string? PrintSn { get; set; }
    }
}
