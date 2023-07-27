using Pr_Signal_ir.Application.DTOs.Common;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToProduct
{
    public class UpdateTagToProductDto : BaseDto, ITagToProductDto
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

    }
}
