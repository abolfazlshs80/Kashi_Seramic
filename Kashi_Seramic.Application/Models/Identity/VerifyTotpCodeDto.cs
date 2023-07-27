using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class VerifyTotpCodeDto
    {
        public string? PTC { get; set; } = "";
        public bool? Status { get; set; } = false;
        public string? Message { get; set; } = "";
        public string? TotpCode { get; set; } = "";
    }
}
