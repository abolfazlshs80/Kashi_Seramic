using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TicketGroup;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTicketGroupDetailRequestHandler : IRequestHandler<GetTicketGroupDetailRequest, TicketGroupDto>
    {
        private readonly ITicketGroupRepository _Repository;
        private readonly IMapper _mapper;

        public GetTicketGroupDetailRequestHandler(ITicketGroupRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TicketGroupDto> Handle(GetTicketGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTicketGroupWithDetails(request.Id);
            return _mapper.Map<TicketGroupDto>(leaveType);
        }
    }
}
