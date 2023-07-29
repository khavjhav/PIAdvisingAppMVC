using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class SaveApiFromBondRequest
    {
        public string ApiNumber { get; set; }
        public string SubmittedDate { get; set; }
        public string CustomerName { get; set; }
        public string RetailerName { get; set; }
        public string Remarks { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalQuantity { get; set; }
        public int CompanyName { get; set; }
        public List<SaveApiFromBondRequestDetails> Details { get; set; }
    }
    public class SaveApiFromBondRequestDetails
    {
        public string ApiNumber { get; set; }
        public string BookingNo { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Measurement { get; set; }
        public string MeasureUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal BookingQty { get; set; }
        public decimal QtyInKG { get; set; }
        public string QuantityUnit { get; set; }
        public decimal Val2 { get; set; }
        public string BondRemarks { get; set; }

        // Nullable properties
        public string PONumber { get; set; }
        public string StyleRef { get; set; }
        public string Color { get; set; }
        public string  BreakDown1 { get; set; }
        public string  BreakDown2 { get; set; }
        public string  ShadeNumber { get; set; }
        public string WashType { get; set; }
        public string GSM { get; set; }
        public string OurRef { get; set; }
        public string CustomerRef { get; set; }
    }
}