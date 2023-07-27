using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Pr_Signal_ir.Application.DTOs.FileToBlog.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.FileToBlog.Requests.Commands;
using FluentValidation;
using Kashi_Seramic.Application.Responses;

namespace Kashi_Seramic.Application.Features.FileToBlogs.Handlers.Commands
{
    public class CreateFileToBlogCommandHandler : IRequestHandler<CreateFileToBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFileToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFileToBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFileToBlogDtoValidator(_unitOfWork.FileToBlogRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFileImageDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FileImage = _mapper.Map<Kashi_Seramic.Domain. FileToBlog>(request.CreateFileImageDto);

                //FileImage.CreatedBy = "abolfazl";
                //FileImage.DateCreated = DateTime.Now;
                //FileImage.LastModifiedDate = DateTime.Now;
                //FileImage.LastModifiedBy = "ali";
                FileImage = await _unitOfWork.FileToBlogRepository.Add(FileImage);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FileImage.BlogId;
            }

            return response;
        }
    }
}
