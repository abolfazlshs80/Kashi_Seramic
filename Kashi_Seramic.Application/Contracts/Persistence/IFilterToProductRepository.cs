
global using Kashi_Seramic.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IFilterToProductRepository : IGenericRepository<FilterToProduct>
    {
    
        Task<List<FilterToProduct>> GetFilterToProductWithBlogId(int id);
        Task<List<FilterToProduct>> GetFilterToProductWithBImageId(int id);
        Task<bool> DeleteFilterToProductByBlogId(int id);


    }
}
