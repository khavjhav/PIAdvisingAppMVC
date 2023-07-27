using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{


    public class PrcRptLcNotReceived  
    {
        public string BookingNo { get; set; }

        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }

        public int CompanyId { get; set; }

        public int RepresentativeId { get; set; }

        public int CMRepresentativeId { get; set; }
        public int AdvisingBankId { get; set; }

        public int AdvisingBranchId { get; set; }
        public int IssuerId { get; set; }

        public int LocationId { get; set; }

        public DateTime BookingDate { get; set; }
        public string RepresentativeName { get; set; }
    
        public string CategoryName { get; set; }
        public string CustomerRef { get; set; }
        public string RNNo { get; set; }
        public decimal BookingQty { get; set; }
        public decimal BookingValue { get; set; }
        public decimal CancelQty { get; set; }
        public decimal CancelValue { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal DelValue { get; set; }
        public decimal LCrcvValue { get; set; }
        public decimal LCBalance { get; set; }
        public string ISPISEND { get; set; }
        public string RetailerName { get; set; }
        public decimal DlvPer { get; set; }


        public string IssuerName { get; set; }
 
        public short RetailerId { get; set; }
        public string CompanyName { get; set; }
       
        public string ShortName { get; set; }
     
        public string ProductName { get; set; }
        public short ProductId { get; set; }
        public string Measurement { get; set; }
        public short MeasureUnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityUnit { get; set; }
        public short QuantityUnitId { get; set; }

    }
    public class PiAdvisingBondViewModel
    {
        public string ApiNumber { get; set; }
        public string BookingNo { get; set; }
        public decimal InvoiceQty { get; set; }
        public string QuantityUnit { get; set; }
        public string Measurement { get; set; }
        public string MeasureUnit { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string BondName { get; set; }
        public string HSCode { get; set; }
        public string CustomerName { get; set; }
        public string ShortName { get; set; }

        public string RetailerName { get; set; }

        public string IssuerName { get; set; }

        public string CompanyName { get; set; }

       
        //public string IssuerId { get; set; }
     
        //public string RetailerId { get; set; }
       
        //public string CompanyId { get; set; }
        //public string RepresentativeId { get; set; }
        
        //public decimal BookingQty { get; set; }
        //public decimal BookingValue { get; set; }
  
        //public string ProductId { get; set; }
       
        //public short MeasureUnitId { get; set; }
        //public decimal UnitPrice { get; set; }
       
        //public short QuantityUnitId { get; set; }
    }

    public class PiAdvisingBondMainViewModel
    {
        public string ApiNumber { get; set; }
        public string CustomerName { get; set; }
        public string RepName { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal InvoiceValue { get; set; }
        public DateTime ApiDate { get; set; }

        public string BookingNo { get; set;}

        public string IssuerName { get; set; }
        public short IssuerId { get; set; }
        public string RetailerName { get; set; }
        public short RetailerId { get; set; }
        public string CompanyName { get; set; }
        public short CompanyId { get; set; }
        public short RepresentativeId { get; set; }
        public string ShortName { get; set; }
        public decimal BookingQty { get; set; }
        public decimal BookingValue { get; set; }
        public string ProductName { get; set; }
        public short ProductId { get; set; }
        public string Measurement { get; set; }
        public short MeasureUnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityUnit { get; set; }
        public short QuantityUnitId { get; set; }

    }
    //public class BondApprovedPiUpdateViewModel
    //{
    //    public List<ParentModel> ParentList { get; set; }
    //    public PrcRptLcNotReceived AdvicePi { get; set; }
    //}

    //public class ParentModel : ChildModel
    //{
    //    public string ParentColumn1 { get; set; }
    //    public string ParentColumn2 { get; set; }
    //    public string ParentColumn3 { get; set; }
    //    public List<ChildModel> Children { get; set; }
    //}

    //public class ChildModel
    //{
    //    public string ChildColumn1 { get; set; }
    //    public string ChildColumn2 { get; set; }
    //    public string ChildColumn3 { get; set; }
    //}
    public class ApiData
    {
        public int Id { get; set; }
        public string ApiNumber { get; set; }
        public string BookingNo { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal DelValue { get; set; }

    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class PiAdvisingBondMainVM
    {
        public int Id { get; set; }
        public string ApiNumber { get; set; }
        public string BookingNo { get; set; }
        public int InvoiceQty { get; set; }
        public decimal Value { get; set; }
        public DateTime BookingDate { get; set; }
        public string Specification { get; set; }
        public string Size { get; set; }
        public string BondName { get; set; }
        public string Category { get; set; }
    }

    //public class ClauseModel
    //{
    //    //public int ClauseId { get; set; }
    //    //public string ClauseCode { get; set; }
    //    public string ClauseName { get; set; }

    //    //public int TermId { get; set; }
    //    public string TermName { get; set; }
    //    //public int ConditionId { get; set; }
    //    public string ConditionDetails { get; set; }
    //    //public string ConditionDetailsHTML { get; set; }
    //    //public int RowNo { get; set; }
    //    //public int IsActive { get; set; }
        
    //}
}