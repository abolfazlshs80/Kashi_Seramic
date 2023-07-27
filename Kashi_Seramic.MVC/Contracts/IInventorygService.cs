using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IInventoryService
    {
        Task<List<InventoryVM>> GetInventorys();
        Task<InventoryVM> GetInventorysDetails(int id);
        Task<Response<int>> CreateInventory(CreateInventoryVM leaveType);
        Task<Response<int>> UpdateInventory(int id,UpdateInventoryVM leaveType);
        Task<Response<int>> DeleteInventory(int id);
    }
}
