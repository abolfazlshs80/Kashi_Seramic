
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Category;

namespace Kashi_Seramic.Application.DTOs.FilterProduct
{
    public class FilterProductDto : BaseDto
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Categories { get; set; }
        public IEnumerable<FilterValueProductDto> FilterValueProduct { get; set; }
    }
}
