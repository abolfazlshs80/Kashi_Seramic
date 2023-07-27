using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FilterToProduct.Requests.Commands
{
    public class DeleteFilterToProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
