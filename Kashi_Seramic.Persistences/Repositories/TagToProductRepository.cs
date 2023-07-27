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
    public class TagToProductRepository : GenericRepository<TagToProduct>, Application.Contracts.Persistence.ITagToProductRepository
    {
        private readonly AppDbContext _dbContext;

        public TagToProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteTagToProductByBlogId(int Blogid)
        {
            var cat = _dbContext.TagToProduct.Where(a => a.ProductId == Blogid).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<TagToProduct>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<TagToProduct>> GetTagToProducts()
        {
            return await _dbContext.TagToProduct.Include(a => a.Tag).Include(a => a.ProductId).ToListAsync();
        }

        public async Task<List<TagToProduct>> GetTagToProductWithBImageId(int id)
        {
            return await _dbContext.TagToProduct.Where(a => a.ProductId == id).ToListAsync();
        }

        public async Task<List<TagToProduct>> GetTagToProductWithBlogId(int id)
        {
            return await _dbContext.TagToProduct.Include(a => a.Tag).Include(a => a.ProductId).Where(a => a.ProductId == id).ToListAsync();
        }
    }
}
