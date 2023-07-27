using Kashi_Seramic.Application.DTOs.Inventory;
using Pr_Signal_ir.Application.Contracts.Persistence;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IInventoryRepository: IGenericRepository<Inventory>
    {
        Task<Inventory> GetInventoryWithDetails(int id);
        Task<List<Inventory>> GetInventorysWithDetails();

        Task<bool> InventoryExists(string userId, int InventoryId);

    }
}
