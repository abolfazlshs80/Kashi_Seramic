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
using Pr_Signal_ir.Application.DTOs.CommentToBlog.Validator;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.CommentToBlog.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateCommentToBlogCommandHandler : IRequestHandler<UpdateCommentToBlogCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentToBlogCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentToBlogDtoValidator(_unitOfWork.CommentToBlogRepository);
            var validationResult = await validator.ValidateAsync(request.CommentToBlogDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.CommentToBlogRepository.Get(request.CommentToBlogDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.CommentToBlogDto.Id);

            _mapper.Map(request.CommentToBlogDto, leaveType);

            await _unitOfWork.CommentToBlogRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
