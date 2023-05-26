using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gin.Models
{
    public partial class GMillingMachine
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public DateTime Ddate { get; set; }
        public int Dtime { get; set; }
        public DateTime DataTime { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? MotorCurrentA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? MotorCurrentB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? MotorPowerKwA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? MotorPowerKwB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? BucketElevatorA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? BucketElevatorB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? OsepaCurrent { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? OsepaRpm { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? BagColletcotM1 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? BagColletcotM2 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? BagColletcotS { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingInA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOutA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOilInA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOilOutA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingInB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOutB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOilInB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillBearingOilOutB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillRawA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillAirA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillRawB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMillAirB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeSIn { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeProduct { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor1A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor2A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor3A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor4A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor5A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor6A { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor1B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor2B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor3B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor4B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor5B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? TeMotor6B { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WpMillA { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WpMillB { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WpOsepa { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WpBcSIn { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WpBcSDiff { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? RpmBcM1 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? RpmBcM2 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? RpmBcS { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? OpBcM1 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? OpBcM2 { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? OpBcS { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1AP { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1AC { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1AQ { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1BP { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1BC { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM1BQ { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2AP { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2AC { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2AQ { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2BP { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2BC { get; set; }
        [DisplayFormat(NullDisplayText = "0.00")]
        public decimal? WM2BQ { get; set; }
    }
}