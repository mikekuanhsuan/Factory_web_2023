using System.ComponentModel.DataAnnotations;

namespace gin.ViewModel
{
    public class PowerDViewModel
    {

        public DateTime dTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd}")]
        public DateTime DataDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerCTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC01 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC02 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC03 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC04 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC05 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC06 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC07 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0;0}")]
        public decimal? PowerC08 { get; set; }
    }
}
