
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Models.TicketToReply;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pr_Signal_ir.MVC.Models.Ticket
{
    public class TicketVM : BaseDomainEntity

    {
        public int GroupId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
        public List<TicketToReplyVM> TicketToReply { get; set; }
        public TicketGroupVM ticketGroup { get; set; }

    }


    public class CreateTicketVM: BaseDomainEntity
    {
        public int GroupId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }

        public List<TicketGroupVM>  Group{ get; set; }

    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }
}
public class UpdateTicketVM : BaseDomainEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
    public bool Status { get; set; }

}

public class AdminTicketVM
{
    public IEnumerable<TicketToReplyVM> TicketToReply { get; set; }
    public IEnumerable<TicketGroupVM> TicketGroup { get; set; }
    public IEnumerable<TicketVM> TicketVMs { get; set; }
    public TicketVM Ticket { get; set; }
}

}
