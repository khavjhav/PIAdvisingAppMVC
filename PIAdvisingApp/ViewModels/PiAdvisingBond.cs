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
        public decimal Val { get; set; }
        public decimal Qty { get; set; }

        public DateTime EntryDate { get; set; }
        public string BookingNos { get; set; }
        public string Remarks { get; set; }
    }
}