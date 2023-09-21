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
}