using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace gin.ViewModel
{
    public class CreatePowerExcel
    {
        public string factory { set; get; }
        public List<string> checkBox { set; get; }
        public List<string> power { set; get; }

        public List<string> date { set; get; }
        public string day { get; set; }
    }
}
