using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kashi_Seramic.Application.DTOs.Ticket;

namespace Kashi_Seramic.Application.DTOs.TicketToReply
{
    public class TicketToReplyDto : BaseDto
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public int TicketId { get; set; }
        public TicketDto Ticket { get; set; }

    }
}
