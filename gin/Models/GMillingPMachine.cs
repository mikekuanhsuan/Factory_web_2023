using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMillingPMachine
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public DateTime Ddate { get; set; }
        public int Dtime { get; set; }
        public DateTime DataTime { get; set; }
        public decimal? MotorPowerKwA { get; set; }
        public decimal? MotorPowerKwB { get; set; }
        public decimal? BucketElevatorA { get; set; }
        public decimal? OsepaCurrent { get; set; }
        public decimal? OsepaRpm { get; set; }
        public decimal? BagColletcotM1 { get; set; }
        public decimal? BagColletcotM2 { get; set; }
        public decimal? BagColletcotS { get; set; }
        public decimal? TeMillAirA { get; set; }
        public decimal? TeMillRawA { get; set; }
        public decimal? TeMillAirB { get; set; }
        public decimal? TeMillRawB { get; set; }
        public decimal? TeSIn { get; set; }
        public decimal? WpMillA { get; set; }
        public decimal? WpMillB { get; set; }
        public decimal? WpOsepa { get; set; }
        public decimal? WpBcSIn { get; set; }
        public decimal? WpBcSDiff { get; set; }
        public decimal? OpBcM1 { get; set; }
        public decimal? OpBcM2 { get; set; }
        public decimal? OpBcS { get; set; }
        public decimal? WM1AP { get; set; }
        public decimal? WM1BP { get; set; }
        public decimal? WM2AP { get; set; }
        public decimal? WM2BP { get; set; }
    }
}
