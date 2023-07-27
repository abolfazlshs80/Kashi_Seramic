using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Ticket;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTicketDetailRequestHandler : IRequestHandler<GetTicketDetailRequest, TicketDto>
    {
        private readonly ITicketRepository _Repository;
        private readonly IMapper _mapper;

        public GetTicketDetailRequestHandler(ITicketRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TicketDto> Handle(GetTicketDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTicketWithDetails(request.Id);
            return _mapper.Map<TicketDto>(leaveType);
        }
    }
}
