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

using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.Contracts.Persistence;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetFaqUserListRequestHandler : IRequestHandler<GetFaqUserListRequest, List<FaqUserDto>>
    {
        private readonly IFaqUserRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetFaqUserListRequestHandler(IFaqUserRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<FaqUserDto>> Handle(GetFaqUserListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetFaqUsersWithDetails();
            return _mapper.Map<List<FaqUserDto>>(leaveTypes);
        }
    }
}
