using gin.Models;

namespace gin.ViewModel
{
    public class AdminRole
    {
        public List<WWebPage> wWebPages { get; set; }
        public List<WSubPage> wSubPages { get; set; }
        public List<WLoginGroupRight> wLoginGroupRights { get; set; }

    }
}
