namespace PIAdvisingApp.ViewModels
{
    public class DashboardViewModel
    {
        public string RepresentativeName { get; set; }
        public short RepresentativeId { get; set; }
        public string CustomerName { get; set; }
        public short Customerid { get; set; }
        public string CategoryName { get; set; }
        public short CategoryId { get; set; }
        public decimal TotalBookingVal { get; set; }
        public decimal TotalCancelValue { get; set; }
        public decimal TotalDeliveredlValue { get; set; }
        public decimal TotalLCrcvValue { get; set; }
        public decimal Totallcbalance { get; set; }
        public decimal Avgdlvper { get; set; }
    }
}