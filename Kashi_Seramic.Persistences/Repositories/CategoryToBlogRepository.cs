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
    public class CategoryToBlogRepository : GenericRepository<CategoryToBlog>, Application.Contracts.Persistence.ICategoryToBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryToBlogRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryToBlog>> GetCategoryToBlogWithBImageId(int id)
        {
            return await _dbContext.CategoryToBlogs.Where(a => a.CategoryId == id).ToListAsync();
        }

        public async Task<List<CategoryToBlog>> GetCategoryToBlogWithBlogId(int id)
        {
            return await _dbContext.CategoryToBlogs.Where(a => a.BlogId == id).ToListAsync();
        }

        public async Task Delete(CategoryToBlog entity)
        {
            _dbContext.Remove<CategoryToBlog>(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryToBlogByBlogId(int Blogid)
        {
            var cat = _dbContext.CategoryToBlogs.Where(a => a.BlogId == Blogid).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<CategoryToBlog>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }
    }
}
