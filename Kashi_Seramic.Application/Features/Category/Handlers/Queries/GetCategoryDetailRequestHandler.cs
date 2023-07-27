using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Category;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.Inventory;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest, CategoryDto>
    {
        private readonly ICategoryRepository _Repository;
        private readonly IMapper _mapper;

        public GetCategoryDetailRequestHandler(ICategoryRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetCategoryWithDetails(request.Id);
            return _mapper.Map<CategoryDto>(leaveType);
        }
    }
}
