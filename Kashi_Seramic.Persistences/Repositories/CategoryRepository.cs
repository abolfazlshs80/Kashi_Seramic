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
    public class CategoryRepository : GenericRepository<Category>, Application.Contracts.Persistence.ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetCategoryWithDetails(int id)
        {
            return await _dbContext.Categories.Include(a => a.CategoryToBlog).ThenInclude(a => a.Blog).ThenInclude(a => a.FileToBlog).ThenInclude(a=>a.FileManager)
                .Include(a => a.CategoryToProduct).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager
                )
                .FirstOrDefaultAsync(A => A.Id == id);
        }

        public async Task<List<Category>> GetCategoryWithDetails()
        {
            return await _dbContext.Categories.Include(a => a.CategoryToBlog).ThenInclude(a => a.Blog).ThenInclude(a => a.FileToBlog).ThenInclude(a => a.FileManager)
                     .Include(a => a.CategoryToProduct).ThenInclude(a => a.Product).ThenInclude(a => a.FileToProduct).ThenInclude(a => a.FileManager)
                     .ToListAsync();
        }
    }
}
