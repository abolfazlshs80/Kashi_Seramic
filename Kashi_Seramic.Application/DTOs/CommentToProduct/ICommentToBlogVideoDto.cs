using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CommentToProduct
{
    public interface ICommentToProductDto
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int ProductId { get; set; }
   
        public int? CommentSubId { get; set; } 

        public int? Like { get; set; }
    }
}
