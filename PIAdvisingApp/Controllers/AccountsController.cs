using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using PIAdvisingApp.Models;
using PIAdvisingApp.Service;
using PIAdvisingApp.ViewModels;

namespace PIAdvisingApp.Controllers
{


    public class AccountsController : Controller
    {

        private readonly UserService _userService;

        public AccountsController()
        {
            _userService = new UserService();
        }

        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            var user = _userService.Login(credentials.UserName,credentials.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(credentials.UserName, false);
                Response.Cookies["UserName"].Value = user.UserName;
                Response.Cookies["UserTitle"].Value = user.UserTitle;
                Response.Cookies["EmployeeId"].Value = user.EmployeeId.ToString();

                //string cookievalue;
                //if (Request.Cookies["UserName"] != null)
                //{
                //    cookievalue = Request.Cookies["cookie"].Value.ToString();
                //}
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(credentials);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["UserName"].Value = null;
            Response.Cookies["UserTitle"].Value = null;
            Response.Cookies["EmployeeId"].Value = null;

            return RedirectToAction("Login", "Accounts");
        }
    }
}
