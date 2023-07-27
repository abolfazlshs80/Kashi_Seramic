
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Queries
{
    public class GetCategoryToProductDetailRequest : IRequest<CategoryToProductDto>
    {
        public int Id { get; set; }
    }
}
