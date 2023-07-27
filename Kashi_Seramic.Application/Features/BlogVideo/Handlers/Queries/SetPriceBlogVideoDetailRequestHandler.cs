using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Product;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.Product.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Product;

namespace Kashi_Seramic.Application.Features.Product.Handlers.Queries
{
    public class SetPriceProductDetailRequestHandler : IRequestHandler<SetPriceProductDetailRequest, ProductDto>
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;

        public SetPriceProductDetailRequestHandler(IProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(SetPriceProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetProductWithDetails(request.Id);
            leaveType.OffPrice = request.offPrice;
            await _Repository.UpdateProduct(leaveType);
            
            return _mapper.Map<ProductDto>(leaveType);
       
        }
         
    
    }
}
