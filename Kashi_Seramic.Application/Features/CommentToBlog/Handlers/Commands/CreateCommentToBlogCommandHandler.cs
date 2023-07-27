using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.Application.DTOs.CommentToBlog.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Responses;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateCommentToBlogCommandHandler : IRequestHandler<CreateCommentToBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCommentToBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCommentToBlogDtoValidator(_unitOfWork.CommentToBlogRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCommentToBlogDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CommentToBlog = _mapper.Map<CommentToBlog>(request.CreateCommentToBlogDto);

                //CommentToBlog.Visit = 0;
                //CommentToBlog.LinkKey = "abc-12";
                //CommentToBlog.Status = true;
               
                //CommentToBlog.CreatedBy = "abolfazl";
                //CommentToBlog.DateCreated = DateTime.Now;
                //CommentToBlog.LastModifiedDate=DateTime.Now;
                //CommentToBlog.LastModifiedBy = "ali"; 
                CommentToBlog = await _unitOfWork.CommentToBlogRepository.Add(CommentToBlog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CommentToBlog.Id;
            }

            return response;
        }
    }
}
