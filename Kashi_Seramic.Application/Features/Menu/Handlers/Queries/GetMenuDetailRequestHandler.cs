using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Menu;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetMenuDetailRequestHandler : IRequestHandler<GetMenuDetailRequest, MenuDto>
    {
        private readonly IMenuRepository _Repository;
        private readonly IMapper _mapper;

        public GetMenuDetailRequestHandler(IMenuRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<MenuDto> Handle(GetMenuDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.Get(request.Id);
            return _mapper.Map<MenuDto>(leaveType);
        }
    }
}
