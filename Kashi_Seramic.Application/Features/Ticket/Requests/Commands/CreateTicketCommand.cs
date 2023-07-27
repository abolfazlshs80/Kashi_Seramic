
using Kashi_Seramic.Application.DTOs.Ticket;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateTicketCommand : IRequest<BaseCommandResponse>
    {
        public CreateTicketDto CreateTicketDto { get; set; }

    }
}
