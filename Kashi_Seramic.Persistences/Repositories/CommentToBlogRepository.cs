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
    public class CommentToBlogRepository : GenericRepository<CommentToBlog>, Application.Contracts.Persistence.ICommentToBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentToBlogRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommentToBlog>> GetCommentToBlogWithCommentToBlogId(int id)
        {
           return await _dbContext.CommentToBlog.Where(a=>a.BlogId==id).Include(a => a.Blog).ThenInclude(a => a.CommentToBlog).ToListAsync();
        }

        public async Task<CommentToBlog> GetCommentToBlogWithDCommentId(int id)
        {
            var model= await _dbContext.CommentToBlog.Where(a => a.Id == id).Include(a => a.Blog).FirstOrDefaultAsync(); ;
            return model;
        }
        public async Task<List<CommentToBlog>> GetCommentToBlogs()
        {
            return await _dbContext.CommentToBlog.Include(a => a.Blog).ToListAsync();
        }
    }
}
