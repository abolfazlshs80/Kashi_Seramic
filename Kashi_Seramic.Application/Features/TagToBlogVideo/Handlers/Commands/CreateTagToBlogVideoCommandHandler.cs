using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.TagToProduct.Requests.Commands;

using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.TagToProduct.Validator;

namespace Kashi_Seramic.Application.Features.TagToProduct.Handlers.Commands
{
    public class CreateTagToProductToBlogCommandHandler : IRequestHandler<CreateTagToProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTagToProductToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTagToProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTagToProductDtoValidator(_unitOfWork.TagToProductRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTagToProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TagToProduct = _mapper.Map< Kashi_Seramic.Domain. TagToProduct> (request.CreateTagToProductDto);

                //TagToProduct.CreatedBy = "abolfazl";
                //TagToProduct.DateCreated = DateTime.Now;
                //TagToProduct.LastModifiedDate = DateTime.Now;
                //TagToProduct.LastModifiedBy = "ali";
                TagToProduct = await _unitOfWork.TagToProductRepository.Add(TagToProduct);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TagToProduct.TagId;
            }

            return response;
        }
    }
}
