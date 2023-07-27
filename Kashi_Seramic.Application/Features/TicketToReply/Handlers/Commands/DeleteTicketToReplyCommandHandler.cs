using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteTicketToReplyCommandHandler : IRequestHandler<DeleteTicketToReplyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTicketToReplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTicketToReplyCommand request, CancellationToken cancellationToken)
        {
            var TicketToReply = await _unitOfWork.TicketToReplyRepository.Get(request.Id);

            if (TicketToReply == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(TicketToReply), request.Id);

            await _unitOfWork.TicketToReplyRepository.Delete(TicketToReply);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
