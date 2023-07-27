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
    public class UserAddressRepository : GenericRepository<UserAddress>, Application.Contracts.Persistence.IUserAddressRepository
    {
        private readonly AppDbContext _dbContext;

        public UserAddressRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
}
