using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Tag
{
    public class CreateTagDto : BaseDto, ITagDto
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string Name { get; set; }
    }
}
