using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Category;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CategoryToProduct
{
    public class CategoryToProductDto : ICategoryToProductDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public CategoryDto Category { get; set; }
    }
}
