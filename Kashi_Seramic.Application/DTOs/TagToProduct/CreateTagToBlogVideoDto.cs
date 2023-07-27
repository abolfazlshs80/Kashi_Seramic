using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToProduct
{
    public class CreateTagToProductDto : BaseDto, ITagToProductDto
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public int TagId { get; set; }
        public int ProductId { get; set; }

    }
}
