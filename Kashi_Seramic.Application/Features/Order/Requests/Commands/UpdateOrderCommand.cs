
using Kashi_Seramic.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Order.Requests.Commands
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public UpdateOrdersDto OrderDto { get; set; }
        public int Id { get; set; }

    }
}
