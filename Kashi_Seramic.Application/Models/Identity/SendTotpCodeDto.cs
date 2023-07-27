using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class SendTotpCodeDto
    {
        public string? PhoneNumber { get; set; } = "";
        public string? PTC { get; set; }
        public bool? Status { get; set; } = false;
        public string? Message { get; set; } = "";
        public string? Code { get; set; } = "";
    }
}
