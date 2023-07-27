
using Kashi_Seramic.Application.DTOs.OrderDetials;
using Kashi_Seramic.Application.Responses;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands
{
    public class CreateOrderDetialsCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrderDetialsDto CreateOrderDetialsDto { get; set; }

    }
}
