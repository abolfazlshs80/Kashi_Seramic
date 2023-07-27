using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class TagToBlog
    {


        public int TagId { get; set; }
        public int BlogId { get; set; }

        public Tag Tag { get; set; }
        public Blog Blog { get; set; }

    }
}
