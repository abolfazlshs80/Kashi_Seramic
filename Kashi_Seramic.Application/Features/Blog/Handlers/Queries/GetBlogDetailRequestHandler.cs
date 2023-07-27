using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.Blog.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.Contracts.Persistence;

namespace Kashi_Seramic.Application.Features.Blog.Handlers.Queries
{
    public class GetBlogDetailRequestHandler : IRequestHandler<GetBlogDetailRequest, BlogDto>
    {
        private readonly IBlogRepository _Repository;
        private readonly IMapper _mapper;

        public GetBlogDetailRequestHandler(IBlogRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<BlogDto> Handle(GetBlogDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetBlogWithDetails(request.Id);
            var map = _mapper.Map<BlogDto>(leaveType);
            return _mapper.Map<BlogDto>(leaveType);
        }
    }
}
