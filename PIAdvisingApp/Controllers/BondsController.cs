using PIAdvisingApp.Models;
using PIAdvisingApp.Service;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace PIAdvisingApp.Controllers
{
    [Authorize]
    public class BondsController : Controller
    {
        private readonly BondsService _bondsService;

        public BondsController()
        {
            _bondsService = new BondsService();
        }

        [HttpGet]
        public ActionResult PiAdvisingBond()
        {
            //List<PiAdvisingBond> bondList = _bondsService.GetPiAdvisingBondList();
            //return View("Sales/PiAdvisingBond", bondList);
            var bondList = _bondsService.GetPiAdvisingBondList();
            return View(bondList);
        }

        public ActionResult ApprovedPiFromBond()
        {
            //List<PiAdvisingBond> bondList = _bondsService.GetPiAdvisingBondList();
            //return View("Sales/PiAdvisingBond", bondList);
            var bondList = _bondsService.GetPiAdvisingBondListApproved();
            return View(bondList);
        }


        [HttpGet]
        public ActionResult GetBondModal(string apiNumber)
        {
            //List<BondDataVm> bondData = _bondsService.GetBondModal(apiNumber);
            //return PartialView("_GetBondPartial", bondData);
            List<BondDataVm> bondData = _bondsService.GetBondModal(apiNumber);

            // Assigning a unique identifier to each row in the bondData list
            for (int i = 0; i < bondData.Count; i++)
            {
                bondData[i].RowId = i; // Using the index as the unique identifier
            }

            return PartialView("_GetBondPartial", bondData);
        }

        public ActionResult ProductAll(int? bookingSubId)
        {
            ProductViewModel productData = null;
            if (bookingSubId.HasValue)
            {
                productData = _bondsService.GetProductByBookingSubId(bookingSubId.Value);
            }

            ViewBag.BookingSubId = bookingSubId;

            return View(productData);
        }

        //public ActionResult EditProduct(int bookingSubId)
        //{
        //    // Get the product data for the specified BookingSubId from your service or database
        //    ProductViewModel productData = _bondsService.GetProductByBookingSubId(bookingSubId);

        //    return PartialView("_EditProduct", productData);
        //}
        public ActionResult EditProduct(int rowNumber)
        {
            // Fetch the data for the specified RowNumber from your service or database
            BondDataVm rowData = _bondsService.GetRowByRowNumber(rowNumber);

            return PartialView("_EditProduct", rowData);
        }

        public ActionResult AddProduct(ProductViewModel newProduct)
        {
            // Add the new product to your database using your service or data access logic
            // For example: _bondsService.AddNewProduct(newProduct);

            // After adding, you can redirect the user back to the main view or any other view
            return RedirectToAction("ProductAll");
        }


        public ActionResult BondData(string apiNumber)
        {
            // Assuming you have logic to retrieve the bond data based on the API number.
            // Here, you'll get the bond data and pass it to the view.
            var bondData = _bondsService.GetBondModal(apiNumber);

            // Assigning a unique identifier to each row in the bondData list
            for (int i = 0; i < bondData.Count; i++)
            {
                bondData[i].RowId = i; // Using the index as the unique identifier
            }
            ViewBag.ProductNameList = _bondsService.GetProductDropdownList();
            return View("BondData", bondData);

        }

        //public ActionResult LoadProductAddModal()
        //{
        //    return PartialView("_ProductAdd");
        //}
        [HttpGet]
        public ActionResult GetProductName()
        {
            var productNameList = _bondsService.GetProductDropdownList();
            ViewBag.ProductNameList = productNameList;
            return View();
        }


        [HttpPost]
        public ActionResult ProductForm(ProductFormVm model)
        {
            if (ModelState.IsValid)
            {
                // Save the selected product ID and proceed to display other fields.
                var productId = model.SelectedProductId;
                // Use the product ID to fetch combination and weight dropdown lists.
                var combinationDropdownList = _bondsService.GetCombinationDropdownList(productId);
                var weightDropdownList = _bondsService.GetWeightDropdownList(productId);

                // Update the model with fetched dropdown lists.
                model.CombinationDropdownList = combinationDropdownList;
                model.WeightDropdownList = weightDropdownList;
            }

            // Re-populate the product dropdown list.
            model.ProductDropdownList = _bondsService.GetProductDropdownList();
            return View(model);
        }

        //public ActionResult ClauseDetails()
        //{
        //    var clauseDetails = _bondsService.GetAllClauseDetails();
        //    return View(clauseDetails);
        //}


        [HttpPost]
        public ActionResult SaveApiFromBond(SaveApiFromBondRequest request)
        {
            int rowAffected = _bondsService.SaveApiFromBond(request);
            return Json(rowAffected);
        }

        [HttpPost]
        public JsonResult GetCombination(int productId)
        {
            var result = _bondsService.GetCombinationDropdownList(productId);
            return Json(result);
        }
    }
}
