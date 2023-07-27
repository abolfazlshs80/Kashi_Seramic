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
using Pr_Signal_ir.Application.DTOs.CommentToProduct.Validator;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.CommentToProduct.Validator;
using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands;
using Kashi_Seramic.Application.DTOs.CommentToProduct.Validator;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Handlers.Commands
{
    public class UpdateCommentToProductCommandHandler : IRequestHandler<UpdateCommentToProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentToProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentToProductDtoValidator(_unitOfWork.CommentToProductRepository);
            var validationResult = await validator.ValidateAsync(request.CommentToProductDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors.ToString());

            var leaveType = await _unitOfWork.CommentToProductRepository.Get(request.CommentToProductDto.Id);

            if (leaveType is null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(leaveType), request.CommentToProductDto.Id);

            _mapper.Map(request.CommentToProductDto, leaveType);

            await _unitOfWork.CommentToProductRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
