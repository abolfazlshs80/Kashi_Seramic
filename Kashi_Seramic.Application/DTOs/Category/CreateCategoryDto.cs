using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Category
{
    public class CreateCategoryDto :BaseDto, ICategoryDto
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
        public string? Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
