using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.Inventory;
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
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        private readonly AppDbContext _dbContext;

        public InventoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Inventory>> GetInventorysWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> GetInventoryWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InventoryExists(string userId, int InventoryId)
        {
            throw new NotImplementedException();
        }
    }
}
