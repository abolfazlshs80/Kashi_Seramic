using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kashi_Seramic.Identity.Models.Security.PhoneTotp
{
    public class PhoneTotpResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
