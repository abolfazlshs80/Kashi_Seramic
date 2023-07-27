
using Kashi_Seramic.Application.DTOs.Product;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Product.Requests.Queries
{
    public class SetEnableProductDetailRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
