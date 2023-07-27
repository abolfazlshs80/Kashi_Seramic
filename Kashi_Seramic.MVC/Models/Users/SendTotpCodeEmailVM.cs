using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Models.Users
{
    public class SendTotpCodeEmailVM
    {
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [MaxLength(50, ErrorMessage = "حداکثر طول مجاز {0} {1} کاراکتر است.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
