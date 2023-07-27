using Kashi_Seramic.Application.DTOs.FileManager;
using Pr_Signal_ir.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Application.DTOs.Product;

namespace Kashi_Seramic.Application.DTOs.FileToProduct
{
    public class FilterToProductDto
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public FilterValueProductDto FilterValueProduct { get; set; }
    }
}
