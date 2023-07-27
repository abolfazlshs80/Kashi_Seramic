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
using Kashi_Seramic.Application.DTOs.TicketGroup.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateTicketGroupCommandHandler : IRequestHandler<UpdateTicketGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTicketGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTicketGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTicketGroupDtoValidator(_unitOfWork.TicketGroupRepository);
            var validationResult = await validator.ValidateAsync(request.TicketGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.TicketGroupRepository.Get(request.TicketGroupDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.TicketGroupDto.Id);

            _mapper.Map(request.TicketGroupDto, leaveType);

            await _unitOfWork.TicketGroupRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
