using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Menu
{
    public class CreateMenuDto : IMenuDto
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public int Order { get; set; }
        public bool StatusInFooter { get; set; }
        public bool StatusInMainMenu { get; set; }

        public bool StatusInUserMenu { get; set; }

        public bool StatusInAdminMenu { get; set; }
        public string RoleName { get; set; }
        public string Icons { get; set; }
        public string ControllerName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }

    }
}
