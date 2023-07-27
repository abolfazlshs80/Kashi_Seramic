global using Kashi_Seramic.Domain;
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
    public class FileToProductRepository : GenericRepository<FileToProduct>, Application.Contracts.Persistence.IFileToProductRepository
    {
        private readonly AppDbContext _dbContext;

        public FileToProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<bool> DeleteFileToProductByBlogId(int id)
        {

            var cat = _dbContext.FileToProduct.Where(a => a.ProductId == id).FirstOrDefault();
            if (cat != null)
            {
                _dbContext.Remove<FileToProduct>(cat);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

       public async Task<List<FileToProduct>> GetFileToProductWithBImageId(int id)
        {
            return await _dbContext.FileToProduct.Where(a => a.ImageId == id).ToListAsync();
        }

       public async Task<List<FileToProduct>> GetFileToProductWithBlogId(int id)
        {
            return await _dbContext.FileToProduct.Where(a => a.ProductId == id).ToListAsync();
        }
    }
}
