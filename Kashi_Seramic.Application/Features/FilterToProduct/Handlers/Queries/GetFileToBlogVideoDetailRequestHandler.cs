using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

using Kashi_Seramic.Application.DTOs.FilterToProduct;

namespace Kashi_Seramic.Application.Features.FilterToBlogVideo.Handlers.Queries
{
    public class GetFilterToProductDetailRequestHandler : IRequestHandler<GetFilterToProductDetailRequest, FilterToProductDto>
    {
        private readonly IFilterToProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetFilterToProductDetailRequestHandler(IFilterToProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<FilterToProductDto> Handle(GetFilterToProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetFilterToProductWithBlogId(request.Id);
            return _mapper.Map<FilterToProductDto>(leaveType);
        }
    }
}
