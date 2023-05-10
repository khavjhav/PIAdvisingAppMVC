using Syncfusion.EJ2.Base;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using PIAdvisingApp.ViewModels;
using PIAdvisingApp.Models;

namespace PIAdvisingApp.Controllers
{
  public class DataGridController : Controller
  {
	    private readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
	        return View();
        }
        public ActionResult UrlDatasource(DataManagerRequest dm)
        {

            IEnumerable DataSource = db.ApiDatas.ToList();

            DataOperations operation = new DataOperations();   
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
               DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
			if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
			    DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<ApiData>().Count();
            if (dm.Skip != 0)//Paging
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);         
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }, JsonRequestBehavior.AllowGet) : Json(DataSource);
        }
   }
}