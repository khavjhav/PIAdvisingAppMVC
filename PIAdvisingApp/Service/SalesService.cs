using DevExpress.XtraExport;
using PIAdvisingApp.Models;
using PIAdvisingApp.ViewModels;
using Syncfusion.EJ2.ImageEditor;
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
                DateTime currentDate = DateTime.Now;
                DateTime fromDate = currentDate.AddYears(-2);
                DateTime toDate = currentDate;

                string fromDateStr = fromDate.ToString("dd-MMM-yyyy");
                string toDateStr = toDate.ToString("dd-MMM-yyyy");

                var result = ctx.Database
                    .SqlQuery<PrcRptLcNotReceived>($"EXEC PrcAdvisePI '{fromDateStr}', '{toDateStr}', 0, 0, 0, 0, 0, null, 1, 0")
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

        //public List<PiAdvisingBondMainViewModel> GetPiAdvisingBondData()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var result = ctx.Database.SqlQuery<PiAdvisingBondMainViewModel>(@"EXEC GetPiAdvisingBondMainByApiNumber").ToList();

        //        return result;
        //    }
        //}

        //public List<PiAdvisingBondViewModel> GetPamModalBond(string apiNumber)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var result = ctx.Database.SqlQuery<PiAdvisingBondViewModel>(@"EXEC GetPamModalBond  @ApiNumber",
        //            new SqlParameter("ApiNumber", apiNumber)).ToList();

        //        return result;
        //    }
        //}

        private static object GenerateDummyData(Type type)
        {
            // Implement your logic to generate dummy data based on the provided type
            // Return the appropriate dummy value based on the type
            if (type == typeof(int))
                return 123; // Replace with appropriate dummy value for int
            else if (type == typeof(string))
                return "test"; // Replace with appropriate dummy value for string
            else if (type == typeof(short))
                return (short)123; // Replace with appropriate dummy value for short
            else if (type == typeof(byte))
                return (byte)123; // Replace with appropriate dummy value for byte
            else if (type == typeof(DateTime))
                return DateTime.Now; // Replace with appropriate dummy value for DateTime
            else if (type == typeof(decimal) || type == typeof(double) || type == typeof(float))
                return 123.45m; // Replace with appropriate dummy value for decimal/float/double
            else
                return null; // Replace with appropriate dummy value for other types
        }



        public int SavePiAdvisingBondMain(ApiData apiData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var query = "INSERT INTO dbo.PiAdvisingBondMain VALUES (@BookingNo, @InvoiceQty, @InvoiceValue, @ApiNumber, @ApiDate)";
                //var result = ctx.Database
                //    .ExecuteSqlCommand(query,
                //        new SqlParameter("BookingNo", apiData.BookingNo),
                //        new SqlParameter("InvoiceQty", apiData.InvoiceQty), //not going to main
                //        new SqlParameter("InvoiceValue", apiData.DelValue),
                //        new SqlParameter("ApiNumber", apiData.ApiNumber),
                //        new SqlParameter("ApiDate", DateTime.Now)

                //);

                var query = "INSERT INTO dbo.PiAdvisingBondMain (PIId, PINo, BookingNo,   PISDate, PIDate, PITypeId, Month, Year, SerialNo, LocationId, CompanyId, CustomerId, IssuerId, CustomerRef, AddEmailAddress, RepresentativeId, CMRepresentativeId, PIClauseId, AdvisingBankId, AdvisingBranchId, BillAddressId, BillAddress, PIAmount, IsCollectionDone, IsCustomizePI, IsPONumber, IsStyleRef, IsSize, IsColor, IsBreakdown1, IsBreakdown2, IsShadeNumber, IsWashType, IsGSM, IsAutoPI, IsSentToCustomer, IsInQueue, PIFwDate, IsWeightPI, IsBookingRevised, SendingCount, EntryUserId, EntryDate, RevisionUserId, RevisionDate, IPAddress, PCName) " +
             "VALUES (@PIId, @PINo, @BookingNo, @PISDate, @PIDate, @PITypeId, @Month, @Year, @SerialNo, @LocationId, @CompanyId, @CustomerId, @IssuerId, @CustomerRef, @AddEmailAddress, @RepresentativeId, @CMRepresentativeId, @PIClauseId, @AdvisingBankId, @AdvisingBranchId, @BillAddressId, @BillAddress, @PIAmount, @IsCollectionDone, @IsCustomizePI, @IsPONumber, @IsStyleRef, @IsSize, @IsColor, @IsBreakdown1, @IsBreakdown2, @IsShadeNumber, @IsWashType, @IsGSM, @IsAutoPI, @IsSentToCustomer, @IsInQueue, @PIFwDate, @IsWeightPI, @IsBookingRevised, @SendingCount, @EntryUserId, @EntryDate, @RevisionUserId, @RevisionDate, @IPAddress, @PCName)";
                var result = ctx.Database.ExecuteSqlCommand(query,
                    new SqlParameter("PIId", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for PIId
                    new SqlParameter("PINo", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for PINo
                     new SqlParameter("PIPrefix", GenerateDummyData(typeof(string))),
                    new SqlParameter("BookingNo", apiData.BookingNo),
                    //new SqlParameter("InvoiceQty", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for InvoiceQty
                    //new SqlParameter("InvoiceValue", apiData.DelValue), // Use the actual PiAmount value
                    //new SqlParameter("ApiNumber", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ApiNumber
                    //new SqlParameter("ApiDate", DateTime.Now),
                    new SqlParameter("PISDate", GenerateDummyData(typeof(DateTime))), // Use your own logic to generate dummy data for PISDate
                    new SqlParameter("PIDate", GenerateDummyData(typeof(DateTime))), // Use your own logic to generate dummy data for PIDate
                    new SqlParameter("PITypeId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for PITypeId
                    new SqlParameter("Month", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for Month
                    new SqlParameter("Year", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for Year
                    new SqlParameter("SerialNo", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for SerialNo
                    new SqlParameter("LocationId", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for LocationId
                    new SqlParameter("CompanyId", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for CompanyId
                    new SqlParameter("CustomerId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for CustomerId
                    new SqlParameter("IssuerId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for IssuerId
                    new SqlParameter("CustomerRef", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for CustomerRef
                    new SqlParameter("AddEmailAddress", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for AddEmailAddress
                    new SqlParameter("RepresentativeId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for RepresentativeId
                    new SqlParameter("CMRepresentativeId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for CMRepresentativeId
                    new SqlParameter("PIClauseId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for PIClauseId
                    new SqlParameter("AdvisingBankId", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for AdvisingBankId
                    new SqlParameter("AdvisingBranchId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for AdvisingBranchId
                    new SqlParameter("BillAddressId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for BillAddressId
                    new SqlParameter("BillAddress", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for BillAddress
                    new SqlParameter("PIAmount", apiData.DelValue), // Use the actual PiAmount value
                    new SqlParameter("IsCollectionDone", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsCollectionDone
                    new SqlParameter("IsCustomizePI", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsCustomizePI
                    new SqlParameter("IsPONumber", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsPONumber
                    new SqlParameter("IsStyleRef", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsStyleRef
                    new SqlParameter("IsSize", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsSize
                    new SqlParameter("IsColor", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsColor
                    new SqlParameter("IsBreakdown1", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsBreakdown1
                    new SqlParameter("IsBreakdown2", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsBreakdown2
                    new SqlParameter("IsShadeNumber", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsShadeNumber
                    new SqlParameter("IsWashType", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsWashType
                    new SqlParameter("IsGSM", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsGSM
                    new SqlParameter("IsAutoPI", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsAutoPI
                    new SqlParameter("IsSentToCustomer", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsSentToCustomer
                    new SqlParameter("IsInQueue", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsInQueue
                    new SqlParameter("PIFwDate", GenerateDummyData(typeof(DateTime))), // Use your own logic to generate dummy data for PIFwDate
                    new SqlParameter("IsWeightPI", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsWeightPI
                    new SqlParameter("IsBookingRevised", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsBookingRevised
                    new SqlParameter("SendingCount", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for SendingCount
                    new SqlParameter("EntryUserId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for EntryUserId
                    new SqlParameter("EntryDate", GenerateDummyData(typeof(DateTime))), // Use your own logic to generate dummy data for EntryDate
                    new SqlParameter("RevisionUserId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for RevisionUserId
                    new SqlParameter("RevisionDate", GenerateDummyData(typeof(DateTime))), // Use your own logic to generate dummy data for RevisionDate
                    new SqlParameter("IPAddress", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for IPAddress
                    new SqlParameter("PCName", GenerateDummyData(typeof(string))) // Use your own logic to generate dummy data for PCName

                    );

                ///sub details from booking sub , like product, measurements.
                //var insertedRowId = 0;
                //            foreach (var detail in data.Details)
                //            {
                //                //Save Sub data
                //                //var detailQuery = "INSERT INTO dbo.PiAdvisingBondSub VALUES (@BookingSubId, @BookingQty, @UnitPrice, @Measurement, @MeasurementID, @ApiDate)";
                //                var detailQuery = "INSERT INTO dbo.YourTableName (PIId, PISubId, ProductId, ProductSpecification, CustomerSpecification, NSDNo, MeasureUnitId, Length, Width, Height, Thickness, Measurement, PONumber, StyleRef, Color, BreakDown1, BreakDown2, Size, PackStyleId, Ply, SqrMeter, IsPerforated, PaperComId, PaperCombination, GlueType, ElasticType, IsPrinted, IsOutDimension, IsDyeCutting, MaterialName, DeptNoColor, Sealing, AirHole, PillowSize, Flap, GsstLength, GsstWidthLeft, GsstWidthRight, PrintCost, AdhesiveCost, PrintOption, NoOfColor, ShadeNumber, ShadeOption, WashType, ItemCode, LabelCaption, Brand, Cut_Fold, GSM, Quantity, QtyInKG, QuantityUnitId, UnitPrice, TotalAmount, RowNo) " +
                //         "VALUES (@PIId, @PISubId, @ProductId, @ProductSpecification, @CustomerSpecification, @NSDNo, @MeasureUnitId, @Length, @Width, @Height, @Thickness, @Measurement, @PONumber, @StyleRef, @Color, @BreakDown1, @BreakDown2, @Size, @PackStyleId, @Ply, @SqrMeter, @IsPerforated, @PaperComId, @PaperCombination, @GlueType, @ElasticType, @IsPrinted, @IsOutDimension, @IsDyeCutting, @MaterialName, @DeptNoColor, @Sealing, @AirHole, @PillowSize, @Flap, @GsstLength, @GsstWidthLeft, @GsstWidthRight, @PrintCost, @AdhesiveCost, @PrintOption, @NoOfColor, @ShadeNumber, @ShadeOption, @WashType, @ItemCode, @LabelCaption, @Brand, @Cut_Fold, @GSM, @Quantity, @QtyInKG, @QuantityUnitId, @UnitPrice, (@Quantity * @UnitPrice), @RowNo)";

                //                var detailResult = ctx.Database
                //                .ExecuteSqlCommand(detailQuery,
                //                        //new SqlParameter("BookingSubID", detail.BookingSubId),
                //                        //new SqlParameter("UnitPrice", detail.UnitPrice),
                //                        //new SqlParameter("Measurement", detail.Measurement),
                //                        //new SqlParameter("MeasurementID", detail.MeasurementID),
                //                        //new SqlParameter("ApiDate", DateTime.Now)
                //                        new SqlParameter("PIId", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for PIId
                //new SqlParameter("PISubId", GenerateDummyData(typeof(int))), // Use your own logic to generate dummy data for PISubId
                //new SqlParameter("ProductId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for ProductId
                //new SqlParameter("ProductSpecification", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ProductSpecification
                //new SqlParameter("CustomerSpecification", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for CustomerSpecification
                //new SqlParameter("NSDNo", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for NSDNo
                //new SqlParameter("MeasureUnitId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for MeasureUnitId
                //new SqlParameter("Length", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Length
                //new SqlParameter("Width", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Width
                //new SqlParameter("Height", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Height
                //new SqlParameter("Thickness", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Thickness
                //new SqlParameter("Measurement", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Measurement
                //new SqlParameter("PONumber", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for PONumber
                //new SqlParameter("StyleRef", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for StyleRef
                //new SqlParameter("Color", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Color
                //new SqlParameter("BreakDown1", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for BreakDown1
                //new SqlParameter("BreakDown2", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for BreakDown2
                //new SqlParameter("Size", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Size
                //new SqlParameter("PackStyleId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for PackStyleId
                //new SqlParameter("Ply", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for Ply
                //new SqlParameter("SqrMeter", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for SqrMeter
                //new SqlParameter("IsPerforated", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsPerforated
                //new SqlParameter("PaperComId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for PaperComId
                //new SqlParameter("PaperCombination", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for PaperCombination
                //new SqlParameter("GlueType", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for GlueType
                //new SqlParameter("ElasticType", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ElasticType
                //new SqlParameter("IsPrinted", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsPrinted
                //new SqlParameter("IsOutDimension", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsOutDimension
                //new SqlParameter("IsDyeCutting", GenerateDummyData(typeof(byte))), // Use your own logic to generate dummy data for IsDyeCutting
                //new SqlParameter("MaterialName", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for MaterialName
                //new SqlParameter("DeptNoColor", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for DeptNoColor
                //new SqlParameter("Sealing", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Sealing
                //new SqlParameter("AirHole", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for AirHole
                //new SqlParameter("PillowSize", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for PillowSize
                //new SqlParameter("Flap", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Flap
                //new SqlParameter("GsstLength", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for GsstLength
                //new SqlParameter("GsstWidthLeft", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for GsstWidthLeft
                //new SqlParameter("GsstWidthRight", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for GsstWidthRight
                //new SqlParameter("PrintCost", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for PrintCost
                //new SqlParameter("AdhesiveCost", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for AdhesiveCost
                //new SqlParameter("PrintOption", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for PrintOption
                //new SqlParameter("NoOfColor", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for NoOfColor
                //new SqlParameter("ShadeNumber", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ShadeNumber
                //new SqlParameter("ShadeOption", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ShadeOption
                //new SqlParameter("WashType", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for WashType
                //new SqlParameter("ItemCode", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for ItemCode
                //new SqlParameter("LabelCaption", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for LabelCaption
                //new SqlParameter("Brand", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Brand
                //new SqlParameter("Cut_Fold", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for Cut_Fold
                //new SqlParameter("GSM", GenerateDummyData(typeof(string))), // Use your own logic to generate dummy data for GSM
                //new SqlParameter("Quantity", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for Quantity
                //new SqlParameter("QtyInKG", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for QtyInKG
                //new SqlParameter("QuantityUnitId", GenerateDummyData(typeof(short))), // Use your own logic to generate dummy data for QuantityUnitId
                //new SqlParameter("UnitPrice", GenerateDummyData(typeof(decimal))), // Use your own logic to generate dummy data for UnitPrice
                //new SqlParameter("TotalAmount", apiData.DelValue), // Use the actual TotalAmount value
                //new SqlParameter("RowNo", GenerateDummyData(typeof(short))) // Use your own logic to generate dummy data for RowNo

                //                        );
                //            }



                return result;
            }

        }

        //public List<ClauseModel> GetClauseDetailsByClauseName(string clauseName)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var clauseNameParameter = new SqlParameter("@clauseName", clauseName);
        //        var result = ctx.Database.SqlQuery<ClauseModel>("SELECT * FROM dbo.viewClauseDetails WHERE ClauseName = @clauseName", clauseNameParameter).ToList();
        //        return result;
        //    }
        //}

        public List<ClauseModel> GetAllClauseDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database.SqlQuery<ClauseModel>("SELECT ClauseName, TermName, ConditionDetails FROM dbo.viewClauseDetails GROUP BY ClauseName,\r\n                                                                                  TermName,\r\n                                                                                  ConditionDetails").ToList();
                return result;
            }
        }

        public void SaveCmApi(CmApprovalModalVm data)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Save main data
                var masterQuery = "INSERT INTO dbo.PiMain VALUES (@BookingNo, @InvoiceQty, @InvoiceValue, @ApiNumber, @ApiDate)";
                var masterResult = ctx.Database
                .ExecuteSqlCommand(masterQuery,
                        new SqlParameter("CustomerName", data.CustomerName),
                        new SqlParameter("RetailerName", data.RetailerName),
                        new SqlParameter("ClauseName", data.ClauseName),
                        new SqlParameter("ApiNumber", data),
                        new SqlParameter("ApiDate", DateTime.Now)
                        // PI save function
                        );
                var insertedRowId = 0;
                foreach (var detail in data.Details)
                {
                    //Save Sub data
                    var detailQuery = "INSERT INTO dbo.PiAdvisingBondMain VALUES (@BookingNo, @InvoiceQty, @InvoiceValue, @ApiNumber, @ApiDate)";
                    var detailResult = ctx.Database
                    .ExecuteSqlCommand(detailQuery,
                            new SqlParameter("CustomerName", detail.BondName),
                            new SqlParameter("RetailerName", detail.BookingNo)
                            );
                }
            }
        }

        public List<CustomerByRepVm> GetCustomerByRepId(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var @EmployeeId = new SqlParameter("EmployeeId", employeeId);
                var query = @"SELECT CAST(cgi.CustomerId AS INT) AS CustomerId, cgi.CustomerName FROM dbo.CustomerGenInfo AS cgi INNER JOIN dbo.Representative AS r ON r.RepresentativeId = cgi.RepresentativeId WHERE r.EmployeeId = @EmployeeId";
                var result = ctx.Database.SqlQuery<CustomerByRepVm>(query, @EmployeeId).ToList();
                return result;
            }
        }

        //public List<CustomerByRepVm> GetCategory()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        //var @EmployeeId = new SqlParameter("EmployeeId", employeeId);
        //        var query = @"SELECT CAST(cgi.CustomerId AS INT) AS CustomerId, cgi.CustomerName FROM dbo.CustomerGenInfo AS cgi INNER JOIN dbo.Representative AS r ON r.RepresentativeId = cgi.RepresentativeId WHERE r.EmployeeId = @EmployeeId";
        //        var result = ctx.Database.SqlQuery<CategoryByRepVm>(query, @EmployeeId).ToList();
        //        return result;
        //    }
        //}

        public List<AdvisePiFromRepResult> GetAdvisePiFromRepDetails(int customerId, int employeeId, DateTime fromDate, DateTime toDate)
        {

            using (var ctx = new ApplicationDbContext())
            {

                var result = ctx.Database
                  .SqlQuery<AdvisePiFromRepResult>($"EXEC PrcAdvisePiForRep '{fromDate.ToString("dd-MMM-yyyy")}', '{toDate.ToString("dd-MMM-yyyy")}', {customerId}, {employeeId}")
                  .ToList();

                return result;
            }
        }

        public int SaveAdvisePiFromRep(List<SaveAdvisePiFromRepRequest> requests)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int rowsAffected = 0;
                var apiNumber = GenerateUniqueNumber(requests.Select(x => x.EmployeeId).FirstOrDefault());
                var datetime = DateTime.Now;
                foreach (var item in requests)
                {
                    var command = "INSERT INTO [dbo].[ApiMainBond]" +
           "([ApiNumber]" +
           ",[BookingId]" +
           ",[BookingNo]" +
           ",[CustomerId]" +
           ",[RetailerId]" +
           ",[BookingQty]" +
           ",[BookingValue]" +
           ",[Remarks]" +
           ",[EmployeeId]" +
           ",[EntryTime]" +
           ",[IpAddress])" +
     "VALUES (@ApiNumber" +
           ",@BookingId" +
           ",@BookingNo" +
           ",@CustomerId" +
           ",@RetailerId" +
           ",@BookingQty" +
           ",@BookingValue" +
           ",@Remarks" +
           ",@EmployeeId" +
           ",@EntryTime" +
           ",@IpAddress)";

                    rowsAffected += ctx.Database.ExecuteSqlCommand(
                        command,
                        new SqlParameter("ApiNumber", apiNumber),
                        new SqlParameter("BookingId", item.BookingId),
                        new SqlParameter("BookingNo", item.BookingNo),
                        new SqlParameter("CustomerId", item.CustomerId),
                        new SqlParameter("RetailerId", item.RetailerId),
                        new SqlParameter("BookingQty", item.BookingQty),
                        new SqlParameter("BookingValue", item.BookingValue),
                        new SqlParameter("Remarks", item.Remarks),
                        new SqlParameter("EmployeeId", item.EmployeeId),
                        new SqlParameter("EntryTime", datetime),
                        new SqlParameter("IpAddress", item.IPAddress));
                }
                return rowsAffected;
            }
        }
        public string GenerateUniqueNumber(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var apiNumber = ctx.Database.SqlQuery<string>("EXEC GetApiNumber @EmployeeId", new SqlParameter("EmployeeId", employeeId)).FirstOrDefault();
                return apiNumber.ToString();
            }
        }

    }
}