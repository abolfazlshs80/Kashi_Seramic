using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Product;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.Product.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Product;

namespace Kashi_Seramic.Application.Features.Product.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _rep_Product;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(IProductRepository rep_Product, IMapper mapper)
        {
            _rep_Product = rep_Product;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_Product.GetProductsWithDetails();
            return _mapper.Map<List<ProductDto>>(leaveTypes);
        }
    }
}
