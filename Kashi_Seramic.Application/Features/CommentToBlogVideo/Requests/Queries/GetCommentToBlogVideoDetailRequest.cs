
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Requests.Queries
{
    public class GetCommentToProductDetailRequest : IRequest<CommentToProductDto>
    {
        public int Id { get; set; }
    }
}
