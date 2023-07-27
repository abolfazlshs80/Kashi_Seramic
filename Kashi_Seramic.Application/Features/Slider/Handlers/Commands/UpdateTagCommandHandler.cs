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
using Kashi_Seramic.Application.DTOs.Slider.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSliderDtoValidator(_unitOfWork.SliderRepository);
            var validationResult = await validator.ValidateAsync(request.SliderDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.SliderRepository.Get(request.SliderDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.SliderDto.Id);

            _mapper.Map(request.SliderDto, leaveType);

            await _unitOfWork.SliderRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
