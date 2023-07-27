using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class FileToBlog
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public FileManager FileManager { get; set; }
    }
}
