using System;

namespace PIAdvisingApp.ViewModels
{
    public class SaveAdvisePiFromRepRequest
    {
        public int? ApiId { get; set; }
        public int? ApiNo { get; set; }

        public string ApiNumber { get; set; }
        public int BookingId { get; set; }
        public string BookingNo { get; set; }
        public decimal BookingQty { get; set; }
        public decimal BookingValue { get; set; }
        //public decimal LCBalance { get; set; }
        public int CustomerId { get; set; }
        public int RetailerId { get; set; }
        public int RepresentativeId { get; set; }
        public int? CompanyId { get; set; }
        public string Remarks { get; set; }
        public int EmployeeId { get; set; }
        public string IPAddress { get; set; } = "1.1.1.1";
        public DateTime? EntryTime { get; set; } = DateTime.Now;
    }
}