using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.Contracts.Persistence;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetFaqUserDetailRequestHandler : IRequestHandler<GetFaqUserDetailRequest, FaqUserDto>
    {
        private readonly IFaqUserRepository _Repository;
        private readonly IMapper _mapper;

        public GetFaqUserDetailRequestHandler(IFaqUserRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<FaqUserDto> Handle(GetFaqUserDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetFaqUserWithDetails(request.Id);
            return _mapper.Map<FaqUserDto>(leaveType);
        }
    }
}
