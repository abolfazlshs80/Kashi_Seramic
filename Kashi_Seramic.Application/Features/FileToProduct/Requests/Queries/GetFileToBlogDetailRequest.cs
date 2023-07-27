
using Kashi_Seramic.Application.DTOs.FileToProduct;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToProduct.Requests.Queries
{
    public class GetFileToProductDetailRequest : IRequest<FileToProductDto>
    {
        public int Id { get; set; }
    }
}
