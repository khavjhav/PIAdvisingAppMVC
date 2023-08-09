using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    
    public class AdviseStatusReport
    {
        public int ApiId { get; set; }
        public string ApiNumber { get; set; }
        public string RepresentativeName { get; set; }
        public short RepresentativeId { get; set; }
        public string CustomerName { get; set; }
        public short CustomerId { get; set; }
        public string SalesRemarks { get; set; }
        public string CommercialRemarks { get; set; }
        public string AdviseCompany { get; set; }
        public string CommercialAdvisedCompany { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime AdviseDate { get; set; }
        public DateTime? CommercialApproveDate { get; set; }
        public int DateDifferenceInDays { get; set; }
        public string Ageing { get; set; }
        public string CommercialStatus { get; set; }
        public string CMApproveDate { get; set; }
        public string CMStatus { get; set; }
    }


}