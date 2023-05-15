using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIAdvisingApp.ViewModels
{
    
    
        public class LoginViewModel
        {
            [Required(ErrorMessage = "Please enter your user name.")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Please enter your password.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
}