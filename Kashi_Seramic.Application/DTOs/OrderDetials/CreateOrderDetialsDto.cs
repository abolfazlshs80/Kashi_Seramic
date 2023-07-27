using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderDetials
{
    public class CreateOrderDetialsDto : IOrderDetialsDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }

    }
}
