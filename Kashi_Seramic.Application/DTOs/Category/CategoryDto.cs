using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Category
{
    public class CategoryDto :BaseDto
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
        public string? Text { get; set; }
        public ICollection<FilterProductDto> FilterProduct { get; set; }
        public ICollection<CategoryToBlogDto> CategoryToBlog { get; set; }
        public ICollection<CategoryToProductDto> CategoryToProduct { get; set; }



    }
}
