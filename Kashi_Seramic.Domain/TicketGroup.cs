
using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class TicketGroup : BaseDomainEntity
    {


        public string NameGroup { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Ticket> SuportTicket { get; set; }
    }
}
