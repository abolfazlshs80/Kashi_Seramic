
using Kashi_Seramic.Application.DTOs.Order;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Order.Requests.Queries
{
    public class GetOrderListRequest : IRequest<List<OrdersDto>>
    {
    }
}
