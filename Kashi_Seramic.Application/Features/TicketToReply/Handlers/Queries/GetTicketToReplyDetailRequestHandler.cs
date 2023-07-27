using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TicketToReply;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTicketToReplyDetailRequestHandler : IRequestHandler<GetTicketToReplyDetailRequest, TicketToReplyDto>
    {
        private readonly ITicketToReplyRepository _Repository;
        private readonly IMapper _mapper;

        public GetTicketToReplyDetailRequestHandler(ITicketToReplyRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<TicketToReplyDto> Handle(GetTicketToReplyDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetTicketToReplyWithDetails(request.Id);
            return _mapper.Map<TicketToReplyDto>(leaveType);
        }
    }
}
