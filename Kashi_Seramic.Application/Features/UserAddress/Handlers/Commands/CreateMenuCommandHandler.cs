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
using Kashi_Seramic.Application.DTOs.UserAddress.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserAddressDtoValidator(_unitOfWork.UserAddressRepository);
            var validationResult = await validator.ValidateAsync(request.CreateUserAddressDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var UserAddress = _mapper.Map<UserAddress>(request.CreateUserAddressDto);

                //UserAddress.Visit = 0;
                //UserAddress.LinkKey = "abc-12";
                //UserAddress.Status = true;
               
                //UserAddress.CreatedBy = "abolfazl";
                //UserAddress.DateCreated = DateTime.Now;
                //UserAddress.LastModifiedDate=DateTime.Now;
                //UserAddress.LastModifiedBy = "ali"; 
                UserAddress = await _unitOfWork.UserAddressRepository.Add(UserAddress);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = UserAddress.Id;
            }

            return response;
        }
    }
}
