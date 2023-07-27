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
    public class TicketRepository : GenericRepository<Ticket>, Application.Contracts.Persistence.ITicketRepository
    {
        private readonly AppDbContext _dbContext;

        public TicketRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> GetTicketWithDetails(int id)
        {
            return await _dbContext.Ticket.Where(a=>a.Id==id).Include(a=>a.ticketGroup).Include(a=>a.TicketToReply).FirstOrDefaultAsync();
        }

        public async Task<List<Ticket>> GetTicketWithDetails()
        {
            return await _dbContext.Ticket.Include(a => a.ticketGroup).Include(a => a.TicketToReply).ToListAsync();
        }
    }
}
