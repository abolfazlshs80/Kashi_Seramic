using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCommentToBlogListRequestHandler : IRequestHandler<GetCommentToBlogListRequest, List<CommentToBlogDto>>
    {
        private readonly ICommentToBlogRepository _rep_CommentToBlog;
        private readonly IMapper _mapper;

        public GetCommentToBlogListRequestHandler(ICommentToBlogRepository rep_CommentToBlog, IMapper mapper)
        {
            _rep_CommentToBlog = rep_CommentToBlog;
            _mapper = mapper;
        }

        public async Task<List<CommentToBlogDto>> Handle(GetCommentToBlogListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_CommentToBlog.GetCommentToBlogs();
            return _mapper.Map<List<CommentToBlogDto>>(leaveTypes);
        }
    }
}
