using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Ticket;
using Pr_Signal_ir.MVC.Models.Ticket;
using Pr_Signal_ir.MVC.Models.Search;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITicketService
    {

        Task<List<TicketVM>> GetTickets();
        Task<TicketVM> GetTicketsDetails(int id);
        Task<List<TicketVM>> GetTicketsByGroupId(int id);
        Task<List<TicketVM>> GetTicketsByGroup(string id);
        Task<IEnumerable<SearchVM>> GetBlogsTicketBySearchVM(int cateid);
        Task<List<TicketVM>> GetTicketsByUserId(string id);
        Task<Response<int>> CreateTicket(CreateTicketVM cate);
        Task<Response<int>> UpdateTicket(int id, UpdateTicketVM cate);
        Task<Response<int>> DeleteTicket(int id);
        Task<Response<int>> ExistsTicket(int id);
    }
}
