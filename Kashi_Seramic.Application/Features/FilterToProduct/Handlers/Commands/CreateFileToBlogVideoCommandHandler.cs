using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Commands;
using FluentValidation;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.FilterToProduct.Validator;

namespace Kashi_Seramic.Application.Features.FilterToProducts.Handlers.Commands
{
    public class CreateFilterToProductCommandHandler : IRequestHandler<CreateFilterToProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFilterToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFilterToProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFilterToProductDtoValidator(_unitOfWork.FilterToProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFilterImageDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FilterImage = _mapper.Map<Kashi_Seramic.Domain. FilterToProduct>(request.CreateFilterImageDto);

                //FilterImage.CreatedBy = "abolfazl";
                //FilterImage.DateCreated = DateTime.Now;
                //FilterImage.LastModifiedDate = DateTime.Now;
                //FilterImage.LastModifiedBy = "ali";
                FilterImage = await _unitOfWork.FilterToProductRepository.Add(FilterImage);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FilterImage.ProductId;
            }

            return response;
        }
    }
}
