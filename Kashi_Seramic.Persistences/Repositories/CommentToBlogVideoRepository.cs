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
    public class CommentToProductRepository : GenericRepository<CommentToProduct>, Application.Contracts.Persistence.ICommentToProductRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentToProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommentToProduct>> GetCommentToProductWithCommentToProductId(int id)
        {
            return await _dbContext.CommentToProduct.Include(a => a.Product).Where(a => a.ProductId == id).ToListAsync();
        }

        public async Task<CommentToProduct> GetCommentToProductWithDCommentId(int id)
        {
            return await _dbContext.CommentToProduct.Where(a => a.Id == id).Include(a => a.Product).FirstOrDefaultAsync();
        }
        public async Task<List<CommentToProduct>> GetCommentToBlogs()
        {
            return await _dbContext.CommentToProduct.Include(a => a.Product).IgnoreAutoIncludes().ToListAsync();
        }
    }
}
