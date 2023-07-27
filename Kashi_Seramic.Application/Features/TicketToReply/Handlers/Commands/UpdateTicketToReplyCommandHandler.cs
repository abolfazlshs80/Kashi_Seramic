using AutoMapper;



using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

using System.ComponentModel.DataAnnotations;

using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.TicketToReply.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateTicketToReplyCommandHandler : IRequestHandler<UpdateTicketToReplyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTicketToReplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTicketToReplyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTicketToReplyDtoValidator(_unitOfWork.TicketToReplyRepository);
            var validationResult = await validator.ValidateAsync(request.TicketToReplyDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.TicketToReplyRepository.Get(request.TicketToReplyDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.TicketToReplyDto.Id);

            _mapper.Map(request.TicketToReplyDto, leaveType);

            await _unitOfWork.TicketToReplyRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
