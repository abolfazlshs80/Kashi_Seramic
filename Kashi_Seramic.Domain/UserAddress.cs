using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain
{
    public class UserAddress:BaseDomainEntity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; } 
        public string City { get; set; }
        public string CodePostal { get; set; }
        public string Avenu { get; set; }
        public bool ActiveByDefualt { get; set; }

    }
}
