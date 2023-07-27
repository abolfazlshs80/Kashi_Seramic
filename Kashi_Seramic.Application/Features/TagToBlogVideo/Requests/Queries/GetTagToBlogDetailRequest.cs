
using Kashi_Seramic.Application.DTOs.TagToProduct;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.TagToProduct.Requests.Queries
{
    public class GetTagToProductDetailRequest : IRequest<TagToProductDto>
    {
        public int Id { get; set; }
    }
}
