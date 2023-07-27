using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.Application.DTOs.Product.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.Product.Requests.Commands;
using Pr_Signal_ir.Application.Extentions;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.Product;

namespace HR.LeaveManagement.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator(_unitOfWork.ProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Product = _mapper.Map<Kashi_Seramic.Domain.Product>(request.CreateProductDto);

                var newcodeClass = new ShortCode();

                Product.Seen = 0;
                Product.LinkKey = await newcodeClass.GetCodeValidForProduct(await _unitOfWork.ProductRepository.GetProductsWithDetails());

                Product.Status = true;
               
                //Product.CreatedBy = "abolfazl";
                //Product.DateCreated = DateTime.Now;
                //Product.LastModifiedDate=DateTime.Now;
                //Product.LastModifiedBy = "ali"; 
                Product = await _unitOfWork.ProductRepository.Add(Product);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Product.Id;
            }

            return response;
        }
    }
}
