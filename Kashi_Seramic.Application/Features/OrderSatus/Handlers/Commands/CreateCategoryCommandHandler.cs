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
using Kashi_Seramic.Application.DTOs.OrderSatus.OrderSatus;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateOrderSatusCommandHandler : IRequestHandler<CreateOrderSatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderSatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderSatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrderSatusDtoValidator(_unitOfWork.OrderSatusRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderSatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OrderSatus = _mapper.Map<OrderSatus>(request.CreateOrderSatusDto);

                //OrderSatus.CreatedBy = "abolfazl";
                //OrderSatus.DateCreated = DateTime.Now;
                //OrderSatus.LastModifiedDate = DateTime.Now;
                //OrderSatus.LastModifiedBy = "ali";
                OrderSatus = await _unitOfWork.OrderSatusRepository.Add(OrderSatus);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OrderSatus.Id;
            }

            return response;
        }
    }
}
