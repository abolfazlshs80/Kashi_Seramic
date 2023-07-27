using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class FileToProduct
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public FileManager FileManager { get; set; }
    }
}
