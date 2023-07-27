using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class Ticket : BaseDomainEntity
    {


        public int GroupId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
        public List<TicketToReply> TicketToReply { get; set; }
        public TicketGroup ticketGroup { get; set; }

    }
}
