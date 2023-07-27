using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IBlogService
    {
        Task<List<Models.Pr_Signal_ir.MVC.Models.BlogVM>> GetBlogs();
        Task<List<Models.Pr_Signal_ir.MVC.Models.BlogVM>> GetBlogsActive();
        Task<List<Models.Pr_Signal_ir.MVC.Models.BlogVM>> GetBlogsByUserId(string UserId);
        Task<IEnumerable<SearchVM>> GetBlogsBySearchVM(string text);
        Task<List<SearchVM>> GetBlogsCategoryBySearchVM(int cateid);
        Task<List<SearchVM>> GetBlogsCategoryBySearchVM();
        Task<Models.Pr_Signal_ir.MVC.Models.BlogVM> GetBlogsDetails(int id);
        Task<Response<int>> CreateBlog(CreateBlogVM leaveType);
        Task<Response<int>> UpdateBlog(int id, Models.Pr_Signal_ir.MVC.Models.UpdateBlogVM leaveType);
        Task<Response<int>> DeleteBlog(int id);
        Task<Response<bool>> ExistsBlog(int id);
        Task<Response<bool>> UserInOwner(string UserId,int id);
    }
}
