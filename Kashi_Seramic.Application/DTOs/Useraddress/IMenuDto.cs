using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.UserAddress
{
    public interface IUserAddressDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public bool ActiveByDefualt { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string CodePostal { get; set; }
        public string Avenu { get; set; }

    }
}
