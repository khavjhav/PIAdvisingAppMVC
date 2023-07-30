using DevExpress.XtraRichEdit.Import.Html;
using Microsoft.Ajax.Utilities;
using PIAdvisingApp.Models;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.Service
{
    public class CmService
    {

//        public List<CmAdvisingBond> GetPiAdvisingBondListForCm()
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var query = @"
//               		 SELECT ablm.ApiNumber, CAST(ab.EntryDate AS DATETIME) as EntryDate,CAST(ablm.SubmittedDate  AS DATETIME)  AS BondSDate, ci.CompanyName, ablm.Remarks, ablm.TotalValue, CAST(ablm.TotalQuantity AS DECIMAL(18,2)) AS TotalQuantity, ab.ShortName FROM dbo.ApiBondListMain AS ablm
//						 LEFT JOIN (SELECT 
//                    api.ApiNumber, 
//                    api.val,rp.ShortName,
//                    api.qty,
//                    CAST(apibk.EntryTime AS DATE) AS EntryDate,
//                    STUFF((
//                        SELECT ', ' + apibk.BookingNo
//                        FROM dbo.ApiMainBond AS apibk
//                        WHERE apibk.ApiNumber = api.ApiNumber
//                        FOR XML PATH(''), TYPE
//                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS BookingNos,
//                    apibk.Remarks
//                FROM
//                    (SELECT
//                        ApiNumber, EmployeeId, 
//                        SUM(BookingValue) AS val,
//                        SUM(BookingQty) AS qty
//                    FROM dbo.ApiMainBond
//                    GROUP BY ApiNumber, EmployeeId) AS api
//                LEFT JOIN dbo.ApiMainBond AS apibk ON apibk.ApiNumber = api.ApiNumber
//				LEFT JOIN dbo.Representative AS rp ON rp.EmployeeId = api.EmployeeId 
//                GROUP BY CAST(apibk.EntryTime AS DATE),
//                         api.ApiNumber,rp.ShortName,
//                         api.val,
//                         api.qty,
//                         apibk.Remarks) AS ab ON ab.ApiNumber = ablm.ApiNumber
//						 LEFT JOIN dbo.CompanyInfo AS ci ON ci.CompanyId = ablm.CompanyName
				
					
					


//";

//                var result = ctx.Database.SqlQuery<CmAdvisingBond>(query).ToList();
//                return result;
//            }
//        }

        public List<BondApprovedList> GetPiAdvisingBondListForCm()
{
    using (var ctx = new ApplicationDbContext())
    {
        var query = @"
            SELECT CAST(am.EntryTime AS DATE) AS AdviseDate,
                   CAST(abm.SubmittedDate AS date) BondDate,
                   abm.ApiNumber,
                   SUM(am.BookingValue) AS OriginalValue,
                   abm.TotalValue,
                   SUM(am.BookingQty) AS OriginalQuantity,
                   abm.TotalQuantity,
                   ci.CompanyName,
                   ci.Address
            FROM dbo.ApiBondListMain AS abm 
            LEFT JOIN dbo.ApiMainBond AS am ON am.ApiNumber = abm.ApiNumber
            LEFT JOIN dbo.CompanyInfo AS ci ON ci.CompanyId = abm.CompanyName
            GROUP BY CAST(am.EntryTime AS DATE),
                     CAST(abm.SubmittedDate AS DATE),
                     abm.ApiNumber,
                     abm.TotalValue,
                     abm.TotalQuantity,
                     ci.CompanyName,
                     ci.Address";

        var result = ctx.Database.SqlQuery<BondApprovedList>(query).ToList();
        return result;
    }
}



        ////        SELECT
        //api.ApiNumber,
        //            api.val,
        //            api.qty,
        //            CAST(apibk.EntryTime AS DATE) AS EntryDate,
        //            STUFF((
        //                SELECT ', ' + apibk.BookingNo
        //                FROM dbo.ApiMainBond AS apibk
        //                WHERE apibk.ApiNumber = api.ApiNumber
        //                FOR XML PATH(''), TYPE
        //            ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS BookingNos,
        //            apibk.Remarks
        //FROM
        //(SELECT
        //                ApiNumber,
        //                SUM(BookingValue) AS val,
        //                SUM(BookingQty) AS qty
        //            FROM dbo.ApiMainBond
        //            GROUP BY ApiNumber) AS api
        //        LEFT JOIN dbo.ApiMainBond AS apibk ON apibk.ApiNumber = api.ApiNumber
        //        GROUP BY CAST(apibk.EntryTime AS DATE),
        //                 api.ApiNumber,
        //                 api.val,
        //                 api.qty,
        //                 apibk.Remarks
    }
}