using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FileToProduct;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Queries;

using Kashi_Seramic.Application.DTOs.FilterToProduct;

namespace Kashi_Seramic.Application.Features.FilterToBlogVideo.Handlers.Queries
{
    public class GetFilterToProductListRequestHandler : IRequestHandler<GetFilterToProductListRequest, List<FilterToProductDto>>
    {
        private readonly IFilterToProductRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetFilterToProductListRequestHandler(IFilterToProductRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<FilterToProductDto>> Handle(GetFilterToProductListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetAll();
            return _mapper.Map<List<FilterToProductDto>>(leaveTypes);
        }
    }
}
