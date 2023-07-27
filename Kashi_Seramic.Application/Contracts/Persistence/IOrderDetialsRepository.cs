

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
        Task<OrderDetails> GetOrderDetialsWithDetails(int id);
        Task<List<OrderDetails>> GetOrderDetialssWithDetails();
        Task<List<OrderDetails>> GetOrderDetialssUserWithDetails(string userId);
        Task<bool> OrderDetialsExists(string userId, int OrderDetialsId);

    }
}
