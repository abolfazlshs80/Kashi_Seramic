
global using Kashi_Seramic.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IFileToProductRepository : IGenericRepository<FileToProduct>
    {
    
        Task<List<FileToProduct>> GetFileToProductWithBlogId(int id);
        Task<List<FileToProduct>> GetFileToProductWithBImageId(int id);
        Task<bool> DeleteFileToProductByBlogId(int id);


    }
}
