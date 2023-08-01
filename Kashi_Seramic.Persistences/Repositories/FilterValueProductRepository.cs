using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
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
    public class FilterValueProductRepository : GenericRepository<FilterValueProduct>, IFilterValueProductRepository
    {
        private readonly AppDbContext _dbContext;

        public FilterValueProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> FilterValueProductExists(string userId, int FilterValueProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FilterValueProduct>> GetFilterValueProductsWithDetails()
        {
           return await _dbContext.FilterValueProduct
               .Include(a=>a.FilterToProduct)
               .ThenInclude(a=>a.Product).
               ThenInclude(a => a.FileToProduct).
               ThenInclude(a => a.FileManager)
               .ToListAsync();
        }

        public async Task<FilterValueProduct> GetFilterValueProductWithDetails(int id)
        {
            return await _dbContext.FilterValueProduct
                .Include(a => a.FilterToProduct)
                .ThenInclude(a => a.Product)
                .ThenInclude(a=>a.FileToProduct)
                .ThenInclude(a=>a.FileManager)
                .FirstOrDefaultAsync(a=>a.Id.Equals(id));
        }
    }
}
