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

using Kashi_Seramic.Application.Features.Order.Requests.Commands;
using Kashi_Seramic.Application.DTOs.Order.Validator;

namespace HR.LeaveManagement.Application.Features.Order.Handlers.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderDtoValidator(_unitOfWork.OrderRepository);
            var validationResult = await validator.ValidateAsync(request.OrderDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.OrderRepository.Get(request.OrderDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.OrderDto.Id);

            _mapper.Map(request.OrderDto, leaveType);

            await _unitOfWork.OrderRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
