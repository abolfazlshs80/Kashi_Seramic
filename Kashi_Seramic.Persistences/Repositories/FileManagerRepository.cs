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
    public class FileManagerRepository : GenericRepository<FileManager>, Application.Contracts.Persistence.IFileManagerRepository
    {
        private readonly AppDbContext _dbContext;

        public FileManagerRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

   
     

        public async Task<List<FileManager>> GetFileManagersWithDetails()
        {
            return await _dbContext.FileManager.ToListAsync();
        }

        public async Task<FileManager> GetFileManagerWithDetails(int id)
        {
            return await _dbContext.FileManager.Where(a => a.Id == id).SingleOrDefaultAsync();

        }
    }
}
