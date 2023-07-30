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


    public class CmController :Controller
    {
        private readonly CmService _cmService;

        public CmController()
        {
            _cmService = new CmService();
        }

        [HttpGet]
        public ActionResult CmApproval()
        {
            //List<PiAdvisingBond> bondList = _bondsService.GetPiAdvisingBondList();
            //return View("Sales/PiAdvisingBond", bondList);
            var cmList = _cmService.GetPiAdvisingBondListForCm();
            return View(cmList);
        }


        public ActionResult CmApprovedPi()
        {
            //List<PiAdvisingBond> bondList = _bondsService.GetPiAdvisingBondList();
            //return View("Sales/PiAdvisingBond", bondList);
            var cmList = _cmService.GetPiAdvisingBondListForCm();
            return View(cmList);
        }
    }
}