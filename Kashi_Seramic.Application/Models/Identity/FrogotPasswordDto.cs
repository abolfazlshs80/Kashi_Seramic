using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class FrogotPasswordDto
    {
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Message { get; set; } = " ";
    }
}
