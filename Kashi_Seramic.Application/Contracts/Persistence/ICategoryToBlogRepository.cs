using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ICategoryToBlogRepository : IGenericRepository<CategoryToBlog>
    {
        Task<List<CategoryToBlog>> GetCategoryToBlogWithBlogId(int id);
        Task<List<CategoryToBlog>> GetCategoryToBlogWithBImageId(int id);
        Task<bool> DeleteCategoryToBlogByBlogId(int Blogid);

    }
}
