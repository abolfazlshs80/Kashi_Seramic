using Pr_Signal_ir.Application.DTOs.Common;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToBlog
{
    public class UpdateTagToBlogDto : BaseDto, ITagToBlogDto
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }

    }
}
