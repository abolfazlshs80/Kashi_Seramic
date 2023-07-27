using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketToReply
{
    public class UpdateTicketToReplyDto : BaseDto, ITicketToReplyDto
    {
        public string Text { get; set; }
        public string Status { get; set; }


    }
}
