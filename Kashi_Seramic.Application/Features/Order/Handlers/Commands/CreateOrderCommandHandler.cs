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

using Kashi_Seramic.Application.Features.Order.Requests.Commands;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.Order.Validator;

namespace HR.LeaveManagement.Application.Features.Order.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrderDtoValidator(_unitOfWork.OrderRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Order = _mapper.Map<Kashi_Seramic.Domain. Orders>(request.CreateOrderDto);

                //Order.Visit = 0;
                //Order.LinkKey = "abc-12";
                //Order.Status = true;
               
                //Order.CreatedBy = "abolfazl";
                //Order.DateCreated = DateTime.Now;
                //Order.LastModifiedDate=DateTime.Now;
                //Order.LastModifiedBy = "ali"; 
                Order = await _unitOfWork.OrderRepository.Add(Order);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Order.Id;
            }

            return response;
        }
    }
}
