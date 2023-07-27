
using Kashi_Seramic.Application.DTOs.Ticket;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetTicketListRequest : IRequest<List<TicketDto>>
    {
    }
}
