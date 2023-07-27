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
using Kashi_Seramic.Application.DTOs.TicketGroup.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateTicketGroupCommandHandler : IRequestHandler<CreateTicketGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTicketGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTicketGroupDtoValidator(_unitOfWork.TicketGroupRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTicketGroupDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TicketGroup = _mapper.Map<TicketGroup>(request.CreateTicketGroupDto);

                //TicketGroup.CreatedBy = "abolfazl";
                //TicketGroup.DateCreated = DateTime.Now;
                //TicketGroup.LastModifiedDate = DateTime.Now;
                //TicketGroup.LastModifiedBy = "ali";
               var TicketGrou2p = await _unitOfWork.TicketGroupRepository.Add(TicketGroup);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TicketGroup.Id;
            }

            return response;
        }
    }
}
