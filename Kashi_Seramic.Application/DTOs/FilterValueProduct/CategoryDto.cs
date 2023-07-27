
using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FilterProduct;

namespace Kashi_Seramic.Application.DTOs.FilterValueProduct
{
    public class FilterValueProductDto : BaseDto
    {

        public string Value { get; set; }
        public int FilterId { get; set; }
        public FilterProductDto FilterProduct { get; set; }
    }
}
