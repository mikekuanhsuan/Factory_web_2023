using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GPowerBill
    {
        public string FactoryId { get; set; } = null!;
        public DateTime DataDate { get; set; }
        public string Mid { get; set; } = null!;
        public DateTime? GetDateTime { get; set; }
        public decimal? PowerKwh { get; set; }
        public decimal? PowerPeak { get; set; }
        public decimal? PowerHalfPeak { get; set; }
        public decimal? PowerOffPeak { get; set; }
        public decimal? BillTotal { get; set; }
        public decimal? BillPeak { get; set; }
        public decimal? BillHalfPeak { get; set; }
        public decimal? BillOffPeak { get; set; }
    }
}
