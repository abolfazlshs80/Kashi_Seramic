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
    public class TagRepository : GenericRepository<Tag>, Application.Contracts.Persistence.ITagRepository
    {
        private readonly AppDbContext _dbContext;

        public TagRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tag> GetTagWithDetails(int id)
        {
            return await _dbContext.Tags.Include(a=>a.TagToBlog).ThenInclude(a=>a.Blog).ThenInclude(a => a.FileToBlog).ThenInclude(a => a.FileManager).FirstOrDefaultAsync(A => A.Id == id);
        }

        public async Task<List<Tag>> GetTagWithDetails()
        {
            return await _dbContext.Tags.Include(a => a.TagToBlog).ThenInclude(a => a.Blog).ThenInclude(a=>a.FileToBlog).ThenInclude(a=>a.FileManager).ToListAsync();
        }
    }
}
