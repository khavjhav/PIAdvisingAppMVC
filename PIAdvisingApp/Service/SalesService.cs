using BudgetCubeApp.Models;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.Service
{
    public class SalesService
    {

        //public List<string> GetAssetNameList(string assetGroupId, string costCenterId)
        //{
        //    using (var ctx = new BudgetCubeEntities())
        //    {
        //        return ctx.prcGetAssetTypeByAssetGroupId(costCenterId, assetGroupId).ToList();
        //    }
        //}

        public List<PrcRptLcNotReceived> LcNotReceived()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var budgetYearParameter = new SqlParameter("@BudgetYear", budgetYear);
                //var versionNoParameter = new SqlParameter("@versionNo", versionNo);
                //var result = ctx.Database
                //    .SqlQuery<CombinedOpexBudgetFinalizationStatus>("EXEC prcRpt @BudgetYear, @versionNo", budgetYearParameter, versionNoParameter)
                //    .ToList();
                var result = ctx.Database
                   .SqlQuery<PrcRptLcNotReceived>("EXEC PrcRptLCNotRecevd '01-oct-2022','09-jan-2023',1,0,0,0,0,null,1,0")
                   .ToList();

                return result;
            }
        }

        public List<PrcRptLcNotReceived> AdvisePI()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                   .SqlQuery<PrcRptLcNotReceived>("EXEC PrcAdvisePI '01-dec-2022','01-jan-2023',1,0,0,0,0,null,1,0")
                   .ToList();

                return result;
            }
        }

        public List<PrcRptLcNotReceived> BondApprovedPi()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                   .SqlQuery<PrcRptLcNotReceived>("EXEC PrcAdvisePI '01-dec-2022','01-jan-2023',1,0,0,0,0,null,1,0")
                   .ToList();

                return result;
            }
        }
    }
}