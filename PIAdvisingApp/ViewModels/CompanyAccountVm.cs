using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class CompanyAccountVm
    {
        public byte CompanyId { get; set; }
        public string CompanyName { get; set; }
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }
        public byte AccountId { get; set; }
        public string SwiftCode { get; set; }
        public byte BankId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public short BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public byte IsActive { get; set; }
    }
}