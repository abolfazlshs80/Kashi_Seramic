
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kashi_Seramic.Domain
{
    public class TicketToReply : BaseDomainEntity
    {

        public string Text { get; set; }
        public int TicketId { get; set; }
        public string Status { get; set; }

        public Ticket Ticket { get; set; }
    }
}
