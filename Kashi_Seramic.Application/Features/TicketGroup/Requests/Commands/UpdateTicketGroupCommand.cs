
using Kashi_Seramic.Application.DTOs.TicketGroup;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateTicketGroupCommand : IRequest<Unit>
    {
        public UpdateTicketGroupDto TicketGroupDto { get; set; }
        public int Id { get; set; }

    }
}
