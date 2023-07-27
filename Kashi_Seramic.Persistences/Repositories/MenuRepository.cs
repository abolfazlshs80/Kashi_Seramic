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
    public class MenuRepository : GenericRepository<Menu>, Application.Contracts.Persistence.IMenuRepository
    {
        private readonly AppDbContext _dbContext;

        public MenuRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
}
