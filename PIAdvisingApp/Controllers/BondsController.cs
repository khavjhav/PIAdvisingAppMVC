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
    public class BondsController : Controller
    {
        private readonly BondsService _bondsService;

        // GET: Bonds
        public BondsController()
        {
            _bondsService = new BondsService();
    }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //public List<BondApprovalViewModel> BondApprovalView()
        //{
        //    //using (var ctx = new ApplicationDbContext())
        //    //{
        //    //   var adviseBond= _bondsService.
        //    //    return View();
        //    //}
        //}
    }
}