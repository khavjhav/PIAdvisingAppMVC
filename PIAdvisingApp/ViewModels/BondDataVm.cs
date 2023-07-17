using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class BondDataVm
    {
        public string ApiNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalQty { get; set; }
        public string BookingNo { get; set; }
        public int BookingId { get; set; }
        public string CategoryName { get; set; }

        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string RetailerName { get; set; }
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
    }
}