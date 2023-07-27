

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ITagToProductRepository : IGenericRepository<TagToProduct>
    {
        Task<List<TagToProduct>> GetTagToProductWithBlogId(int id);
        Task<List<TagToProduct>> GetTagToProductWithBImageId(int id);
        Task<List<TagToProduct>> GetTagToProducts();
        Task<bool> DeleteTagToProductByBlogId(int Blogid);

    }
}
