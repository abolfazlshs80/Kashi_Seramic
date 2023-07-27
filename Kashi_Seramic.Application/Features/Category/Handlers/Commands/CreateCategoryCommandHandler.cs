using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.Application.DTOs.Category.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Responses;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryDtoValidator(_unitOfWork.CategoryRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Category = _mapper.Map<Category>(request.CreateCategoryDto);

                //Category.CreatedBy = "abolfazl";
                //Category.DateCreated = DateTime.Now;
                //Category.LastModifiedDate = DateTime.Now;
                //Category.LastModifiedBy = "ali";
                Category = await _unitOfWork.CategoryRepository.Add(Category);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Category.Id;
            }

            return response;
        }
    }
}
