
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

        public List<PiAdvisingBond> GetPiAdvisingBondList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = @"
                SELECT
                    api.ApiNumber,cgi.CustomerName, rp.ShortName,
                    api.val,
                    api.qty,
                    CAST(apibk.EntryTime AS DATE) AS EntryDate,
                    STUFF((
                        SELECT ', ' + apibk.BookingNo
                        FROM dbo.ApiMainBond AS apibk
                        WHERE apibk.ApiNumber = api.ApiNumber
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS BookingNos,
                    apibk.Remarks
                FROM
                    (SELECT
                        ApiNumber,
                        SUM(BookingValue) AS val,
                        SUM(BookingQty) AS qty
                    FROM dbo.ApiMainBond
                    GROUP BY ApiNumber) AS api
                LEFT JOIN dbo.ApiMainBond AS apibk ON apibk.ApiNumber = api.ApiNumber
                LEFT JOIN dbo.CustomerGenInfo AS cgi ON cgi.CustomerId = apibk.CustomerId
				LEFT JOIN dbo.Representative AS rp ON rp.EmployeeId = apibk.EmployeeId
                GROUP BY CAST(apibk.EntryTime AS DATE),
                         api.ApiNumber,cgi.CustomerName, rp.ShortName,
                         api.val,
                         api.qty,
                         apibk.Remarks";

                var result = ctx.Database.SqlQuery<PiAdvisingBond>(query).ToList();
                return result;
            }


        }

        public List<PiAdvisingBond> GetPiAdvisingBondListApproved()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = @"
                SELECT
                    api.ApiNumber,
                    api.val,
                    api.qty,
                    CAST(apibk.EntryTime AS DATE) AS EntryDate,
                    STUFF((
                        SELECT ', ' + apibk.BookingNo
                        FROM dbo.ApiMainBond AS apibk
                        WHERE apibk.ApiNumber = api.ApiNumber
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS BookingNos,
                    apibk.Remarks
                FROM
                    (SELECT
                        ApiNumber,
                        SUM(BookingValue) AS val,
                        SUM(BookingQty) AS qty
                    FROM dbo.ApiMainBond
                    GROUP BY ApiNumber) AS api
                LEFT JOIN dbo.ApiMainBond AS apibk ON apibk.ApiNumber = api.ApiNumber
                GROUP BY CAST(apibk.EntryTime AS DATE),
                         api.ApiNumber,
                         api.val,
                         api.qty,
                         apibk.Remarks";

                var result = ctx.Database.SqlQuery<PiAdvisingBond>(query).ToList();
                return result;
            }


        }
        public List<ProductDropdownVm> GetProductDropdownList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = "SELECT ProductId, ProductName FROM dbo.Product";
                var result = ctx.Database.SqlQuery<ProductDropdownVm>(query).ToList();
                return result;
            }
        }

        //public List<ClauseModel> GetAllClauseDetails()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var result = ctx.Database.SqlQuery<ClauseModel>("SELECT ClauseName, TermName, ConditionDetails FROM dbo.viewClauseDetails GROUP BY ClauseName,\r\n                                                                                  TermName,\r\n                                                                                  ConditionDetails").ToList();
        //        return result;
        //    }
        //}

        public List<CombinationDropdownVm> GetCombinationDropdownList(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = @"
                    SELECT pcm.CombinationDetails, pcm.Ply ,pd.NetWeight
                    FROM dbo.Product AS pd 
                    LEFT JOIN dbo.PaperCombinationMain AS pcm ON pcm.ProductId = pd.ProductId
                    WHERE pd.ProductId = @ProductId";

                var result = ctx.Database.SqlQuery<CombinationDropdownVm>(query, new SqlParameter("ProductId", productId)).ToList();
                return result;
            }
        }

        public List<WeightDropdownVm> GetWeightDropdownList(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = @"
                    SELECT pd.NetWeight
                    FROM dbo.Product AS pd 
                    LEFT JOIN dbo.PaperCombinationMain AS pcm ON pcm.ProductId = pd.ProductId
                    WHERE pd.ProductId = @ProductId";

                var result = ctx.Database.SqlQuery<WeightDropdownVm>(query, new SqlParameter("ProductId", productId)).ToList();
                return result;
            }
        }

        //public List<BondDataVm> GetBondModal(string apiNumber)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var result = ctx.Database.SqlQuery<BondDataVm>("EXEC GetApiMainBondData  @ApiNumber",
        //            new SqlParameter("ApiNumber", apiNumber)).ToList();

        //        return result;
        //    }
        //}
        public List<BondDataVm> GetBondModal(string apiNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database.SqlQuery<BondDataVm>(@"
            EXEC GetApiMainBondData @ApiNumber",
                    new SqlParameter("ApiNumber", apiNumber)
                ).ToList();

                return result;
            }
        }

        public int SaveApiFromBond(SaveApiFromBondRequest request)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int rowsAffected = 0;
                var commandMain = "INSERT INTO [dbo].[ApiBondListMain]" +
                    "([ApiNumber]" +
                    ",[SubmittedDate]" +
                    ",[CustomerName]" +
                    ",[RetailerName]" +
                    ",[Remarks]" +
                    ",[TotalValue]" +
                    ",[TotalQuantity]" +
                    ",[CompanyName])" +
                    "VALUES (@ApiNumber" +
                    ",@SubmittedDate" +
                    ",@CustomerName" +
                    ",@RetailerName" +
                    ",@Remarks" +
                    ",@TotalValue" +
                    ",@TotalQuantity" +
                    ",@CompanyName)";
                rowsAffected += ctx.Database.ExecuteSqlCommand(
                    commandMain,
                    new SqlParameter("ApiNumber", request.ApiNumber),
                    new SqlParameter("SubmittedDate", request.SubmittedDate),
                    new SqlParameter("CustomerName", request.CustomerName),
                    new SqlParameter("RetailerName", request.RetailerName),
                    new SqlParameter("Remarks", request.Remarks),
                    new SqlParameter("TotalValue", request.TotalValue),
                    new SqlParameter("TotalQuantity", request.TotalQuantity),
                    new SqlParameter("CompanyName", request.CompanyName));

                foreach (var item in request.Details)
                {
                    var command = "INSERT INTO [dbo].[ApiBondListSub]" +
                        "([ApiNumber]" +
                        ",[ProductName]" +
                        ",[Measurement]" +
                        ",[MeasureUnit]" +
                        ",[BookingQty]" +
                        ",[QtyInKG]" +
                        ",[QuantityUnit]" +
                        ",[UnitPrice]" +
                        ",[Val2]" +
                        ",[PONumber]" +
                        ",[StyleRef]" +
                        ",[Color]" +
                        ",[BreakDown1]" +
                        ",[BreakDown2]" +
                        ",[ShadeNumber]" +
                        ",[WashType]" +
                        ",[GSM]" +
                        ",[OurRef]" +
                        ",[CustomerRef]" +
                        ",[BondRemarks])" +
                        "VALUES (@ApiNumber" +
                        ",@ProductName" +
                        ",@Measurement" +
                        ",@MeasureUnit" +
                        ",@BookingQty" +
                        ",@QtyInKG" +
                        ",@QuantityUnit" +
                        ",@UnitPrice" +
                        ",@Val2" +
                        ",@PONumber" +
                        ",@StyleRef" +
                        ",@Color" +
                        ",@BreakDown1" +
                        ",@BreakDown2" +
                        ",@ShadeNumber" +
                        ",@WashType" +
                        ",@GSM" +
                        ",@OurRef" +
                        ",@CustomerRef" +
                        ",@BondRemarks)";
                    rowsAffected += ctx.Database.ExecuteSqlCommand(
                        command,
                        new SqlParameter("ApiNumber", item.ApiNumber),
                        new SqlParameter("ProductName", item.ProductName),
                        new SqlParameter("Measurement", item.Measurement),
                        new SqlParameter("MeasureUnit", item.MeasureUnit ?? ""),
                        new SqlParameter("BookingQty", item.BookingQty),
                        new SqlParameter("QtyInKG", item.QtyInKG),
                        new SqlParameter("QuantityUnit", item.QuantityUnit),
                        new SqlParameter("UnitPrice", item.UnitPrice),
                        new SqlParameter("Val2", item.Val2),
                        new SqlParameter("PONumber", item.PONumber ?? ""),
                        new SqlParameter("StyleRef", item.StyleRef ?? "" ),
                        new SqlParameter("Color", item.Color ?? ""),
                        new SqlParameter("BreakDown1", item.BreakDown1 ?? ""),
                        new SqlParameter("BreakDown2", item.BreakDown2 ?? ""),
                        new SqlParameter("ShadeNumber", item.ShadeNumber ?? ""),
                        new SqlParameter("WashType", item.WashType ?? ""),
                        new SqlParameter("GSM", item.GSM ?? ""),
                        new SqlParameter("OurRef", item.OurRef ?? ""),
                        new SqlParameter("CustomerRef", item.CustomerRef ?? ""),
                        new SqlParameter("BondRemarks", item.BondRemarks ?? ""));
                }
                return rowsAffected;
            }
        }


        //     public int SaveApiFromBond(SaveApiFromBondRequest request)
        //     {
        //         using (var ctx = new ApplicationDbContext())
        //         {
        //             int rowsAffected = 0;
        //             var commandMain = "INSERT INTO [dbo].[ApiBondListMain]" +
        //      "([ApiNumber]" +
        //      ",[SubmittedDate]" +
        //      ",[CustomerName]" +
        //      ",[RetailerName]" +
        //      ",[Remarks]" +
        //      ",[TotalValue]" +
        //      ",[TotalQuantity]" +
        //      ",[CompanyName])" +
        //"VALUES (@ApiNumber" +
        //      ",@SubmittedDate" +
        //      ",@CustomerName" +
        //      ",@RetailerName" +
        //      ",@Remarks" +
        //      ",@TotalValue" +
        //      ",@TotalQuantity" +
        //      ",@CompanyName)";
        //             rowsAffected += ctx.Database.ExecuteSqlCommand(
        //                          commandMain,
        //                          new SqlParameter("ApiNumber", request.ApiNumber),
        //                          new SqlParameter("SubmittedDate", request.SubmittedDate),
        //                          new SqlParameter("CustomerName", request.CustomerName),
        //                          new SqlParameter("RetailerName", request.RetailerName),
        //                          new SqlParameter("Remarks", request.Remarks),
        //                          new SqlParameter("TotalValue", request.TotalValue),
        //                          new SqlParameter("TotalQuantity", request.TotalQuantity),
        //                          new SqlParameter("CompanyName", request.CompanyName));

        //             foreach (var item in request.Details)
        //             {
        //                 var command = "INSERT INTO [dbo].[ApiBondListSub]" +
        //        "([ApiNumber]" +
        //        ",[BookingNo]" +
        //        ",[CategoryName]" +
        //        ",[ProductName]" +
        //        ",[Measurement]" +
        //        ",[MeasureUnit]" +
        //        ",[UnitPrice]" +
        //        ",[BookingQty]" +
        //        ",[QuantityUnit]" +
        //        ",[Val2]" +
        //        ",[BondRemarks])" +
        //  "VALUES (@ApiNumber" +
        //        ",@BookingNo" +
        //        ",@CategoryName" +
        //        ",@ProductName" +
        //        ",@Measurement" +
        //        ",@MeasureUnit" +
        //        ",@UnitPrice" +
        //        ",@BookingQty" +
        //        ",@QuantityUnit" +
        //        ",@Val2" +
        //        ",@BondRemarks)";
        //                 rowsAffected += ctx.Database.ExecuteSqlCommand(
        //                                 command,
        //                                 new SqlParameter("ApiNumber", item.ApiNumber),
        //                                 new SqlParameter("BookingNo", item.BookingNo),
        //                                 new SqlParameter("CategoryName", item.CategoryName),
        //                                 new SqlParameter("ProductName", item.ProductName),
        //                                 new SqlParameter("Measurement", item.Measurement),
        //                                 new SqlParameter("MeasureUnit", item.MeasureUnit),
        //                                 new SqlParameter("UnitPrice", item.UnitPrice),
        //                                 new SqlParameter("BookingQty", item.BookingQty),
        //                                 new SqlParameter("QuantityUnit", item.QuantityUnit),
        //                                 new SqlParameter("Val2", item.Val2),
        //                                 new SqlParameter("BondRemarks", item.BondRemarks));
        //             }
        //             return rowsAffected;
        //         }
        //     }
    }
}