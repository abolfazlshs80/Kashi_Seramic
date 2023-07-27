using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IFileToBlogRepository : IGenericRepository<FileToBlog>
    {
    
        Task<List<FileToBlog>> GetFileToBlogWithBlogId(int id);
        Task<List<FileToBlog>> GetFileToBlogWithBImageId(int id);
        Task<bool> DeleteFileToBlogByBlogId(int id);


    }
}
