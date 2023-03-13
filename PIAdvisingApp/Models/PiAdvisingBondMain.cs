using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System;

namespace PIAdvisingApp.Models
{
    public class PiAdvisingBondMain
    {
        public int Id { get; set; }
        public string ApiNumber { get; set; }
        public string BookingNo { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal Value { get; set; }
        public DateTime BookingDate { get; set; }
        public string Specification { get; set; }
        public string Size { get; set; }
        public string BondName { get; set; }
        public string Category { get; set; }
    }
}