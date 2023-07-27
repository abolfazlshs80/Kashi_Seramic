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
    public class TicketToReplyRepository : GenericRepository<TicketToReply>, Application.Contracts.Persistence.ITicketToReplyRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketToReplyRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketToReply> GetTicketToReplyWithDetails(int id)
        {
          return  await _dbContext.TicketToReply.Include(a => a.Ticket).Where(a=>a.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<TicketToReply>> GetTicketToReplyWithDetails()
        {
            return await _dbContext.TicketToReply.Include(a => a.Ticket).ToListAsync();
        }
    }
}
