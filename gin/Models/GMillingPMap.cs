using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class GMillingPMap
    {
        public string FactoryId { get; set; } = null!;
        public string MillId { get; set; } = null!;
        public string? MotorPowerKwA { get; set; }
        public string? MotorPowerKwB { get; set; }
        public string? BucketElevatorA { get; set; }
        public string? OsepaCurrent { get; set; }
        public string? OsepaRpm { get; set; }
        public string? BagColletcotM1 { get; set; }
        public string? BagColletcotM2 { get; set; }
        public string? BagColletcotS { get; set; }
        public string? TeMillAirA { get; set; }
        public string? TeMillRawA { get; set; }
        public string? TeMillAirB { get; set; }
        public string? TeMillRawB { get; set; }
        public string? TeSIn { get; set; }
        public string? WpMillA { get; set; }
        public string? WpMillB { get; set; }
        public string? WpOsepa { get; set; }
        public string? WpBcSIn { get; set; }
        public string? WpBcSDiff { get; set; }
        public string? OpBcM1 { get; set; }
        public string? OpBcM2 { get; set; }
        public string? OpBcS { get; set; }
        public string? WM1AP { get; set; }
        public string? WM1BP { get; set; }
        public string? WM2AP { get; set; }
        public string? WM2BP { get; set; }
    }
}
