using Kashi_Seramic.Application.Contracts.Persistence;
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
    public class BlogRepository : GenericRepository<Blog>,IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> BlogExists(string userId, int blogId)
        {
            return await _dbContext.Blogs.AnyAsync(a => a.CreatedBy == userId && a.Id == blogId);
        }

        public async Task<List<Blog>> GetBlogsUserWithDetails(string userId)
        {
            return await _dbContext.Blogs.Include(a => a.FileToBlog)
                .ThenInclude(a => a.FileManager)
                .Include(c => c.CommentToBlog).Where(a => a.CreatedBy == userId).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithDetails()
        {
            var res = await _dbContext.Blogs.Include(a => a.FileToBlog)
                .ThenInclude(a => a.FileManager)
                .Include(c => c.CommentToBlog)
                .Include(a => a.CategoryToBlog)
                .ThenInclude(a => a.Category)
                .Include(a => a.TagToBlog)
                .ThenInclude(a => a.Tag)
               .ToListAsync();
            return res;
        }

        public async Task<Blog> GetBlogWithDetails(int id)
        {
            return await _dbContext.Blogs
                .Include(a => a.FileToBlog)
                .ThenInclude(a => a.FileManager)
                .Include(c => c.CommentToBlog)
                .Include(a=>a.TagToBlog)
                .ThenInclude(a=>a.Tag)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
