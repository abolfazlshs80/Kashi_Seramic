
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Models.Ticket;

namespace Pr_Signal_ir.MVC.Models.TicketToReply
{
    public class TicketToReplyVM:BaseDomainEntity
        
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public int TicketId { get; set; }
        public TicketVM Ticket { get; set; }
    }

    public class CreateTicketToReplyVM: BaseDomainEntity
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public int TicketId { get; set; }


    }
    public class UpdateTicketToReplyVM:BaseDomainEntity
    {
        public string Text { get; set; }
        public string Status { get; set; }
    }

    public class AdminTicketToReplyVM : BaseDomainEntity
    {
    }

}
