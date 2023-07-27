using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderDetials
{
    public class UpdateOrderDetialsDto : BaseDto, IOrderDetialsDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
    }
}
