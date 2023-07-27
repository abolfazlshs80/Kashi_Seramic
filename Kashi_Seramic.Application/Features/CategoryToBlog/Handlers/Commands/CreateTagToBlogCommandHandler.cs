using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Responses;

namespace HR.LeaveManagement.Application.Features.CategoryToBlogToBlog.Handlers.Commands
{
    public class CreateCategoryToBlogToBlogCommandHandler : IRequestHandler<CreateCategoryToBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryToBlogToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryToBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryToBlogDtoValidator(_unitOfWork.CategoryToBlogRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCategoryToBlogDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CategoryToBlog = _mapper.Map<CategoryToBlog>(request.CreateCategoryToBlogDto);

                //CategoryToBlog.CreatedBy = "abolfazl";
                //CategoryToBlog.DateCreated = DateTime.Now;
                //CategoryToBlog.LastModifiedDate = DateTime.Now;
                //CategoryToBlog.LastModifiedBy = "ali";
                CategoryToBlog = await _unitOfWork.CategoryToBlogRepository.Add(CategoryToBlog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CategoryToBlog.BlogId;
            }

            return response;
        }
    }
}
