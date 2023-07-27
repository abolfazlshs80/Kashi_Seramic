using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.Menu;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetMenuListRequestHandler : IRequestHandler<GetMenuListRequest, List<MenuDto>>
    {
        private readonly IMenuRepository _rep_Menu;
        private readonly IMapper _mapper;

        public GetMenuListRequestHandler(IMenuRepository rep_Menu, IMapper mapper)
        {
            _rep_Menu = rep_Menu;
            _mapper = mapper;
        }

        public async Task<List<MenuDto>> Handle(GetMenuListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_Menu.GetAll();
            return _mapper.Map<List<MenuDto>>(leaveTypes);
        }
    }
}
