using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteTicketGroupCommandHandler : IRequestHandler<DeleteTicketGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTicketGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTicketGroupCommand request, CancellationToken cancellationToken)
        {
            var TicketGroup = await _unitOfWork.TicketGroupRepository.Get(request.Id);

            if (TicketGroup == null)
                throw new NotFoundException(nameof(TicketGroup), request.Id);

            await _unitOfWork.TicketGroupRepository.Delete(TicketGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
