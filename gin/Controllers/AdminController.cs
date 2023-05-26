using DocumentFormat.OpenXml.Office2010.Excel;
using gin.Models;
using gin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace gin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public AdminController(ZDBContext context)
        {
            _ZDBContext = context;
        }
        [Authorize(Roles = "admin")]
        public IActionResult User_list()
        {
            var data = _ZDBContext.WLoginUsers;
            return View(data);
        }
        [Authorize(Roles = "admin")]
        //管理者-修改權限
        public IActionResult Edit(string id)
        {
            var name = _ZDBContext.WLoginUsers.Where(x => x.Account == id).FirstOrDefault();
            
            ViewBag.Name = name.UserName;
            ViewBag.account = id;

            AdminRole adminRole = new AdminRole();

            List<WWebPage> webPages = new List<WWebPage>();
            List<WSubPage> subPages = new List<WSubPage>();
            List<WLoginGroupRight> wLoginGroupRights = new List<WLoginGroupRight>();

            var web = _ZDBContext.WWebPages.OrderBy(x => x.OrderById).ToList();
            foreach (var i in web)
            {
                WWebPage wWebPage = new WWebPage();
                wWebPage.WebId = i.WebId;
                wWebPage.WebName = i.WebName;
                webPages.Add(wWebPage);
            }
            var sub = _ZDBContext.WSubPages;
            foreach (var i in sub)
            {
                WSubPage wSubPage = new WSubPage();
                wSubPage.SubId = i.SubId;
                wSubPage.SubName = i.SubName;
                wSubPage.WebId = i.WebId;
                subPages.Add(wSubPage);
            }
            var right = _ZDBContext.WLoginGroupRights.Where(x => x.Account == id).ToList();
            foreach (var i in right)
            {
                WLoginGroupRight wLogin = new WLoginGroupRight();
                wLogin.FactoryId = i.FactoryId;
                wLogin.SubId = i.SubId;
                wLogin.RightId = i.RightId;
                wLoginGroupRights.Add(wLogin);
            }
            adminRole.wSubPages = subPages;
            adminRole.wWebPages = webPages;
            adminRole.wLoginGroupRights = wLoginGroupRights;

            return View(adminRole);
        }
        //使用者權限申請
        [Authorize]
        public IActionResult Role_apply()
        {
            string account = HttpContext.Session.GetString("Account");
            if (account == "")
            {
                return RedirectToAction("loginlist", "login");
            }
            //System.Diagnostics.Debug.WriteLine("---------------------------------------------------" + account);

            else { 
                var name = _ZDBContext.WLoginUsers.Where(x => x.Account == account).FirstOrDefault();
                ViewBag.Name = name.UserName;
                ViewBag.account = account;

                AdminRole adminRole = new AdminRole();

                List<WWebPage> webPages = new List<WWebPage>();
                List<WSubPage> subPages = new List<WSubPage>();
                List<WLoginGroupRight> wLoginGroupRights = new List<WLoginGroupRight>();

                var web = _ZDBContext.WWebPages.OrderBy(x => x.OrderById).ToList();
                foreach (var i in web)
                {
                    if (i.State != 0)
                    {
                        WWebPage wWebPage = new WWebPage();
                        wWebPage.WebId = i.WebId;
                        wWebPage.WebName = i.WebName;
                        webPages.Add(wWebPage);
                    }
                }
                var sub = _ZDBContext.WSubPages.ToList();
                foreach (var i in sub)
                {
                    WSubPage wSubPage = new WSubPage();
                    wSubPage.SubId = i.SubId;
                    wSubPage.SubName = i.SubName;
                    wSubPage.WebId = i.WebId;
                    subPages.Add(wSubPage);
                }
                var right = _ZDBContext.WLoginGroupRights.Where(x => x.Account == account).ToList();
                foreach (var i in right)
                {
                    WLoginGroupRight wLogin = new WLoginGroupRight();
                    wLogin.FactoryId = i.FactoryId;
                    wLogin.SubId = i.SubId;
                    wLogin.RightId = i.RightId;
                    wLoginGroupRights.Add(wLogin);
                }
                adminRole.wSubPages = subPages;
                adminRole.wWebPages = webPages;
                adminRole.wLoginGroupRights = wLoginGroupRights;

                return View(adminRole);
            }
        }
    }
}
