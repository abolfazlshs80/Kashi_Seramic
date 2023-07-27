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
    public class TicketGroupRepository : GenericRepository<TicketGroup>, Application.Contracts.Persistence.ITicketGroupRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketGroupRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketGroup> GetTicketGroupWithDetails(int id)
        {
            return await _dbContext.TicketGroup.Where(a=>a.Id==id).Include(a => a.SuportTicket).FirstOrDefaultAsync();
        }

        public async Task<List<TicketGroup>> GetTicketGroupWithDetails()
        {
         return await _dbContext.TicketGroup.Include(a=>a.SuportTicket).ToListAsync();
        }

        public async Task<TicketGroup> InsertTicketGroup(TicketGroup model)
        {
            try
            {
              _dbContext.Add<TicketGroup>(model);
              // await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                return new TicketGroup();
            }
           
        }
    }
}
