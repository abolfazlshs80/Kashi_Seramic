using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ICategoryToProductRepository : IGenericRepository<CategoryToProduct>
    {
        Task<List<CategoryToProduct>> GetCategoryToProductWithBlogId(int id);
        Task<List<CategoryToProduct>> GetCategoryToProductWithBImageId(int id);
        Task<bool> DeleteCategoryToProductByBlogId(int Blogid);

    }
}
