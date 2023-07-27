using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.OrderDetials;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IOrderDetialservice
    {
        Task<List<OrderDetialsVM>> GetOrderDetials();
        Task<OrderDetialsVM> GetOrderDetialsDetails(int id);
        Task<OrderDetialsVM> GetOrderDetialsBlogId_OrderId(int blogId,int orderId);
        Task<Response<int>> CreateOrderDetials(CreateOrderDetialsVM leaveType);
        Task<Response<int>> UpdateOrderDetials(int id,UpdateOrderDetialsVM leaveType);

        Task<Response<int>> DeleteOrderDetials(int id);
        Task<Response<bool>> ExistsOrderDetials(int id);
        Task<Response<int>> GetOrderDetialsDetails(int orderId, int blogId);
    }
}
