using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMillingMachineMapping
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public string? MotorCurrentA { get; set; }
        public string? MotorCurrentB { get; set; }
        public string? MotorPowerKwA { get; set; }
        public string? MotorPowerKwB { get; set; }
        public string? BucketElevatorA { get; set; }
        public string? BucketElevatorB { get; set; }
        public string? OsepaCurrent { get; set; }
        public string? OsepaRpm { get; set; }
        public string? BagColletcotM1 { get; set; }
        public string? BagColletcotM2 { get; set; }
        public string? BagColletcotS { get; set; }
        public string? TeMillBearingInA { get; set; }
        public string? TeMillBearingOutA { get; set; }
        public string? TeMillBearingOilInA { get; set; }
        public string? TeMillBearingOilOutA { get; set; }
        public string? TeMillBearingInB { get; set; }
        public string? TeMillBearingOutB { get; set; }
        public string? TeMillBearingOilInB { get; set; }
        public string? TeMillBearingOilOutB { get; set; }
        public string? TeMillRawA { get; set; }
        public string? TeMillAirA { get; set; }
        public string? TeMillRawB { get; set; }
        public string? TeMillAirB { get; set; }
        public string? TeSIn { get; set; }
        public string? TeProduct { get; set; }
        public string? TeMotor1A { get; set; }
        public string? TeMotor2A { get; set; }
        public string? TeMotor3A { get; set; }
        public string? TeMotor4A { get; set; }
        public string? TeMotor5A { get; set; }
        public string? TeMotor6A { get; set; }
        public string? TeMotor1B { get; set; }
        public string? TeMotor2B { get; set; }
        public string? TeMotor3B { get; set; }
        public string? TeMotor4B { get; set; }
        public string? TeMotor5B { get; set; }
        public string? TeMotor6B { get; set; }
        public string? WpMillA { get; set; }
        public string? WpMillB { get; set; }
        public string? WpOsepa { get; set; }
        public string? WpBcSIn { get; set; }
        public string? WpBcSDiff { get; set; }
        public string? RpmBcM1 { get; set; }
        public string? RpmBcM2 { get; set; }
        public string? RpmBcS { get; set; }
        public string? OpBcM1 { get; set; }
        public string? OpBcM2 { get; set; }
        public string? OpBcS { get; set; }
        public string? WM1AP { get; set; }
        public string? WM1AC { get; set; }
        public string? WM1AC2 { get; set; }
        public string? WM1AQ { get; set; }
        public string? WM1BP { get; set; }
        public string? WM1BC { get; set; }
        public string? WM1BC2 { get; set; }
        public string? WM1BQ { get; set; }
        public string? WM2AP { get; set; }
        public string? WM2AC { get; set; }
        public string? WM2AC2 { get; set; }
        public string? WM2AQ { get; set; }
        public string? WM2BP { get; set; }
        public string? WM2BC { get; set; }
        public string? WM2BC2 { get; set; }
        public string? WM2BQ { get; set; }
    }
}
