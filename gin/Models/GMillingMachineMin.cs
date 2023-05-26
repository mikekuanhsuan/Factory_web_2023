using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMillingMachineMin
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public DateTime DataTime { get; set; }
        public decimal? MotorCurrentA { get; set; }
        public decimal? MotorCurrentB { get; set; }
        public decimal? MotorPowerKwA { get; set; }
        public decimal? MotorPowerKwB { get; set; }
        public decimal? BucketElevatorA { get; set; }
        public decimal? BucketElevatorB { get; set; }
        public decimal? OsepaCurrent { get; set; }
        public decimal? OsepaRpm { get; set; }
        public decimal? BagColletcotM1 { get; set; }
        public decimal? BagColletcotM2 { get; set; }
        public decimal? BagColletcotS { get; set; }
        public decimal? TeMillBearingInA { get; set; }
        public decimal? TeMillBearingOutA { get; set; }
        public decimal? TeMillBearingOilInA { get; set; }
        public decimal? TeMillBearingOilOutA { get; set; }
        public decimal? TeMillBearingInB { get; set; }
        public decimal? TeMillBearingOutB { get; set; }
        public decimal? TeMillBearingOilInB { get; set; }
        public decimal? TeMillBearingOilOutB { get; set; }
        public decimal? TeMillRawA { get; set; }
        public decimal? TeMillAirA { get; set; }
        public decimal? TeMillRawB { get; set; }
        public decimal? TeMillAirB { get; set; }
        public decimal? TeSIn { get; set; }
        public decimal? TeProduct { get; set; }
        public decimal? TeMotor1A { get; set; }
        public decimal? TeMotor2A { get; set; }
        public decimal? TeMotor3A { get; set; }
        public decimal? TeMotor4A { get; set; }
        public decimal? TeMotor5A { get; set; }
        public decimal? TeMotor6A { get; set; }
        public decimal? TeMotor1B { get; set; }
        public decimal? TeMotor2B { get; set; }
        public decimal? TeMotor3B { get; set; }
        public decimal? TeMotor4B { get; set; }
        public decimal? TeMotor5B { get; set; }
        public decimal? TeMotor6B { get; set; }
        public decimal? WpMillA { get; set; }
        public decimal? WpMillB { get; set; }
        public decimal? WpOsepa { get; set; }
        public decimal? WpBcSIn { get; set; }
        public decimal? WpBcSDiff { get; set; }
        public decimal? RpmBcM1 { get; set; }
        public decimal? RpmBcM2 { get; set; }
        public decimal? RpmBcS { get; set; }
        public decimal? OpBcM1 { get; set; }
        public decimal? OpBcM2 { get; set; }
        public decimal? OpBcS { get; set; }
        public decimal? WM1AP { get; set; }
        public decimal? WM1AC { get; set; }
        public decimal? WM1AQ { get; set; }
        public decimal? WM1BP { get; set; }
        public decimal? WM1BC { get; set; }
        public decimal? WM1BQ { get; set; }
        public decimal? WM2AP { get; set; }
        public decimal? WM2AC { get; set; }
        public decimal? WM2AQ { get; set; }
        public decimal? WM2BP { get; set; }
        public decimal? WM2BC { get; set; }
        public decimal? WM2BQ { get; set; }
    }
}
