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
using Kashi_Seramic.Application.DTOs.FilterProduct.Validator;
using Kashi_Seramic.Application.DTOs.FilterProduct;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateFilterProductCommandHandler : IRequestHandler<CreateFilterProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFilterProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFilterProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFilterProductDtoValidator(_unitOfWork.FilterProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFilterProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FilterProduct = _mapper.Map<FilterProduct>(request.CreateFilterProductDto);

                //FilterProduct.CreatedBy = "abolfazl";
                //FilterProduct.DateCreated = DateTime.Now;
                //FilterProduct.LastModifiedDate = DateTime.Now;
                //FilterProduct.LastModifiedBy = "ali";
                FilterProduct = await _unitOfWork.FilterProductRepository.Add(FilterProduct);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FilterProduct.Id;
            }

            return response;
        }
    }
}
