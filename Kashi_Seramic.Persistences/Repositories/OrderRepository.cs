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
    public class OrderRepository : GenericRepository<Orders>, Application.Contracts.Persistence.IOrdersRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> OrderExists(string userId, int OrderId)
        {
            return await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a => a.Product).ThenInclude(a=>a.FileToProduct).ThenInclude(a => a.FileManager).AnyAsync(a => a.UserId == userId && a.Id == OrderId);
        }

        public async Task<Orders> GetOrdersUserWithDetails(string userId)
        {
            return await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager).Where(a => a.UserId == userId&&!a.Finaly).FirstOrDefaultAsync(a => !a.Finaly);
        }


        public async Task<List<Orders>> GetOrdersUserWithDetailsActive(string userId)
        {
            return await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a=>a.FileManager).Where(a => a.UserId == userId && a.Finaly).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersWithDetails()
        {
            return await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager).ToListAsync();
        }

        public async Task<Orders> GetOrderWithDetails(int id)
        {
            return await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a=>a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SetEnableorder(int OrderId)
        {
            var order = await _dbContext.Order.Include(a => a.orderDetails).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager).Where(a => a.Id == OrderId).FirstOrDefaultAsync();
            order.Finaly = true;
            _dbContext.Order.Update(order);
            return true;
        }
    }
}
