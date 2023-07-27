
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToProduct;
using Pr_Signal_ir.Application.DTOs.Common;
using Pr_Signal_ir.Application.DTOs.FileToBlog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }

        public decimal OffPrice { get; set; }
        public int Qountity { get; set; }
        public int Seen { get; set; }
        public string LinkKey { get; set; }
        public IEnumerable<OrderDetails> orderDetails { get; set; }

        public IEnumerable<CategoryToProductDto> CategoryToProduct { get; set; }
        public IEnumerable<FileToProductDto> FileToProduct { get; set; }
        public IEnumerable<CommentToProductDto> CommentToProduct { get; set; }

        public IEnumerable<TagToProductDto> TagToProduct { get; set; }
        public ICollection<FilterToProductDto> FilterToProduct { get; set; }

    }
}
