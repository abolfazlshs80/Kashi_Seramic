using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.FaqUser;
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
    public class FaqUserRepository : GenericRepository<FaqUser>, IFaqUserRepository
    {
        private readonly AppDbContext _dbContext;

        public FaqUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FaqUser>> GetFaqUsersWithDetails()
        {
            return await _dbContext.FaqUser.ToListAsync();
        }

        public Task<FaqUser> GetFaqUserWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
