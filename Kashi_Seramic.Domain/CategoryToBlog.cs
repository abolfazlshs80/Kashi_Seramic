using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class CategoryToBlog
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public Category Category { get; set; }

    }
}
