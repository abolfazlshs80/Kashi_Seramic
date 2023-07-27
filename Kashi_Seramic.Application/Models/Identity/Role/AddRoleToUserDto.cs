using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Models.Identity.Role
{
    public class AddRoleToUserDto
    {
        public bool Selected { get; set; } = false;
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
    }
}
