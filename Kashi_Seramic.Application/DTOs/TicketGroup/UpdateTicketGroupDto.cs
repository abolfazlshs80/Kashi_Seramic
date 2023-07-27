using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketGroup
{
    public class UpdateTicketGroupDto : BaseDto, ITicketGroupDto
    {

        public string NameGroup { get; set; }
        public string UserId { get; set; }
    }
}
