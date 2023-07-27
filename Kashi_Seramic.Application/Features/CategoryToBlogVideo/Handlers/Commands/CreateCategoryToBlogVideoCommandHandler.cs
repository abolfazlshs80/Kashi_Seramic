using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.CategoryToProduct.Requests.Commands;

using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.CategoryToProduct.Validator;

namespace Kashi_Seramic.Application.Features.CategoryToProduct.Handlers.Commands
{
    public class CreateCategoryToProductToBlogCommandHandler : IRequestHandler<CreateCategoryToProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryToProductToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryToProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryToProductDtoValidator(_unitOfWork.CategoryToProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCategoryToProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CategoryToProduct = _mapper.Map<Kashi_Seramic.Domain. CategoryToProduct> (request.CreateCategoryToProductDto);

                //CategoryToProduct.CreatedBy = "abolfazl";
                //CategoryToProduct.DateCreated = DateTime.Now;
                //CategoryToProduct.LastModifiedDate = DateTime.Now;
                //CategoryToProduct.LastModifiedBy = "ali";
                CategoryToProduct = await _unitOfWork.CategoryToProductRepository.Add(CategoryToProduct);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CategoryToProduct.ProductId;
            }

            return response;
        }
    }
}
