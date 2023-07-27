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
using Kashi_Seramic.Application.DTOs.FaqUser.Validator;
using Kashi_Seramic.Application.DTOs.FaqUser;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateFaqUserCommandHandler : IRequestHandler<CreateFaqUserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFaqUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFaqUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFaqUserDtoValidator(_unitOfWork.FaqUserRepository);
            var validationResult = await validator.ValidateAsync(request.CreateFaqUserDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FaqUser = _mapper.Map<FaqUser>(request.CreateFaqUserDto);

                //FaqUser.CreatedBy = "abolfazl";
                //FaqUser.DateCreated = DateTime.Now;
                //FaqUser.LastModifiedDate = DateTime.Now;
                //FaqUser.LastModifiedBy = "ali";
                FaqUser = await _unitOfWork.FaqUserRepository.Add(FaqUser);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FaqUser.Id;
            }

            return response;
        }
    }
}
