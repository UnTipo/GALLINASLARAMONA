using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.Login
{
    public class Login
    {
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)] 
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)] 
        public string password { get; set; }
    }
}