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
using Kashi_Seramic.Application.DTOs.UserAddress.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserAddressDtoValidator(_unitOfWork.UserAddressRepository);
            var validationResult = await validator.ValidateAsync(request.UserAddressDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.UserAddressRepository.Get(request.UserAddressDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.UserAddressDto.Id);

            _mapper.Map(request.UserAddressDto, leaveType);

            await _unitOfWork.UserAddressRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
