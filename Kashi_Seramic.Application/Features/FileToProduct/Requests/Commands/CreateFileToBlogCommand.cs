
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToProduct.Requests.Commands
{
    public class CreateFileToProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateFileToProductDto CreateFileImageDto { get; set; }

    }
}
