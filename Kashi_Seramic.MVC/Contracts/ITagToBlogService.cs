using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Models.TagToBlog;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITagToBlogService
    {
        Task<List<TagToBlogVM>> GetTagToBlogs();
        Task<TagToBlogVM> GetTagToBlogsDetails(int id);
        Task<Response<int>> CreateTagToBlog(CreateTagToBlogVM leaveType);
        Task<Response<int>> UpdateTagToBlog(int id,UpdateTagToBlogVM leaveType);
        Task<Response<int>> DeleteTagToBlog(int id);
        Task<Response<int>> DeleteAnyTagToBlog(int ProductId);
    }
}
