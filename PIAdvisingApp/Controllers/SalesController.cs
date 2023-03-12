using PIAdvisingApp.Models;
using PIAdvisingApp.Service;
using PIAdvisingApp.ViewModels;
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

        [HttpGet]
        public ActionResult LcNotReceived(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = new DateTime(2022, 1, 1);
            }

            if (!toDate.HasValue)
            {
                toDate = new DateTime(2023, 12, 31);
            }

            var lcNotReceived = _salesService.LcNotReceived(fromDate.Value, toDate.Value);
            return View(lcNotReceived);
        }

        //public ActionResult LcNotReceived(DateTime? fromDate, DateTime? toDate, string customerName, string retailerName, string representativeName)
        //{
        //    var result = _salesService.LcNotReceived(fromDate,toDate);


        //    if (fromDate == null || toDate == null)
        //    {
        //        fromDate = DateTime.Today.AddMonths(-1);
        //        toDate = DateTime.Today;
        //    }

        //    var model = new List<PrcRptLcNotReceived>();

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.PrcRptLcNotReceived
        //            .Where(x => x.BookingDate >= fromDate && x.BookingDate <= toDate);

        //        if (!string.IsNullOrEmpty(customerName))
        //        {
        //            query = query.Where(x => x.CustomerName.Contains(customerName));
        //        }

        //        if (!string.IsNullOrEmpty(retailerName))
        //        {
        //            query = query.Where(x => x.RetailerName.Contains(retailerName));
        //        }

        //        if (!string.IsNullOrEmpty(representativeName))
        //        {
        //            query = query.Where(x => x.RepresentativeName.Contains(representativeName));
        //        }

        //        model = query.ToList();
        //    }

        //    return View(model);
        //}



        public ActionResult AdvisePi()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }

        public ActionResult AdvisePiUpdate()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }


        public ActionResult CmApproval()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }

        public ActionResult BondApprovedPiUpdate()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);

        }

        //public ActionResult BondApprovedPiUpdate()
        //{
        //    var advicePi = _salesService.AdvisePI();
        //    List<ParentModel> parentList = new List<ParentModel>();
        //    // Populate parentList with data

        //    var viewModel = new BondApprovedPiUpdateViewModel
        //    {
        //        AdvicePi = advicePi,
        //        ParentList = parentList
        //    };

        //    return View(viewModel);
        //}


        public ActionResult BondApprovedPi()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }
        [HttpPost]
        public ActionResult LoadPiAdvisingDataPartial(List<string> bookings)
        {
            ViewBag.AdviseNumber = "API-001234/50/23";
            return PartialView("_PiAdvisingDataPartial", bookings);
        }

        [HttpPost]
        public JsonResult SaveApiData(List<ApiData> apiDataList)
        {
            // generate a unique API number
            var apiNumber = "API-" + DateTime.Now.Ticks.ToString();
            int rowAffected = 0;
            // save each row to the database
            foreach (var apiData in apiDataList)
            {
                // create a new PiAdvisingBondMain object
                apiData.ApiNumber = apiNumber;
                rowAffected += _salesService.SavePiAdvisingBondMain(apiData);
            }

            return Json(true); 
        }
    }
}