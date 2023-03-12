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
    public class SalesService
    {

        //public List<string> GetAssetNameList(string assetGroupId, string costCenterId)
        //{
        //    using (var ctx = new BudgetCubeEntities())
        //    {
        //        return ctx.prcGetAssetTypeByAssetGroupId(costCenterId, assetGroupId).ToList();
        //    }
        //}

        //public List<PrcRptLcNotReceived> LcNotReceived()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        //var budgetYearParameter = new SqlParameter("@BudgetYear", budgetYear);
        //        //var versionNoParameter = new SqlParameter("@versionNo", versionNo);
        //        //var result = ctx.Database
        //        //    .SqlQuery<CombinedOpexBudgetFinalizationStatus>("EXEC prcRpt @BudgetYear, @versionNo", budgetYearParameter, versionNoParameter)
        //        //    .ToList();
        //        var result = ctx.Database
        //           .SqlQuery<PrcRptLcNotReceived>("EXEC PrcRptLCNotRecevd '01-oct-2022','03-jan-2023',1,0,0,0,0,null,1,0")
        //           .ToList();

        //        return result;
        //    }
        //}

        public List<PrcRptLcNotReceived> LcNotReceived(DateTime? fromDate, DateTime? toDate, int productCatId = 0, int locationId = 0, int customerId = 0, int repId = 0, int teamId = 0, string contractName = "", int userID = 1, int retailerId = 0)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                    .SqlQuery<PrcRptLcNotReceived>("EXEC PrcRptLCNotRecevd @fromDate, @toDate, @productCatId, @locationId, @customerId, @repId, @teamId, @contractName, @userID, @retailerId ",
                        new SqlParameter("fromDate", fromDate),
                        new SqlParameter("toDate", toDate),
                        new SqlParameter("productCatId", productCatId),
                        new SqlParameter("locationId", locationId),
                        new SqlParameter("customerId", customerId),
                        new SqlParameter("repId", repId),
                        new SqlParameter("teamId", teamId),
                        new SqlParameter("contractName", contractName),
                        new SqlParameter("userID", userID),
                        new SqlParameter("retailerId", retailerId)
                        )
                    .ToList();

                return result;
            }
        }


        public List<PrcRptLcNotReceived> AdvisePI()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                   .SqlQuery<PrcRptLcNotReceived>("EXEC PrcAdvisePI '01-dec-2022','01-Jan-2023',0,0,0,50,0,null,1,0")
                   .ToList();

                return result;
            }
        }

        public List<PrcRptLcNotReceived> BondApprovedPi(DateTime? fromDate, DateTime? toDate, int productCatId = 0, int locationId = 0, int customerId = 0, int repId = 0, int teamId = 0, string contractName = "", int userID = 1, int retailerId = 0)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                      .SqlQuery<PrcRptLcNotReceived>("EXEC PrcRptLCNotRecevd @fromDate, @toDate, @productCatId, @locationId, @customerId, @repId, @teamId, @contractName, @userID, @retailerId ",
                          new SqlParameter("fromDate", fromDate),
                          new SqlParameter("toDate", toDate),
                          new SqlParameter("productCatId", productCatId),
                          new SqlParameter("locationId", locationId),
                          new SqlParameter("customerId", customerId),
                          new SqlParameter("repId", repId),
                          new SqlParameter("teamId", teamId),
                          new SqlParameter("contractName", contractName),
                          new SqlParameter("userID", userID),
                          new SqlParameter("retailerId", retailerId)
                          )
                      .ToList();

                return result;
            }
        }

        public List<PrcRptLcNotReceived> SavePiAdvisingBondMain(PiAdvisingBondMain piAdvisingBondMain)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = "INSERT INTO dbo.PiAdvisingBondMain VALUES (@BookingNo, @InvoiceQty, @InvoiceValue, @BookingDate, @Specification, @Size, @BondName, @Category, @ApiNumber)";
                var result = ctx.Database
                    .SqlQuery<PrcRptLcNotReceived>(query,
                        new SqlParameter("BookingNo", piAdvisingBondMain.BookingNo),
                        new SqlParameter("InvoiceQty", piAdvisingBondMain.InvoiceQty),
                        new SqlParameter("InvoiceValue", piAdvisingBondMain.Value),
                        new SqlParameter("BookingDate", piAdvisingBondMain.BookingDate),
                        new SqlParameter("Specification", piAdvisingBondMain.Specification),
                        new SqlParameter("Size", piAdvisingBondMain.Size),
                        new SqlParameter("BondName", piAdvisingBondMain.BondName),
                        new SqlParameter("Category", piAdvisingBondMain.Category),
                        new SqlParameter("ApiNumber", piAdvisingBondMain.ApiNumber)
                        )
                    .ToList();

                return result;
            }
        }
    }
}