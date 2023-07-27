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
    public class FileToBlogRepository : GenericRepository<FileToBlog>, Application.Contracts.Persistence.IFileToBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public FileToBlogRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FileToBlog>> GetFileToBlogWithBImageId(int id)
        {
       return await _dbContext.FileToBlogs.Where(a=>a.ImageId==id).ToListAsync();
        }

        public async Task<List<FileToBlog>> GetFileToBlogWithBlogId(int id)
        {
            return await _dbContext.FileToBlogs.Where(a => a.ImageId == id).ToListAsync();
        }

        public async Task<bool> DeleteFileToBlogByBlogId(int Blogid)
        {
            var cat = _dbContext.FileToBlogs.Where(a => a.BlogId == Blogid).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<FileToBlog>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }
    }
}
