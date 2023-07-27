using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Models.Users
{
    public class VerifyTotpCodeVM
    {
        [Display(Name = "کد ارسال شده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [MaxLength(6, ErrorMessage = "حداکثر طول مجاز {0} {1} کاراکتر است.")]
        public string TotpCode { get; set; }
    }
}
