using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Product
{
    public interface IProductDto
    {

        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }

        public decimal OffPrice { get; set; }
        public int Qountity { get; set; }
        public int Seen { get; set; }
      

  


    }
}
