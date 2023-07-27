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
using Kashi_Seramic.Application.Features.FileManager.Requests.Commands;
using Kashi_Seramic.Application.DTOs.FileManager.Validator;

namespace HR.LeaveManagement.Application.Features.FileManager.Handlers.Commands
{
    public class UpdateFileManagerCommandHandler : IRequestHandler<UpdateFileManagerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFileManagerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFileManagerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFileManagersDtoValidator(_unitOfWork.FileManagerRepository);
            var validationResult = await validator.ValidateAsync(request.FileImageDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.FileManagerRepository.Get(request.FileImageDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.FileImageDto.Id);

            _mapper.Map(request.FileImageDto, leaveType);

            await _unitOfWork.FileManagerRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
