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
    public class TagToBlogRepository : GenericRepository<TagToBlog>, Application.Contracts.Persistence.ITagToBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public TagToBlogRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TagToBlog>> GetTagToBlogWithBImageId(int id)
        {
            return await _dbContext.TagToBlog.Include(a=>a.Tag).Include(a=>a.Blog).Where(a => a.TagId == id).ToListAsync();
        }

        public async Task<List<TagToBlog>> GetTagToBlogWithBlogId(int id)
        {
            return await _dbContext.TagToBlog.Include(a => a.Tag).Include(a => a.Blog).Where(a => a.BlogId == id).ToListAsync();
        }

        public async Task Delete(TagToBlog entity)
        {
            _dbContext.Remove<TagToBlog>(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteTagToBlogByBlogId(int Blogid)
        {
            var cat = _dbContext.TagToBlog.Where(a => a.BlogId == Blogid).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<TagToBlog>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public async Task<List<TagToBlog>> GetTagToBlogs()
        {
            return await _dbContext.TagToBlog.Include(a => a.Tag).Include(a => a.Blog).ToListAsync();
        }
    }
}
