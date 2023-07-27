
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class Menu : BaseDomainEntity
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
    }
}
