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
using Kashi_Seramic.Application.DTOs.TicketToReply.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateTicketToReplyCommandHandler : IRequestHandler<CreateTicketToReplyCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketToReplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTicketToReplyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTicketToReplyDtoValidator(_unitOfWork.TicketToReplyRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTicketToReplyDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TicketToReply = _mapper.Map<TicketToReply>(request.CreateTicketToReplyDto);

                //TicketToReply.CreatedBy = "abolfazl";
                //TicketToReply.DateCreated = DateTime.Now;
                //TicketToReply.LastModifiedDate = DateTime.Now;
                //TicketToReply.LastModifiedBy = "ali";
                TicketToReply = await _unitOfWork.TicketToReplyRepository.Add(TicketToReply);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TicketToReply.Id;
            }

            return response;
        }
    }
}
