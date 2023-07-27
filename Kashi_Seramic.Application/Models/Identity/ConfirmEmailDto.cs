using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
