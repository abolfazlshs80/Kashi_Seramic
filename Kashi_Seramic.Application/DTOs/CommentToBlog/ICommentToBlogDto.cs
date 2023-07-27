using Kashi_Seramic.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pr_Signal_ir.Application.DTOs.CommentToBlog
{
    public interface ICommentToBlogDto
    {
        [AllowHtml]
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int BlogId { get; set; }

        public int? CommentSubId { get; set; }
        public int? Like { get; set; }
    }
}
