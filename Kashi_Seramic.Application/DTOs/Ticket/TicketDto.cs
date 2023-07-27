using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kashi_Seramic.Application.DTOs.TicketGroup;
using Kashi_Seramic.Application.DTOs.TicketToReply;

namespace Kashi_Seramic.Application.DTOs.Ticket
{
    public class TicketDto : BaseDto
    {
        public int GroupId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
        public List<TicketToReplyDto> TicketToReply { get; set; }
        public TicketGroupDto ticketGroup { get; set; }

    }
}
