using PIAdvisingApp.Models;
using PIAdvisingApp.Service;
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
        public readonly SalesService _ssService;

        //public ActionResult Index()
        ////{
        ////    return View();
        ////}
        public HomeController()
        {
            _ssService = new SalesService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            int repId = 37; // Set the repId value manually
            var dashboardData = _ssService.GetDashboardForRep(repId);

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


        public ActionResult Login()
        {
            return View();
        }

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