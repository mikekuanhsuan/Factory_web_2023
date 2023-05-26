using Microsoft.AspNetCore.Mvc;

using System.DirectoryServices.Protocols;
using System.Net;

namespace gin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginList()
        {
            return View();
        }

    }
}
