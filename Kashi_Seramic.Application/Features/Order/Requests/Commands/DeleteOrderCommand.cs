using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Order.Requests.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
