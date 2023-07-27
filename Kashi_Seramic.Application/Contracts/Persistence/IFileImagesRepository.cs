using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IFileManagerRepository : IGenericRepository<FileManager>
    {
        Task<FileManager> GetFileManagerWithDetails(int id);
        Task<List<FileManager>> GetFileManagersWithDetails();
   

    }
}
