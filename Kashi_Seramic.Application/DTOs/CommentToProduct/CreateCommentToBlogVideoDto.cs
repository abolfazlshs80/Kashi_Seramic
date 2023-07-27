﻿using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CommentToProduct
{
    public class CreateCommentToProductDto : ICommentToProductDto
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int ProductId { get; set; }
        public int? CommentSubId { get; set; } = 0;

        public int? Like { get; set; } = 0;
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
