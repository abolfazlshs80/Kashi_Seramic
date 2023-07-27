
using Kashi_Seramic.Application.DTOs.Order;
using Kashi_Seramic.Application.Responses;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Order.Requests.Commands
{
    public class CreateOrderCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrdersDto CreateOrderDto { get; set; }

    }
}
