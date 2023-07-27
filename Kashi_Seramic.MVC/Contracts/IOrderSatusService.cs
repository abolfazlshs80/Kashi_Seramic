using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IOrderSatusService
    {
        Task<List<OrderSatusVM>> GetOrderSatuss();
        Task<OrderSatusVM> GetOrderSatussDetails(int id);
        Task<Response<int>> CreateOrderSatus(CreateOrderSatusVM leaveType);
        Task<Response<int>> UpdateOrderSatus(int id,UpdateOrderSatusVM leaveType);
        Task<Response<int>> DeleteOrderSatus(int id);
    }
}
