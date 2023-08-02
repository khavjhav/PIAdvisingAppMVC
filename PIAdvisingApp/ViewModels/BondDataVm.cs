using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class BondDataVm
    {
        public int RowId { get; set; }
        public long RowNumber { get; set; }
        public string ApiNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalQty { get; set; }
        public string BookingNo { get; set; }
        public string BookingId { get; set; }
        public string CategoryName { get; set; }
        public string OurRef { get; set; }
        public string CustomerRef { get; set; }

        public string ProductName { get; set; }
        public short ProductId { get; set; }
        public int BookingSubId { get; set; }
        public string CustomerName { get; set; }
        public string RetailerName { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }

        public string Size { get; set; }
        public string BondName { get; set; }
        public string Remarks { get; set; }
        public string Measurement { get; set; }
        public string MeasureUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BookingQty { get; set; }
        public string QuantityUnit { get; set; }
        public decimal Val2 { get; set; }

        public string PONumber { get; set; }
        public string StyleRef { get; set; }
        public string Color { get; set; }
        public string BreakDown1 { get; set; }
        public string BreakDown2 { get; set; }
        public string ShadeNumber { get; set; }
        public string WashType { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public byte IsPerforated { get; set; }
        public byte IsPrinted { get; set; }
        public string GSM { get; set; }
        public decimal QtyInKG { get; set; }
    }

    public class ClauseModel
    {
        //public int ClauseId { get; set; }
        //public string ClauseCode { get; set; }
        public string ClauseName { get; set; }

        //public int TermId { get; set; }
        public string TermName { get; set; }
        //public int ConditionId { get; set; }
        public string ConditionDetails { get; set; }
        //public string ConditionDetailsHTML { get; set; }
        //public int RowNo { get; set; }
        //public int IsActive { get; set; }

    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class PaperCombinationMain
    {
        public string CombinationDetails { get; set; }
        public int Ply { get; set; }
        public decimal NetWeight { get; set; }
    }

    public class ProductDropdownVm
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class CombinationDropdownVm
    {
        public string CombinationDetails { get; set; }
        //public int Ply { get; set; }
    }

    public class WeightDropdownVm
    {
        public decimal NetWeight { get; set; }
    }
    public class ProductFormVm
    {
        [Required(ErrorMessage = "Please select a product.")]
        public int SelectedProductId { get; set; }

        public List<ProductDropdownVm> ProductDropdownList { get; set; }

        public List<CombinationDropdownVm> CombinationDropdownList { get; set; }

        public List<WeightDropdownVm> WeightDropdownList { get; set; }

        // Add other properties and validation as needed...
    }
    public class ProductViewModel
    {
        public int RowId { get; set; }
        public string ProductName { get; set; }
        public int BookingId { get; set; }
        public int BookingSubId { get; set; }
        public int BookingRelationId { get; set; }
        public int RelationId { get; set; }
        public short ProductId { get; set; }
        public string NSDNo { get; set; }
        public short MeasureUnitId { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Thickness { get; set; }
        public string Measurement { get; set; }
        public string PONumber { get; set; }
        public string StyleRef { get; set; }
        public string Color { get; set; }
        public string BreakDown1 { get; set; }
        public string BreakDown2 { get; set; }
        public string Size { get; set; }
        public short PackStyleId { get; set; }
        public byte Ply { get; set; }
        public decimal SqrMeter { get; set; }
        public byte IsPerforated { get; set; }
        public short PaperComId { get; set; }
        public string PaperCombination { get; set; }
        public string GlueType { get; set; }
        public string ElasticType { get; set; }
        public byte IsPrinted { get; set; }
        public byte IsOutDimension { get; set; }
        public byte IsDyeCutting { get; set; }
        public string MaterialName { get; set; }
        public string DeptNoColor { get; set; }
        public string Sealing { get; set; }
        public string AirHole { get; set; }
        public decimal PillowSize { get; set; }
        public decimal Flap { get; set; }
        public decimal GsstLength { get; set; }
        public decimal GsstWidthLeft { get; set; }
        public decimal GsstWidthRight { get; set; }
        public decimal PrintCost { get; set; }
        public decimal AdhesiveCost { get; set; }
        public decimal ZipperCost { get; set; }
        public string PrintOption { get; set; }
        public string NoOfColor { get; set; }
        public string ShadeNumber { get; set; }
        public string ShadeOption { get; set; }
        public string WashType { get; set; }
        public string ItemCode { get; set; }
        public string LabelCaption { get; set; }
        public string Brand { get; set; }
        public string Cut_Fold { get; set; }
        public string GSM { get; set; }
        public string LogoType { get; set; }
        public string PolishQuality { get; set; }
        public int PolishQualityId { get; set; }
        public byte IsSymbol { get; set; }
        public byte IsCountryOfOrigin { get; set; }
        public byte IsAddWashCare { get; set; }
        public byte IsWashBox { get; set; }
        public byte IsKAFF { get; set; }
        public byte IsFiberContent { get; set; }
        public byte IsAWSupplied { get; set; }
        public byte IsAWSpecification { get; set; }
        public decimal BookingQty { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal CancelQty { get; set; }
        public decimal ReturnQty { get; set; }
        public short QtyUnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OI { get; set; }
        public decimal ExcessAmount { get; set; }
        public decimal KGPerUnit { get; set; }
        public decimal QtyInKG { get; set; }
        public short PcsPerUnit { get; set; }
        public decimal QtyInPcs { get; set; }
        public decimal UnitPriceKG { get; set; }
        public decimal MinPrice { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public short DeliveryPointSId { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime DeliveryDate1 { get; set; }
        public DateTime DeliveryDate2 { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string PrintInstructionFS { get; set; }
        public string PrintInstructionBS { get; set; }
        public string Remarks { get; set; }
        public DateTime EntryDate { get; set; }
        public byte IsScheduleLock { get; set; }
        public DateTime ScheduleLockDate { get; set; }
        public short ScheduleLockUserId { get; set; }
        public string ScheduleLockIPAddress { get; set; }
        public string ScheduleLockPCName { get; set; }
        public short RowNo { get; set; }
        public byte RelationType { get; set; }
        public byte IsRetailerStyle { get; set; }
    }

}