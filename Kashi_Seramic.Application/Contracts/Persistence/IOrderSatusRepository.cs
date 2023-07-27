using Kashi_Seramic.Application.DTOs.OrderSatus;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IOrderSatusRepository : IGenericRepository<OrderSatus>
    {
        Task<OrderSatus> GetOrderSatusWithDetails(int id);
        Task<List<OrderSatus>> GetOrderSatussWithDetails();

        Task<bool> OrderSatusExists(string userId, int OrderSatusId);

    }
}
