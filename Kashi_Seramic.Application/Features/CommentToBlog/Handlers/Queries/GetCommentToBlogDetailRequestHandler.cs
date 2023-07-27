using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCommentToBlogDetailRequestHandler : IRequestHandler<GetCommentToBlogDetailRequest, CommentToBlogDto>
    {
        private readonly ICommentToBlogRepository _Repository;
        private readonly IMapper _mapper;

        public GetCommentToBlogDetailRequestHandler(ICommentToBlogRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<CommentToBlogDto> Handle(GetCommentToBlogDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetCommentToBlogWithDCommentId(request.Id);
            return _mapper.Map<CommentToBlogDto>(leaveType);
        }
    }
}
