using Kashi_Seramic.Application.DTOs.Product;
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
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<List<Product>> GetProductsUserWithDetails(string userId)
        {
            return await _dbContext.Product.Include(a => a.FileToProduct)
                .ThenInclude(a => a.FileManager)
                .Include(c => c.CommentToProduct).Where(a => a.CreatedBy == userId).ToListAsync();
        }

       public async Task<List<Product>> GetProductsWithDetails()
        {
            var res = await _dbContext.Product.Include(a => a.FileToProduct)
                   .ThenInclude(a => a.FileManager)
                   .Include(c => c.CommentToProduct)
                   .Include(a => a.CategoryToProduct)
                   .ThenInclude(a => a.Category)
                   .Include(a => a.TagToProduct)
                   .ThenInclude(a => a.Tag)
                  .ToListAsync();
            return res;
        }

        public async Task<Product> GetProductWithDetails(int id)
        {
            return await _dbContext.Product
                   .Include(a => a.FileToProduct).ThenInclude(a => a.FileManager)
                   .Include(c => c.CommentToProduct)
                   .Include(a => a.TagToProduct)
                   .ThenInclude(a => a.Tag)
                   .Include(a=>a.FilterToProduct)
                   .ThenInclude(a=>a.FilterValueProduct)
                   .ThenInclude(a=>a.FilterProduct)
                   .SingleOrDefaultAsync(a => a.Id == id);
        }

       public async Task<bool> ProductExists(string userId, int ProductId)
        {
            return await _dbContext.Blogs.AnyAsync(a => a.CreatedBy == userId && a.Id == ProductId);
        }

       public async Task<bool> UpdateProduct(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
