using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class ResetPasswordDto
    {
        [Required]
        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Message { get; set; }
        public bool? Status { get; set; }
    }
}
