using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CommentToBlog
{
    public class CreateCommentToBlogDto:  ICommentToBlogDto
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int BlogId { get; set; }

        public int? CommentSubId { get; set; }
        public int? Like { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
