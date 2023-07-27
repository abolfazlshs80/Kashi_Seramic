using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.FileManager.Requests.Commands;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.FileManager.Validator;

namespace Kashi_Seramic.Application.Features.FileManagers.Handlers.Commands
{
    public class CreateFileManagerCommandHandler : IRequestHandler<CreateFileManagerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFileManagerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFileManagerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFileManagersDtoValidator(_unitOfWork.FileManagerRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFileImageDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FileImage = _mapper.Map<Kashi_Seramic.Domain. FileManager>(request.CreateFileImageDto);

                //FileImage.CreatedBy = "abolfazl";
                //FileImage.DateCreated = DateTime.Now;
                //FileImage.LastModifiedDate = DateTime.Now;
                //FileImage.LastModifiedBy = "ali";
                FileImage = await _unitOfWork.FileManagerRepository.Add(FileImage);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FileImage.Id;
            }

            return response;
        }
    }
}
