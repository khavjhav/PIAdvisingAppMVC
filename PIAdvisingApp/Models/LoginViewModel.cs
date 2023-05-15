using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIAdvisingApp.Models;

namespace PIAdvisingApp.Controllers
{

    public class LoginViewModel
    {
        // GET: Login
        [Key]
        public string UserName { get; set; }
        public string UserPWD { get; set; }

    }

    public class SysUserInfo : DbContext
    {
        public DbSet<LoginViewModel> Users { get; set; }
        // other DbSet properties

        // other code
    }

}
