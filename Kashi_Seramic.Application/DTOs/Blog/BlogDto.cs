using Kashi_Seramic.Application.DTOs.TagToBlog;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.Common;
using Pr_Signal_ir.Application.DTOs.FileToBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Blog
{
    public class BlogDto : BaseDto
    {

        public string TitleBrowser { get; set; }

        public string ShortTitle { get; set; }

        public string LongTitle { get; set; }

        public string Text { get; set; }

        public int Seen { get; set; }
        public string Tag { get; set; }
        public string LinkKey { get; set; }

        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public IEnumerable<CategoryToBlogDto> CategoryToBlog { get; set; }
        public IEnumerable<FileToBlogDto> FileToBlog { get; set; }
        public IEnumerable<CommentToBlogDto> CommentToBlog { get; set; }
        public IEnumerable<TagToBlogDto> TagToBlog { get; set; }



    }
}
