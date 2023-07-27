using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.TagToProduct.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TagToProduct;

namespace Kashi_Seramic.Application.Features.TagToBlogVideo.Handlers.Queries
{
    public class GetTagToProductDetailRequestHandler : IRequestHandler<GetTagToProductDetailRequest, TagToProductDto>
    {
        private readonly ITagToProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetTagToProductDetailRequestHandler(ITagToProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TagToProductDto> Handle(GetTagToProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTagToProductWithBlogId(request.Id);
            return _mapper.Map<TagToProductDto>(leaveType);
        }
    }
}
