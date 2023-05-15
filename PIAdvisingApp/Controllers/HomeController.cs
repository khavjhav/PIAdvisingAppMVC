using PIAdvisingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIAdvisingApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        loginEntities db = new loginEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(SysUserInfo log)
        //{

        //    var SysUserInfo = db.sysUserInfo.Where(x => x.UserName == log.UserName && x.UserPWD == log.UserPWD).Count();
        //    if (SysUserInfo > 0 )
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
                
        //}

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}