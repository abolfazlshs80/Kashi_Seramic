using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class PhoneTotpTempDataModel
    {
        public byte[] SecretKey { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
