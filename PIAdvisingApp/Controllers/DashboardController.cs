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
        [HttpGet]
        public ActionResult Index()
        {
            int repId = 37; // Set the repId value manually
            var dashboardData = _dashboardService.GetDashboard(repId);

            var customerLcData = dashboardData
                .GroupBy(item => item.CustomerName)
                .Select(group => new
                {
                    CustomerName = group.Key,
                    TotalBookingVal = group.Sum(item => item.TotalBookingVal),
                    Totallcbalance = group.Sum(item => item.Totallcbalance)
                })
                .ToList();

            ViewBag.customerLcData = customerLcData;
            return View(dashboardData);
        }


    }
}
