using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kashi_Seramic.Application.DTOs.Ticket;

namespace Kashi_Seramic.Application.DTOs.TicketGroup
{
    public class TicketGroupDto : BaseDto
    {
        public string UserId { get; set; }

        public string NameGroup { get; set; }
        public IEnumerable<TicketDto> SuportTicket { get; set; }

    }
}
