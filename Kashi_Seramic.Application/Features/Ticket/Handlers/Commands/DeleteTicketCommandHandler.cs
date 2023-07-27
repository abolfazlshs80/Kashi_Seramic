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
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var Ticket = await _unitOfWork.TicketRepository.Get(request.Id);

            if (Ticket == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Ticket), request.Id);

            await _unitOfWork.TicketRepository.Delete(Ticket);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
