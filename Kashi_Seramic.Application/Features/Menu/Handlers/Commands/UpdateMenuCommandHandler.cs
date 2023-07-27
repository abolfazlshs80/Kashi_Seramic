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
using Kashi_Seramic.Application.DTOs.Menu.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMenuDtoValidator(_unitOfWork.MenuRepository);
            var validationResult = await validator.ValidateAsync(request.MenuDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.MenuRepository.Get(request.MenuDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.MenuDto.Id);

            _mapper.Map(request.MenuDto, leaveType);

            await _unitOfWork.MenuRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
