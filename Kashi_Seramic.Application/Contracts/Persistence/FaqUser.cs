using Kashi_Seramic.Application.DTOs.FaqUser;
using Pr_Signal_ir.Application.Contracts.Persistence;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IFaqUserRepository :IGenericRepository<FaqUser>
    {
        Task<FaqUser> GetFaqUserWithDetails(int id);
        Task<List<FaqUser>> GetFaqUsersWithDetails();

    }
}
