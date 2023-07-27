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
using Pr_Signal_ir.Application.DTOs.Category;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.Inventory;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetCategoryListRequestHandler(ICategoryRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetCategoryWithDetails();
            return _mapper.Map<List<CategoryDto>>(leaveTypes);
        }
    }
}
