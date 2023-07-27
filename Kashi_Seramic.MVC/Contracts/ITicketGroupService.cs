using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Pr_Signal_ir.MVC.Models.TicketGroup;
using Pr_Signal_ir.MVC.Models.Search;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITicketGroupService
    {

        Task<List<TicketGroupVM>> GetTicketGroups();
        Task<List<TicketGroupVM>> GetTicketGroupsByUser(string userid);
        Task<TicketGroupVM> GetTicketGroupsDetails(int id);
        Task<IEnumerable<SearchVM>> GetBlogsTicketGroupBySearchVM(int cateid);
        Task<Response<int>> CreateTicketGroup(CreateTicketGroupVM cate);
        Task<Response<int>> UpdateTicketGroup(int id, UpdateTicketGroupVM cate);
        Task<Response<int>> DeleteTicketGroup(int id);
        Task<Response<int>> ExistsTicketGroup(int id);
    }
}
