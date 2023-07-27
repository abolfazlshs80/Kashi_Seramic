using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.FilterProduct;
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
    public class FilterProductRepository : GenericRepository<FilterProduct>, IFilterProductRepository
    {
        private readonly AppDbContext _dbContext;

        public FilterProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> FilterProductExists(string userId, int FilterProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FilterProduct>> GetFilterProductsWithDetails()
        {
            return await _dbContext.FilterProduct
                .Include(a=>a.FilterValueProduct)
                .ToListAsync();
        }

        public async Task<FilterProduct> GetFilterProductWithDetails(int id)
        {
            return await _dbContext.FilterProduct
                .FirstOrDefaultAsync(A => A.Id == id);
        }
    }
}
