using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;
using Pr_Signal_ir.MVC.Models.Receipt;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderVM>> GetOrders();
        Task<List<ReceiptVM>> GetOrdersByUserId(string UserId);
        Task<List<ReceiptVM>> GetOrdersALL();
        Task<Response<int>> UpdateEnableOrderDetials(int id);
        Task<OrderVM> GetOrdersDetails(int id);
        Task<OrderVM> GetOrdersDetailsUserId(string id);
        Task<List<OrderVM>> GetOrdersUserId(string id);
        Task<int> AddUserToDore(string UserId,int blogId);
        Task<bool> IsUserInDore(string UserId,int blogId);
        Task<int> CreateOrder(CreateOrderVM leaveType);
        Task<Response<int>> UpdateOrder(int id, UpdateOrderVM leaveType);
        Task<Response<int>> DeleteOrder(int id);
        Task<Response<bool>> ExistsOrder(int id);
    }
}
