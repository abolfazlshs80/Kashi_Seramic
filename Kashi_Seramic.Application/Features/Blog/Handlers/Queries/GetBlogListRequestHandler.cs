using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.Blog.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.Contracts.Persistence;

namespace Kashi_Seramic.Application.Features.Blog.Handlers.Queries
{
    public class GetBlogListRequestHandler : IRequestHandler<GetBlogListRequest, List<BlogDto>>
    {
        private readonly IBlogRepository _rep_Blog;
        private readonly IMapper _mapper;

        public GetBlogListRequestHandler(IBlogRepository rep_Blog, IMapper mapper)
        {
            _rep_Blog = rep_Blog;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(GetBlogListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_Blog.GetBlogsWithDetails();
            return _mapper.Map<List<BlogDto>>(leaveTypes);
        }
    }
}
