
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.TagToProduct.Requests.Commands
{
    public class CreateTagToProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateTagToProductDto CreateTagToProductDto { get; set; }

    }
}
