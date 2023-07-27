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

using Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.OrderDetials.Validator;

namespace HR.LeaveManagement.Application.Features.OrderDetials.Handlers.Commands
{
    public class CreateOrderDetialsCommandHandler : IRequestHandler<CreateOrderDetialsCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderDetialsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderDetialsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrderDetialsDtoValidator(_unitOfWork.OrderDetailsRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderDetialsDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OrderDetials = _mapper.Map<Kashi_Seramic.Domain. OrderDetails>(request.CreateOrderDetialsDto);


               
                //OrderDetials.CreatedBy = "abolfazl";
                //OrderDetials.DateCreated = DateTime.Now;
                //OrderDetials.LastModifiedDate=DateTime.Now;
                //OrderDetials.LastModifiedBy = "ali"; 
                OrderDetials = await _unitOfWork.OrderDetailsRepository.Add(OrderDetials);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OrderDetials.Id;
            }

            return response;
        }
    }
}
