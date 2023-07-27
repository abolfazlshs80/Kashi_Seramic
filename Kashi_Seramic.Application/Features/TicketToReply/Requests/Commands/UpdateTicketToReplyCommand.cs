
using Kashi_Seramic.Application.DTOs.TicketToReply;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateTicketToReplyCommand : IRequest<Unit>
    {
        public UpdateTicketToReplyDto TicketToReplyDto { get; set; }
        public int Id { get; set; }

    }
}
