using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIAdvisingApp.ViewModels
{
    public class PrcRptLcNotReceived  
    {
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public string RepresentativeName { get; set; }
        public string CustomerName { get; set; }
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
        public string RepName { get; set; }
    }

    public class PiAdvisingBondMainViewModel
    {
        public string ApiNumber { get; set; }
        public string CustomerName { get; set; }
        public string RepName { get; set; }
        public decimal InvoiceQty { get; set; }
        public decimal InvoiceValue { get; set; }
       
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
}