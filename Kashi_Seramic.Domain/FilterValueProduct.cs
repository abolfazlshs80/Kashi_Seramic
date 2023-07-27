using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain
{
    public class FilterValueProduct:BaseDomainEntity
    {
        public string Value { get; set; }
        public int FilterId { get; set; }
        public FilterProduct FilterProduct { get; set; }
        public IEnumerable< FilterToProduct> FilterToProduct { get; set; }


    }
}
