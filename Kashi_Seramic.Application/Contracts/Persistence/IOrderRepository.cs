
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IOrdersRepository:IGenericRepository<Orders>
    {
        Task<Orders> GetOrderWithDetails(int id);
        Task<List<Orders>> GetOrdersWithDetails();
        Task<Orders> GetOrdersUserWithDetails(string userId);
        Task<List<Orders>> GetOrdersUserWithDetailsActive(string userId);
        Task<bool> OrderExists(string userId, int OrderId);
        Task<bool> SetEnableorder( int OrderId);

    }
}
