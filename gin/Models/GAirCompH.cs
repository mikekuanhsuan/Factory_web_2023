using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gin.Models
{
    public partial class GAirCompH
    {
        public string FactoryId { get; set; } = null!;
        public string Mid { get; set; } = null!;
        public DateTime DataDate { get; set; }
        public int Dhour { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd HH:mm}")]
        public DateTime Dtime { get; set; }
        public decimal? SpecificPower { get; set; }
        public decimal? AirConsumption { get; set; }
        public decimal? AirAcc01 { get; set; }
        public decimal? AirAcc02 { get; set; }
        public decimal? PowerC { get; set; }
        public decimal? PowerC01 { get; set; }
        public decimal? PowerC02 { get; set; }
        public decimal? PowerC03 { get; set; }
        public decimal? PowerC04 { get; set; }
        public decimal? PowerC05 { get; set; }
        public decimal? PowerCh01 { get; set; }
        public decimal? PowerCh02 { get; set; }
        public decimal? PowerCh03 { get; set; }
        public decimal? PowerCh04 { get; set; }
        public decimal? PowerCh05 { get; set; }
        public decimal? Power01 { get; set; }
        public decimal? Power02 { get; set; }
        public decimal? Power03 { get; set; }
        public decimal? Power04 { get; set; }
        public decimal? Power05 { get; set; }
        public decimal? WorkTime01 { get; set; }
        public decimal? WorkTime02 { get; set; }
        public decimal? WorkTime03 { get; set; }
        public decimal? WorkTime04 { get; set; }
        public decimal? WorkTime05 { get; set; }
    }
}
