using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Queries;
using Kashi_Seramic.Application.DTOs.CategoryToProduct;

namespace Kashi_Seramic.Application.Features.CategoryToProductVideo.Handlers.Queries
{
    public class GetCategoryToProductDetailRequestHandler : IRequestHandler<GetCategoryToProductDetailRequest, CategoryToProductDto>
    {
        private readonly ICategoryToProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetCategoryToProductDetailRequestHandler(ICategoryToProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<CategoryToProductDto> Handle(GetCategoryToProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetCategoryToProductWithBlogId(request.Id);
            return _mapper.Map<CategoryToProductDto>(leaveType);
        }
    }
}
