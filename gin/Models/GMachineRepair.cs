using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMachineRepair
    {
        public string? FactoryId { get; set; }
        public string? ObjectId { get; set; }
        public string Cid { get; set; } = null!;
        public string RepairNum { get; set; } = null!;
        public string? PartsName { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? CalculateChangeDate { get; set; }
        public int? ServiceLife { get; set; }
        public int? ChangeNum { get; set; }
        public string? PartsDetail { get; set; }
        public string? MarkLable { get; set; }
        public int? Price { get; set; }
        public string? ChangeReason { get; set; }
        public string? ChangePerson { get; set; }
        public string? Note { get; set; }
        public decimal? WorkTime { get; set; }
        public decimal? CaculateWorkTime { get; set; }
        public string? CountFlag { get; set; }
        public string? CreateAccount { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Stop { get; set; }
        public DateTime? StopTime { get; set; }
        public string? StopAccount { get; set; }
    }
}
