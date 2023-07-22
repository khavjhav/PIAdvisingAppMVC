using System;

namespace PIAdvisingApp.ViewModels
{

    public class AdvisePiFromRepResult
    {

        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public string PIStatus { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string LocationName { get; set; }



        public string RepresentativeName { get; set; }

        public string ShortName { get; set; }

        public decimal BookingQty { get; set; }
        public decimal BookingValue { get; set; }
        public short RetailerId { get; set; } = 0;
        public string RetailerName { get; set; }
        public decimal DeliveryPercentage { get; set; }
        public string CategoryName { get; set; }
     
    }
}