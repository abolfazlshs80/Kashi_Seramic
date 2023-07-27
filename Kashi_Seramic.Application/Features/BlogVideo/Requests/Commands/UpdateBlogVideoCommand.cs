
using Kashi_Seramic.Application.DTOs.Product;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto ProductDto { get; set; }
        public int Id { get; set; }

    }
}
