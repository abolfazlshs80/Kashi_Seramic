
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToProduct
{
    public interface ITagToProductDto
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

    }
}
