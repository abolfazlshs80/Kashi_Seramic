using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCategoryToBlogDetailRequestHandler : IRequestHandler<GetCategoryToBlogDetailRequest, CategoryToBlogDto>
    {
        private readonly ICategoryToBlogRepository _Repository;
        private readonly IMapper _mapper;

        public GetCategoryToBlogDetailRequestHandler(ICategoryToBlogRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<CategoryToBlogDto> Handle(GetCategoryToBlogDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetCategoryToBlogWithBlogId(request.Id);
            return _mapper.Map<CategoryToBlogDto>(leaveType);
        }
    }
}
