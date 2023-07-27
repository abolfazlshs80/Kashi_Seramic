
using Kashi_Seramic.Application.DTOs.OrderDetials;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.OrderDetials.Requests.Queries
{
    public class GetOrderDetialsDetailRequest : IRequest<OrderDetialsDto>
    {
        public int Id { get; set; }
    }
}
