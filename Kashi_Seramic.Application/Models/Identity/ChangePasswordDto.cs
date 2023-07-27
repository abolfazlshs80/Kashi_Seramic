using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity
{
    public class ChangePasswordDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
