using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Tag;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTagDetailRequestHandler : IRequestHandler<GetTagDetailRequest, TagDto>
    {
        private readonly ITagRepository _Repository;
        private readonly IMapper _mapper;

        public GetTagDetailRequestHandler(ITagRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TagDto> Handle(GetTagDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTagWithDetails(request.Id);
            return _mapper.Map<TagDto>(leaveType);
        }
    }
}
