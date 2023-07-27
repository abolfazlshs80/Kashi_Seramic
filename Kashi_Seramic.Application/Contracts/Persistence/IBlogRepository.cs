using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<Blog> GetBlogWithDetails(int id);
        Task<List<Blog>> GetBlogsWithDetails();

        Task<bool> BlogExists(string userId, int BlogId);

    }
}
