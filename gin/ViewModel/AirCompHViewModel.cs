using gin.Models;

namespace gin.ViewModel
{
    public class AirCompHViewModel
    {
        public string[] Avg { get; set; }
        public string[] specificPower { get; set; }
        public string[] dateTime { get; set; }
        public List<GAirCompH> airCompH { get; set; }
    }
}
