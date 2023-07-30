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
        public string ApiNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalQty { get; set; }
        public string BookingNo { get; set; }
        public string BookingId { get; set; }
        public string CategoryName { get; set; }
        public string OurRef { get; set; }
        public string CustomerRef { get; set; }

        public string ProductName { get; set; }
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


    public class IssuerViewModel
    {
        public short IssuerId { get; set; }
        public short CustomerId { get; set; }
        public string IssuerCode { get; set; }
        public string IssuerName { get; set; }
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
}