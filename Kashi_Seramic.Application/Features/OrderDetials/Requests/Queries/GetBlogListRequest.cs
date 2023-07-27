
using Kashi_Seramic.Application.DTOs.OrderDetials;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.OrderDetials.Requests.Queries
{
    public class GetOrderDetialsListRequest : IRequest<List<OrderDetialsDto>>
    {
    }
}
