using gin.Models;

namespace gin.ViewModel
{
    public class AirCompViewModel
    {
        public string[] Avg { get; set; }
        public string[] specificPower { get; set; }
        public string[] dateTime { get; set; }
        public List<GAirComp> airComp { get; set; }
    }
}
