using PIAdvisingApp.Models;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.Service
{
    public class DashboardService
    {
        private readonly ApplicationDbContext _context;



 

        public List<DashboardViewModel> GetDashboard(int repId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                    .SqlQuery<DashboardViewModel>($"EXEC PrdGetDashboardForRep @RepId = {repId}")
                    .ToList();

                return result;
            }
        }



    }
}
