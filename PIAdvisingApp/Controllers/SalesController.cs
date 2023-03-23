using PIAdvisingApp.Models;
using PIAdvisingApp.Service;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                advicePi = (List<PrcRptLcNotReceived>)advicePi.Where(x => x.CustomerName == customerName);
            }

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

        public ActionResult PiAdvisingBond()
        {
            var advicePi = _salesService.GetPiAdvisingBondData();
            return View(advicePi);

        }  
        
        public ActionResult GetPamModalBondPartial(string apiNumber)
        {
            var result = _salesService.GetPamModalBond(apiNumber);
            return PartialView("_GetPamModalBondPartial", result);

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
        //public ActionResult PiAdvisingBond(PiAdvisingBondViewModel item)
        //{
        //    List<PrcRptLcNotReceived> model = new List<PrcRptLcNotReceived>();

        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PiAdvisingDbContext"].ConnectionString))
        //    {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand("SELECT pam.ApiNumber, pam.BookingNo, pam.InvoiceQty, vq.QuantityUnit, ps.Measurement, vm.MeasureUnit, pc.CategoryName,pd.ProductName, pd.BondName, pd.HSCode, cgi.CustomerName, rp.ShortName  FROM dbo.PiAdvisingBondMain AS pam LEFT JOIN dbo.PIMain AS pm ON pm.BookingNo = pam.BookingNo LEFT JOIN dbo.PISub AS ps ON ps.PIId = pm.PIId LEFT JOIN dbo.Product AS pd ON pd.ProductId = ps.ProductId LEFT JOIN dbo.ProductCategory AS pc ON pc.CategoryId = pd.CategoryId LEFT JOIN dbo.viewMeasurementUnit AS vm ON vm.MeasureUnitId = ps.MeasureUnitId LEFT JOIN dbo.viewQuantityUnit AS vq ON vq.QuantityUnitId = ps.QuantityUnitId LEFT JOIN dbo.CompanyInfo AS ci ON ci.CompanyId = pm.CompanyId LEFT JOIN dbo.CustomerGenInfo AS cgi ON cgi.CustomerId = pm.CustomerId LEFT JOIN dbo.Representative AS rp ON rp.RepresentativeId = pm.RepresentativeId", conn);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            PiAdvisingBondViewModel newitem = new PiAdvisingBondViewModel();

        //            item.ApiNumber = reader.GetString(0);
        //            item.BookingNo = reader.GetString(1);
        //            item.InvoiceQty = reader.GetDecimal(2);
        //            item.QuantityUnit = reader.GetString(3);
        //            item.Measurement = reader.GetString(4);
        //            item.MeasureUnit = reader.GetString(5);
        //            item.CategoryName = reader.GetString(6);
        //            item.ProductName = reader.GetString(7);
        //            item.BondName = reader.GetString(8);
        //            item.HSCode = reader.GetString(9);
        //            item.CustomerName = reader.GetString(10);
        //            item.RepName = reader.GetString(11);

        //            model.Add(newitem);
        //        }

        //        reader.Close();
        //        conn.Close();
        //    }

        //    return View(model);
        //}

        public ActionResult BondApprovedPi()
        {
            var advicePi = _salesService.AdvisePI();
            return View(advicePi);
        }

        public ActionResult PiAdvisingBondService()
        {
            var advicePi = _salesService.GetPiAdvisingBondData();
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