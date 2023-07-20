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
        [HttpPost]
        public ActionResult SaveApiFromBond(SaveApiFromBondRequest request)
        {
            int rowAffected = _bondsService.SaveApiFromBond(request);
            return Json(rowAffected);
        }
    }
}
