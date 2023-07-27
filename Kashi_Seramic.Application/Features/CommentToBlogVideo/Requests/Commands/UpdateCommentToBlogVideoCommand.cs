
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands
{
    public class UpdateCommentToProductCommand : IRequest<Unit>
    {
        public UpdateCommentToProductDto CommentToProductDto { get; set; }
        public int Id { get; set; }

    }
}
