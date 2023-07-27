using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketToReply
{
    public class CreateTicketToReplyDto : BaseDto, ITicketToReplyDto
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public int TicketId { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
