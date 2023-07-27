using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Blog
{
    public class CreateProductDto:  IProductDto
    {
        public string? Owner { get; set; }
        public string LinkKey { get; set; }
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }

        public decimal OffPrice { get; set; }
        public int Qountity { get; set; }
        public int Seen { get; set; }
     
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
