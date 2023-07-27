using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands
{
    public class DeleteCommentToProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
