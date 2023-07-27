using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class Category : BaseDomainEntity
    {



        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
        public string? Text { get; set; }
        public ICollection<FilterProduct> FilterProduct { get; set; }
        public ICollection<CategoryToBlog> CategoryToBlog { get; set; }
        public ICollection<CategoryToProduct> CategoryToProduct { get; set; }



    }
}
