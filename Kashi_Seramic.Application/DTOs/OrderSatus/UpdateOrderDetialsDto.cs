using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderSatus;

public class UpdateOrderSatusDto : BaseDto, IOrderSatusDto
{
    public int OrderId { get; set; }
}
