using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Domain;
using Kashi_Seramic.Persistences;
using Microsoft.EntityFrameworkCore;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Pr_Signal_ir.Persistence;
using Pr_Signal_ir.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Persistences.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderSatus>, IOrderSatusRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<OrderSatus>> GetOrderSatussWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<OrderSatus> GetOrderSatusWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderSatusExists(string userId, int OrderSatusId)
        {
            throw new NotImplementedException();
        }
    }
}
