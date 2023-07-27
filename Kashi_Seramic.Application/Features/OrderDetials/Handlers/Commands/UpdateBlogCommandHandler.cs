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

using Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands;
using Kashi_Seramic.Application.DTOs.OrderDetials.Validator;

namespace HR.LeaveManagement.Application.Features.OrderDetials.Handlers.Commands
{
    public class UpdateOrderDetialsCommandHandler : IRequestHandler<UpdateOrderDetialsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderDetialsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderDetialsCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderDetialsDtoValidator(_unitOfWork.OrderDetailsRepository);
            var validationResult = await validator.ValidateAsync(request.OrderDetialsDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.OrderDetailsRepository.Get(request.OrderDetialsDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.OrderDetialsDto.Id);

            _mapper.Map(request.OrderDetialsDto, leaveType);

            await _unitOfWork.OrderDetailsRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
