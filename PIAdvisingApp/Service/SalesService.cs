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
       
            public List<PiAdvisingBondViewModel> GetPiAdvisingBondData()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var result = ctx.Database.SqlQuery<PiAdvisingBondViewModel>(@"
                SELECT pam.ApiNumber, pam.BookingNo, pam.InvoiceQty, vq.QuantityUnit, ps.Measurement, vm.MeasureUnit, pc.CategoryName,pd.ProductName, pd.BondName, pd.HSCode, cgi.CustomerName, rp.RepresentativeName 
                FROM dbo.PiAdvisingBondMain AS pam
                LEFT JOIN dbo.PIMain AS pm ON pm.BookingNo = pam.BookingNo
                LEFT JOIN dbo.PISub AS ps ON ps.PIId = pm.PIId
                LEFT JOIN dbo.Product AS pd ON pd.ProductId = ps.ProductId
                LEFT JOIN dbo.ProductCategory AS pc ON pc.CategoryId = pd.CategoryId
                LEFT JOIN dbo.viewMeasurementUnit AS vm ON vm.MeasureUnitId = ps.MeasureUnitId
                LEFT JOIN dbo.viewQuantityUnit AS vq ON vq.QuantityUnitId = ps.QuantityUnitId
                LEFT JOIN dbo.CompanyInfo AS ci ON ci.CompanyId = pm.CompanyId
                LEFT JOIN dbo.CustomerGenInfo AS cgi ON cgi.CustomerId = pm.CustomerId
                LEFT JOIN dbo.Representative AS rp ON rp.RepresentativeId = pm.RepresentativeId
            ").ToList();

                    return result;
                }
            }
        


        public int SavePiAdvisingBondMain(ApiData apiData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = "INSERT INTO dbo.PiAdvisingBondMain VALUES (@BookingNo, @InvoiceQty, @InvoiceValue, @ApiNumber, @ApiDate)";
                var result = ctx.Database
                    .ExecuteSqlCommand(query,
                        new SqlParameter("BookingNo", apiData.BookingNo),
                        new SqlParameter("InvoiceQty", apiData.InvoiceQty),
                        new SqlParameter("InvoiceValue", apiData.DelValue),
                        new SqlParameter("ApiNumber", apiData.ApiNumber),
                        new SqlParameter("ApiDate", DateTime.Now)
                        );

                return result;
            }
           
        }


    }
}