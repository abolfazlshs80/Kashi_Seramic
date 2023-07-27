using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Ticket
{
    public class CreateTicketDto : BaseDto, ITicketDto
    {
        public int GroupId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
