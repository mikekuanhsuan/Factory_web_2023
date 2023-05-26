using DocumentFormat.OpenXml.Drawing.Charts;
using gin.Models;
using NuGet.Protocol;

namespace gin.ViewModel
{
    public class TotalPower
    {
        public string factoryId { get; set; }
        public string contract { get; set; }
        public string halfpeak { get; set; }
        public string peak { get; set; }
        public string sixpeak { get; set; }
        public string offpeak { get; set; }
        public string halfpeakk { get; set; }
        public string peakk { get; set; }
        public string sixpeakk { get; set; }
        public string offpeakk { get; set; }
        public double seid { get; set; }
        public double seid2 { get; set; }
        public string v { get; set; }
        public string v2 { get; set; }
        public string solarenergy { get; set; }
        public string solarenergy2 { get; set; }
        public string factoryPower { get; set; }
        public string airtotal { get; set; }
        public List<GPowerM> GPowerM { get; set; }
        public string[] millChart { get; set; }
        public string[] millNameChart { get; set; }
        
        //public DateTime FirstDay { get; set; }
        //public DateTime LastDay { get; set; }
        //public string nowwDay { get; set; }
        //public double totalDay { get; set; }



    }
}
