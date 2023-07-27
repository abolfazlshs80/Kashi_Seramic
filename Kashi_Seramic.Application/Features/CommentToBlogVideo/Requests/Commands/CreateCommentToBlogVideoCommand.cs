
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Kashi_Seramic.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands
{
    public class CreateCommentToProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateCommentToProductDto CreateCommentToProductDto { get; set; }

    }
}
