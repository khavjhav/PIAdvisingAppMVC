using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class BondApprovalViewModel
    {
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public string PIStatus { get; set; }
        public string CustomerName { get; set; }
        public string RepresentativeName { get; set; }

        public string ShortName { get; set; }

        public decimal BookingQty { get; set; }
        public decimal BookingValue { get; set; }
        public string RetailerName { get; set; }
        public decimal DeliveryPercentage { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }

    }
}