using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Kashi_Seramic.Application.DTOs.Product;
using Kashi_Seramic.Application.DTOs.Tag;

namespace Kashi_Seramic.Application.DTOs.TagToProduct
{
    public class TagToProductDto : BaseDto
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

        public virtual TagDto Tag { get; set; }
        public virtual ProductDto Product { get; set; }

    }
}
