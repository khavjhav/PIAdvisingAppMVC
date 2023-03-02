using PIAdvisingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIAdvisingApp.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesService _salesService;


        public SalesController()
        {
            _salesService = new SalesService();
        }
        // GET: Sales
        public ActionResult LcNotRecieved()
        {
            var lcNotReceived = _salesService.LcNotReceived();
            return View(lcNotReceived);
        }

        public ActionResult AdvisePi()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }

        public ActionResult BondApprovedPi()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }
    }
}