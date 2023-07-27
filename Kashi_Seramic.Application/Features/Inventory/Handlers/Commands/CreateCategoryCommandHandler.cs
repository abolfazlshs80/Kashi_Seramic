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
using Kashi_Seramic.Application.DTOs.Inventory.Validator;
using Kashi_Seramic.Application.DTOs.Inventory;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInventoryDtoValidator(_unitOfWork.InventoryRepository);
            var validationResult = await validator.ValidateAsync(request.CreateInventoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Inventory = _mapper.Map<Inventory>(request.CreateInventoryDto);

                //Inventory.CreatedBy = "abolfazl";
                //Inventory.DateCreated = DateTime.Now;
                //Inventory.LastModifiedDate = DateTime.Now;
                //Inventory.LastModifiedBy = "ali";
                Inventory = await _unitOfWork.InventoryRepository.Add(Inventory);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Inventory.Id;
            }

            return response;
        }
    }
}
