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
    public class OrderDetialsRepository : GenericRepository<OrderDetails>, Application.Contracts.Persistence.IOrderDetailsRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderDetialsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> OrderDetialsExists(string userId, int OrderDetialsId)
        {
            return false;
        }



        public async Task<List<OrderDetails>> GetOrderDetialssWithDetails()
        {
      return    await  _dbContext.OrderDetials
                .Include(a => a.Product)
      
                .ToListAsync();
        }

        public async Task<OrderDetails> GetOrderDetialsWithDetails(int id)
        {
            return await _dbContext.OrderDetials
                .Include(a => a.Product).
         
                Where(a=>a.Id== id)
                .FirstOrDefaultAsync();
        }

        public Task<List<OrderDetails>> GetOrderDetialssUserWithDetails(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
