using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.DTOs.Tag;

namespace Kashi_Seramic.Application.DTOs.TagToBlog
{
    public class TagToBlogDto 
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }

        public virtual TagDto Tag { get; set; }
        public virtual BlogDto Blog { get; set; }

    }
}
