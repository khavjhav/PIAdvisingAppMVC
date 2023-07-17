
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


    }
}