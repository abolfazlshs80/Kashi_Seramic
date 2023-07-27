using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.Common;
using Pr_Signal_ir.Application.DTOs.FileToBlog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderDetials
{
    public class OrderDetialsDto : BaseDto
    {


        //public OrderDto Orders { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public ProductDto Product { get; set; }
        //public OrderDto Orders { get; set; }
    }
}
