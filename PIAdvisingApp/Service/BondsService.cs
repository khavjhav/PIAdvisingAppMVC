
using PIAdvisingApp.Models;
using PIAdvisingApp.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace PIAdvisingApp.Service
{
    public class BondsService
    {
         public List<PiAdvisingBondViewModel> GetPamModalBond(string apiNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database.SqlQuery<PiAdvisingBondViewModel>(@"EXEC GetPamModalBond  @ApiNumber",
                    new SqlParameter("ApiNumber", apiNumber)).ToList();

                return result;
            }
        }


    }
}