using Kashi_Seramic.Application.DTOs.Order;
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

namespace Kashi_Seramic.Application.DTOs.OrderSatus;

public class OrderSatusDto : BaseDto
{

    public int OrderId { get; set; }

    public OrdersDto Orders { get; set; }
}
