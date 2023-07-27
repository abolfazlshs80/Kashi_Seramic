﻿
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.DTOs.OrderSatus;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateOrderSatusCommand : IRequest<Unit>
    {
        public UpdateOrderSatusDto OrderSatusDto { get; set; }
        public int Id { get; set; }

    }
}
