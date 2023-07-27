
using Kashi_Seramic.Application.DTOs.FilterToProduct;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;
using Kashi_Seramic.Application.DTOs.FileToProduct;

namespace Kashi_Seramic.Application.Features.FilterToProduct.Requests.Commands
{
    public class CreateFilterToProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateFilterToProductDto CreateFilterImageDto { get; set; }

    }
}
