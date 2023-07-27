using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands
{
    public class DeleteOrderDetialsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
