using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.FilterValueProduct.Validator;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateFilterValueProductCommandHandler : IRequestHandler<CreateFilterValueProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFilterValueProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFilterValueProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFilterValueProductDtoValidator(_unitOfWork.FilterValueProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFilterValueProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FilterValueProduct = _mapper.Map<FilterValueProduct>(request.CreateFilterValueProductDto);

                //FilterValueProduct.CreatedBy = "abolfazl";
                //FilterValueProduct.DateCreated = DateTime.Now;
                //FilterValueProduct.LastModifiedDate = DateTime.Now;
                //FilterValueProduct.LastModifiedBy = "ali";
                FilterValueProduct = await _unitOfWork.FilterValueProductRepository.Add(FilterValueProduct);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FilterValueProduct.Id;
            }

            return response;
        }
    }
}
