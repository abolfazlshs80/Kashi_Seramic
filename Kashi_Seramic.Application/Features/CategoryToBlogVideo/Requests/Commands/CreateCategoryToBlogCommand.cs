
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Commands
{
    public class CreateCategoryToProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryToProductDto CreateCategoryToProductDto { get; set; }

    }
}
