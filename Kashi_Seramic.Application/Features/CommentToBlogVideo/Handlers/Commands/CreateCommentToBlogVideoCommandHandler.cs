using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Pr_Signal_ir.Application.DTOs.CommentToProduct.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands;
using Kashi_Seramic.Application.Responses;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Handlers.Commands
{
    public class CreateCommentToProductCommandHandler : IRequestHandler<CreateCommentToProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCommentToProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCommentToProductDtoValidator(_unitOfWork.CommentToProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCommentToProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CommentToProduct = _mapper.Map <Kashi_Seramic.Domain. CommentToProduct>(request.CreateCommentToProductDto);

                //CommentToProduct.Visit = 0;
                //CommentToProduct.LinkKey = "abc-12";
                //CommentToProduct.Status = true;

                //CommentToProduct.CreatedBy = "abolfazl";
                //CommentToProduct.DateCreated = DateTime.Now;
                //CommentToProduct.LastModifiedDate=DateTime.Now;
                //CommentToProduct.LastModifiedBy = "ali"; 
                CommentToProduct = await _unitOfWork.CommentToProductRepository.Add(CommentToProduct);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CommentToProduct.Id;
            }

            return response;
        }
    }
}
