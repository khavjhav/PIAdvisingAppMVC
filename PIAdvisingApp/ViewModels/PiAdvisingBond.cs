using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class PiAdvisingBond
    {
        public string ApiNumber { get; set; }
        public string CustomerName { get; set; }
        public string ShortName { get; set; }
        public string CompanyName { get; set; }

        public decimal Val { get; set; }
        public decimal Qty { get; set; }

        public DateTime EntryDate { get; set; }
        public string BookingNos { get; set; }
        public string Remarks { get; set; }
    }

    //public class PiAdvisingBond
    //{
    //    public int TrxId { get; set; }
    //    public string ApiNumber { get; set; }
    //    public string SubmittedDate { get; set; }
    //    public string CustomerName { get; set; }
    //    public string RetailerName { get; set; }
    //    public string ShortName { get; set; }
    //    public int CompanyName { get; set; }

    //    public decimal TotalValue { get; set; }
    //    public decimal TotalQuantity { get; set; }

    //    public DateTime EntryDate { get; set; }
    //    public string BookingNos { get; set; }
    //    public string Remarks { get; set; }
    //}


    public class BondApprovedSub
    {
        public int TrxId { get; set; }
        public string ApiNumber { get; set; }
        public string SubmittedDate { get; set; }
        public string CustomerName { get; set; }
        public string RetailerName { get; set; }
        public string Remarks { get; set; }
        public decimal TotalValue { get; set; }
        public string TotalQuantity { get; set; }
        public int CompanyName { get; set; }

        // Existing properties
        public int TrxSubId { get; set; }
        public string ProductName { get; set; }
        public string Measurement { get; set; }
        public string MeasureUnit { get; set; }
        public decimal BookingQty { get; set; }
        public decimal QtyInKG { get; set; }
        public string QuantityUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Val2 { get; set; }
        public string PONumber { get; set; }
        public string StyleRef { get; set; }
        public string Color { get; set; }
        public string BreakDown1 { get; set; }
        public string BreakDown2 { get; set; }
        public string ShadeNumber { get; set; }
        public string WashType { get; set; }
        public string GSM { get; set; }
        public string OurRef { get; set; }
        public string CustomerRef { get; set; }
        public string BondRemarks { get; set; }
    }

}