using System;
using System.Collections.Generic;

namespace PIAdvisingApp.ViewModels
{
    public class CmApprovalModalVm
    {
        public string CustomerName { get; set; }
        public string RetailerName { get; set; }
        public string RepresentativeName { get; set; }
        public string CompanyName { get; set; }
        public string PproductCategory { get; set; }
        public string ProductName { get; set; }
        public string ClauseName { get; set; }
        public List<CmApprovalModalList> Details { get; set; }
    }

    public class CmApprovalModalList
    {
        public string BookingNo { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string BondName { get; set; }
        public string InvoiceQty { get; set; }
        public string QuantityUnit { get; set; }
        public string Measurement { get; set; }
        public string MeasureUnit { get; set; }
    }

    public class CmAdvisingBond
    {
        //public int TrxId { get; set; }
        public string ApiNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BondSDate { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string RetailerName { get; set; }
        public string ShortName { get; set; }


        public decimal TotalValue { get; set; }
        public decimal TotalQuantity { get; set; }

        public string Remarks { get; set; }
    }
    public class BondApprovedList
    {
        public DateTime AdviseDate { get; set; }
        public DateTime BondDate { get; set; }
        public string ApiNumber { get; set; }
        public decimal OriginalValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal OriginalQuantity { get; set; }
        public string TotalQuantity { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}