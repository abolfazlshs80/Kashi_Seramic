

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<Tag> GetTagWithDetails(int id);
        Task<List<Tag>> GetTagWithDetails();
   

    }
}
