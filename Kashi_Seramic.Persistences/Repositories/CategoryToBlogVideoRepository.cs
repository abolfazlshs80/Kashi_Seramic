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
    public class CategoryToProductRepository : GenericRepository<CategoryToProduct>, Application.Contracts.Persistence.ICategoryToProductRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryToProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteCategoryToProductByBlogId(int Blogid)
        {
            var cat = _dbContext.CategoryToProduct.Where(a => a.ProductId == Blogid).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<CategoryToProduct>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<CategoryToProduct>> GetCategoryToProductWithBImageId(int id)
        {
            return await _dbContext.CategoryToProduct.Where(a => a.CategoryId == id).ToListAsync();
        }

        public async Task<List<CategoryToProduct>> GetCategoryToProductWithBlogId(int id)
        {
            return await _dbContext.CategoryToProduct.Where(a => a.ProductId == id).ToListAsync();
        }
    }
}
