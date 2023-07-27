using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Kashi_Seramic.Application.DTOs.TagToBlog;
using Kashi_Seramic.Application.DTOs.TagToProduct;

namespace Kashi_Seramic.Application.DTOs.Tag
{
    public class TagDto : BaseDto
    {
        public string Name { get; set; }

        public IEnumerable<TagToBlogDto> TagToBlog { get; set; }
        public IEnumerable<TagToProductDto> TagToProduct { get; set; }

    }
}
