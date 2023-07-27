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
using Kashi_Seramic.Application.DTOs.FilterValueProduct.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateFilterValueProductCommandHandler : IRequestHandler<UpdateFilterValueProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFilterValueProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFilterValueProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFilterValueProductDtoValidator(_unitOfWork.FilterValueProductRepository);
            var validationResult = await validator.ValidateAsync(request.FilterValueProductDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.FilterValueProductRepository.Get(request.FilterValueProductDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.FilterValueProductDto.Id);

            _mapper.Map(request.FilterValueProductDto, leaveType);

            await _unitOfWork.FilterValueProductRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
