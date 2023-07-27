using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pr_Signal_ir.MVC.Models.Users
{
    public class ForgotPasswordVM
    {
       
            [Required]
            [Display(Name = "ایمیل")]
            [EmailAddress]
            public string Email { get; set; }
        
    }
}
