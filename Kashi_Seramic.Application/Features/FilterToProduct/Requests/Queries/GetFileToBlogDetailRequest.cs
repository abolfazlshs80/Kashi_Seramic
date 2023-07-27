
using Kashi_Seramic.Application.DTOs.FilterToProduct;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;

using System;
using System.Collections.Generic;
using System.Text;
using Kashi_Seramic.Application.DTOs.FileToProduct;

namespace Kashi_Seramic.Application.Features.FilterToProduct.Requests.Queries
{
    public class GetFilterToProductDetailRequest : IRequest<FilterToProductDto>
    {
        public int Id { get; set; }
    }
}
