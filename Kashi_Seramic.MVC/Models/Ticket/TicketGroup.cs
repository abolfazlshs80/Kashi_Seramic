
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Models.Ticket;

namespace Pr_Signal_ir.MVC.Models.TicketGroup
{
    public class TicketGroupVM : BaseDomainEntity

    {
        public string UserId { get; set; }
        public string NameGroup { get; set; }
        public IEnumerable<TicketVM> SuportTicket { get; set; }
    }


    public class CreateTicketGroupVM
    {

        public string UserId { get; set; }
        public string NameGroup { get; set; }

    }
    public class UpdateTicketGroupVM : BaseDomainEntity
    {
        public string UserId { get; set; }
        public string NameGroup { get; set; }
    }

    public class AdminTicketGroupVM : BaseDomainEntity
    {
    }


}