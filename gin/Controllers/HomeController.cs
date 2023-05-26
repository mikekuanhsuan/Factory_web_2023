using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using gin.Models;
using gin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Reflection.PortableExecutable;
    
namespace gin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZDBContext _zdbContext;
        public HomeController(ILogger<HomeController> logger, ZDBContext zdbContext)
        {
            _logger = logger;
            _zdbContext = zdbContext;
        }

       

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Login") == "true")
            {
                return View();
            }
            else
            {
                return Redirect("/Login/LoginList");
            }

        }

        public IActionResult test()
        {
            return View();
        }
        public IActionResult test2()
        {
      
            var startTimeParam = new SqlParameter("@STime", SqlDbType.DateTime) { Value = DateTime.Parse("2023-04-06") };
            var endTimeParam = new SqlParameter("@ETime", SqlDbType.DateTime) { Value = DateTime.Parse("2023-04-07") };
            var factoryIdParam = new SqlParameter("@FactoryID", SqlDbType.NVarChar) { Value = "KY-T1HIST" };
            var tagNameParam = new SqlParameter("@TagName", SqlDbType.NVarChar) { Value = "HPA-1_A" };
            var result = _zdbContext.GMMs.FromSqlRaw("EXECUTE dbo.h_GetTagValueList @STime, @ETime, @FactoryID, @TagName", startTimeParam, endTimeParam, factoryIdParam, tagNameParam).ToList();
            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}