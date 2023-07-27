using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.Blog;
using System.Web.Mvc;

namespace Pr_Signal_ir.Application.DTOs.CommentToBlog
{
    public class CommentToBlogDto:BaseDto
    {
        [AllowHtml]
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int BlogId { get; set; }

        public int? CommentSubId { get; set; } = 0;
        public int? Like { get; set; } = 0;
        public virtual BlogDto? Blog { get; set; }
    }
}
