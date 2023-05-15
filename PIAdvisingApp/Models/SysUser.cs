using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PIAdvisingApp.Models
{
    public class SysUser
    {
        [Key]
        public short UserId { get; set; }
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        public string UserPWD { get; set; }
        public string UserTitle { get; set; }
        public short DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string ShortName { get; set; }
        public string eMail { get; set; }
        public string BookingEntryCatId { get; set; }
        public string BookingEntryLocationId { get; set; }
        public string MinPriceQAppCatId { get; set; }
        public string MinPriceQAppLocationId { get; set; }
        public string CRLimitQAppCatId { get; set; }
        public string CRLimitQAppLocationId { get; set; }
        public string RevisionCatId { get; set; }
        public string RevisionLocationId { get; set; }
        public string BarCodeRcvTypeId { get; set; }
        public short LocationId { get; set; }
        public string LoginKey { get; set; }
        public System.DateTime KeyStartDate { get; set; }
        public System.DateTime KeyEndDate { get; set; }
        public string ADMRetailerId { get; set; }
        public short UserTypeId { get; set; }
        public short UserLevelId { get; set; }
        public byte IsLogged { get; set; }
        public byte IsActive { get; set; }
    }
}