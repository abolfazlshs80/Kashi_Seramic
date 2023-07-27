

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<Ticket> GetTicketWithDetails(int id);
        Task<List<Ticket>> GetTicketWithDetails();
   

    }
}
