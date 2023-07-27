using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.TicketToReply;
using Pr_Signal_ir.MVC.Models.TicketToReply;
using Pr_Signal_ir.MVC.Models.Search;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITicketToReplyService
    {

        Task<List<TicketToReplyVM>> GetTicketToReplys();
        Task<List<TicketToReplyVM>> GetTicketToReplysDetailsByTicket(int Ticketid);
        Task<TicketToReplyVM> GetTicketToReplysDetails(int id);
        Task<IEnumerable<SearchVM>> GetBlogsTicketToReplyBySearchVM(int cateid);
        Task<Response<int>> CreateTicketToReply(CreateTicketToReplyVM cate);
        Task<Response<int>> UpdateTicketToReply(int id, UpdateTicketToReplyVM cate);
        Task<Response<int>> DeleteTicketToReply(int id);
        Task<Response<int>> ExistsTicketToReply(int id);
    }
}
