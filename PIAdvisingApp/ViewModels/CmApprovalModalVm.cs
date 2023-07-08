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
}