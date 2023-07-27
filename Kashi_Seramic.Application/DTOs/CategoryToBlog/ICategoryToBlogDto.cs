using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CategoryToBlog
{
    public interface ICategoryToBlogDto
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
    }
}
