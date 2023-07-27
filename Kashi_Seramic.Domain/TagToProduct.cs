
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class TagToProduct
    {


        public int TagId { get; set; }
        public int ProductId { get; set; }

        public Tag Tag { get; set; }
        public Product Product { get; set; }

    }
}
