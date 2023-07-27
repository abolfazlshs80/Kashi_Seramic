

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ITagToBlogRepository : IGenericRepository<TagToBlog>
    {
        Task<List<TagToBlog>> GetTagToBlogWithBlogId(int id);
        Task<List<TagToBlog>> GetTagToBlogs();
        Task<List<TagToBlog>> GetTagToBlogWithBImageId(int id);
        Task<bool> DeleteTagToBlogByBlogId(int Blogid);

    }
}
