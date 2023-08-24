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
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;

        public DashboardController()
        {
            _dashboardService = new DashboardService();
        }
        // GET: Dashboard
        //[HttpGet]
        //public ActionResult Test(int repId)
        //{
        //    var dashboardData = _dashboardService.GetDashboardForRep(repId);

        //    //if (dashboardData == null || dashboardData.Count == 0)
        //    //{
        //    //    ViewBag.Message = "No data available for this user.";
        //    //    return View(new List<DashboardViewModel>()); // Return an empty list to the view
        //    //}

        //    return View(dashboardData);
        //}


    }
}
