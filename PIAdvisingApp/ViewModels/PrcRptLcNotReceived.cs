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
        //[BookingNo] VARCHAR(18),
        //[BookingDate] SMALLDATETIME,
        //[RepresentativeName] VARCHAR(150),
        //[CustomerName] VARCHAR(150),
        //[CustomerRef] VARCHAR(1129),
        //[RNNo] VARCHAR(500),
        //[BookingQty] MONEY,
        //[BookingValue] DECIMAL(38, 8),
        //[CancelQty] MONEY,
        //[CancelValue] DECIMAL(38, 8),
        //[InvoiceQty] MONEY,
        //[DelValue] DECIMAL(38, 8),
        //[LCrcvValue] DECIMAL(38, 6),
        //[LCBalance] DECIMAL(38, 6),
        //[ISPISEND] NVARCHAR(MAX),
        //[RetailerName] VARCHAR(150),
        //[DlvPer]
        //    DECIMAL(38, 6)

    }
}