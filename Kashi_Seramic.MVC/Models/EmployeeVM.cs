using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pr_Signal_ir.MVC.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
       
        [Remote(action: "IS_EMAIL_USE", controller: "RemoteValidation", HttpMethod = "POST", ErrorMessage = "نام کاربری وارد شده قبلا در سایت ثبت شده است")]

        public string? Email { get; set; }
        [Remote("IS_USERNAME_USE", "RemoteValidation", HttpMethod = "Post", AdditionalFields = "__RequestVerificationToken")]

        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        [Remote("IS_PHONE_USE", "RemoteValidation", HttpMethod = "Post", AdditionalFields = "__RequestVerificationToken")]

        public string? PhoneNumber { get; set; }
    }
}
