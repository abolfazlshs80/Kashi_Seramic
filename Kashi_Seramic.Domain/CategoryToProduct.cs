using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }

    }
}
