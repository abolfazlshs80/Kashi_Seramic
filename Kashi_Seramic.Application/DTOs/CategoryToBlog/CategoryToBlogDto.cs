using Kashi_Seramic.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CategoryToBlog
{
    public class CategoryToBlogDto : ICategoryToBlogDto
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

        public BlogDto Blog { get; set; }
        //public CategoryDto Category { get; set; }
    }
}
