
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Product;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductDto CreateProductDto { get; set; }

    }
}
