using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCategoryToBlogListRequestHandler : IRequestHandler<GetCategoryToBlogListRequest, List<CategoryToBlogDto>>
    {
        private readonly ICategoryToBlogRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetCategoryToBlogListRequestHandler(ICategoryToBlogRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<CategoryToBlogDto>> Handle(GetCategoryToBlogListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetAll();
            return _mapper.Map<List<CategoryToBlogDto>>(leaveTypes);
        }
    }
}
