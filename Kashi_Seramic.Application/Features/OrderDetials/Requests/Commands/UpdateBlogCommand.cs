
using Kashi_Seramic.Application.DTOs.OrderDetials;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands
{
    public class UpdateOrderDetialsCommand : IRequest<Unit>
    {
        public UpdateOrderDetialsDto OrderDetialsDto { get; set; }
        public int Id { get; set; }

    }
}
