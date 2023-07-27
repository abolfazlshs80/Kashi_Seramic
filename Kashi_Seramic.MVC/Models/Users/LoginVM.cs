using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Models
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string ReturnUrl { get; set; }
        public string   ErrorMessage{ get; set; }


    }
}
