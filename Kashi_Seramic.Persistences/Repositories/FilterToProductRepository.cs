global using Kashi_Seramic.Domain;
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
    public class FilterToProductRepository : GenericRepository<FilterToProduct>, Application.Contracts.Persistence.IFilterToProductRepository
    {
        private readonly AppDbContext _dbContext;

        public FilterToProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<bool> DeleteFilterToProductByBlogId(int id)
        {

            var cat = _dbContext.FilterToProduct.Where(a => a.ProductId == id).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<FilterToProduct>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

       public async Task<List<FilterToProduct>> GetFilterToProductWithBImageId(int id)
        {
            return await _dbContext.FilterToProduct.Where(a => a.FilterId == id).ToListAsync();
        }

       public async Task<List<FilterToProduct>> GetFilterToProductWithBlogId(int id)
        {
            return await _dbContext.FilterToProduct.Where(a => a.ProductId == id).ToListAsync();
        }
    }
}
