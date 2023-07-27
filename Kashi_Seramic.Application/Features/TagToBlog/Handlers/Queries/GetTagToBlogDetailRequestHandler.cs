using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TagToBlog;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTagToBlogDetailRequestHandler : IRequestHandler<GetTagToBlogDetailRequest, TagToBlogDto>
    {
        private readonly ITagToBlogRepository _Repository;
        private readonly IMapper _mapper;

        public GetTagToBlogDetailRequestHandler(ITagToBlogRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TagToBlogDto> Handle(GetTagToBlogDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTagToBlogWithBlogId(request.Id);
            return _mapper.Map<TagToBlogDto>(leaveType);
        }
    }
}
