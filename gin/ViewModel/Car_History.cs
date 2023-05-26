using gin.Models;
using System.ComponentModel.DataAnnotations;

namespace gin.ViewModel
{
    public class Car_History
    {
        
        public List<OccDespatch> occDespatches { get; set; }
        public List<hatlist> hat { get; set; }
    }

    public class hatlist { 
        public string workId { get; set; }
        public string hat { get; set; }
        public string shake { get; set; }
    }
}
