

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ITicketGroupRepository : IGenericRepository<TicketGroup>
    {
        Task<TicketGroup> GetTicketGroupWithDetails(int id);
        Task<TicketGroup> InsertTicketGroup(TicketGroup model);
        Task<List<TicketGroup>> GetTicketGroupWithDetails();
   

    }
}
