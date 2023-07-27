using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kashi_Seramic.Application.DTOs.CommentToProduct
{
    public class CommentToProductDto : BaseDto
    {
        [AllowHtml]
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int ProductId { get; set; }
        public int? CommentSubId { get; set; } = 0;

        public int? Like { get; set; } = 0;
        public virtual ProductDto? Product { get; set; }
    }
}
