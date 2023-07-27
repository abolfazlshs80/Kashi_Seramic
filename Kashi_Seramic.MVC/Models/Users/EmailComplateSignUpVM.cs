using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pr_Signal_ir.MVC.Models.Users
{
    public class EmailComplateSignUpVM
    {


        public string UserId { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "نام کاربری")]
        [Remote("IsUserNameInUse", "Home", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }

        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "رمزعبور باید حداقل {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(Password), ErrorMessage = "رمزعبور و تکرار رمزعبور یکسان نیستند")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "تکرار رمزعبور باید حداقل {1} کاراکتر باشد")]
        public string ConfirmPassword { get; set; }
    }
}
