using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain
{
    public class FilterProduct:BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public  Category Categories { get; set; }
        public IEnumerable< FilterValueProduct> FilterValueProduct { get; set; }
        public IEnumerable< FilterToProduct> FilterToProduct { get; set; }
    }
}
