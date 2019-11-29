using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationSite.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не сопадают")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int Age { get; set; }
    }
}