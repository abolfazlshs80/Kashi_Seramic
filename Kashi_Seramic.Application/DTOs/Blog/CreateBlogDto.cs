using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Blog
{
    public class CreateBlogDto : IBlogDto
    {
        public string? Owner { get; set; }
        public string TitleBrowser { get; set; }

        public string ShortTitle { get; set; }

        public string LongTitle { get; set; }

        public string Text { get; set; }

        public int Seen { get; set; }
        public string Tag { get; set; }
        public string LinkKey { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

    }
}
