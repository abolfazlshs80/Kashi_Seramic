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
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using Kashi_Seramic.Application.Features.Blog.Requests.Commands;
using Kashi_Seramic.Application.DTOs.Blog.Validator;

namespace HR.LeaveManagement.Application.Features.Blog.Handlers.Commands
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBlogDtoValidator(_unitOfWork.BlogRepository);
            var validationResult = await validator.ValidateAsync(request.blogDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.BlogRepository.Get(request.blogDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.blogDto.Id);

            _mapper.Map(request.blogDto, leaveType);

            await _unitOfWork.BlogRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
