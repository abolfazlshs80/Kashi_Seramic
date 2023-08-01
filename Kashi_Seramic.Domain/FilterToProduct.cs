using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class FilterToProduct
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public FilterValueProduct FilterValueProduct { get; set; }
    }
}
