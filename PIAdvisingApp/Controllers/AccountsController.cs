using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using PIAdvisingApp.Models;

namespace PIAdvisingApp.Controllers
{


    public class AccountsController : Controller
    {



        SysUserInfo db = new SysUserInfo();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = db.Users.Any(x => x.UserName == credentials.UserName && x.UserPWD == credentials.UserPWD);
            LoginViewModel u= db.Users.FirstOrDefault(x => x.UserName == credentials.UserName && x.UserPWD == credentials.UserPWD);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(credentials.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(credentials);
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
    }
}
