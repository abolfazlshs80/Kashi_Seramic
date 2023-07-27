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
using Kashi_Seramic.Application.DTOs.Ticket.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTicketDtoValidator(_unitOfWork.TicketRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTicketDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Ticket = _mapper.Map<Ticket>(request.CreateTicketDto);

                //Ticket.CreatedBy = "abolfazl";
                //Ticket.DateCreated = DateTime.Now;
                //Ticket.LastModifiedDate = DateTime.Now;
                //Ticket.LastModifiedBy = "ali";
                Ticket = await _unitOfWork.TicketRepository.Add(Ticket);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Ticket.Id;
            }

            return response;
        }
    }
}
